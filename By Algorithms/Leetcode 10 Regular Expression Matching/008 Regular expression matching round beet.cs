using System;

class Solution
{
    public static bool IsMatch(string text, string pattern)
    {
        if (text == null || pattern == null)
        {
            return false;
        }

        var tLength = text.Length;
        var pLength = pattern.Length;

        var dp = new bool[tLength + 1, pLength + 1];

        // set base case first 
        dp[0, 0] = true; ;

        // first row
        for (int col = 1; col < pLength + 1; col++)
        {
            var pChar = pattern[col - 1];
            var isStar = pChar == '*';
            if (col >= 2 && isStar)   // "" matches "a*" or "a*b*"
                dp[0, col] = dp[0, col - 2];
        }

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
                    dp[row, col] = (isDot || (tChar == pChar)) && dp[row - 1, col - 1]; // bug fixed
                }
                else
                {
                    // it is star
                    //                 zero time,                     one time          or more than one time 
                    dp[row, col] = (col >= 2 || dp[row, col - 2]) || dp[row, col - 1] || dp[row - 1, col];
                }
            }
        }

        return dp[tLength, pLength];
    }

    static void Main(string[] args)
    {

    }
}
/*
   b*  repeat zero time, one time and more than one time
   
   "",
   b
   bb
   bbbb
   
   acd with ab*c.
          0    1     2     3      4        5          pattern 
         ""   "a"  "ab"  "ab*"  "ab*c"  "ab*c."
         ----------------------------------------
 0  ""    T    F    F     F       F       F
 1  "a"   F    T    F     T(0)    F       F
 2  "ac"  F    
 3  "acd" F                              dp(3,5)=?
    text 
     
     base case:  "", dp[0,0] = true, dp[row,0] = false;
              text empty, "" match "a*" and "a*b*"
     
     inductive step: 
            discuss two case: 
            * involved - match zero, match one or more than one
            compare two key or if pattern key is wild char .
    */