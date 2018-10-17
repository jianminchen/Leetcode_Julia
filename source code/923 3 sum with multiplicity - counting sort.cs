using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _923_3_sum_with_multiplicity_II
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int ThreeSumMulti(int[] numbers, int target)
        {
            if (numbers == null || numbers.Length == 0)
            {
                return 0;
            }

            const int Max = 101;
            var countSort = new long[Max]; // int -> long 
            for (int i = 0; i < numbers.Length; i++)
            {
                countSort[numbers[i]]++;
            }

            long SIZE = 1000 * 1000 * 1000 + 7;
            long ways = 0;            

            for (int first = 0; first < Max; first++)
            {
                var search = target - first;
                if (search < 2 * first)
                    break;

                var value1 = countSort[first];
                if (value1 == 0)
                    continue;

                for (int second = first; second <= search / 2 && second < Max; second++)
                {
                    var third = search - second;
                    if (third >= Max)
                        continue; // break -> fail test case

                    var value2 = countSort[second];
                    var value3 = countSort[third];

                    if (value2 == 0 || value3 == 0)
                    {
                        continue;
                    }

                    if (first == second && second == third)
                    {
                        ways += value1 * (value1 - 1) * (value1 - 2) / 3 / 2;                       
                    }
                    else if (first == second)
                    {
                        ways += (value2 * (value2 - 1) / 2) * value3;
                    }
                    else if (second == third)
                    {
                        ways += value1 * value2 * (value2 - 1) / 2;
                    }
                    else
                    {
                        ways += value1 * value2 * value3;
                    }

                    ways = ways % SIZE;
                }
            }

            return (int)ways;
        }
    }
}
