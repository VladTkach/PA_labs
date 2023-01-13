using System.Drawing;
using System.Windows.Forms;

namespace DA_LR6
{
    public class IndexFinder
    {
        public static Point CoordinatesOf(Button[,] buttons, Button button)
        {
            for (int i = 0; i < buttons.GetLength(0); i++)
            {
                for (int j = 0; j < buttons.GetLength(1); j++)
                {
                    if (buttons[i, j] == button)
                    {
                        return new Point(i, j);
                    }
                }
            }

            return new Point(0, 0);
        }
    }
}