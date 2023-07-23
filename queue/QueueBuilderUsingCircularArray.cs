using queue;

public class QueueBuilderUsingCircularArray : IQueueBuilder
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
    // Circular array, 
    // as soon as the items are dequeued, mmake it as 0, so that it can be filled with new items 
    // in this case this array will behave as a circular array

    int[] queueArray = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    int front = 0;
    int rear = 0;
    int counter = 0;

    public bool Enqueue(int item)
    {
        //queue cannot hold more than 10 items - limitation
        if (counter == queueArray.Length - 1)
        {
            Console.WriteLine("The queue is full");
            return false;
        }

        queueArray[rear] = item;
        rear = (rear + 1) % queueArray.Length;
        counter++;

        return true;
    }

    public int Dequeue()
    {
        int item = 0;

        if (counter == 0)
        {
            Console.WriteLine("No items in queue");
        }

        item = queueArray[front];
        queueArray[front] = 0;
        front = (front + 1) % queueArray.Length;
        counter--;

        return item;

    }

    public int Peek()
    {
        int item = 0;

        if (counter == 0)
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
        if (counter == 0)
            return true;
        else
            return false;
    }

    public bool IsFull()
    {
        if (counter == queueArray.Length - 1)
            return true;
        else
            return false;
    }

}