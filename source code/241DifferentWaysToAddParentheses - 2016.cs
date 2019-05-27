using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _241DifferentWaysToAddParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /*
         * Leetcode 241: 
         * Different ways to add parentheses
         * Given a string of numbers and operators, return all possible results from computing all 
         * the different possible ways to group numbers and operators. The valid operators are +, - and *.
         * 
         */
        public static int compute(int a, int b, char op)
        {
            switch (op)
            {
                case '+': return a + b;
                case '-': return a - b;
                case '*': return a * b; 
            }

            return 0;   // do not return anything meaningful
        }

        public static IList<int> diffWays_MissingMemorization(string s)
        {
            if (s==null)
                return null; 

            int n1 = 0;
            int n2 = s.Length;
            int i = 0;
            for (; i < s.Length && isDigit(s[i]); i++)
            {
                n1 = n1 * 10 + s[i] - '0'; 
            }

            IList<int> list = new List<int>();
            // if pure number, just return
            bool isPureNumber = i==n2;
            if (isPureNumber)
            {
                list.Add(n1);
                return list;
            }
            
            IList<int> lefts = new List<int>();
            IList<int> rights = new List<int>();

            lefts  = diffWays_MissingMemorization(s.Substring(0, i));
            rights = diffWays_MissingMemorization(s.Substring(i + 1, n2 - i));

            for (int j = 0; j < lefts.Count; j++)
                for (int k = 0; k < rights.Count; k++)
                {
                    int   a = lefts[j];
                    int   b = rights[k]; 
                    char op = s[i];
                    int res = compute(a, b, op); 
                    list.Add(res);
                }

            return list; 
        }

        public static bool isDigit(char c)
        {
            int no = c - '0';
            if (no >= 0 && no <= 9)
                return true;
            return false; 
        }

        public static string getKey(int start, int end)
        {
            return start.ToString() + "_" + end.ToString(); 
        }

        public static IList<int> diffWaysToCompute(string s)
        {
            return diffWaysToComputeWithMemo(ref s, 0, s.Length - 1); 
        }

        public static Hashtable memo = new Hashtable(); 
        /*
         * julia's comment: 
         * 1. 
         */
        public static IList<int> diffWaysToComputeWithMemo(ref string s, int start, int end)
        {
            string cache_key = getKey(start, end);

            if (memo.Contains(cache_key))
                return (IList<int>)memo[cache_key];

            int n1 = 0;
            int n2 = s.Length;
            int i = start;
            for (; i < end && isDigit(s[i]); i++)
            {
                n1 = n1 * 10 + s[i] - '0';
            }

            IList<int> list = new List<int>();

            // if pure number, just return
            bool isPureNumber = i == end;
            if (isPureNumber)
            {
                list.Add(n1);
                
                memo.Add(cache_key, list); 
                 
                return list;
            }
             
            IList<int> lefts = new List<int>();
            IList<int> rights = new List<int>();

            lefts  = diffWaysToComputeWithMemo(ref s, start, i-1);
            rights = diffWaysToComputeWithMemo(ref s, i+1,   end);

            for (int j = 0; j < lefts.Count; j++)
                for (int k = 0; k < rights.Count; k++)
                {
                    int   a = lefts[j];
                    int   b = rights[k];
                    char op = s[i];

                    int res = compute(a, b, op);
                    list.Add(res);
                }

            memo.Add(cache_key, list);  

            return list; 
        }
    }
}
