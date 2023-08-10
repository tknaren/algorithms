using System.Text;

public class LevelOrderTraversal
{
    private readonly Tree tree;

    // Initialize the data
    // Create an object of the Tree class and Insert the nodes
    public LevelOrderTraversal(Tree tree)
    {
        this.tree = tree;
    }

    public void TraverseLevelOrder()
    {
        for (int i = 0; i <= tree.GetHeight(); i++)
            foreach (var item in tree.GetNodesAtDistance(i))
                Console.WriteLine(item);

    }
}