public class PreOrderTraversal : Tree
{
    // Always consider the root node, go to the Root, Left and Right
    public void TraversePreOrder(Node root)
    {
        // when visiting the left and right children we are recursively call this method itself

        if (root == null)
            return;

        Console.WriteLine(root.Val);        // Root
        TraversePreOrder(root.LeftChild);   // Left
        TraversePreOrder(root.RightChild);  // Right
    }
}