using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _973_K_Closest_points_to_origin_II
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// 68/80 test case passed, time limit exceeded
        /// </summary>
        /// <param name="points"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public int[][] KClosest(int[][] points, int K)
        {
            int rows = points.Length;

            var dict = new Dictionary<int, HashSet<int>>();

            for (int i = 0; i < rows; i++)
            {
                var value = points[i][0] * points[i][0] + points[i][1] * points[i][1];

                if (!dict.ContainsKey(value))
                {
                    dict[value] = new HashSet<int>();
                }

                dict[value].Add(i);
            }

            var result = new int[K][];
            for (int i = 0; i < K; i++)
            {
                result[i] = new int[2];
            }

            int index = 0;
            var needStop = false;
            for (int sum = 0; sum < 10000 * 10000; sum++) // this causes timeout?
            {
                if (dict.ContainsKey(sum))
                {
                    foreach (var item in dict[sum])
                    {
                        result[index][0] = points[item][0];
                        result[index][1] = points[item][1];
                        index++;
                        if (index == K)
                        {
                            needStop = true;
                            break;
                        }
                    }
                }

                if (needStop)
                    break;
            }

            return result;
        }      
    }
}
