// See https://aka.ms/new-console-template for more information

using System.Collections;

try
{

    #region Arrays

    // Array numbers = new Array(3);
    // numbers.Insert(10);
    // numbers.Insert(80);
    // numbers.Insert(30);
    // numbers.Insert(40);
    // numbers.Insert(50);
    // numbers.RemoveAt(5);
    // //Console.WriteLine(numbers.IndexOf(40));
    // //System.Console.WriteLine(numbers.Max());
    // numbers.InsertAt(60, 1);
    // numbers.Print();

    // int[] anotherArray = { 100 };
    // numbers.Intersect(anotherArray);
    // numbers.Reverse();

    #endregion

    #region LinkedList

    // CustomLinkedList list = new CustomLinkedList();

    // list.AddFirst(10);
    // list.AddLast(20);
    // list.AddLast(30);
    // list.AddLast(40);
    // list.AddLast(50);
    // list.AddLast(60);
    // list.AddLast(70);
    // list.AddLast(80);
    // list.AddLast(90);

    // list.DeleteFirst();
    // list.DeleteLast();

    // Console.WriteLine(list.Size());
    // Console.WriteLine(string.Join(",", list.PrintList()));
    // Console.WriteLine(string.Join(",", list.PrintInReverse()));
    // Console.WriteLine(list.GetKthNodeFromEnd(3));
    // list.printMiddle();

    #endregion

    #region Stacks

    // StringReverser reverser = new StringReverser();
    // System.Console.WriteLine(reverser.Reverse("What is my name?"));

    // BalancedExpression expression = new BalancedExpression();
    // System.Console.WriteLine(expression.ValidateExpression("(([1] + <2>))[a]"));



    #endregion

    #region Queue

    // Queue<int> m_Queue = new Queue<int>();
    // m_Queue.Enqueue(0);
    // m_Queue.Enqueue(1);
    // m_Queue.Enqueue(2);
    // m_Queue.Enqueue(3);
    // m_Queue.Enqueue(4);
    // m_Queue.Enqueue(5);


    // QueueReverser.Reverse(m_Queue);


    // QueueBuilderUsingArray queue = new QueueBuilderUsingArray();
    //QueueBuilderUsingStack queue = new QueueBuilderUsingStack();
    // PriorityQueue queue = new PriorityQueue();
    // queue.Enqueue(30);
    // queue.Enqueue(40);
    // queue.Enqueue(10);
    // queue.Enqueue(80);
    // queue.Enqueue(90);
    // queue.Enqueue(20);
    // queue.Enqueue(50);
    // queue.Enqueue(60);
    // queue.Enqueue(70);
    // queue.Enqueue(100);

    // Console.WriteLine(queue.Dequeue());
    // Console.WriteLine(queue.Dequeue());
    // Console.WriteLine(queue.Dequeue());
    // Console.WriteLine(queue.Dequeue());
    // Console.WriteLine(queue.Dequeue());

    // Console.WriteLine(queue.Peek());
    // Console.WriteLine(queue.IsEmpty());
    //Console.WriteLine(queue.IsFull());



    #endregion

    #region Hash Tables

    // CharOperations charOperations = new CharOperations();
    // Console.WriteLine(charOperations.GetFirstNonRepeatingChar("a green apple"));
    // Console.WriteLine(charOperations.GetFirstRepeatingCharUsingHashSet("a green apple"));

    // FrequencyFinder frequencyFinder = new FrequencyFinder();
    // Console.WriteLine(frequencyFinder.MostFrequent(new int[] { 1, 2, 3, 2, 3, 3, 4 }));

    // PairsWithDifference pairsWithDifference = new PairsWithDifference();
    // Console.WriteLine(pairsWithDifference.CountPairsWithDiff(input: new int[] { 1, 7, 5, 9, 2, 12, 3 }, diffVal: 2));



    #endregion

    Tree tree = new Tree();
    tree.Insert(10);
    tree.Insert(7);
    tree.Insert(11);
    tree.Insert(12);
    tree.Insert(8);
    tree.Insert(5);
    tree.Insert(3);
    tree.Insert(14);

    //tree.Find(5);

    PreOrderTraversal preOrderTraversal = new PreOrderTraversal();
    preOrderTraversal.TraversePreOrder(tree.Root);


}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

