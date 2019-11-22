using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _69Sqrt_x_
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /*
         * source code from blog:
         * http://yucoding.blogspot.ca/2013/03/leetcode-question-102-sqrtx.html
         * 
         * comment from the above blog:
         *  One thing you need to consider is the length of the input, since taking 
         *  the mid of a big value and computing its square may overflow the int type.
            We can use "long long" , which have a max value 2^63-1.
            The max of an int is 2^15-1
            The max of a long is 2^31-1
         * 
         * julia's comment:
         * 1. online judge passed
         * 2. thought process:
         *    using binary search to speed up, time complexity is O(lgn), and space is O(1)
         *    
         */
        public static int sqrt(int x) {
            
            long  high = x;
            long  low = 0;

            if (x<=0) 
                return 0;            

            if (x==1) 
                return 1;

            while (high-low >1){
                long  mid = low + (high-low)/2;
                
                if (mid * mid <= x){
                    low = mid;
                }
                else {
                    high = mid;
                }
            }

            return (int)low;
        }


    }
}
