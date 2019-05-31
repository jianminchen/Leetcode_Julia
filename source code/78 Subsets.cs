using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace power_set
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = Subsets(new int[] { 1, 2, 3 });
        }

        /// <summary>
        /// May 31, 2019
        /// leetcode 78: Subsets
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<IList<int>> Subsets(int[] nums)
        {
            if (nums == null)
                return new List<IList<int>>();

            var length = nums.Length;
            var powerSet = new List<IList<int>>(); 

            for (int i = 0; i < length; i++)
            {
                var current = nums[i];

                if (i == 0)
                {
                    var subsets = new List<int>();
                    subsets.Add(current);

                    powerSet.Add(new List<int>());
                    powerSet.Add(subsets);
                }
                else
                {
                    var count = powerSet.Count;

                    for (int j = 0; j < count; j++)
                    {
                        var list = new List<int>(powerSet[j]);
                        list.Add(current);

                        powerSet.Add(list);
                    }
                }
            }

            return powerSet;
        }
    }
}
