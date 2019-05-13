using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1042_flower_plant_with_no_adjacent
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        /// <summary>
        /// code review on May 13, 2019
        /// code is written on weekly contest 136
        /// </summary>
        /// <param name="N"></param>
        /// <param name="paths"></param>
        /// <returns></returns>
        public int[] GardenNoAdj(int N, int[][] paths)
        {
            var onePathSet = new HashSet<int>();
            var twoPathSet = new HashSet<int>();
            var threePathSet = new HashSet<int>();

            var rows = paths.Length;
            var dict = new Dictionary<int, HashSet<int>>();

            for (int i = 0; i < rows; i++)
            {
                var garden1 = paths[i][0];
                var garden2 = paths[i][1];

                if (!dict.ContainsKey(garden1))
                {
                    dict.Add(garden1, new HashSet<int>());
                }

                if (!dict.ContainsKey(garden2))
                {
                    dict.Add(garden2, new HashSet<int>());
                }

                dict[garden1].Add(garden2);
                dict[garden2].Add(garden1);
            }

            foreach (var key in dict.Keys)
            {
                var count = dict[key].Count;
                if (count == 1)
                {
                    onePathSet.Add(key);
                }
                else if (count == 2)
                {
                    twoPathSet.Add(key);
                }
                else if (count == 3)
                {
                    threePathSet.Add(key);
                }
            }

            var flowers = new int[N];

            workOnKeyPaths(threePathSet, flowers, dict);
            workOnKeyPaths(twoPathSet, flowers, dict);
            workOnKeyPaths(onePathSet, flowers, dict);

            for (int i = 0; i < N; i++)
            {
                if (flowers[i] == 0)
                    flowers[i] = 1;
            }

            return flowers;
        }

        private static void workOnKeyPaths(
            HashSet<int> specificSet,
            int[] flowers,
            Dictionary<int, HashSet<int>> dict)
        {
            foreach (var key in specificSet)
            {
                var notUsed = new HashSet<int>(new int[] { 1, 2, 3, 4 });
                if (flowers[key - 1] != 0)
                {
                    notUsed.Remove(flowers[key - 1]);
                }

                foreach (var value in dict[key])
                {
                    if (flowers[value - 1] != 0)
                    {
                        notUsed.Remove(flowers[value - 1]);
                    }
                }

                var numbers = notUsed.ToArray();
                int index = 0;
                if (flowers[key - 1] == 0)
                {
                    flowers[key - 1] = numbers[index++];
                }
                /*
                foreach (var value in dict[key])
                {
                    if (flowers[value - 1] == 0)
                    {
                        flowers[value - 1] = numbers[index++];
                    }
                } */
            }
        }
    }
}
