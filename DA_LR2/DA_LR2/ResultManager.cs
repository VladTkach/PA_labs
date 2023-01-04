namespace DA_LR2;

public class ResultManager
{
    public void Manage(Node? solve)
    {
        MassageWriter massageWriter = new MassageWriter();
        massageWriter.Write(Massages.ShowResult);
        bool correctEnter = false;
        string showResult = string.Empty;
        while (!correctEnter)
        {
            showResult = Console.ReadLine() ?? string.Empty;
            if (showResult == "Y")
            {
                ResultShower resultShower = new ResultShower();
                massageWriter.Write(Massages.NextStep);
                resultShower.ShowResult(solve);
                correctEnter = true;
                Console.SetCursorPosition(0, Console.CursorTop + solve.State.GetLength(0));
            }
            else if (showResult == "N")
            {
                correctEnter = true;
            }
            else
                massageWriter.Write(Massages.IncorrectInput);
        }
    }
}