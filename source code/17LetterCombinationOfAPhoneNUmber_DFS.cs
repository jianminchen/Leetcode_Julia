using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17LetterCombinationOfAPhoneNUmber_DFS
{
    /*
     * Leetcode 17:
     * Given a digit string, return all possible letter combinations that 
     * the number could represent.
       A mapping of digit to letters (just like on the telephone buttons) is given below.
     * Input:Digit string "23"
       Output: ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"].
     * 
     * Telephone dial pad:
     *                     0  1   2     3     4     5     6     7      8     9 
     * String[] keyboard={"","","abc","def","ghi","jkl","mno","pqrs","tuv","wxyz"};
     */
    class Solution
    {
        static void Main(string[] args)
        {
            IList<string> list = letterCombination("23"); 
            // test result: "abc", "def", so 3x3 = 9 cases. 
        }

        public static IList<string> letterCombination(string digits)
        {
            IList<string> list = new List<string>();
            if (digits == null || digits.Length == 0)
                return list;

            string[] keyboard = { "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
            StringBuilder builder = new StringBuilder();
            buildResult(list, keyboard, digits, 0, builder);  // think about design here

            return list; 
        }

        /*
         * January 29, 2016
         * DFS - backtracking - design recursive extra 2 columns - start, current
         * 3 ideas - Julia is taking DFS rehearsal - start to build a ritual about DFS design
         * challenge 
         * Question 1: When to add a string to the list? - complete the numbers of input digits
         * Question 2: input arguments - help recursive function to store temporary result
         * 
         * Julia, you only have 3 jobs for this function: 
         * 1. First,  decide to choose DFS algorithm; use recursive function /backtracking 
         *    (Need to emphasis the DFS drilling - work on basic algorithms)
         * 2. Second, add extra function arguments for temporary results 
         *    1. index 
         *    2. StringBuilder current - not string, need to modify - add/remove 
         *    (60 seconds to recall)
         * 3. Need to be able to convert int from a char '1' - 1 
         *    (give yourself 60 seconds to recall)
         *    char c; 
         *    int digit = c-'0'
         * 4. Think about test case "12", how to work out a solution. 
         *    
         */
        private static void buildResult(
            IList<string>   list,
            string[]        keyboard,
            string          digits,
            int             index, 
            StringBuilder   current
            )
        {
            if (current.Length == digits.Length)
            {
                list.Add(current.ToString());
                return; 
            }

            // work on first case, first char in digits array
            int number = digits[index] - '0';  // string 12, '1'->1

            for (int i = 0; i < keyboard[number].Length; i++)
            {
                current.Append(keyboard[number][i]);
                buildResult(list, keyboard, digits, index + 1, current);
                current.Remove(current.Length-1, 1); // remove last char - backtracking
            }             
        }
    }
}
