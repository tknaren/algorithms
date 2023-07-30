public class FrequencyFinder
{
    public int MostFrequent(int[] input)
    {
        int frequencyItem = 0;
        int frequencyVal = 0;

        Dictionary<int, int> frequencyLog = new Dictionary<int, int>();

        foreach (int item in input)
        {
            if (frequencyLog.ContainsKey(item))
            {
                frequencyLog[item] = frequencyLog[item] + 1;
            }
            else
            {
                frequencyLog[item] = 1;
            }
        }

        foreach (KeyValuePair<int, int> entry in frequencyLog)
        {
            // do something with entry.Value or entry.Key
            if (frequencyVal == 0)
            {
                frequencyVal = entry.Value;
                frequencyItem = entry.Key;
            }
            else if (frequencyVal < entry.Value)
            {
                frequencyVal = entry.Value;
                frequencyItem = entry.Key;
            }
        }

        return frequencyItem;
    }
}