using System.IO.Compression;

namespace DA_LR2;

public class PazzleCreator
{
    public int[,] Create(int size)
    {
        MassageWriter massageWriter = new MassageWriter();
        massageWriter.Write(Massages.createPazzle);
        
        bool correctEnter = false;
        string input = string.Empty;

        int[,] state = new int[size, size];
        while (!correctEnter)
        {
            input = Console.ReadLine() ?? string.Empty;
            if (input == "G")
            {
                RandomPazzle randomPazzle = new RandomPazzle(size);
                state = randomPazzle.currentState;
                correctEnter = true;
            }
            else if (input == "M")
            {
                UserPazzle userPazzle = new UserPazzle();
                state = userPazzle.Input(size);
                correctEnter = true;
            }
            else
                massageWriter.Write(Massages.IncorrectInput);
        }

        return state;
    }
}