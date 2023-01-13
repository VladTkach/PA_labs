using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace DA_LR6
{
    public class EnemyColoring
    {
        public static void Coloring(Button[,] buttons, int[,] map, int currentPlayer, int x, int y, Direction direction)
        {
            DeltaFinder deltaFinder = new DeltaFinder();
            Point delta = deltaFinder.Find(direction);
            int dx = delta.X;
            int dy = delta.Y;

            int ennemyPlayer = currentPlayer == 1 ? 2 : 1;
            x += dx;
            y += dy;

            while (x >= 0 && x < map.GetLength(0) && y >= 0 && y < map.GetLength(1))
            {
                if (map[x, y] == currentPlayer || map[x, y] == 3)
                    break;

                if (map[x, y] == ennemyPlayer)
                {
                    buttons[x, y].BackColor = currentPlayer == 1 ? Color.Black : Color.White;
                    map[x, y] = currentPlayer == 1 ? 1 : 2;
                }
                    

                x += dx;
                y += dy;
            }
        }
        
        public static void ColoringNew( int[,] map, int currentPlayer, int x, int y, Direction direction)
        {
            int dx = 0;
            int dy = 0;
            switch (direction)
            {
                case Direction.Up:
                    dy = -1;
                    break;
                case Direction.Dowm:
                    dy = 1;
                    break;
                case Direction.Right:
                    dx = 1;
                    break;
                case Direction.Left:
                    dx = -1;
                    break;
                case Direction.DiagonalUR:
                    dx = 1;
                    dy = -1;
                    break;
                case Direction.DiagonalDR:
                    dx = 1;
                    dy = 1;
                    break;
                case Direction.DiagonalDL:
                    dx = -1;
                    dy = 1;
                    break;
                case Direction.DiagonalUL:
                    dx = -1;
                    dy = -1;
                    break;
            }

            int ennemyPlayer = currentPlayer == 1 ? 2 : 1;
            x += dx;
            y += dy;

            while (x >= 0 && x < map.GetLength(0) && y >= 0 && y < map.GetLength(1))
            {
                if (map[x, y] == currentPlayer || map[x, y] == 3)
                    break;

                if (map[x, y] == ennemyPlayer)
                {
                    map[x, y] = currentPlayer == 1 ? 1 : 2;
                }
                
                x += dx;
                y += dy;
            }
        }
    }
}