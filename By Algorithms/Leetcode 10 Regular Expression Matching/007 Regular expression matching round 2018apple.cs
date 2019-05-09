using System;

class Solution
{
    public static bool IsMatch(string text, string pattern) // "", "a*b*"
    {
        if (text == null || pattern == null) // false 
        {
            return false;
        }

        var tLength = text.Length; // 0 
        var pLength = pattern.Length; // 4

        var dp = new bool[tLength + 1, pLength + 1]; // 1, 5

        dp[0, 0] = true; // 

        for (int i = 1; i < tLength + 1; i++)
        {
            dp[i, 0] = false;
        }

        for (int i = 1; i < pLength + 1; i++)
        {
            dp[0, i] = false;

            var visit = pattern[i - 1];
            var isStar = visit == '*';
            if (isStar)
            {
                if (i - 2 >= 0)
                {
                    dp[0, i] = dp[0, i - 2];
                }
            }
        }

        for (int row = 1; row < tLength + 1; row++)
        {
            for (int col = 1; col < pLength + 1; col++)
            {
                var visitChar = text[row - 1];
                var patternChar = pattern[col - 1];

                var isStar = patternChar == '*';
                if (!isStar)
                {
                    var isEqual = patternChar == '.' || visitChar == patternChar;

                    if (isEqual)
                    {
                        dp[row, col] = dp[row - 1, col - 1];
                    }
                }
                else
                {                            //   zero time          one time           more then one time        
                    dp[row, col] = col > 2 && (dp[row, col - 2] || dp[row, col - 1] || dp[row - 1, col]);
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
base case: 

"", "a*b*c*", OK 
"abc", "",    false 
  
  dp[textLength + 1, patternLength + 1]
   ""  "a*"  "a*b*"   
   ------------------------
""  1 0  1  0  1
"a" 0 
  
  
  
            (i, j)
  
  if current char is not *, dp[i,j] =    
     dp[i - 1, j - 1] if text[i - 1] == pattern[i - 1] || pattern[i - 1] = '.'
     0                if text[i - 1] == pattern[i - 1]
     
  if current char is *, b* 
    match 0 time,        1 time                  or more than 1 time 
    dp[i, j - 2]  ||    dp[i, j - 1]            ||  dp[i - 1, j]
    
*/