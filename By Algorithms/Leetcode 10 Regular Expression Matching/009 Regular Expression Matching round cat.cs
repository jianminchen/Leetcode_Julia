using System;

class Solution
{
    public static bool IsMatch(string text, string pattern) // "", "a*" - true
    {
        if (text == null || pattern == null) // false
            return false;

        var tLength = text.Length; // 0
        var pLength = pattern.Length; // 2
        var rows = tLength + 1; // 1
        var columns = pLength + 1; // 3

        var dp = new bool[rows, columns]; // false

        //base case
        dp[0, 0] = true; // "", ""

        // base case here - "" matches "a*b*"
        for (int col = 1; col < columns; col++)  // "", "a*", 3
        {
            var pChar = pattern[col - 1]; // a, *         

            var isStarPattern = pChar == '*' && col >= 2 && pattern[col - 2] != '*';  // b*
            if (isStarPattern)
            {
                dp[0, col] = dp[0, col - 2];
            }
        }

        for (int row = 1; row < rows; row++)
        {
            for (int col = 1; col < columns; col++)
            {
                var tChar = text[row - 1];
                var pChar = pattern[col - 1];
                var isDot = pChar == '.';

                var isStarPattern = pChar == '*' && col != 0 && pattern[col - 2] != '*';  // b*

                if (!isStarPattern)
                {
                    if (isDot || tChar == pChar)
                    {
                        dp[row, col] = dp[row - 1, col - 1];
                    }
                }
                else
                {
                    // recursive checks 
                    //              0 time                  1 time            more than 1 time
                    dp[row, col] = dp[row, col - 2] || (tChar == pChar && (dp[row - 1, col - 2]) || dp[row - 1, col]);
                }
            }
        }

        return dp[rows - 1, columns - 1];
    }

    static void Main(string[] args)
    {

    }
}

/*
. matches any char
* repeat 0 time, 1 time or more than 1 times
"" .*
b  .*
bb .*

b  b*
bb b*
extend line 18 - 
"" b*a*.* - pattern string may not be empty

"a" "" -> false
  
  dynamic programming solution - "acd", "ab*c."  true
  
  scan from left to right 
  
        "" "a"  "ab"  "ab*"  "ab*c"   "ab*c."  - pattern
       -------------------------------------------------------
  ""    T   F    F     F      F        F     
  "a"   F   T    F     T      F        F
  "ac"  F
  "acd" F                              ?
  
  bottom up, from base case, from lower axis values 
  
  time complexity: 
  dynamic programming, bottom up, I need to argue O(m * n)
  
  space complexity: 
  should be O(m * n), m is text length, n pattern length, use two dimension array
  
  */