using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _967_Numbers_with_same_consecutive_differences
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int[] NumsSameConsecDiff(int N, int K)
        {
            // build a map 
            var map = new HashSet<int>[10];

            for (int i = 0; i < 10; i++)
            {
                map[i] = new HashSet<int>();

                int sum = i + K;
                if (sum < 10)
                    map[i].Add(sum);

                var diff = i - K;
                if (diff >= 0)
                    map[i].Add(diff);
            }

            // brute force the solution
            // 2 ^ 9 = 512
            var list = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                var sb = new StringBuilder();
                sb.Append((char)(i + '0'));
                recursiveAppend(N, K, 1, i, sb, map, list);
            }

            return list.ToArray();
        }

        private static void recursiveAppend(
          int N, int K, int step, int current, StringBuilder sb, HashSet<int>[] map, List<int> numbersFound)
        {
            if (step == N)
            {
                var number = sb.ToString();
                if (number[0] == '0' && N > 1)
                    return;

                var toInt = Convert.ToInt32(number);
                numbersFound.Add(toInt);

                return;
            }

            var options = map[current];
            foreach (var item in options)
            {
                var newSb = new StringBuilder();
                newSb.Append(sb.ToString());
                newSb.Append((char)(item + '0'));
                recursiveAppend(N, K, step + 1, item, newSb, map, numbersFound);
            }
        }
    }
}
