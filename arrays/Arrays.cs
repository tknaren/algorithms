using System.Runtime.InteropServices;

class Array
{
    private int[] items;

    // to keep track of number of items in the array, 
    // otherwise using length property of an array will show all the items in array as 0
    private int count;

    public Array(int length)
    {
        count = 0;
        items = new int[length];
    }

    public void Print()
    {
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(items[i].ToString());
        }
    }

    public void Insert(int item)
    {
        // If the array is full resize it
        // Add the items at the end of the array

        if (items.Length == count)
        {
            // Create a new array (twice the size)
            int[] newItems = new int[count * 2];

            // Copy all existing items
            for (int i = 0; i < count; i++)
            {
                newItems[i] = items[i];
            }

            // Set "items" to this new array
            items = newItems;
        }


        items[count++] = item;
    }

    public void RemoveAt(int index)
    {
        // validate the index value sent as a param
        if (index < 0 || index >= count)
        {
            throw new Exception("Index out of range");
        }

        //Shift the items to te left to fill the hole
        for (int i = index; i < count; i++)
            items[i] = items[i + 1];

        count--;

    }

    public int IndexOf(int item)
    {
        for (int i = 0; i < count; i++)
            if (items[i] == item)
                return i;

        return -1;
    }

    public int Max()
    {
        int maxVal = 0;
        for (int i = 0; i < count; i++)
        {
            if (maxVal < items[i])
                maxVal = items[i];
        }

        return maxVal;
    }

    public void Intersect(int[] anotherArray)
    {
        int[] commonItems = new int[anotherArray.Length];
        int commonItemsCount = 0;

        // O(n^2)
        for (int i = 0; i < anotherArray.Length; i++)
        {
            for (int j = 0; j < count; j++)
            {
                if (anotherArray[i] == items[j])
                {
                    commonItems[commonItemsCount++] = items[j];
                }
            }
        }

        for (int i = 0; i < commonItemsCount; i++)
        {
            Console.WriteLine(commonItems[i].ToString());
        }

    }

    public void Reverse()
    {
        int[] reverseItems = new int[count];
        int reverseIndex = 0;
        for (int i = count - 1; i >= 0; i--)
        {
            reverseItems[reverseIndex++] = items[i];
        }

        for (int i = 0; i < reverseIndex; i++)
        {
            Console.WriteLine(reverseItems[i].ToString());
        }
    }

    public void InsertAt(int item, int index)
    {
        // create a new array and initialize the size as 1 item more than the current array
        int[] newItems = new int[count + 1];
        int newItemsIndex = 0;
        // traverse to the index and insert the item
        for (int i = 0; i < count; i++)
        {
            if (i == index)
            {
                newItems[newItemsIndex++] = item;

            }
            newItems[newItemsIndex++] = items[i];
        }

        items = newItems;
    }
}