using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_to_expression_100
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = ParseExpression100("123456789");
        }

        /// <summary>
        /// Phone screen: 
        /// July 3, 2020
        /// 输入是”123456789”，可以在任意位置加上多个+或-的运算符，最后结果要是100。输出所有的可能组合。简单的dfs题。
        /// 比如”123-45-67+89 = 100”
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static IList<string> ParseExpression100(string digits)
        {
            if (digits == null)
            {
                return new List<string>(); 
            }

            int index = 0;
            var expressions = new List<string>();
            int value = 0;

            runDFS(digits, index, expressions, "", value);

            return expressions; 
        }

        /// <summary>
        /// Run DFS search algorithm
        /// "123456789"
        /// </summary>
        /// <param name="digits"></param>
        /// <param name="index"></param>
        /// <param name="expression"></param>
        /// <param name="value"></param>
        private static void runDFS(string digits, int index, List<string> expressions, string current, int value)
        {
            // base case 
            if(index == digits.Length)
            {
                if(value == 100)
                {
                    expressions.Add(current); 
                    return; 
                }

                return; 
            }

            // RUN DFS 
            var length = digits.Length; 
            for(int i = index; i < length; i++)
            {
                // current number is from index to i
                var number = Convert.ToInt32(digits.Substring(index, i - index + 1));
                // + or - 
                var addition = value + number;
                var minus    = value - number; 

                runDFS(digits, i + 1, expressions, current + " + "+ number.ToString(), addition);

                if (index > 0)
                {
                    runDFS(digits, i + 1, expressions, current + " - " + number.ToString(), minus);
                }
            }
        }
    }
}
