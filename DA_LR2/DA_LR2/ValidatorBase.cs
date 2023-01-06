namespace DA_LR2;

public abstract class ValidatorBase
{
    protected ValidatorBase Successor { get; private set; }
    protected Dictionary<string, string> ErrorsResult { get; set; }

    protected ValidatorBase()
    {
        ErrorsResult = new Dictionary<string, string>();
    }

    public abstract Dictionary<string, string> HandleValidation(string inputPazzle, int size);

    public void SetSuccessor(ValidatorBase successor)
    {
        this.Successor = successor;
    }
}