using System.Drawing;

namespace DA_LR2;

public class Node
{
    public int[,] State { get; }
    public Point Zero { get; set; }
    public Step ForbiddenStep { get; }
    public int Level { get; }
    public Node? Predecessor { get; set; }


    public Node(int[,] newState)
    {
        ForbiddenStep = Step.None;
        Predecessor = null;
        Level = 0;
        State = newState;
        for (int i = 0; i < State.GetLength(0); i++)
        {
            for (int j = 0; j < State.GetLength(1); j++)
            {
                if (State[i, j] == 0)
                {
                    Zero = new Point(i, j);
                    break;
                }
            }
        }
    }

    public Node(int[,] newState, Step forbiddenStep, int x, int y, int level)
    {
        State = newState;
        this.ForbiddenStep = forbiddenStep;
        Zero = new Point(x, y);
        Level = level;
    }
}