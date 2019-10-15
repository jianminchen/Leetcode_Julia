using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1200_minimum_absolute_difference
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Leetcode 1200 minimum absolution difference
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public IList<IList<int>> MinimumAbsDifference(int[] numbers)
        {
            if (numbers == null || numbers.Length < 2)
                return new List<IList<int>>();

            var length = numbers.Length;
            Array.Sort(numbers);

            var minimums = new SortedSet<int>();
            var minimum = numbers[length - 1] - numbers[0];
            for (int i = 1; i < length; i++)
            {
                var diff = numbers[i] - numbers[i - 1];
                if (diff < minimum)
                {
                    minimum = diff;
                    minimums.Clear();
                    minimums.Add(i);
                }
                else if (diff == minimum)
                {
                    minimums.Add(i);
                }
            }

            var result = new List<IList<int>>();
            foreach (var item in minimums)
            {
                result.Add(new List<int>(new int[] { numbers[item - 1], numbers[item] }));
            }

            return result;
        }    
    }
}
