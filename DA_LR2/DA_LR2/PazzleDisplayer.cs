namespace DA_LR2;

public class PazzleDisplayer
{
    public void Display(int[,] graph)
    {
        for (int i = 0; i < graph.GetLength(0); i++)
        {
            for (int j = 0; j < graph.GetLength(1); j++)
            {
                Console.Write(graph[i, j] + " ");
            }

            Console.WriteLine("");
        }
        Console.WriteLine("");
    }
}