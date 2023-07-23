namespace queue
{
    public interface IQueueBuilder
    {
        public bool Enqueue(int item);
        public int Dequeue();
        public int Peek();
        public bool IsEmpty();
        public bool IsFull();
    }
}