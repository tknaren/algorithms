public class InOrderTraversal : Tree
{
    // Always consider the root node, go to the Left, Root and Right
    public void TraversePreOrder(Node root)
    {
        // when visiting the left and right children we are recursively call this method itself
        if (root == null)
            return;

        TraversePreOrder(root.LeftChild);   // Left
        Console.WriteLine(root.Val);        // Root
        TraversePreOrder(root.RightChild);  // Right
    }
}