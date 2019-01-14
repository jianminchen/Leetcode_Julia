using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _973_K_Cloest_points_on_origin
{
    class Program
    {
        static void Main(string[] args)
        {
        }

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
            var keys = dict.Keys.ToArray();
            Array.Sort(keys);

            foreach (var key in keys)
            {
                foreach (var item in dict[key])
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

                if (needStop)
                    break;
            }

            return result;
        }      
    }
}
