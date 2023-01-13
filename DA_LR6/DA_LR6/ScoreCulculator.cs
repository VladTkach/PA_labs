namespace DA_LR6
{
    public static class Culculator
    {

        public static int ScoreBlack(int[,] map)
        {
            int black = 0;
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == 1)
                        black++;
                }
            }

            return black;
        }
        
        public static int ScoreWhite(int[,] map)
        {
            int white = 0;
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == 2)
                        white++;
                }
            }

            return white;
        }
        public static int Score(int[,] map)
        {
            int black = 0;
            int white = 0;
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == 1)
                        black++;
                    else if (map[i, j] == 2)
                        white++;
                }
            }

            return white - black;
        }
        
        public static int LostMove(int[,] map)
        {
            int move = 0;
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == 0)
                        move++;
                }
            }

            return move;
        }
    }
}