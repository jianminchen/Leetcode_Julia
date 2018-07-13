using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _58LengthOfLastWord
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /*
         * Code Reference:
         * http://blog.csdn.net/kenden23/article/details/17280525
         * 
         * julia's comment:
         * 1. fixed 3 bugs, and then, passed online judge
         */
        public static int lengthOfLastWord(string s) {
            if (s == null || s.Length == 0)   // 1. bug fix: add base case 
                return 0; 

            int n = s.Length - 1;  
  
            while (n>=0 && s[n] == ' ') n--;   // 2. add n>=0, bug fix: index out of range 
  
            int i = 0;  
            for (; n>=0 && s[n] != ' '; n--, i++);  // 3. add n>=0, bug fix: index out of range
  
            return i;  
        } 

    
    
    }
}
