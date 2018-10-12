using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _844_backspace_string_compare
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = BackspaceCompare("ab#c","ad#c"); 
        }

        /// <summary>
        /// use stack to compare to string, # backspace
        /// </summary>
        /// <param name="S"></param>
        /// <param name="T"></param>
        /// <returns></returns>
        public static bool BackspaceCompare(string S, string T)
        {
            if(S == null || T == null)
                return false;

            var s = applyBackspace(S);
            var t = applyBackspace(T);

            return s.CompareTo(t) == 0; 
        }

        private static string applyBackspace(string s)
        {
            if (s == null || s.Length == 0)
                return s;

            var stack = new Stack<char>();            

            foreach (var item in s)
            {
                var isBackSpace = item == '#';

                if (!isBackSpace)
                {
                    stack.Push(item);
                    continue;
                }                
                
                if (stack.Count > 0)
                {
                    stack.Pop();
                }                              
            }

            return new string(stack.ToArray()); 
        }
    }
}
