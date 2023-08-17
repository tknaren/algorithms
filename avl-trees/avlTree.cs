using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

public class AVLTree
{
    public class AVLNode
    {
        public int Val { get; set; }
        public int height { get; set; }
        public int balanceFactor { get; set; }
        public AVLNode LeftChild { get; set; }
        public AVLNode RightChild { get; set; }

        public AVLNode(int value)
        {
            this.Val = value;
        }

        public new string ToString()
        {
            return string.Format("{0} - {1} - {2}", this.Val, this.height, this.balanceFactor);
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

        // determine the balance factor
        // using the height of left and right node, 
        // balanceFactor = height(L) - height(R)
        // balanceFactor > 1 -- left heavy
        // balanceFactor < -1 -- right heavy
        root.balanceFactor = GetBalanceFactor(root);

        root = Balance(root);

        // Set null nodes having negative height
        // Get the max height of left and right and add 1 to it.
        root.height = DetermineHeight(root);

        return root;
    }

    public bool IsBalanced()
    {
        return IsBalanced(this.Root);
    }

    private bool IsBalanced(AVLNode root)
    {
        if (root == null)
        {
            return true;
        }

        return !isLeftHeavy(root) && !isRightHeavy(root)
            && IsBalanced(root.LeftChild) && IsBalanced(root.RightChild);

    }

    private int DetermineHeight(AVLNode root)
    {
        return Math.Max(GetHeightOfLeftChild(root), GetHeightOfRightChild(root)) + 1;
    }

    private int GetHeightOfLeftChild(AVLNode root)
    {
        return root.LeftChild == null ? -1 : root.LeftChild.height;
    }

    private int GetHeightOfRightChild(AVLNode root)
    {
        return root.RightChild == null ? -1 : root.RightChild.height;
    }

    private int GetBalanceFactor(AVLNode root)
    {
        return (root.LeftChild == null ? -1 : root.LeftChild.height)
            - (root.RightChild == null ? -1 : root.RightChild.height);

    }

    private bool isLeftHeavy(AVLNode root)
    {
        return root.balanceFactor > 1 ? true : false;
    }

    private bool isRightHeavy(AVLNode root)
    {
        return root.balanceFactor < -1 ? true : false;
    }

    private AVLNode Balance(AVLNode root)
    {
        if (isLeftHeavy(root))
        {
            //Console.WriteLine(string.Format("{0} => L {1}", root.balanceFactor, root.LeftChild.balanceFactor));

            if (root.LeftChild.balanceFactor < 0)
            {
                Console.WriteLine(string.Format(" LeftRotate - {0}", root.LeftChild.Val));
                root.LeftChild = RotateLeft(root.LeftChild);
            }

            Console.WriteLine(string.Format(" RightRotate - {0}", root.Val));

            return RotateRight(root);

        }

        if (isRightHeavy(root))
        {
            //Console.WriteLine(string.Format("{0} => R {1}", root.balanceFactor, root.RightChild.balanceFactor));

            if (root.RightChild.balanceFactor > 0)
            {
                Console.WriteLine(string.Format(" RightRotate - {0}", root.RightChild.Val));
                root.RightChild = RotateRight(root.RightChild);
            }

            Console.WriteLine(string.Format(" LeftRotate - {0}", root.Val));

            return RotateLeft(root);
        }

        return root;
    }

    private AVLNode RotateLeft(AVLNode root)
    {
        // newRoot = root.Right
        // root.Right = newRoot.Left
        // newRoot.Left = root

        AVLNode newRoot = root.RightChild;
        root.RightChild = newRoot.LeftChild;
        newRoot.LeftChild = root;

        root.height = DetermineHeight(root);
        newRoot.height = DetermineHeight(newRoot);

        return newRoot;
    }

    private AVLNode RotateRight(AVLNode root)
    {
        // newRoot = root.Left
        // root.Left = newRoot.Right
        // newRoot.Right = root

        AVLNode newRoot = root.LeftChild;
        root.LeftChild = newRoot.RightChild;
        newRoot.RightChild = root;

        root.height = DetermineHeight(root);
        newRoot.height = DetermineHeight(newRoot);

        return newRoot;
    }



}