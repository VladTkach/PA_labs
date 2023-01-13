using System;
using System.Windows.Forms;

namespace DA_LR6
{
    public class Sleep
    {
        public static void sleep(int secondes)
        {
            DateTime t = DateTime.Now;
            while (true) {
                DateTime now = DateTime.Now;
                if ((now - t).TotalSeconds >= secondes) {
                    break;
                }
                Application.DoEvents();
            }
        }
    }
}