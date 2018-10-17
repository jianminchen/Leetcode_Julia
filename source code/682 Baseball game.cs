using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_682_Baseball_game
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTestcase();
        }

        /// <summary>
        /// should be 27, my submission is 14
        /// The bug was found since the numbers are put back into stack in wrong order. 
        /// </summary>
        public static void RunTestcase()
        {
            CalPoints(new string[]{"5","-2","4","C","D","9","+","+"}); 
        }

        /// <summary>
        /// Integer
        /// + - last two points
        /// D - last point double
        /// C - last round is invalid and should be removed
        /// </summary>
        /// <param name="ops"></param>
        /// <returns></returns>
        public static int CalPoints(string[] ops)
        {
            if (ops == null || ops.Length == 0)
                return 0;
            
            var stack = new Stack<int>();

            foreach (var item in ops)
            {
                var isAdd    = item.CompareTo("+") == 0;
                var isDouble = item.CompareTo("D") == 0;
                var isCancel = item.CompareTo("C") == 0; 

                var isInteger = !(isAdd || isDouble || isCancel);
                if (isInteger)
                {
                    stack.Push(Convert.ToInt32(item)); 
                }
                else if (isAdd)
                {
                    if (stack.Count < 2)
                        return -1;

                    var number1 = stack.Pop();
                    var number2 = stack.Pop();
                    stack.Push(number2);  // last out, first in - caught by online judge
                    stack.Push(number1);
                    stack.Push(number1 + number2);
                }
                else if(isCancel)
                {
                    if (stack.Count < 1)
                        return -1;

                    stack.Pop(); 
                }
                else if (isDouble)
                {
                    var number = stack.Peek();
                    stack.Push(number * 2);
                }
            }

            return stack.ToArray().Sum();
        }
    }
}
