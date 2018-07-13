using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterCombinationOfAPhoneNumber
{
    class LetterCombinationOfAPhoneNumber
    {
        static void Main(string[] args)
        {
            ArrayList test = letterCombinations("23"); 
        }

        /*
         * 
         * http://codeganker.blogspot.ca/2014/02/letter-combinations-of-phone-number.html
         */

        public static ArrayList letterCombinations(String digits)
        {
            ArrayList res = new ArrayList();
            res.Add("");

            if (digits == null || digits.Length == 0)
                return res;

            for (int i = 0; i < digits.Length; i++)
            {
                String letters = getLetters(digits[i]);

                ArrayList newRes = new ArrayList();

                for (int j = 0; j < res.Count; j++)
                {
                    for (int k = 0; k < letters.Length; k++)
                    {
                        newRes.Add(res[j] + letters[k].ToString());
                    }
                }
                res = newRes;
            }

            return res;
        }

        private static String getLetters(char digit)
        {
            switch (digit)
            {
                case '2':
                    return "abc";
                case '3':
                    return "def";
                case '4':
                    return "ghi";
                case '5':
                    return "jkl";
                case '6':
                    return "mno";
                case '7':
                    return "pqrs";
                case '8':
                    return "tuv";
                case '9':
                    return "wxyz";
                case '0':
                    return " ";
                default:
                    return "";
            }
        }

    }
}
