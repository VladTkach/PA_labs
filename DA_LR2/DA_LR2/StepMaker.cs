namespace DA_LR2;

public class StepMaker
{
    public Node? NewStep(Node? node, int deltaX, int deltaY, Step forbiddenStep)
    {
        int[,] newState = (int[,])node.State.Clone() ;
        newState[node.Zero.X, node.Zero.Y] = newState[node.Zero.X + deltaX, node.Zero.Y + deltaY];
        newState[node.Zero.X + deltaX, node.Zero.Y + deltaY] = 0;

        Node? newNode = new Node(newState, forbiddenStep, node.Zero.X + deltaX, node.Zero.Y + deltaY, node.Level + 1);
        newNode.Predecessor = node;
        return newNode;
    }
}