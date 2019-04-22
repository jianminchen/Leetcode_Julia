using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _402_remove_k_digits
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Leetcode 402 remove K digits
        /// 4/19/2019
        /// I learned two lessons. 
        /// first I should evaluate time complexity; if I choose to use stack then it will much easy to write;
        /// Second the edge case is not handled time efficent way. 
        /// </summary>
        /// <param name="num"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public string RemoveKdigits(string num, int k)
        {
            if (k == 0)
                return num;
            if (num == null || num.Length == 0)
                return num;

            var length = num.Length;
            var chose = new StringBuilder();

            var stack = new Stack<char>();

            for (int i = 0; i < length; i++)
            {
                var current = num[i];
                while (stack.Count > 0 && stack.Peek() > current && k > 0)
                {
                    stack.Pop();
                    k--;
                }

                stack.Push(current);
            }

            // edge case: "9", 1
            while (k > 0 && stack.Count > 0)
            {
                stack.Pop();
                k--;
            }

            var numbers = stack.ToList();

            var sb = new StringBuilder();
            var foundNonZero = false;
            for (int i = 0; i < numbers.Count; i++)
            {
                var index = numbers.Count - i - 1;
                var current = numbers[index];
                if (!foundNonZero && current == '0')
                {
                    continue;
                }

                foundNonZero = true;
                sb.Append(current);
            }

            return sb.ToString().Length == 0 ? "0" : sb.ToString();
        }
    }
}
