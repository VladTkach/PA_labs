using System.Collections.Generic;
using System.Drawing;

namespace DA_LR6
{
    public class RepeatCleaner
    {
        public static void Clear(List<Point> points)
        {
            for (int i = 0; i < points.Count; i++)
            {
                Point point = points[i];
                for (int j = i + 1; j < points.Count; j++)
                {
                    if (point.X == points[j].X && point.Y == points[j].Y)
                    {
                        points.RemoveAt(j);
                        j--;
                    }
                }
            }
        }
    }
}