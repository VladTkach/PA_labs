namespace DA_LR2;

public class IsNumberValidator : ValidatorBase
{
    public override Dictionary<string, string> HandleValidation(string inputPazzle, int size)
    {
        string[] entries = inputPazzle.Split();
        int parse;
        foreach (var enter in entries)
        {
            if (!int.TryParse(enter, out parse))
            {
                ErrorsResult.Add("Is numbers", "You only need to enter the numbers as in the example");
                return ErrorsResult;
            }
        }

        if (Successor != null)
            return Successor.HandleValidation(inputPazzle, size);

        return ErrorsResult;
    }
}