using System.Globalization;

class CharOperations
{
    public char GetFirstNonRepeatingChar(string input)
    {
        char returnChar = ' ';

        Dictionary<char, int> charDict = new Dictionary<char, int>();

        foreach (char c in input.ToCharArray())
        {
            if (!charDict.ContainsKey(c))
            {
                charDict.Add(c, 1);
            }
            else
            {
                charDict[c] = charDict[c] + 1;
            }
        }

        foreach (char c in charDict.Keys)
        {
            if (charDict[c] == 1)
            {
                returnChar = c;
                break;
            }
        }

        return returnChar;
    }

    public char GetFirstRepeatingChar(string input)
    {
        char returnChar = ' ';

        Dictionary<char, int> charDict = new Dictionary<char, int>();

        foreach (char c in input.ToCharArray())
        {
            if (!charDict.ContainsKey(c))
            {
                charDict.Add(c, 1);
            }
            else
            {
                charDict[c] = charDict[c] + 1;
            }
        }

        // if the count is > 1, then it is a repeating char
        foreach (char c in charDict.Keys)
        {
            if (charDict[c] > 1)
            {
                returnChar = c;
                break;
            }
        }

        return returnChar;
    }

    public char GetFirstRepeatingCharUsingHashSet(string input)
    {
        HashSet<char> returnHashSet = new HashSet<char>();

        foreach (char c in input.ToArray())
        {
            if (returnHashSet.Contains(c))
                return c;

            returnHashSet.Add(c);
        }

        return ' ';

    }
}