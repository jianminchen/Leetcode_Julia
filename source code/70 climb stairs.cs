using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _70_climb_stairs
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// 70 climb stairs
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairs(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            if (n == 1)
            {
                return 1;
            }
        
            var previous = 1; 
            var previousPrevious = 1; 
            var current = 0; 
        
            for(int i = 2; i <= n; i++)
            {
                current = previous + previousPrevious;
            
                // reset
                previousPrevious = previous;
                previous = current; 
            }
        
            return current;     
        }
    }
}
