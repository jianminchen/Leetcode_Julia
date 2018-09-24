using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _868_binary_gap
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = BinaryGap(22);
            var result1 = BinaryGap(5);
            var result2 = BinaryGap(6);
            var result3 = BinaryGap(8); 
        }

        /// <summary>
        /// need to get binary expression first, and then track the distance
        /// between two consecutive's 1's distance
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public static int BinaryGap(int N)
        {           
            int index = 0;
            int maxLength = 0;

            int previousBitOne = -1; 

            while (N >= 1)  
            {                
                var currentBit = N & 1;

                if (currentBit == 1)
                {
                    if (previousBitOne == -1)
                    {
                        previousBitOne = index; 
                    }
                    else
                    {                        
                        var current = index - previousBitOne;
                        previousBitOne = index;
                        maxLength = current > maxLength ? current : maxLength;
                    }
                }                

                N = N >> 1;
                index++;
            }

            return maxLength;
        }
    }
}
