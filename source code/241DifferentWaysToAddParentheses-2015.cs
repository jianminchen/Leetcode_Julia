using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _241DifferentWaysToAddParentheses_B
{
    class test2
    {
        /*
         * Leetcode: 241
         * different ways to add parentheses 
         * 
            Input: "2-1-1".

            ((2-1)-1) = 0
            (2-(1-1)) = 2
            Output: [0, 2]
         
            Input: "2*3-4*5"

            (2*(3-(4*5))) = -34
            ((2*3)-(4*5)) = -14
            ((2*(3-4))*5) = -10
            (2*((3-4)*5)) = -10
            (((2*3)-4)*5) = 10
            Output: [-34, -14, -10, -10, 10]
         */
        static void Main(string[] args)
        {
            string test = "2-1-1";
            IList<int> list = DiffWaysToCompute(test);

            string test2 = "2*3-4*5";
            IList<int> list2 = DiffWaysToCompute(test2);
        }

        /*
         * The source code is from the blog in Java:
         * http://blog.csdn.net/sbitswc/article/details/48546421
         * 
         * Julia's comment on Nov. 6, 2015: 
         * 1. convert it to C#
         * 2. make some comment on the idea.
         * A. bug fix 001 - cannot fall through the case, so add "break;" 
         * B. the code has redundant calls, not using memorization
         * C. The code puts everything in one function. 
         * D. check out C# List<> vs. ArrayList, and understand using List forcing type checking
         *    in compiling time save debugging time. 
         *    Read the article:
         *    http://stackoverflow.com/questions/2309694/arraylist-vs-list-in-c-sharp
         *    My favorite reading:
         *    List<T> is a generic class. It supports storing values of a specific type without 
         *    casting to or from object (which would have incurred boxing/unboxing overhead when 
         *    T is a value type in the ArrayList case). ArrayList simply stores object references.
         * E. estimate the complexity of time, 3 loops, 
         *    the first loop, i - maximum n, 
         *    second loop, lefts - maximum length of array - ?
         * F. What to choose, int, or INT16, or any integer type? 
         *   int - System.Int32 - signed 32 bit integer 
         *   Int16 
         *   
         * online judge:
         *  24 / 24 test cases passed.
            Status: Accepted
            Runtime: 468 ms
         */
        public static IList<int> DiffWaysToCompute(String input) {  
            IList<int> res = new List<int>();  

            for(int i=0; i<input.Length; i++){  
                char c = input[i];  
                if('+' == c || '-' == c || '*' == c) {  
                    String lv = input.Substring(0, i);  
                    String rv = input.Substring(i+1); 
 
                    IList<int> lefts   = DiffWaysToCompute(lv);  
                    IList<int> rights  = DiffWaysToCompute(rv);  

                    foreach(int j in lefts) {  
                        foreach(int k in rights){  
                            int temp = 0;  
                            switch(c){  
                                case'+':   
                                    temp = j + k;  
                                    break;  
                                case'-':   
                                    temp = j - k;  
                                    break;  
                                case'*': temp = j * k;
                                    break;   // bug fix 001 
                            }  

                            res.Add(Convert.ToInt16(temp));  
                        }  
                    }  
                }  
            }  

            if(res.Count == 0){  
                    res.Add(Convert.ToInt16(input));  
                } 
 
            return res;  
        }  

    }
}
