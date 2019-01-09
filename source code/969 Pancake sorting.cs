using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _969_Pancake_sorting
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static IList<int> PancakeSort(int[] numbers)
        {
            var list = new List<int>();
            var length = numbers.Length;

            findMaximumOne(numbers, length - 1, list);

            return list;
        }

        private static void findMaximumOne(int[] numbers, int lastOne, List<int> list)
        {
            if (lastOne <= 0)
                return;

            var maxIndex = 0;
            var maxValue = numbers[0];

            for (int i = 1; i <= lastOne; i++)
            {
                var current = numbers[i];
                if (current > maxValue)
                {
                    maxIndex = i;
                    maxValue = current;
                }
            }

            // reverse the first maxValue elements
            arrayReverse(numbers, 0, maxIndex);
            arrayReverse(numbers, 0, lastOne);

            // reverse the first lastOne elements
            if (maxIndex > 0)
                list.Add(maxIndex + 1);

            if (lastOne > 0)
                list.Add(lastOne + 1);

            findMaximumOne(numbers, lastOne - 1, list);
        }

        private static void arrayReverse(int[] numbers, int start, int end)
        {

            var startIndex = start;
            var endIndex = end;

            while (startIndex < endIndex)
            {
                var tmp = numbers[startIndex];
                numbers[startIndex] = numbers[endIndex];
                numbers[endIndex] = tmp;

                startIndex++;
                endIndex--;
            }
        }
    }
}
