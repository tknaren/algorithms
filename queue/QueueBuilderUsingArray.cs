using queue;

public class QueueBuilderUsingArray : IQueueBuilder
{

    //enqueue
    //dequeue
    //peek
    //isEmpty
    //isFull

    // consider the queue can hold only 10 items
    // initialize the int array with 10 items, with all values to 0
    // Enqueue adds the items to the last
    // Dequeue removes the item from begining
    // we are not going to add or remove any items from the array
    //  rather we are going to use the pointer to know which is first and last
    // var to hold first and last indexes

    int[] queueArray = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    int front = -1;
    int rear = -1;

    public bool Enqueue(int item)
    {
        // first item to be added in the array
        if (front == -1 && rear == -1)
        {
            queueArray[rear + 1] = item;
            front++;
            rear++;
        }
        //queue cannot hold more than 10 items - limitation
        else if (rear == queueArray.Length - 1)
        {
            Console.WriteLine("The queue is full");
            return false;
        }
        // add an item to the queue
        else
        {
            queueArray[rear + 1] = item;
            rear++;
        }

        return true;
    }

    public int Dequeue()
    {
        int arItem = 0;

        if (front == -1 && rear == -1)
        {
            Console.WriteLine("No items in queue");
        }
        else if (front == rear)
        {
            arItem = queueArray[front];
            front = rear = -1;
        }
        else
        {
            arItem = queueArray[front];
            front++;
        }

        return arItem;

    }

    public int Peek()
    {
        int item = 0;

        if (front == -1 && rear == -1)
        {
            Console.WriteLine("No items in queue");
        }
        else
        {
            item = queueArray[front];
        }

        return item;
    }

    public bool IsEmpty()
    {
        if (front == -1 && rear == -1)
            return true;
        else
            return false;
    }

    public bool IsFull()
    {
        if (rear == queueArray.Length - 1)
            return true;
        else
            return false;
    }

}