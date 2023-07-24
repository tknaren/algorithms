using System.Collections;
using System.Data.Common;
using queue;

class PriorityQueue
{
    int[] queueArray = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    int front = 0;
    int rear = 0;
    int counter = 0;

    public void Enqueue(int item)
    {
        // while adding the items to the queue, 
        //  loop it from the back
        //  check if the item is greater than the new item
        //      move the existing item to next index
        //  if the item is lesser
        //      place this item in index + 1

        //queue cannot hold more than 10 items - limitation
        if (counter == queueArray.Length)
        {
            Console.WriteLine("The queue is full");
            return;
        }

        for (int i = counter; i >= 0; i--)
        {
            if (queueArray[i] != 0)
            {
                if (queueArray[i] > item)
                {
                    queueArray[i + 1] = queueArray[i];
                    queueArray[i] = item;
                }
                else
                {
                    queueArray[i + 1] = item;
                    break;
                }
            }
            else if (queueArray[i] == 0 && counter == 0)
            {
                queueArray[i] = item;
                break;
            }
        }

        rear = (rear + 1) % queueArray.Length;
        counter++;
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
}