using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _961_N_repeated_element_in_the_array
{
    /// <summary>
    /// N-Repeated Element in Size 2N Array
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int RepeatedNTimes(int[] numbers)
        {
            var length = numbers.Length;

            var hashset = new HashSet<int>();

            for (int i = 0; i < length; i++)
            {
                var current = numbers[i];
                if (hashset.Contains(current))
                {
                    return current;

                }

                hashset.Add(current);
            }

            return -1;
        }
    }
}
