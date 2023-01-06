namespace DA_LR2;

public class AlgorithmEnter
{
    public string ChoseAlgorithm()
    {
        MassageWriter massageWriter = new MassageWriter();
        massageWriter.Write(Massages.chooseAlgorithm);
        bool correctEnter = false;
        string algorithm = string.Empty;
        while (!correctEnter)
        {
            algorithm = Console.ReadLine() ?? string.Empty;
            if (algorithm == "B" || algorithm == "A")
            {
                correctEnter = true;
            }
            else
                massageWriter.Write(Massages.IncorrectInput);
        }

        return algorithm;
    }
}