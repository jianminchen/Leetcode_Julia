using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_849_maximum_distance_to_closest_person
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// scan the array once from left to right, and then find start/ end positon of 0. 
        /// find current minimum length to 1. 
        /// </summary>
        /// <param name="seats"></param>
        /// <returns></returns>
        public int MaxDistToClosest(int[] seats)
        {
            if (seats == null)
            {
                return 0; 
            }

            int start = 0;
            int end = 0;
            int maxDistance = 0;
            var length = seats.Length;

            for (int i = 0; i < length; i++)
            {
                var current = seats[i];
                var isZero  = current == 0;
                var isStart = isZero && (i == 0 || seats[i - 1] == 1);
                var isEnd   = isZero && (i == length - 1 || seats[i + 1] == 1);

                if (isStart)
                {
                    start = i;
                }

                if (isEnd)
                {
                    end = i;
                    var distanceToOne = 0;
                    var hasLeftOne  = start != 0;
                    var hasRightOne = end != length - 1; 

                    if (hasLeftOne && hasRightOne)
                    {
                        distanceToOne = (end - start)/ 2 + 1;
                    }
                    else
                    {
                        distanceToOne = end - start + 1; 
                    }

                    maxDistance = distanceToOne > maxDistance ? distanceToOne : maxDistance; 
                }
            }

            return maxDistance; 
        }
    }
}
