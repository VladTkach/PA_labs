namespace DA_LR2;

public class EndProgram
{
    public bool End()
    {
        MassageWriter massageWriter = new MassageWriter();
        massageWriter.Write(Massages.EndProgram);
        bool correctEnter = false;
        string input = string.Empty;
        bool result = false;
        while (!correctEnter)
        {
            input = Console.ReadLine() ?? string.Empty;
            if (input == "E")
            {
                correctEnter = true;
                result = true;
            }
            else if (input == "A")
            {
                correctEnter = true;
                result = false;
            }
            else
                massageWriter.Write(Massages.IncorrectInput);
        }

        return result;
    }
}