public class CustomLinkedList
{
    class Node
    {
        public int value;
        public Node? next;
        public Node? previous;

        public Node(int value)
        {
            this.value = value;
        }
    }

    private Node? first;
    private Node? last;

    public void AddLast(int item)
    {
        var node = new Node(item);

        if (first == null)
        {
            first = node;
            last = node;
        }
        else
        {
            if (last != null)
            {
                node.previous = last;
                last.next = node;
            }

            last = node;
        }
    }

    public void AddFirst(int item)
    {
        var node = new Node(item);

        if (first == null)
        {
            first = node;
            last = node;
        }
        else
        {
            node.next = first;
            node.previous = null;
            first = node;
        }
    }

    public void DeleteFirst()
    {
        if (first != null && first.next != null)
        {
            first = first.next;
            first.previous = null;
        }
        else if (first != null && first.next == null)
        {
            first = null;
        }

    }

    // public void DeleteLast()
    // {
    //     int index = 0;
    //     var current = first;

    //     while (current != null)
    //     {
    //         index++;
    //         // If next node is the last one
    //         // assign it to temp variable
    //         // remove the link to the last node
    //         // refer the current node as last node
    //         // deallocate the old last node from memory
    //         if (current.next == last)
    //         {
    //             current.next = null;
    //             last = current;
    //             return;
    //         }
    //         else
    //         {
    //             current = current.next;
    //         }
    //     }
    // }

    public void DeleteLast()
    {
        if (last != null && last.previous != null)
        {
            last = last.previous;
            last.next = null;
        }
        else if (last != null && last.previous == null)
        {
            last = null;
        }
    }

    public int IndexOf(int item)
    {
        int index = -1;
        var current = first;
        // when we reach at the end of the list
        while (current != null)
        {
            index++;

            if (current.value == item)
            {
                return index;
            }

            current = current.next;
        }

        return index;
    }

    public bool Contains(int item)
    {
        int index = 0;
        var current = first;

        while (current != null)
        {
            if (current.value == item)
            {
                return true;
            }

            index++;

            current = current.next;
        }

        return false;
    }

    public int Size()
    {
        int size = 0;

        var current = first;

        while (current != null)
        {
            size++;

            current = current.next;
        }

        return size;
    }

    public int[] PrintList()
    {
        // Get the size of the list and initialize it to the array
        int size = Size();

        int[] linkedListArray = new int[size];
        int listCounter = 0;

        var current = first;

        while (current != null)
        {
            linkedListArray[listCounter++] = current.value;

            current = current.next;
        }

        return linkedListArray;
    }

    public int[] PrintInReverse()
    {
        // Get the size of the list and initialize it to the array
        int size = Size();

        int[] linkedListArray = new int[size];
        int listCounter = 0;

        var current = last;

        while (current != null)
        {
            linkedListArray[listCounter++] = current.value;

            current = current.previous;
        }

        return linkedListArray;
    }

    public int GetKthNodeFromEnd(int kthNode)
    {
        int index = Size();
        int nodeCounter = -1;
        var current = last;
        // when we reach at the end of the list
        while (current != null)
        {
            index--;
            nodeCounter++;

            if (nodeCounter == kthNode)
            {
                return current.value;
            }

            current = current.previous;
        }

        return nodeCounter;
    }

    public void printMiddle()
    {
        var a = first;
        var b = first;

        while (b != last && b.next != last)
        {
            b = b.next.next;
            a = a.next;
        }

        if (b == last)
            Console.WriteLine(a.value);
        else
            Console.WriteLine(a.value + " " + a.next.value);
    }
}