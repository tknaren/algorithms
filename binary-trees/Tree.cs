using System.ComponentModel.DataAnnotations;

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

    public int GetHeight(Node root)
    {
        if (root == null)
            return -1;

        // base condition to exit the recursive call
        // if both the left and right side of the node is null then it is considered as LEAF node
        if (root.LeftChild == null && root.RightChild == null)
            return 0;

        // Using Post Order traversal here to determine the height
        // Left, Right and Root
        // formula : height = 1 + Max(height(L), height(R))

        return 1 + Math.Max(GetHeight(root.LeftChild), GetHeight(root.RightChild));

    }

}