namespace DA_LR2;

public class RandomPazzle
{
    public int[,] currentState { get; private set; }

    public RandomPazzle(int size)
    {
        Next(size);
    }
    public int[,] Next(int size)
    {
        currentState = new int [size, size];
        List<int> numbers = new List<int>(Enumerable.Range(0, size*size));
        Random random = new Random();
        for (int i = 0; i < currentState.GetLength(0); i++)
        {
            for (int j = 0; j < currentState.GetLength(1); j++)
            {
                int randIndex = random.Next(numbers.Count);
                currentState[i, j] = numbers[randIndex];
                numbers.RemoveAt(randIndex);
            }
        }
        return currentState;
    }
}