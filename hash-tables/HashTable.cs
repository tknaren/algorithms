public class HashTable
{
    class Entry
    {
        internal int key;
        internal string value;

        public Entry(int key, string value)
        {
            this.key = key;
            this.value = value;
        }
    }

    private LinkedList<Entry>[] entries = new LinkedList<Entry>[25];

    public void Put(int key, string value)
    {
        // generate the hash key for storing it in index
        int index = Hash(key);

        //if no item in the index, initialize with an linked list
        if (entries[index] == null)
        {
            entries[index] = new LinkedList<Entry>();
        }

        //each entry has one linked list. 
        //when the hash key resolves to the same item #, 
        //  the new entries are added as a node to the linked list    

        // first, iterate thru the items in the linked list to find if the items already exist
        //  if exist replace the value of the item. 

        var bucket = entries[index];
        foreach (var entry in bucket)
        {
            if (entry.key == key)
            {
                entry.value = value;
                return;
            }
        }

        // if doesn't exist, add the item to the end of the linked list
        bucket.AddLast(new Entry(key, value));

    }

    public string Get(int key)
    {
        // convert the key to hash 
        // go to that specific item in the array 
        // retreive the linked list
        // iterate thru the linked list to find the key
        // return the value

        int index = Hash(key);

        var bucket = entries[index] ?? throw new InvalidOperationException("Invalid Key");

        foreach (var entry in bucket)
        {
            if (entry.key == key)
            {
                return entry.value;
            }
        }

        return string.Empty;
    }

    public bool Remove(int key)
    {
        // convert the key to hash
        // go to the item and pull the linkedlist
        // remove the item from the linkedlist
        // return the status once removed

        int index = Hash(key);

        var bucket = entries[index] ?? throw new InvalidOperationException("Invalid Key");

        foreach (var entry in bucket)
        {
            if (entry.key == key)
            {
                return bucket.Remove(entry);
            }
        }

        return false;
    }

    private int Hash(int key)
    {
        return key % entries.Length;
    }
}