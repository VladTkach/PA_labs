namespace DA_LR2;

public static class InputPazzleValidationContext
{
    public static Dictionary<string, string> Validate(string inputPazzle, int size)
    {
        NumberEntriesValidator numberEntriesValidator = new NumberEntriesValidator();
        IsNumberValidator isNumberValidator = new IsNumberValidator();
        numberEntriesValidator.SetSuccessor(isNumberValidator);
        CorectNumberValidator correctNumberValidator = new CorectNumberValidator();
        isNumberValidator.SetSuccessor(correctNumberValidator);

        return numberEntriesValidator.HandleValidation(inputPazzle, size); 
    }
}