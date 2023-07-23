using System.Text;

public class QueueReverser
{
    public static void Reverse(Queue<int> queue)
    {
        // add
        // remove
        // isEmpty
        Stack<int> tempStorage = new Stack<int>();
        Queue<int> reversedQueue = new Queue<int>();

        while (queue.Count > 0)
        {
            tempStorage.Push(queue.Dequeue());
        }

        while (tempStorage.Count > 0)
        {
            reversedQueue.Enqueue(tempStorage.Pop());
        }

        while (reversedQueue.Count > 0)
        {
            System.Console.WriteLine(reversedQueue.Dequeue());
        }

    }
}