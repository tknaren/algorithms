public class PairsWithDifference
{
    class Pair
    {
        public int x { get; set; }
        public int y { get; set; }

        public Pair(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    List<Pair> pairs = new List<Pair>();

    public int CountPairsWithDiff(int[] input, int diffVal)
    {
        // determine all the pairs 
        //      create a class caleld Pair with Val1 and Val2 as variables
        //      Create a list of Pair objects
        //      Arrange - always place the lesser one in Val1 and greater one in Val2 of the pair 
        //          Loop item by item
        //              Inner Loop other remaining items in the array
        //              arrange the items in the pair
        //              add the item to the list object
        // find the diff bet all the pairs 
        //      Loop thru the list of pairs
        //      calculate the diff and if the diff is matching the inputDiff then increment the counter
        // Return the counter


        //DetermineThePairs
        //GetNumberOfPairsWithDiff

        DetermineThePairs(input);
        return GetNumberOfPairsWithDiff(diffVal);
    }

    private void DetermineThePairs(int[] input)
    {
        for (int i = 0; i < input.Length; i++)
        {
            for (int j = i + 1; j < input.Length; j++)
            {
                int a = input[i];
                int b = input[j];

                if (a > b)
                {
                    if (!IsPairExist(b, a))
                        pairs.Add(new Pair(b, a));
                }
                else
                {
                    if (!IsPairExist(a, b))
                        pairs.Add(new Pair(a, b));
                }
            }
        }
    }

    private int GetNumberOfPairsWithDiff(int diffVal)
    {
        int diffMatchCounter = 0;

        foreach (Pair pair in pairs)
        {
            if ((pair.y - pair.x) == diffVal)
            {
                diffMatchCounter++;
            }
        }

        return diffMatchCounter;
    }

    private bool IsPairExist(int val1, int val2)
    {
        foreach (Pair pair in pairs)
        {
            if (pair.x == val1 && pair.y == val2)
            {
                return true;
            }
        }

        return false;
    }


}