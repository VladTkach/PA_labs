using System.Drawing;

namespace DA_LR6
{
    public class DeltaFinder
    {
        public Point Find(Direction direction)
        {
            Point point = new Point(0, 0);
            switch (direction)
            {
                case Direction.Up:
                    point.Y = -1;
                    break;
                case Direction.Dowm:
                    point.Y = 1;
                    break;
                case Direction.Right:
                    point.X = 1;
                    break;
                case Direction.Left:
                    point.X  = -1;
                    break;
                case Direction.DiagonalUR:
                    point.X  = 1;
                    point.Y = -1;
                    break;
                case Direction.DiagonalDR:
                    point.X  = 1;
                    point.Y = 1;
                    break;
                case Direction.DiagonalDL:
                    point.X  = -1;
                    point.Y = 1;
                    break;
                case Direction.DiagonalUL:
                    point.X  = -1;
                    point.Y = -1;
                    break;
            }

            return point;
        }
    }
}