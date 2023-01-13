using System.Drawing;

namespace DA_LR6
{
    public static class PossibleFinder
    {
        public static Point Check(int[,] map, int currentPlayer, int x, int y, Direction direction)
        {
            DeltaFinder deltaFinder = new DeltaFinder();
            Point delta = deltaFinder.Find(direction);
            int dx = delta.X;
            int dy = delta.Y;

            Point empty = new Point(x, y);
            int ennemyPlayer = currentPlayer == 1 ? 2 : 1;
            x += dx;
            y += dy;
            bool enemyBetween = false;

            while (x >= 0 && x < map.GetLength(0) && y >= 0 && y < map.GetLength(1))
            {
                if (map[x, y] == currentPlayer || map[x, y] == 3)
                    break;

                if (map[x, y] == ennemyPlayer)
                    enemyBetween = true;

                if (map[x, y] == 0)
                {
                    if (enemyBetween)
                    {
                        empty.X = x;
                        empty.Y = y;
                    }
                    break;
                }

                x += dx;
                y += dy;
            }

            return empty;
        }
    }
}