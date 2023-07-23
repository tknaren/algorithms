using System.Collections;
using queue;

public class QueueBuilderUsingStack : IQueueBuilder
{

    Stack<int> stk = new Stack<int>();
    Stack<int> rStk = new Stack<int>();

    public bool Enqueue(int item)
    {
        stk.Push(item);

        return true;
    }

    public int Dequeue()
    {
        while (stk.Count > 0)
        {
            rStk.Push(stk.Pop());
        }

        return rStk.Pop();
    }

    public int Peek()
    {
        throw new NotImplementedException();
    }

    public bool IsEmpty()
    {
        throw new NotImplementedException();
    }

    public bool IsFull()
    {
        throw new NotImplementedException();
    }
}