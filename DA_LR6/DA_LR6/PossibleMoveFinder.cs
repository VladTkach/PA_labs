using System.Collections.Generic;
using System.Drawing;

namespace DA_LR6
{
    public class PossibleMoveFinder
    {
        public static List<Point> Find(int[,] map, int currentPlayer)
        {
            List<Point> points = new List<Point>();
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == currentPlayer)
                    {
                        for (int k = 0; k < 8; k++)
                        {
                            Point point = PossibleFinder.Check(map, currentPlayer, i, j, (Direction)k);
                            if (point.X != i || point.Y != j)
                            {
                                points.Add(point);
                            }
                        }
                    }
                }
            }
            RepeatCleaner.Clear(points);
            return points;
        }
    }
}