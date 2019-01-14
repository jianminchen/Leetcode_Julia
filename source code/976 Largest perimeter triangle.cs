using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _976_Largest_perimeter_triangle
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static int LargestPerimeter(int[] numbers)
        {
            Array.Sort(numbers);
            var length = numbers.Length;

            for (int i = 0; i < length; i++)
            {
                var lastOne = length - 1 - i;
                var nextToLast = lastOne - 1;
                var smallest = lastOne - 2;
                if (smallest < 0)
                {
                    break;
                }

                if (numbers[nextToLast] + numbers[smallest] > numbers[lastOne])
                {
                    return numbers[nextToLast] + numbers[smallest] + numbers[lastOne];
                }
            }

            return 0;
        }
    }
}
