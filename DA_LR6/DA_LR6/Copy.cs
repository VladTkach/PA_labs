namespace DA_LR6
{
    public static class Copy
    {
        public static int[,] Map(int[,] map)
        {
            int[,] newMap = new int[map.GetLength(0), map.GetLength(1)];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    newMap[i, j] = map[i, j];
                }
            }

            return newMap;
        }
    }
}