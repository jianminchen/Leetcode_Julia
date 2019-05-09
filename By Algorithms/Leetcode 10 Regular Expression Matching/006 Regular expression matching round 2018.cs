using System;

class Solution
{
    public static bool IsMatch(string text, string pattern) // "aa", "a"
    {
        if (pattern == null || pattern.Length == 0) // false 
        {
            return text == null || text.Length == 0;
        }

        if (text == null)
        {
            return false;
        }

        int length1 = text.Length + 1;
        int length2 = pattern.Length + 1;

        int[,] dp = new int[length1, length2];

        for (int row = 0; row < length1; row++)
        {
            // base case -         
            var isFirstRow = row == 0;
            for (int col = 0; col < length2; col++)
            {
                if (isFirstRow)
                {
                    dp[0, col] = col > 0 ? 0 : 1;
                    // "" matches "a*" or "a*b*" or "a*b*.*" etc.
                    if (col % 2 == 0 && col > 0 && pattern[col - 1] == '*')  // bug found in debug: 1/16/2018 should be col - 1
                    {
                        dp[0, col] = dp[0, col - 2];
                    }
                }

                var isFirstCol = col == 0;
                if (isFirstCol)
                {
                    dp[row, 0] = isFirstRow ? 1 : 0;
                }

                // handle case after base case
                if (isFirstRow || isFirstCol)
                {
                    continue;
                }

                var charText = text[row - 1];
                var charPattern = pattern[col - 1];

                var isDot = charPattern == '.';
                var isStar = charPattern == '*';

                // match one char 
                if (!isStar)
                {
                    if (dp[row - 1, col - 1] == 1 && (isDot || charText == charPattern))
                    {
                        dp[row, col] = 1;
                    }
                }
                else
                {
                    // isStar = True, apply zero time, one time or more than one time 
                    //   zero time                   one time                 dot char           char comparison           more than one time
                    if (dp[row, col - 2] == 1 || dp[row, col - 1] == 1 || ((pattern[col - 2] == '.' || charText == charPattern) && dp[row - 1, col] == 1))
                    {
                        dp[row, col] = 1;
                    }

                    /*
                    0 - "", a 1, * 2
                    a* - pattern len = 2, col = 1
                    b - text
            
                    */

                }
            }
        }

        return dp[length1 - 1, length2 - 1] == 1;
    }

    static void Main(string[] args)
    {

    }
}

/*

aa, a -> false 
a - a , a text cannot match any thing, - false text is not empty, pattern is empty
aa, aa -> a - a, a - a
abc -> a.c , a -a, b -. c - c

abbb - ab* -> abbb - ab* -> a - a, bbb - b*, b repeats 3 times

acd - ab*c -> a - a , b* match 0, cd match c -> false
                         match, cd match bc -> false
                         false 
                         
                         
 text length1
 pattern length2
 
 abb   abb* 
            ""  "a"   "ab"   "abb"  "abb*"
          ------------------------------------
   ""       T    F      F      F     F
   "a"      F
   "ab"     F           -       ?     
   "abb"    F                        ?
   
   "abb"  with "abb"
   
            "abb" with "ab"
            "ab"  with "abb"
            "ab"  with "ab"
            check . || (search[i] == pattern[j])
            
    has *, b* or .* 
    
    check if b* apply 0 time or 1 time or more than 1 times
    matrix(i, j - 2) || matrix(i - 1, j - 2) || matrix(i - 1, j)
    
    b* -> "", b, bb, bbb
    .* -> "", b, bb, bbb
    
    Pattern   ----
    Text      ----
    apply 0 time - matrix(i, j - 2)    | ""
    apply 1 time - b* - check search[i] == pattern[j -1] && matrix(i - 1, j -2)   -> optimized to this expression, take away one star matrix(i, j-1)  - 
                  .*  matrix(i -1, j - 2)      | b
    apply more than 1 time 
                  (pattern[j -1] == '.' || search[i] == pattern[j -1]) && matrix(i - 1 , j)
   

*/

/*

// aab, c*a*b
// ab, .b
// aaa, ab*a

*/