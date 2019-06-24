using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _947_ranking_117
{
    class Program
    {        
        public static void RunTestcase2()
        {
            var stones = new int[7][]{
                new int[]{3, 3},
                new int[]{4, 4},
                new int[]{1, 4},
                new int[]{1, 5},
                new int[]{2, 3},
                new int[]{4, 3},
                new int[]{2, 4}
            };

            var number = RemoveStones(stones);
        }

        static void Main(string[] args)
        {
            RunTestcase2(); 
        }

        /// <summary>
        /// https://leetcode.com/contest/weekly-contest-112/ranking/5/
        /// rank 117
        /// yajingleo
        /// 
        /// </summary>
        /// <param name="stones"></param>
        /// <returns></returns>
        public static int RemoveStones(int[][] stones)
        {
            var length = stones.Length;
            var root = new int[length];
            for (int i = 0; i < length; i++)
            {
                root[i] = i;
            }

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (stones[i][0] == stones[j][0] || stones[i][1] == stones[j][1])
                    {
                        var root1 = getRoot(root, i);
                        var root2 = getRoot(root, j);

                        // given constraint on the root, smaller index will be the root. 
                        root[root2] = root1;
                    }
                }
            }

            int result = length;
            for(int i = 0; i < length; i++)
            {
                if(root[i] == i)
                {
                    result--; 
                }
            }

            return result; 
        }

        /// <summary>
        /// code review April 4, 2019
        /// It is better to use while loop instead of recursive function
        /// </summary>
        /// <param name="root"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        private static int getRoot(int[] root, int i)
        {
            while (root[i] != i)
            {
                i = root[i];
            }

            return i; 
        }
    }
}
