using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _241_different_way_to_add_parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTestcase1(); 
        }

        public static void RunTestcase1()
        {
            var result = DiffWaysToCompute("2-1-1"); 
        }

        public static Dictionary<string, IList<int>> map = new Dictionary<string, IList<int>>();

        /// <summary>
        /// May 27, 2019
        /// study code 
        /// https://leetcode.com/problems/different-ways-to-add-parentheses/discuss/66328/A-recursive-Java-solution-(284-ms)/179202
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static IList<int> DiffWaysToCompute(string input)
        {
            if (map.ContainsKey(input))
            {
                return map[input]; 
            }

            var results = new List<int>();

            // base case - input is an integer
            if (!(input.Contains("+") || input.Contains("-") || input.Contains("*")))
            {
                results.Add(Convert.ToInt32(input)); 
            }

            // brute force solution - go over each operator in the expression
            for (int i = 0; i < input.Length; i++)
            {
                var current = input[i];
                var isOperator = "+-*".IndexOf(current) != -1;
                if (!isOperator)
                    continue; 

                /*
                 * 1 + 2
                 * part1 "1"
                 * part2 "2"
                 * '+' will not be counted by part1 or part2
                 */
                var part1 = input.Substring(0, i);
                var part2 = input.Substring(i + 1);  // bug fix, i + 1 instead of i

                var list1 = DiffWaysToCompute(part1);
                var list2 = DiffWaysToCompute(part2);

                foreach (var item1 in list1)
                {
                    foreach (var item2 in list2)
                    {
                        int calculated = 0;
                        if (current == '+')
                        {
                            calculated = item1 + item2;
                        }
                        else if (current == '-')
                        {
                            calculated = item1 - item2; 
                        }
                        else if (current == '*')
                        {
                            calculated = item1 * item2;
                        }

                        results.Add(calculated); 
                    }
                }                
            }

            map.Add(input, results); 

            return results;
        }
    }
}
