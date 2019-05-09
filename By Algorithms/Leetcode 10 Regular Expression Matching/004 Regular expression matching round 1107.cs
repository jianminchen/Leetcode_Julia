using System;

class Solution
{
    public static bool IsMatch(string text, string pattern)
    {
        // base case: if pattern is empty, then it is ready to return the result. 
        if (pattern == null || pattern.Length == 0)
        {
            return text == null || text.Length == 0;
        }

        int lengthText = text.Length;
        int lengthPattern = pattern.Length;

        var memo = new int[lengthText + 1, lengthPattern + 1]; // 0 - not set, 1 - true, -1 - false

        return IsMatchHelper(text, pattern, memo, 0, 0);
    }

    /// <summary>
    /// recursive solution using memoization technique
    /// Recursive solution design is customized to avoid timeout. 
    /// Enforce the order to repeat one time first and then repeat 0 time next
    /// </summary>
    /// <param name="text"></param>
    /// <param name="pattern"></param>
    /// <param name="memo"></param>
    /// <param name="textIndex"></param>
    /// <param name="patternIndex"></param>
    /// <returns></returns>
    private static bool IsMatchHelper(string text, string pattern, int[,] memo, int textIndex, int patternIndex)
    {
        int lengthText = text.Length;
        int lengthPattern = pattern.Length;

        // base case 
        if (patternIndex == lengthPattern)
        {
            var textEmpty = textIndex == lengthText;
            memo[textIndex, patternIndex] = textEmpty ? 1 : -1;
            return textEmpty;
        }

        var firstCharIsDot = pattern[patternIndex] == '.';
        var isLastOne = patternIndex == lengthPattern - 1;
        var textIsEmpty = textIndex == lengthText;
        // 1st: apply to case: "", "."
        // 2nd: apply to case: "", a*, a*b*, a*.*
        if (textIsEmpty)
        {
            if (firstCharIsDot && (isLastOne || pattern[patternIndex + 1] != '*'))
            {
                return IsMatchHelper(text, pattern, memo, textIndex, patternIndex + 1);
            }

            var firstTwoWildMatch = patternIndex + 1 < lengthPattern && pattern[patternIndex + 1] == '*';
            return firstTwoWildMatch && IsMatchHelper(text, pattern, memo, textIndex, patternIndex + 2);
        }

        if (memo[textIndex, patternIndex] != 0)
        {
            return memo[textIndex, patternIndex] == 1;
        }

        if (isLastOne || pattern[patternIndex + 1] != '*')
        {
            // do one char comparison first
            var visit = text[textIndex];
            var patternChar = pattern[patternIndex];

            var isSameChar = isSame(visit, patternChar);

            if (isSameChar)
            {
                var nextIteration = IsMatchHelper(text, pattern, memo, textIndex + 1, patternIndex + 1);
                memo[textIndex, patternIndex] = nextIteration ? 1 : -1;
                return nextIteration;
            }
            else
            {
                memo[textIndex, patternIndex] = -1; //
                return false;
            }
        }
        else
        {
            var visit = text[textIndex];
            var patternChar = pattern[patternIndex];

            var firstRecursiveMatchOneTime = isSame(visit, patternChar) && IsMatchHelper(text, pattern, memo, textIndex + 1, patternIndex);

            if (firstRecursiveMatchOneTime)
            {
                memo[textIndex, patternIndex] = 1;
                return true;
            }

            var secondRecurisveMatchZeroTime = IsMatchHelper(text, pattern, memo, textIndex, patternIndex + 2);
            if (secondRecurisveMatchZeroTime)
            {
                memo[textIndex, patternIndex] = 1;
                return true;
            }

            return false;
        }
    }

    private static bool isSame(char visit, char patternChar)
    {
        return (visit == patternChar) || (patternChar == '.');
    }

    static void Main(string[] args)
    {

    }
}
// "aa", "a" -> false 
// "aa", "aa" -> true
// "abc", "a.c" -> . matches any char, true
// "abbb", "ab*" ->
// b* match 0 or 1 and 1 more time
// two branches -> 
// "bbb" match ""  - 0 time -> false 
// "bb"  match "b*" -> match 1 time - subproblem - re
// time out -> apply to test case 
// "abcdabcdabcdabcdabcdabcd", "a*b*c*d*a*b*c*d*a*b*c*d*a*b*c*d*a*b*c*d*"  -> time out , match, 2^20 timeout
// "bb"  match "b*" -> match 1 time - subproblem - re
// "bbb" match ""  - 0 time -> false 
// 
// "acd"   "ab*c." 