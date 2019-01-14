using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _973_K_closest_points_to_origin_III
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// 68/ 80 test case passed. Time limit exceeded
        /// </summary>
        /// <param name="points"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public int[][] KClosest(int[][] points, int K)
        {
            map.Clear();

            int rows = points.Length;

            for (int i = 0; i < rows; i++)
            {
                var current = points[i];
                int val = current[0] * current[0] + current[1] * current[1];

                bool adding = false;

                adding = i < K;
                if (i >= K)
                {
                    var maxValue = map.Last().Key;
                    if (val < maxValue)
                    {
                        popMax();
                        adding = true;
                    }
                }

                if (adding)
                {
                    add(val, current);
                }
            }

            var result = new int[K][];
            for (int i = 0; i < K; i++)
            {
                result[i] = new int[2];
            }

            var index = 0;
            foreach (var item in map)
            {
                var queue = item.Value;
                while (queue.Count > 0)
                {
                    var numbers = queue.Dequeue();
                    result[index][0] = numbers[0];
                    result[index][1] = numbers[1];

                    index++;
                }
            }

            return result;
        }

        public static SortedDictionary<int, Queue<int[]>> map = new SortedDictionary<int, Queue<int[]>>();

        private static void add(int val, int[] node)
        {
            if (!map.ContainsKey(val))
            {
                map.Add(val, new Queue<int[]>());
            }

            map[val].Enqueue(node);
        }

        private static int[] popMax()
        {
            int maxKey = map.Last().Key;
            var node = map[maxKey].Dequeue();

            if (map[maxKey].Count == 0)
            {
                map.Remove(maxKey);
            }

            return node;
        }
    }
}
