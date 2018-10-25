public class Solution
{
    public IList<string> RemoveInvalidParentheses(String s)
    {
        var answer = new List<String>();
        remove(s, answer, 0, 0, new char[] { '(', ')' });
        return answer;
    }

    private static void remove(String s, List<String> validStrings, int right, int left, char[] parenthese)
    {
        for (int openBracket = 0, i = right; i < s.Length; ++i)
        {
            var current = s[i];
            if (current == parenthese[0])
            {
                openBracket++;
            }

            if (current == parenthese[1])
            {
                openBracket--;
            }

            if (openBracket >= 0)
            {
                continue;
            }

            // find first unmatched parenthese, and then go over all the options to remove it.
            for (int j = left; j <= i; ++j)
            {
                if (s[j] == parenthese[1] && (j == left || s[j - 1] != parenthese[1]))
                {
                    // remove s[j]
                    var stringAfterRemove = s.Substring(0, j) + s.Substring(j + 1);
                    remove(stringAfterRemove, validStrings, i, j, parenthese);
                }
            }

            return;
        }

        var reversed = new String(s.ToCharArray().Reverse().ToArray());

        if (parenthese[0] == '(') // finished left to right
        {
            remove(reversed, validStrings, 0, 0, new char[] { ')', '(' });
        }
        else // finished right to left
        {
            validStrings.Add(reversed);
        }
    }
}