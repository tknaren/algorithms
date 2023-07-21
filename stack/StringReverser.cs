using System.Text;

public class StringReverser
{
    public String Reverse(String input)
    {
        if (input == null)
            return string.Empty;

        Stack<Char> charStack = new Stack<Char>();

        foreach (char item in input.ToCharArray())
        {
            charStack.Push(item);
        }

        StringBuilder reversedString = new StringBuilder();

        while (!(charStack.Count == 0))
        {
            reversedString.Append(charStack.Pop());
        }

        return reversedString.ToString();

    }
}