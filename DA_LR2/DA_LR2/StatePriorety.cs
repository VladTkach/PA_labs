namespace DA_LR2;

public class StatePriorety
{
    public int CulcStatePrioretty(Node? node)
    {
        int h = 0;
        int size = node.State.GetLength(0);
        for (int i = 0; i < node.State.GetLength(0); i++)
        {
            for (int j = 0; j < node.State.GetLength(1); j++)
            {
                h += Math.Abs(node.State[i, j] / size - i) + Math.Abs(node.State[i, j] % size - j);
            }
        }
        return h + node.Level;
    }
}