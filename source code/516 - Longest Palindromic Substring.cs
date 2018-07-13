public class Solution
{
    public int LongestPalindromeSubseq(string s)
    {
        if (s == null || s.Length == 0)
        {
            return 0;
        }

        int length = s.Length;

        var subsequence = new int[length][];
        for (int i = 0; i < length; i++)
        {
            subsequence[i] = new int[length];
        }

        // assuming i < j, subsequence from index i to index j
        for (int i = length - 1; i >= 0; i--)
        {
            subsequence[i][i] = 1;

            for (int j = i + 1; j < length; j++)
            {
                if (s[i] == s[j])
                {
                    subsequence[i][j] = subsequence[i + 1][j - 1] + 2;
                }
                else
                {
                    subsequence[i][j] = Math.Max(subsequence[i + 1][j], subsequence[i][j - 1]);
                }
            }
        }

        return subsequence[0][length - 1];
    }
}