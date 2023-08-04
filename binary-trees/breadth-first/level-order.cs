using System.Text;

public class LevelOrderTraversal
{
    Tree tree = new Tree();

    // Initialize the data
    // Create an object of the Tree class and Insert the nodes
    public LevelOrderTraversal()
    {
        int[] nodeData = new int[] { 20, 10, 30, 6, 14, 24, 3, 8, 26 };

        foreach (int item in nodeData)
        {
            tree.Insert(item);
        }
    }

    public string GetItemsUsingBreadFirstTraversal()
    {
        StringBuilder stringBuilder = new StringBuilder();

        Tree.Node currentNode = tree.Root;

        while (currentNode != null)
        {

        }

        return stringBuilder.ToString();

    }


}