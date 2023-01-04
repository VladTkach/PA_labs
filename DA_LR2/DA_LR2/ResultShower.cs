namespace DA_LR2;

public class ResultShower
{
    public void ShowResult(Node? solved)
    {
        PazzleDisplayer pazzleDisplayer = new PazzleDisplayer();
        if (solved == null)
        {
            return;
        }
        ShowResult(solved.Predecessor);
        pazzleDisplayer.Display(solved.State);
        while (Console.ReadKey().Key != ConsoleKey.Enter)
        {
            ConsoleCleaner.cleanLines(1);
        }
        Console.SetCursorPosition(0, Console.CursorTop - 4);
    }
}