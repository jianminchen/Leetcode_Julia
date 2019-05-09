using System;

class Solution
{
    public static bool IsMatch(string text, string pattern)
    {
        if (text == null || pattern == null)
            return false;

        var tLength = text.Length;
        var pLength = pattern.Length;

        var dp = new bool[tLength + 1, pLength + 1];

        // base case "" match "a*" or "a*b*"
        dp[0, 0] = true;

        for (int col = 1; col < pLength + 1; col++)
        {
            // pattern[col - 1]
            dp[0, col] = col >= 2 && pattern[col - 1] == '*' && dp[0, col - 2];
        }

        // base case "a" does not match "" - do not need anything - default false


        // row by row, column by row 
        for (int row = 1; row < tLength + 1; row++)
        {
            for (int col = 1; col < pLength + 1; col++)
            {
                var tChar = text[row - 1];
                var pChar = pattern[col - 1];

                var isStar = pChar == '*';
                var isDot = pChar == '.';

                if (!isStar)
                {
                    dp[row, col] = (tChar == pChar || isDot) && dp[row - 1, col - 1];
                }
                else
                {
                    // "" matches "b*", "b" matches "b*", "bb" matches "b*"
                    //                          match 0 time        match one time
                    dp[row, col] = col >= 2 && (dp[row, col - 2] || ((tChar == pattern[col - 2] || pattern[col - 2] == '.') && dp[row - 1, col - 2]) ||
                        // match more than one time
                                                ((tChar == pattern[col - 2] || pattern[col - 2] == '.') && dp[row - 1, col]));
                }
            }

        }

        return dp[tLength, pLength];
    }

    static void Main(string[] args)
    {
        // Console.WriteLine(IsMatch("a","a"));
        // Console.WriteLine(IsMatch("a","."));
        // Console.WriteLine(IsMatch("b","b*")); 
        Console.WriteLine(IsMatch("", "b*a*"));

    }
}

/*
"aa", "a" -> false
"aa", "aa" -> true
"abc", "a.c" -> true
"abbb"  "ab*" -> true 0 time, 1 time or more than 1 time
"acd"   "ab*c." -> true
  
  tlength, plength
  dp[tlength + 1, plength + 1]
  
        ""  'a'  'b'   '*'      'c'    '.''
        """  "a" "ab"  "ab*"  "ab*c"  "ab*c."
        -----------------------------------------
""  ""  T    F    F     F
''  a"
'c' "ac"
'd' "acd"                               ? 
 */
