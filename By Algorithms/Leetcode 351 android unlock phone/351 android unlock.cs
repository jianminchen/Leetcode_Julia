using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _351_android_unlock
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        private int[][] jumps;
        private bool[] visited;

        /// <summary>
        /// Nov. 19 2020
        /// study code
        /// https://leetcode.com/problems/android-unlock-patterns/discuss/82464/Simple-and-concise-Java-solution-in-69ms
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumberOfPatterns(int m, int n)
        {
            const int SIZE = 10;
            jumps = new int[SIZE][];
            for (int i = 0; i < SIZE; i++)
            {
                jumps[i] = new int[SIZE];
            }

            jumps[1][3] = 2;
            jumps[3][1] = 2;

            jumps[4][6] = 5;
            jumps[6][4] = 5;

            jumps[7][9] = 8;
            jumps[9][7] = 8;

            jumps[1][7] = 4;
            jumps[7][1] = 4;

            jumps[2][8] = 5;
            jumps[8][2] = 5;

            jumps[3][9] = 6;
            jumps[9][3] = 6;

            jumps[1][9] = 5;
            jumps[9][1] = 5;
            jumps[3][7] = 5;
            jumps[7][3] = 5;

            visited = new bool[10];

            int count = 0;
            count += runDFS(1, 1, 0, m, n) * 4; // 1, 3, 7, 9 are symmetrical
            count += runDFS(2, 1, 0, m, n) * 4; // 2, 4, 6, 8 are symmetrical
            count += runDFS(5, 1, 0, m, n);
            return count;
        }

        private int runDFS(int num, int len, int count, int m, int n)
        {
            if (len >= m)
            {
                count++; // only count if moves are larger than m
            }

            len++;

            if (len > n)
            {
                return count;
            }

            visited[num] = true;

            for (int next = 1; next <= 9; next++)
            {
                int jump = jumps[num][next];

                // For example, num
                if (!visited[next] && (jump == 0 || visited[jump]))
                {
                    count = runDFS(next, len, count, m, n);
                }
            }

            visited[num] = false; // backtracking
            return count;
        }
    }
}
