using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DA_LR6
{
    public class Map
    {
        public int mapSize { get; }
        public int cellSize {get;}

        public int[,] map { get; set; } 
        public Map()
        {
            mapSize = 8;
            cellSize = 50;
            ReloadMap();
        }

        public void ReloadMap()
        {
            map = new int[,] {
                {0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 1, 2, 0, 0, 0},
                {0, 0, 0, 2, 1, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0}
            };
        }
    }
}