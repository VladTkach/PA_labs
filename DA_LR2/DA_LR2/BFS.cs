using System.Diagnostics;

namespace DA_LR2;

public class BFS
{
    public Node? FindSolution(Node? problem)
    {
        StepManager stepManager = new StepManager();
        PazzleChecker pazzleChecker = new PazzleChecker();

        Queue<Node?> queue = new Queue<Node?>();
        queue.Enqueue(problem);
        while (GC.GetTotalMemory(false) / 1048576 < 1024)
        {
            Node? currentState = queue.Dequeue();
            if (pazzleChecker.IsSolved(currentState.State))
                return currentState;

            for (int i = 1; i < 5; i++)
            {
                Node? child = stepManager.MakeStep(currentState, (Step)i);
                if (child != null)
                {
                    queue.Enqueue(child);
                }
            }
        }
        return null;
    }
}