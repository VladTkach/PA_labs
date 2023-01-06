namespace DA_LR2;

public class AlgorithmManager
{
    public Node? ChooseAlgorithm(Node? problem)
    {
        AStar aStar = new AStar();
        BFS bfs = new BFS();
        AlgorithmEnter algorithmEnter = new AlgorithmEnter();
        MassageWriter massageWriter = new MassageWriter();
        string algorithm = algorithmEnter.ChoseAlgorithm();

        switch (algorithm)
        {
            case "A":
                massageWriter.Write(Massages.AStar);
                return aStar.FindSolution(problem);
            case "B":
                massageWriter.Write(Massages.BFS);
                return bfs.FindSolution(problem);
        }

        return null;
    }
}