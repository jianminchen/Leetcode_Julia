using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _218_skyline_problem
{
    class Program
    {
        static void Main(string[] args)
        {
            var buildings = new int[3][];
            buildings[0] = new int[]{1, 4, 2};
            buildings[1] = new int[]{2, 5, 3};
            buildings[2] = new int[]{3, 6, 1};

            var result = GetSkyline(buildings); 

            // result[0] = new int[]{1, 2};
            // result[1] = new int[]{2, 3};
            // result[2] = new int[]{5, 1};
            // result[3] = new int[]{6, 0};
        }

        /// <summary>
        /// Oct. 26, 2020
        /// Two steps:
        /// 1. Go over the discussion post how to solve it using minimum heap
        /// 2. Sorting first, and then minimum heap
        /// 3. Study C# code using SortedSet
        /// </summary>
        /// <param name="buildings"></param>
        /// <returns></returns>
        public static IList<IList<int>> GetSkyline(int[][] buildings)
        {
            if (buildings == null || buildings.Length == 0 || buildings[0].Length == 0)
            {
                return new List<IList<int>>();
            }

            var rows = buildings.Length;
            var columns = buildings[0].Length;

            var heightList = new List<int[]>();
            var result = new List<IList<int>>();

            var map = new Dictionary<int, int>();

            for (int col = 0; col < columns; col++)
            {
                var start    = buildings[col][0];
                var end      = buildings[col][1];
                var heightNo = buildings[col][2];

                heightList.Add(new int[] { start, -heightNo });
                heightList.Add(new int[] { end,    heightNo });
            }

            // Sorting is challenging - Look up Google
            heightList.Sort((a, b) =>
            {
                if (a[0] != b[0])
                {
                    return a[0].CompareTo(b[0]);
                }

                return a[1].CompareTo(b[1]);
            });

            var sorted = new SortedSet<int>();

            sorted.Add(0);
            var previous = 0;

            foreach (var item in heightList)
            {
                var position = item[0];
                var height = item[1];

                if (height < 0)
                {
                    if (!map.ContainsKey(-height))
                    {
                        map.Add(-height, 0);
                    }

                    sorted.Add(-height);
                    map[-height]++;
                }
                else
                {
                    map[height]--;
                    if (map[height] <= 0)
                    {
                        sorted.Remove(height);
                    }
                }

                int current = sorted.Max;
                if (previous != current)
                {
                    var numbers = new int[] { position, current };
                    result.Add(numbers.ToList());
                    previous = current;
                }
            }

            return result;
        }
    }
}
