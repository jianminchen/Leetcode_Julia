public class Solution
{
    static Dictionary<int, HashSet<int>> friends = new Dictionary<int, HashSet<int>>();
    static HashSet<int> visited = new HashSet<int>();

    public int FindCircleNum(int[,] M)
    {
        friends.Clear();
        visited.Clear();

        int numberOfCircles = 0;
        for (int i = 0; i < M.GetLength(0); i++) // build the graph
        {
            for (int j = 0; j < M.GetLength(1); j++)
            {
                if (i != j && M[i, j] == 1)
                {
                    if (friends.ContainsKey(i))
                    {
                        friends[i].Add(j);
                    }
                    else
                    {
                        var set = new HashSet<int>();
                        set.Add(j);
                        friends.Add(i, set);
                    }
                }
            }
        }

        // explore the graph to see how many isolated graphs
        for (int i = 0; i < M.GetLength(0); i++)
        {
            if (!visited.Contains(i))
            {
                numberOfCircles++;
                exploreFriends(i);
            }
        }

        return numberOfCircles;
    }

    /// <summary>
    /// recursive function - DFS
    /// </summary>
    /// <param name="i"></param>
    private static void exploreFriends(int i)
    {
        visited.Add(i);
        if (!friends.ContainsKey(i))
        {
            return;
        }

        foreach (var friend in friends[i])
        {
            if (!visited.Contains(friend))
            {
                exploreFriends(friend);
            }
        }
    }
}