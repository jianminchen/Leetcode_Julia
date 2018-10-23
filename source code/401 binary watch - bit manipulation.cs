using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _401_binary_watch___Bit_manipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = ReadBinaryWatch(1); 
        }

        /// <summary>
        /// use bit manipulation
        /// idea is from 
        /// https://leetcode.com/problems/binary-watch/discuss/88465/Straight-forward-6-line-c%2B%2B-solution-no-need-to-explain
        /// Brute force, there are 12 * 60 options to choose, 0 to 11 for hours options, 
        /// 0 to 59 for minutes options. 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static IList<string> ReadBinaryWatch(int num)
        {
            var result = new List<string>();

            for (int h = 0; h < 12; h++)
            {
                for (int m = 0; m < 60; m++)
                {
                    // integer with 10 bit
                    var current = h << 6 | m;

                    var bitArray = new BitArray(new int[] { current });

                    if (getCount(bitArray) == num)
                    {
                        result.Add(h.ToString() + (m < 10 ? ":0" : ":") + m.ToString());
                    }
                }
            }

            return result;
        }

        public static int getCount(BitArray bits)
        {
            int count = 0;
            for (int i = 0; i < bits.Length; i++ )
            {
                if (bits[i])
                {
                    count++;
                }
            }

            return count; 
        }
    }
}
