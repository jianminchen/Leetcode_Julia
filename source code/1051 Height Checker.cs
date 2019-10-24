using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1051_height_checker
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Oct. 24, 2019
        /// 1051 Height checker
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        public int HeightChecker(int[] heights)
        {
            var length = heights.Length;

            var arrayCopy = new int[length];
            for (int i = 0; i < length; i++)
                arrayCopy[i] = heights[i];

            Array.Sort(arrayCopy);

            int count = 0;
            for (int i = 0; i < length; i++)
            {
                if (arrayCopy[i] != heights[i])
                {
                    count++;
                }
            }

            return count;
        }
    }
}
