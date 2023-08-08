using System.ComponentModel.DataAnnotations;
using System.Text;

public class Tree
{
    public class Node
    {
        public int Val { get; set; }
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }

        public Node(int value)
        {
            this.Val = value;
        }
    }

    public Node Root { get; set; }


    public void Insert(int value)
    {
        if (Root == null)
        {
            Root = new Node(value);
            return;
        }

        var node = new Node(value);

        var currentNode = Root;

        while (currentNode != null)
        {
            if (currentNode.Val > value)
            {
                if (currentNode.LeftChild != null)
                {
                    currentNode = currentNode.LeftChild;
                }
                else
                {
                    currentNode.LeftChild = node;
                    break;
                }
            }
            else if (currentNode.Val < value)
            {
                if (currentNode.RightChild != null)
                {
                    currentNode = currentNode.RightChild;
                }
                else
                {
                    currentNode.RightChild = node;
                    break;
                }
            }
            else break;
        }
    }

    public bool Find(int value)
    {
        var currentNode = Root;

        while (currentNode != null)
        {
            if (currentNode.Val > value)
            {
                if (currentNode.LeftChild != null)
                {
                    currentNode = currentNode.LeftChild;
                    if (currentNode.Val == value)
                        return true;
                }
            }
            else if (currentNode.Val < value)
            {
                if (currentNode.RightChild != null)
                {
                    currentNode = currentNode.RightChild;
                    if (currentNode.Val == value)
                        return true;

                }
            }
            else return true;
        }

        return false;
    }

    private bool IsLeafNode(Node root)
    {
        // base condition to exit the recursive call
        // if both the left and right side of the node is null then it is considered as LEAF node
        if (root.LeftChild == null && root.RightChild == null)
            return true;

        return false;
    }

    public int GetHeight(Node root)
    {
        if (root == null)
            return -1;

        if (IsLeafNode(root)) return -1;

        // Using Post Order traversal here to determine the height
        // Left, Right and Root
        // formula : height = 1 + Max(height(L), height(R))

        return 1 + Math.Max(GetHeight(root.LeftChild), GetHeight(root.RightChild));

    }

    public int GetMinimumVal(Node root)
    {
        if (root == null) return -1;

        if (IsLeafNode(root)) return root.Val;

        int left = GetMinimumVal(root.LeftChild);
        int right = GetMinimumVal(root.RightChild);

        // Find the minimum of all 3 (left, right and root)
        return Math.Min(Math.Min(left, right), root.Val);

    }

    // Time Complixity - O(log n) 
    public int GetMinimumValFromBinaryTree(Node root)
    {
        // consider it ia binary tree, that the left side of the node is always less than the root node
        //  and the right side is always greater than the root node

        // so to find the minimum, you can just traverse to the left most LEAF and get the value
        // same is applicable for the maximum, where you take the right most LEAF node 

        if (root == null)
        {
            throw new Exception("Invalid operation");
        }

        var current = root;
        var last = current;
        while (current != null)
        {
            last = current;
            current = current.LeftChild;
        }

        return last.Val;

    }

    // Time Complixity - O(log n) 
    public int GetMaximumValFromBinaryTree(Node root)
    {
        // consider it ia binary tree, that the left side of the node is always less than the root node
        //  and the right side is always greater than the root node

        // so to find the maximum, you can just traverse to the right most LEAF and get the value

        if (root == null)
        {
            throw new Exception("Invalid operation");
        }

        var current = root;
        var last = current;
        while (current != null)
        {
            last = current;
            current = current.RightChild;
        }

        return last.Val;

    }


    // compare the trees using In-order traversals
    public bool IsEqualUsingString(Tree tree)
    {
        var stringA = new StringBuilder();
        var stringB = new StringBuilder();

        return TraverseTree(this.Root, stringA) == TraverseTree(tree.Root, stringB);
    }

    public string TraverseTree(Node root, StringBuilder stringBuilder)
    {
        if (root != null)
        {
            TraverseTree(root.LeftChild, stringBuilder);   // Left
            stringBuilder.Append(root.Val); // Root
            TraverseTree(root.RightChild, stringBuilder);  // Right
        }

        return stringBuilder.ToString();
    }

    public bool IsEquals(Tree tree)
    {
        if (tree == null)
            return false;

        return IsEquals(this.Root, tree.Root);
    }

    private bool IsEquals(Node first, Node second)
    {
        if (first == null && second == null)
            return true;

        //pre-order traversal algo
        if (first != null && second != null)
            return first.Val == second.Val
                    && IsEquals(first.LeftChild, second.LeftChild)
                    && IsEquals(first.RightChild, second.RightChild);

        return false;
    }

    public bool ValidateBinaryTreePrinciple()
    {
        if (this.Root == null)
            return false;

        return Validate(this.Root, int.MinValue, int.MaxValue);
    }

    private bool Validate(Node root, int min, int max)
    {
        if (root != null)
        {
            if (root.Val < min || root.Val > max)
                return false;

            if (root.Val > min && root.Val < max)
            {
                return Validate(root.LeftChild, min, root.Val) && Validate(root.RightChild, root.Val, max);
            }
        }

        return true;
    }

}