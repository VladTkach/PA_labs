namespace DA_LR2;

public class StepManager
{
    public Node? MakeStep(Node? node, Step step)
    {
        StepMaker stepMaker = new StepMaker();
        int sizeX = node.State.GetLength(1) - 1;
        int sizeY = node.State.GetLength(0) - 1;
        switch (step)
        {
            case Step.Up when node.ForbiddenStep != Step.Up && node.Zero.X != 0:
                return stepMaker.NewStep(node, -1, 0, Step.Down);
            case Step.Down when node.ForbiddenStep != Step.Down && node.Zero.X != sizeX:
                return stepMaker.NewStep(node, 1, 0, Step.Up);
            case Step.Left when node.ForbiddenStep != Step.Left && node.Zero.Y != 0:
                return stepMaker.NewStep(node, 0, -1, Step.Right);
            case Step.Right when node.ForbiddenStep != Step.Right && node.Zero.Y != sizeY:
                return stepMaker.NewStep(node, 0, 1, Step.Left);
        }
        return null;
    }
}