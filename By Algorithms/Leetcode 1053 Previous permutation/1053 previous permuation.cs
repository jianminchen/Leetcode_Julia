using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1053_previous_premutations
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = PrevPermOpt1(new int[]{3, 2, 1});
        }

        public int[] PrevPermOpt1(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                return new int[0];
            }

            var length = numbers.Length;
            const int SIZE = 10000;
            var lastPos = new int[SIZE];  // 10^4, not 10
            for (int i = 0; i < SIZE; i++)
            {
                lastPos[i] = -1;
            }

            var swap = new int[length];
            for (int i = 0; i < length; i++)
            {
                swap[i] = numbers[i];
            }

            for (int i = length - 1; i >= 1; i--)
            {
                var current = numbers[i];
                var previous = numbers[i - 1];

                lastPos[current] = i;

                if (previous > current)
                {
                    for (int smaller = previous - 1; smaller >= 1; smaller--)
                    {
                        if (lastPos[smaller] != -1)
                        {
                            // swap two numbers
                            // i-1, largest[smaller]
                            var front = i - 1;
                            var back = lastPos[smaller];

                            swap[front] = smaller;
                            swap[back] = previous;

                            return swap;
                        }
                    }
                }
            }

            return swap;
        }
    }
}
