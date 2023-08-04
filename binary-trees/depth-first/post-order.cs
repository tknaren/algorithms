public class PostOrderTraversal : Tree
{
    // Always consider the root node, go to the Left, Right and Root
    public void TraversePreOrder(Node root)
    {
        // when visiting the left and right children we are recursively call this method itself

        if (root == null)
            return;

        TraversePreOrder(root.LeftChild);   // Left
        TraversePreOrder(root.RightChild);  // Right
        Console.WriteLine(root.Val);        // Root
    }

}