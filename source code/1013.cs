using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1013
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int NumPairsDivisibleBy60(int[] time)
        {
            var count = new int[60];
            var length = time.Length;

            for (int i = 0; i < length; i++)
            {
                var current = time[i] % 60;
                count[current]++;
            }

            var pairs = 0;
            for (int i = 0; i < 60; i++)
            {
                var current = i;
                var search = (60 - i) % 60;
                var equal = current == search;
                var number = count[current];
                var pair = count[search];
                if (!equal)
                {
                    pairs += number * pair;
                }
                else
                {
                    pairs += number * (number - 1);
                }
            }

            return pairs / 2;
        }
    }
}
