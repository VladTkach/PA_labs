namespace DA_LR2;

public class PazzleChecker
{
    public bool IsSolved(int[,] state)
    {
        int sizeY = state.GetLength(0);
        for (int i = 0; i < sizeY; i++)
        {
            for (int j = 0; j < state.GetLength(1); j++)
            {
                if (state[i, j] != i * sizeY + j)
                {
                    return false;
                }
            }
        }
        return true;
    }
}