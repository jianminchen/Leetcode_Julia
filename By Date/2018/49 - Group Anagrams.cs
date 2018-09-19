public class Solution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        if (strs == null || strs.Length == 0)
        {
            return new List<IList<String>>();
        }

        var map = new Dictionary<String, List<String>>();

        foreach (String s in strs)
        {
            char[] ca = s.ToCharArray();
            Array.Sort(ca);

            String keyStr = new string(ca);
            if (!map.ContainsKey(keyStr))
            {
                map.Add(keyStr, new List<String>());
            }

            map[keyStr].Add(s);
        }

        return new List<IList<String>>(map.Values);
    }
}