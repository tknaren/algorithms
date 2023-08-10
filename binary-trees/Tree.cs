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

    private int size;

    private int leavesCount;

    private int max;

    private bool contains;

    private bool areSibling;

    private bool isItemFound;

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

    public int GetHeight()
    {
        return GetHeight(this.Root);
    }

    private int GetHeight(Node root)
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

    // method to find the distance of a node from the root node.
    // get the distance param from the user
    // run a recursion till the distance value becomes 0
    // ie., if the user needs nodes at Distance 1, it means the 2nd level from the root
    // so if you decrement the distance by 1 when you traverse thru the node, until it hits zero, 
    // that is the node you are looking for
    public void PrintNodesAtDistance(int distance)
    {
        PrintNodesAtDistance(this.Root, distance);
    }


    private void PrintNodesAtDistance(Node root, int distance)
    {
        if (root == null)
            return;

        if (distance == 0)
        {
            Console.WriteLine(root.Val);
            return;
        }

        PrintNodesAtDistance(root.LeftChild, distance - 1);
        PrintNodesAtDistance(root.RightChild, distance - 1);
    }

    public List<int> GetNodesAtDistance(int distance)
    {
        List<int> ints = new List<int>();

        GetNodesAtDistance(this.Root, ints, distance);

        return ints;
    }
    private void GetNodesAtDistance(Node root, List<int> list, int distance)
    {
        if (root == null)
            return;

        if (distance == 0)
        {
            list.Add(root.Val);
            return;
        }

        GetNodesAtDistance(root.LeftChild, list, distance - 1);
        GetNodesAtDistance(root.RightChild, list, distance - 1);
    }

    public int Size()
    {
        // Size of the binary tree means, total number of nodes in a tree
        Size(this.Root);

        return size;
    }

    private void Size(Node root)
    {
        if (root == null)
            return;

        this.size++;              // Root
        Size(root.LeftChild);     // Left
        Size(root.RightChild);    // Right
    }

    public int CountLeaves()
    {
        //leavesCount

        // Size of the binary tree means, total number of nodes in a tree
        CountLeaves(this.Root);

        return leavesCount;

    }

    private void CountLeaves(Node root)
    {
        if (root == null)
            return;

        if (root.LeftChild == null && root.RightChild == null)
        {
            this.leavesCount++;
            return;
        }

        CountLeaves(root.LeftChild);     // Left
        CountLeaves(root.RightChild);    // Right
    }

    public int Max()
    {
        Max(this.Root);

        return this.max;
    }

    private void Max(Node root)
    {
        if (root == null)
            return;

        // consider the right most child where there are no more nodes. 
        // As per the binary tree rule
        if (root.RightChild == null)
        {
            this.max = root.Val;
            return;
        }

        //Max(root.LeftChild);     // Left
        Max(root.RightChild);    // Right
    }


    public bool Contains(int value)
    {
        Contains(this.Root, value);

        return contains;
    }

    private void Contains(Node root, int value)
    {
        if (root == null)
            return;

        if (root.Val == value)
        {
            contains = true;
            return;
        }

        Contains(root.LeftChild, value);     // Left
        Contains(root.RightChild, value);    // Right
    }

    public bool AreSibling(int val1, int val2)
    {
        //areSibling
        AreSibling(this.Root, val1, val2);

        return areSibling;

    }

    private void AreSibling(Node root, int val1, int val2)
    {
        //areSibling

        if (root == null)
            return;

        if (root.LeftChild != null && root.RightChild != null)
        {
            if ((root.LeftChild.Val == val1 || root.LeftChild.Val == val2) &&
                (root.RightChild.Val == val1 || root.RightChild.Val == val2))
            {
                areSibling = true;
                return;
            }
        }

        AreSibling(root.LeftChild, val1, val2);     // Left
        AreSibling(root.RightChild, val1, val2);    // Right        
    }

    public List<int> GetAncestors(int value)
    {
        List<int> ints = new List<int>();

        GetAncestors(this.Root, ints, value);

        return ints;
    }

    /* If value is present in tree, then prints the ancestors
       and returns true, otherwise returns false. */
    private bool GetAncestors(Node root, List<int> list, int value)
    {
        if (root == null)
            return false;

        if (root.Val == value)
        {
            return true;
        }

        /* If target is present in either left or right subtree of this node,
             then add this node val */
        if (GetAncestors(root.LeftChild, list, value) ||
            GetAncestors(root.RightChild, list, value))
        {
            list.Add(root.Val);
            return true;
        }

        return false;
    }
}