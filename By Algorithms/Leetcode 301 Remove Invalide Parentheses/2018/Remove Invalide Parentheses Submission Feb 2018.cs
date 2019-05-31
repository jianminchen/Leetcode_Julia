using System;

public class Solution
{
    public IList<string> RemoveInvalidParentheses(string s)
    {
        var validStrings = new List<string>();

        if (s == null)
        {
            return validStrings;
        }

        var visited = new HashSet<string>();
        var queue = new Queue<string>();

        // initialize
        queue.Enqueue(s);
        visited.Add(s);

        var found = false;

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            if (isValid(current))
            {
                validStrings.Add(current);
                found = true;
            }

            if (found)
            {
                continue;
            }

            // generate all possible states
            for (int i = 0; i < current.Length; i++)
            {
                // we only try to remove left or right parenthese
                var visit = current[i];
                bool isParenthese = visit == '(' || visit == ')';

                if (!isParenthese)
                {
                    continue;
                }

                // remove char stored in variable visit
                var candidate = current.Substring(0, i) + current.Substring(i + 1);

                if (!visited.Contains(candidate))
                {
                    queue.Enqueue(candidate);
                    visited.Add(candidate);
                }
            }
        }

        return validStrings;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static bool isValid(String s)
    {
        int count = 0;
        for (int i = 0; i < s.Length; ++i)
        {
            var visit = s[i];
            bool isOpen = visit == '(';
            bool isClose = visit == ')';
            if (isOpen)
            {
                ++count;
            }

            if (isClose)
            {
                bool noOpenToMatch = count <= 0;

                if (noOpenToMatch)
                {
                    return false;
                }

                count--;
            }
        }

        return count == 0;
    }
}