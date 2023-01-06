namespace DA_LR2;

public class UserPazzle
{
    public int[,] Input(int size)
    {
        MassageWriter massageWriter = new MassageWriter();
        ExampleWriter exampleWriter = new ExampleWriter();
        ErrorsWriter errorsWriter = new ErrorsWriter();
        massageWriter.Write(Massages.UserInput);
        exampleWriter.Write(size);

        bool correctEnter = false;
        string input = string.Empty;
        while (!correctEnter)
        {
            input = Console.ReadLine() ?? string.Empty;
            Dictionary<string, string> errors = InputPazzleValidationContext.Validate(input, size);
            if (errors.Count != 0)
            {
                errorsWriter.Write(errors);
                massageWriter.Write(Massages.UserInput);
                exampleWriter.Write(size);
            }
            else
                correctEnter = true;
        }

        string[] splitInput = input.Split();
        int[,] problem = new int[size, size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                problem[i, j] = int.Parse(splitInput[i * size + j]);
            }
        }

        return problem;
    }
}