using System;
using System.Collections.Generic;
using System.Drawing;

namespace DA_LR6
{
    public class HardEnemmy
    {
        private int Color;
        private int Complexity;

        public HardEnemmy(int color, int complexity)
        {
            Color = color;
            Complexity = complexity;
        }

        public void ChangeComplexity(int complexity)
        {
            Complexity = complexity * 2;
        }

        public Point? nextMove(int[,] map)
        {
            int lostMove = Culculator.LostMove(map);
            if (lostMove % 2 == 1)
            {
                lostMove--;
            }

            int[,] newMap = Copy.Map(map);

            State state = Analysis(newMap, Color, Math.Min(lostMove, Complexity));

            if (state == null)
            {
                Point? lastChanse = Next(map, Color);
                if (lastChanse == null)
                    return null;
                return lastChanse;
            }

            return state.Point;
        }

        private State Analysis(int[,] map, int currentPlayer, int deep)
        {
            deep--;
            List<Point> points = PossibleMoveFinder.Find(map, currentPlayer);
            int? max = null;
            int maxIndex = 0;

            for (int i = 0; i < points.Count; i++)
            {
                int[,] newMap = Copy.Map(map);
                newMap[points[i].X, points[i].Y] = currentPlayer;
                MoveMaker.newMove(newMap, currentPlayer, points[i].X, points[i].Y);
                State newMin = FindMin(newMap, currentPlayer == 1 ? 2 : 1, max, deep);
                if (newMin != null)
                {
                    if (max == null)
                    {
                        max = newMin.Score;
                    }
                    else if (max < newMin.Score)
                    {
                        max = newMin.Score;
                        maxIndex = i;
                    }
                }
            }

            if (max == null)
                return null;
            return new State(points[maxIndex], max);
        }

        private State FindMin(int[,] map, int currentPlayer, int? max, int deep)
        {
            deep--;
            if (deep == 0)
            {
                int localMin = int.MaxValue;
                int minIndex = 0;
                int minScore = 0;
                List<Point> points = PossibleMoveFinder.Find(map, currentPlayer);
                for (int i = 0; i < points.Count; i++)
                {
                    int[,] newMap = Copy.Map(map);
                    newMap[points[i].X, points[i].Y] = currentPlayer;
                    MoveMaker.newMove(newMap, currentPlayer, points[i].X, points[i].Y);
                    int score = Culculator.Score(newMap);

                    if (score < localMin)
                    {
                        localMin = score;
                        minIndex = i;
                        minScore = score;
                    }

                    if (localMin <= max)
                        return new State(points[i], score);
                }

                if (localMin == int.MaxValue)
                    return null;

                return new State(points[minIndex], minScore);
            }
            else
            {
                int localMin = int.MaxValue;
                State minState = null;
                List<Point> points = PossibleMoveFinder.Find(map, currentPlayer);
                foreach (var t in points)
                {
                    int[,] newMap = Copy.Map(map);
                    newMap[t.X, t.Y] = currentPlayer;
                    MoveMaker.newMove(newMap, currentPlayer, t.X, t.Y);
                    State stata = Analysis(newMap, currentPlayer == 1 ? 2 : 1, deep);
                    if (stata != null)
                    {
                        if (stata.Score < localMin)
                        {
                            localMin = (int)stata.Score;
                            minState = stata;
                        }
                    }
                }

                return minState;
            }
        }

        private Point? Next(int[,] map, int currentPlayer)
        {
            int max = Int32.MinValue;
            int maxId = 0;
            List<Point> points = PossibleMoveFinder.Find(map, currentPlayer);
            for (int i = 0; i < points.Count; i++)
            {
                int[,] newMap = Copy.Map(map);
                newMap[points[i].X, points[i].Y] = currentPlayer;
                MoveMaker.newMove(newMap, currentPlayer, points[i].X, points[i].Y);
                int score = Culculator.Score(newMap);
                if (score > max)
                {
                    max = score;
                    maxId = i;
                }
            }

            if (points.Count == 0)
                return null;

            return points[maxId];
        }
    }
}