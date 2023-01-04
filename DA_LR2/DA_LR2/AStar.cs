namespace DA_LR2;

public class AStar
{
    public Node? FindSolution(Node? problem)
    {
        StatePriorety statePriorety = new StatePriorety();
        StepManager stepManager = new StepManager();
        PazzleChecker pazzleChecker = new PazzleChecker();
        
        PriorityQueue<Node?, int> priorityQueue = new PriorityQueue<Node?, int>();
        priorityQueue.Enqueue(problem, statePriorety.CulcStatePrioretty(problem));
        while (GC.GetTotalMemory(false) / 1048576 < 1024)
        {
            Node? currentState = priorityQueue.Dequeue();
            if (pazzleChecker.IsSolved(currentState.State))
                return currentState;

            for (int i = 1; i < 5; i++)
            {
                Node? child = stepManager.MakeStep(currentState, (Step)i);
                if (child != null)
                {
                    priorityQueue.Enqueue(child, statePriorety.CulcStatePrioretty(child));
                }
            }
        }
        return null;
    }
}