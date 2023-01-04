namespace DA_LR2;

public class ErrorsWriter
{
    public void Write(Dictionary<string, string> Errors)
    {
        foreach (var error in Errors.Values)
        {
            Console.WriteLine(error);
        }
    }
}