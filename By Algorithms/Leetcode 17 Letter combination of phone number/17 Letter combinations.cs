using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_Letter_combination
{
    class Program
    {        
        static void Main(string[] args)
        {
            RunTestcase();
        }

        public static void RunTestcase()
        {
            // test result: "abc", "def", so 3x3 = 9 cases.
            IList<string> letterCombinations = LetterCombination("23");
            Debug.Assert(letterCombinations.Count == 9);

            IList<string> letterCombinations2 = LetterCombination("2345678");
            Debug.Assert(letterCombinations.Count == 9 * 9 * 3);
        }

        public static IList<string> LetterCombination(string digitString)
        {
            var letterCombinations = new List<string>();
            if (digitString == null || digitString.Length == 0)
                return letterCombinations;

            var keyboard = new string[] { "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };

            var builder = new StringBuilder();
            RunDepthFirstSearch(keyboard, digitString, 0, builder, letterCombinations);

            return letterCombinations;
        }

        /*                  
         * keyboard = { "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
         * 
         * input arguments: 
         * @keyboard
         * @digitString
         * 
         * helper to track DFS steps, the index of digitString, and intermediate result
         * @scanIndex - scan digitString. Go over digitString, scan chars from 
         *              left to right one by one. 
         * @letterCombination
         * 
         * output arguments: 
         * @letterCombinations
         * 
         * Because there are 5 arguments, order the arguments using input, DFS helpers, 
         * and output arguments.
         * 
         * For each digit, apply depth first search and backtrack through chars in keyboard. 
         * For example, digitString "23", the first char 2 maps to "abc".
         * Do not forget to backtrack.  
         */
        private static void RunDepthFirstSearch(
            string[] keyboard,
            string digitString,
            int scanIndex,
            StringBuilder letterCombination,
            IList<string> letterCombinations
            )
        {
            if (letterCombination.Length == digitString.Length)
            {
                letterCombinations.Add(letterCombination.ToString());
                return;
            }

            // work on first case, first char in digits array
            var keyboardIndex = digitString[scanIndex] - '0';
            var letters = keyboard[keyboardIndex];

            for (int i = 0; i < letters.Length; i++)
            {
                // work on one char a time
                char currentChar = letters[i];

                // DFS step 
                letterCombination.Append(currentChar);
                RunDepthFirstSearch(keyboard, digitString, scanIndex + 1, letterCombination, letterCombinations);

                // remove last char - backtracking - StringBuilder API Remove(int index, int length)
                letterCombination.Remove(letterCombination.Length - 1, 1);
            }
        }
    }
}
