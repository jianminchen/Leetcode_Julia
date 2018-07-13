public class Solution
{
    public int MinDistance(string word1, string word2)
    {
        int length1 = word1.Length;
        int length2 = word2.Length;

        // consider to add empty space string 
        var distance = new int[length1 + 1][];

        for (int i = 0; i < length1 + 1; i++)
        {
            distance[i] = new int[length2 + 1];
        }

        // base case: one thing is empty, then distance is another string's length  
        for (int i = 0; i < length1 + 1; i++)
        {
            distance[i][0] = i;
        }

        for (int j = 1; j < length2 + 1; j++)
        {
            distance[0][j] = j;
        }

        // recursive，[i][j] depends on left，top and left top 3 situations
        for (int i = 1; i < length1 + 1; i++)
        {
            var current1 = word1[i - 1];

            for (int j = 1; j < length2 + 1; j++)
            {
                var current2 = word2[j - 1];

                // If last characters of two words are the same, then it is 0. 
                // If they are different, then it is 1. 
                var distanceValue = (current1 == current2) ? 0 : 1;

                var top = distance[i - 1][j];
                var left = distance[i][j - 1];
                var leftTop = distance[i - 1][j - 1];

                // from top or from left, both needs insertion
                var minimum = Math.Min(top + 1, left + 1);

                // from top left, consider substitution                                       
                distance[i][j] = Math.Min(minimum, leftTop + distanceValue);
            }
        }

        // return right bottom corner 
        return distance[length1][length2];
    }
}