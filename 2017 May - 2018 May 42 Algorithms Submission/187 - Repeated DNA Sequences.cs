public class Solution
{
    public IList<string> FindRepeatedDnaSequences(string s)
    {
        const int SIZE = 10;

        var repeated = new List<string>();
        if (s == null || s.Length <= SIZE)
        {
            return repeated;
        }

        var visited = new HashSet<string>();
        var added = new HashSet<string>();

        int length = s.Length;
        for (int start = 0; start <= length - SIZE; start++) // string length = 101
        {
            var current = s.Substring(start, SIZE);
            if (visited.Contains(current))
            {
                if (!added.Contains(current))
                {
                    repeated.Add(current);
                    added.Add(current);
                }
            }
            else
            {
                visited.Add(current);
            }
        }

        return repeated;
    }
}