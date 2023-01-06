namespace DA_LR2;

public class ConsoleCleaner
{
    public static void cleanLines(int numLines)
    {
        int currentLineCursor = Console.CursorTop;
        for (int i = 0; i < numLines + 1; i++)
        {
            Console.SetCursorPosition(0, Console.CursorTop - i);
            Console.Write(new string(' ', Console.WindowWidth));
        }
        Console.SetCursorPosition(0, Console.CursorTop - numLines);
    }
}