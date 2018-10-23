using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _401_binary_watch___recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = ReadBinaryWatch(2); 
        }        
        
        public static int[] Watch = {1,2,4,8,1,2,4,8,16,32};
	
        /// <summary>
        /// idea from 
        /// https://leetcode.com/problems/binary-watch/discuss/88609/3m-Java-recursion-solution-easy-to-understand
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static IList<string> ReadBinaryWatch(int num) {
            var list = new List<string>();
            if (num >= 0)
            {
                readRecursion(num, 0, list, 0, 0);
            }

            return list;
        }

        /// <summary>
        /// think about recursively
        /// How to make sure there is no deadloop here. 
        /// </summary>
        /// <param name="num"></param>
        /// <param name="start"></param>
        /// <param name="list"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        private static void readRecursion(int num, int start, List<String> list, int hour, int minute)
        {
            // base case 
    	    if(num <= 0) 
            {
    	        if(hour < 12 && minute < 60)
                {
                    if (minute < 10)
                    {
                        list.Add(hour + ":0" + minute);
                    }
                    else
                    {
                        list.Add(hour + ":" + minute);
                    }
    	        }

                return; 
    	    }

            for (int i = start; i < Watch.Length; i++)
            {
                if (i < 4)
                {
                    readRecursion(num - 1, i + 1, list, hour + Watch[i], minute);
                }
                else
                {
                    readRecursion(num - 1, i + 1, list, hour, minute + Watch[i]);
                }
	        }            
        }
    }
}
