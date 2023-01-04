namespace DA_LR2;

public class CorectNumberValidator : ValidatorBase
{
    public override Dictionary<string, string> HandleValidation(string inputPazzle, int size)
    {
        string[] splitInput = inputPazzle.Split();
        int[] numbers = new int[splitInput.Length];
        for (int i = 0; i < splitInput.Length; i++)
        {
            numbers[i] = int.Parse(splitInput[i]);
        }
        Array.Sort(numbers);

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] != i)
            {
                ErrorsResult.Add("incorrect numbers", "you have entered incorrect numbers, they must be in the specified range without repetitions");
                return ErrorsResult;
            }
        }

        if (Successor != null)
            return Successor.HandleValidation(inputPazzle, size);

        return ErrorsResult;
    }
}