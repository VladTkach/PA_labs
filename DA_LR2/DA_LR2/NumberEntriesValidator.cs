namespace DA_LR2;

public class NumberEntriesValidator : ValidatorBase
{
    public override Dictionary<string, string> HandleValidation(string inputPazzle, int size)
    {
        if (inputPazzle.Split().Length != size * size)
        {
            ErrorsResult.Add("Number of entries", "the number of entries does not meet the requirements");
            return ErrorsResult;
        }

        if (Successor != null)
            return Successor.HandleValidation(inputPazzle, size);

        return ErrorsResult;
    }
}