using System.Drawing;

namespace DA_LR6
{
    public class State
    {
        public Point Point { get; }
        public int? Score { get; }

        public State(Point point, int? score)
        {
            Point = new Point(point.X, point.Y);
            Score = score;
        }
    }
}