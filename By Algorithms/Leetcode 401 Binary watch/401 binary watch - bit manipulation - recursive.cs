using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _401_binary_watch___backtracking_II
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// source code is based on the idea from 
        /// https://leetcode.com/problems/binary-watch/discuss/88582/Concise-Backtracking
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public IList<string> ReadBinaryWatch(int num)
        {
            var result = new List<string>();

            goOverAllBits(result, 0, 0, 0, num);
            return result;
        }

        /// <summary>
        /// base case is well defined: 
        /// 10 bits in binary number for hour and minutes.
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <param name="time"></param>
        /// <param name="startBit"></param>
        /// <param name="count"></param>
        /// <param name="num"></param>
        private static void goOverAllBits(List<String> result, int time, int startBit, int count, int num)
        {
            // base case
            if (startBit == 10 || count == num)
            {
                if (count == num && isValid(time))
                {
                    result.Add(print(time));
                }

                return;
            }

            for (int i = startBit; i < 10; i++)
            {   //                    turn on ith bit
                goOverAllBits(result, time | (1 << i), i + 1, count + 1, num);
            }
        }

        private static bool isValid(int time)
        {
            //   lowest six bits           highest 4 bits
            return (time & 0x3f) < 60 && ((time >> 6) & 0xf) < 12;
        }

        private static string print(int time)
        {
            var hour = (time >> 6) & 0xf;
            var minutes = time & 0x3f;

            var timeFormatted = hour + ":" + minutes;
            if (minutes < 10)
            {
                timeFormatted = hour + ":0" + minutes;
            }

            return timeFormatted;
        }
    }
}
