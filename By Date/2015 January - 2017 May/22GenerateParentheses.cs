using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
        }        
        
         static ArrayList list;

         public static ArrayList generateParenthesis(int n)
         {
             list = new ArrayList();
             generateParenthesis("", 0, 0, n);
             return list;
         }

         /**
          * Latest update: July 13, 2015 
          * http://yyeclipse.blogspot.ca/2013/01/leetcode-generate-parentheses.html
          */
         private static void generateParenthesis(String s, int left, int right, int n)
         {
             if (left == n && right == n)
             {
                 list.Add(s);
                 return;
             }

             /* julia comment: 
                1. the way to add ) will prevent "right > left"
              * 2. add ( freely if the total of it is less than n
              * 
              * */

             if (left < n)
                 generateParenthesis(s + "(", left + 1, right, n);
             if (right < left)
                 generateParenthesis(s + ")", left, right + 1, n);
         }
    }
}
