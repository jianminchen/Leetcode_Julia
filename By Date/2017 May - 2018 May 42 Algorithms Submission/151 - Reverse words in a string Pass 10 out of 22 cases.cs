public class Solution
{
    public string ReverseWords(string s)
    {
        // your code goes here
        if (s == null || s.Length == 0)
        {
            return string.Empty;
        }

        if (s[0] == ' ')
        {
            return ReverseWords(s.Substring(1));
        }

        if (s[s.Length - 1] == ' ')
        {
            return ReverseWords(s.Substring(0, s.Length - 1));
        }

        char[] input = s.ToCharArray();
        reverseString(input, 0, s.Length - 1); // 

        // reverse each word 
        reverseEachWord(input);
        return s;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="arr"></param>
    private static void reverseEachWord(char[] arr)
    {
        int length = arr.Length;

        int start = 0;  // "a ", "ab b " 
        for (int i = 0; i < length; i++)
        {
            var visit = arr[i];
            bool visitIsSpace = visit == ' ';

            var startChar = arr[start];
            bool startIsSpace = startChar == ' ';
            if (startIsSpace)
            {
                start = i; // mark the word start 
            }

            bool isLastChar = i == (length - 1);
            bool foundWord = !startIsSpace && visitIsSpace; // "ab ", "ab cd"  " practice"
            bool foundWordCase1 = (foundWord && (i - 1 - start) >= 0);
            bool foundWordCase2 = !startIsSpace && !visitIsSpace && isLastChar;

            if (foundWordCase1 || foundWordCase2)
            {
                var end = isLastChar ? i : (i - 1); // bug in mocking experience, missing isLastChar end = i instead of i - 1. 
                reverseString(arr, start, end);
                start = i + 1;   // start new word 
            }
        }
    }

    private static void reverseString(char[] arr, int start, int end)
    {
        if (start >= end)
        {
            return;
        }

        while (start < end)
        {
            var tmp = arr[start];
            arr[start] = arr[end];
            arr[end] = tmp;

            start++;
            end--;
        }
    }
}