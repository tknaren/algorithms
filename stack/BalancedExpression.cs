public class BalancedExpression
{
    public string ValidateExpression(String input)
    {
        // Add the opening braces and closing braces in a separate collection 
        //  eg "({<[" to a collection and "]>})" to a collection
        // Have a Dictionary where closing brace is the key and opening brace is the value 
        // Loop thru the string
        //  When encountered a opening brace, add to stack
        //  when encountered a closing brace, pop the item from stack and check for the pair
        //   If matches pop it from the stack. 
        //  When the string traversal comes to an end, the stack should be empty. 
        //   if not it is not a valid string 

        Stack<char> expressionChars = new Stack<char>();
        List<char> openingBraces = new List<char>() { '[', '{', '(', '<' };
        List<char> closingBraces = new List<char>() { ']', '}', ')', '>' };
        Dictionary<char, char> bracePairs = new Dictionary<char, char>();
        bracePairs.Add(']', '[');
        bracePairs.Add('}', '{');
        bracePairs.Add('>', '<');
        bracePairs.Add(')', '(');

        foreach (char item in input.ToCharArray())
        {
            if (openingBraces.Contains(item))
            {
                expressionChars.Push(item);
            }

            if (closingBraces.Contains(item))
            {
                char pair = bracePairs[item];
                if (expressionChars.Pop() != pair)
                {
                    return "In-valid expression";
                }
            }
        }

        if (expressionChars.Count > 0)
            return "In-valid expression";

        return "Valid";
    }
}