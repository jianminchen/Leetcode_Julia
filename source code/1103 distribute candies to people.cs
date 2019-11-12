using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1103_distribute_candies_to_people
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// 1103 distribute candies to people
        /// </summary>
        /// <param name="candies"></param>
        /// <param name="num_people"></param>
        /// <returns></returns>
        public int[] DistributeCandies(int candies, int num_people)
        {
            if (candies < 0 || num_people <= 0)
                return new int[0];

            var sum = new int[num_people];

            int left = candies;
            int index = 0;
            int count = 1;

            while (left > 0 && index < num_people)
            {
                if (left >= count)
                {
                    sum[index] += count;
                    left -= count;
                }
                else
                {
                    sum[index] += left;
                    break;
                }

                // next iteration
                count++;
                index = (index + 1) % num_people;
            }

            return sum;
        }
    }
}
