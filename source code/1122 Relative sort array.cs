using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1122_relative_sort_array
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Oct. 24, 2019
        /// 1122 Relative sort Array
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
        public int[] RelativeSortArray(int[] arr1, int[] arr2)
        {
            if (arr1 == null || arr1.Length == 0)
            {
                return new int[0];
            }

            var hashset = new HashSet<int>(arr2);

            var list = new List<int>();

            var map = new Dictionary<int, int>();
            var length = arr1.Length;

            for (int i = 0; i < length; i++)
            {
                var current = arr1[i];
                if (!hashset.Contains(current))
                {
                    list.Add(current);
                }
                else
                {
                    if (!map.ContainsKey(current))
                    {
                        map.Add(current, 0);
                    }

                    map[current]++;
                }
            }

            var relativedSorted = new List<int>();

            for (int i = 0; i < arr2.Length; i++)
            {
                var visit = arr2[i];
                var count = map[visit];

                for (int j = 0; j < count; j++)
                {
                    relativedSorted.Add(visit);
                }
            }

            list.Sort();
            foreach (var item in list)
            {
                relativedSorted.Add(item);
            }

            return relativedSorted.ToArray();
        }
    }
}
