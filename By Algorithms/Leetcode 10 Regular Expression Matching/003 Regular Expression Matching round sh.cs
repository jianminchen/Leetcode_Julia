
using System;

class Solution
{
    public static bool IsMatch(string text, string pattern) //"abc"  "a.c"
    {
        // base case 
        if (text == null || pattern == null)
        {
            return false;
        }

        if (pattern.Length == 0)
        {
            return text.Length == 0; // true, "a", ""
        }

        return isMatchHelper(text, pattern, 0, 0);
    }

    // "abbb", 1, "bbb" , "ab*", 0, "bbb" with "ab*"
    private static bool isMatchHelper(string text, string pattern, int textIndex, int patternIndex) // abbb, ab*
    {
        var lengthText = text.Length;
        var lengthPattern = pattern.Length;

        // base case
        if (patternIndex == lengthPattern)
        {
            return lengthText == textIndex;
        }


        // pattenrIndex < lengthPattern
        // single char match

        var template = pattern[patternIndex]; //'a'      
        var isContainingStar = template != '*' && patternIndex < lengthPattern - 1 && pattern[patternIndex + 1] == '*'; // standalone "*"

        // base case
        if (lengthText == 0 && isContainingStar)
        {
            return isMatchHelper(text, pattern, textIndex, patternIndex + 2);
        }

        var visit = text[textIndex]; // out-of-index range // 'a'

        if (!isContainingStar)
        {
            var comparisonEqual = visit == template || template == '.';
            if (!comparisonEqual)
            {
                return false;
            }

            return isMatchHelper(text, pattern, textIndex + 1, patternIndex + 1);
        }

        // assuming that containing * 
        // return at least 2 branch, pattern a*, or .* 
        // match 0 time, match 1 time or more than 1 time 
        if (isMatchHelper(text, pattern, textIndex, patternIndex + 2))  // abbb, ab* 
        {
            return true;
        }
        else if (visit == template || template == '.') // match one time
        {
            var matchOneTime = isMatchHelper(text, pattern, textIndex + 1, patternIndex + 2);
            if (matchOneTime)
            {
                return true;
            }

            return isMatchHelper(text, pattern, textIndex + 1, patternIndex); // text = bbb, pattern b*b; text = bb
        }             // bbb  b -> false 
        // b == b || b == '.'  one time , bb match b -> false 
        // bb match b*b -> it will 
        return false;
    }

    static void Main(string[] args)
    {

    }
}

// d* = d ddd ddddd

// . * 
// . any char 
// * duplicate, 0 or 1 or more than 1, nothing, repeat once or more than once 
// .* any char 0 or 1 or more than 1, it can be empty, or any char, or aaaa, ...
// "aa", pattern a -> do not match, a matchs a, second a does not match anything ""
// "aa"  "aa"  a - a , a - a 
// "abc" "a.c" a - a, b - ., c - c, true
// "abbb", "ab*" -> a - a , b, b*, b* "", b, bb, bbb, this case b* matchs bbb   true -> b*  branch 0 || branch 1 || branch more than 1 
// write code for this test case whiteboard testing 
// "acd"  "ab*c."     a - a, "" b*, c -c d -. return true 
// I write recursive, substring, index 
