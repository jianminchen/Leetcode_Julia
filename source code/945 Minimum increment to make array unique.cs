using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _945_Minimum_increment_to_make_array_unique
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int MinIncrementForUnique(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
                return 0;

            Array.Sort(numbers);

            var length = numbers.Length;

            var sum = numbers.Sum();

            var newNumber = new int[length];
            newNumber[0] = numbers[0];

            for (int i = 1; i < length; i++)
            {
                var current = numbers[i];

                newNumber[i] = Math.Max(current, newNumber[i - 1] + 1);
            }

            return newNumber.Sum() - sum;
        }
    }
}
