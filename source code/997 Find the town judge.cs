using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _997_Find_the_town_judge
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// code written in the weekly contest 125
        /// </summary>
        /// <param name="N"></param>
        /// <param name="trust"></param>
        /// <returns></returns>
        public int FindJudge(int N, int[][] trust)
        {
            if (N == 1 && (trust == null || trust.Length == 0 || trust[0].Length == 0))
                return 1;

            if (trust == null || trust.Length == 0)
                return -1;

            var rows = trust.Length;
            var columns = trust[0].Length;

            var townJudge = new HashSet<int>[N + 1];
            for (int i = 1; i < N + 1; i++)
                townJudge[i] = new HashSet<int>();

            var notTownJudge = new HashSet<int>();

            for (int row = 0; row < rows; row++)
            {
                var A = trust[row][0];
                var B = trust[row][1];

                townJudge[A].Clear();

                notTownJudge.Add(A);

                if (!notTownJudge.Contains(B))
                {
                    townJudge[B].Add(A);
                }
            }

            for (int i = 1; i < N + 1; i++)
            {
                if (townJudge[i].Count == N - 1)
                    return i;
            }

            return -1;
        }
    }
}
