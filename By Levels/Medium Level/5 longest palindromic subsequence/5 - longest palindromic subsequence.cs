public class Solution
{
    /// <summary>
    /// code review
    /// The code is written 3 years ago, current date: June 19, 2018
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public string LongestPalindrome(string s)
    {
        if (s == null)
            return null;

        if (s.Length <= 1)
            return s;

        int maxLen = 0;
        String longestStr = null;

        int length = s.Length;

        int[][] table = new int[length][];
        for (int i = 0; i < length; i++)
            table[i] = new int[length];

        //every single letter is palindrome
        for (int i = 0; i < length; i++)
        {
            table[i][i] = 1;
        }       

        //e.g. bcba
        //two consecutive same letters are palindrome
        for (int i = 0; i <= length - 2; i++)
        {
            if (s[i] == s[i + 1])
            {
                table[i][i + 1] = 1;
                longestStr = s.Substring(i, 2);
            }
        }

        //condition for calculate whole table
        for (int l = 3; l <= length; l++)
        {
            for (int i = 0; i <= length - l; i++)
            {
                int j = i + l - 1;

                if (s[i] == s[j])
                {
                    // how to ensure that table[i+1][j-1] is calculated before table[i][j] because the first one's length is j-i-2 whereas the second one is j-i. So, it is in the order. 
                    table[i][j] = table[i + 1][j - 1];

                    if (table[i][j] == 1 && l > maxLen)
                    {
                        longestStr = s.Substring(i, j + 1 - i);
                        maxLen = j + 1 - i;
                    }
                }
                else
                {
                    table[i][j] = 0;
                }                
            }
        }

        return longestStr;
    }
}