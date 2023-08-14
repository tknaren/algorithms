public class AVLTree
{
    public class AVLNode
    {
        public int Val { get; set; }
        public int height { get; set; }
        public AVLNode LeftChild { get; set; }
        public AVLNode RightChild { get; set; }

        public AVLNode(int value)
        {
            this.Val = value;
        }

        public new string ToString()
        {
            return string.Format("{0} - {1}", this.Val, this.height);
        }
    }

    public AVLNode Root;

    public void Insert(int val)
    {
        Root = Insert(Root, val);
    }

    private AVLNode Insert(AVLNode root, int val)
    {
        if (root == null)
        {
            return new AVLNode(val);
        }

        if (val < root.Val) root.LeftChild = Insert(root.LeftChild, val);
        if (val > root.Val) root.RightChild = Insert(root.RightChild, val);

        // Set null nodes having negative height
        // Get the max height of left and right and add 1 to it.
        root.height = Math.Max(
            root.LeftChild == null ? -1 : root.LeftChild.height,
            root.RightChild == null ? -1 : root.RightChild.height) + 1;

        // determine the balance factor
        // using the height of left and right node, 

        return root;
    }

}