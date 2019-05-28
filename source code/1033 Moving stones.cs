using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1033_moving_stones
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int[] NumMovesStones(int a, int b, int c)
        {
            // get min
            var numbers = new int[] { a, b, c };

            int x = numbers.Min();
            int z = numbers.Max();

            var hashSet = new HashSet<int>(numbers);
            hashSet.Remove(x);
            hashSet.Remove(z);
            int y = 0;
            foreach (var item in hashSet)
                y = item;

            if (z - x - 2 == 0)
            {
                return new int[] { 0, 0 };
            }

            int min = (y - x <= 2) || (z - y <= 2) ? 1 : 2;
            return new int[] { min, z - x - 2 };
        }
    }
}
