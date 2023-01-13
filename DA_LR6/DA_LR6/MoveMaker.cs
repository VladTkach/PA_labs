namespace DA_LR6
{
    public class MoveMaker
    {
        public static void newMove(int[,] map, int currentPlayer, int x, int y)
        {
            for (int i = 0; i < 8; i++)
            {
                if (SameFinder.Check(map, currentPlayer, x, y, (Direction)i))
                {
                    EnemyColoring.ColoringNew(map, currentPlayer, x, y, (Direction)i);
                }
            }
            
        }
    }
}