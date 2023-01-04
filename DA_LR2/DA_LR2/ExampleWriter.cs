namespace DA_LR2;

public class ExampleWriter
{
    public void Write(int size)
    {
        for (int i = 0; i < size * size; i++)
        {
            Console.Write(i + " ");
        }

        Console.WriteLine("");
    }
}