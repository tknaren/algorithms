// See https://aka.ms/new-console-template for more information

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

    CustomLinkedList list = new CustomLinkedList();

    list.AddFirst(10);
    list.AddLast(20);
    list.AddLast(30);
    list.AddLast(40);
    list.AddLast(50);
    list.AddLast(60);
    list.AddLast(70);
    list.AddLast(80);
    list.AddLast(90);

    list.DeleteFirst();
    list.DeleteLast();

    Console.WriteLine(list.Size());
    Console.WriteLine(string.Join(",", list.PrintList()));
    Console.WriteLine(string.Join(",", list.PrintInReverse()));
    Console.WriteLine(list.GetKthNodeFromEnd(3));
    list.printMiddle();

    #endregion
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

