using System.Diagnostics;

namespace DA_LR2
{
    class Program
    {
        private static void Main(string[] args)
        {
            const int size = 3;
            
            MassageWriter massageWriter = new MassageWriter();
            massageWriter.Write(Massages.Start);
            
            PazzleCreator pazzleCreator = new PazzleCreator();
            PazzleDisplayer pazzleDisplayer = new PazzleDisplayer();
            AlgorithmManager algorithmManager = new AlgorithmManager();
            ResultManager resultManager = new ResultManager();
            EndProgram endProgram = new EndProgram();

            bool work = true;
            while (work)
            {
                Node? problem = new Node(pazzleCreator.Create(size));
                massageWriter.Write(Massages.newPazzle);
                pazzleDisplayer.Display(problem.State);
                
                Node? solved = algorithmManager.ChooseAlgorithm(problem);
                if (solved == null)
                {
                    massageWriter.Write(Massages.Fail);
                }
                else
                {
                    massageWriter.Write(Massages.Success);
                    resultManager.Manage(solved);
                }

                if (endProgram.End())
                {
                    work = false;
                    massageWriter.Write(Massages.Bye);
                }

                GC.Collect();
            }
        }
    }
}