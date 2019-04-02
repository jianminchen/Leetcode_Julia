using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _947_remove_stones
{
    class Program
    {
        static void Main(string[] args)
        {

            var stones = new int[6][]{
                new int[]{0,0},
                new int[]{0,1},
                new int[]{1,0},
                new int[]{1,2},
                new int[]{2,1},
                new int[]{2,2}
            };

            var result = RemoveStones(stones);
        }

        private static List<int> father;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private static int getFather(int search)        
        {
            if (search == father[search])
            {
                return search;
            }

            int root = getFather(father[search]);

            father[search] = root;

            return root;                            
        }

        /// <summary>
        /// Leetcode 947
        /// https://leetcode.com/contest/weekly-contest-112/ranking/
        /// ranking 8
        /// Windsfantasy6
        /// </summary>
        /// <param name="stones"></param>
        /// <returns></returns>
        public static int RemoveStones(int[][] stones)
        {
            var rows = stones.Length;

            father = new List<int>();
            for (int i = 0; i < rows; i++)
            {
                father.Add(i);
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = i + 1; j < rows; j++)
                {
                    if (stones[i][0] == stones[j][0] || stones[i][1] == stones[j][1])
                    {
                        int fi = getFather(i);
                        int fj = getFather(j);
                        father[fi] = fj;
                    }
                }
            }        

            int result = 0;

            for (int i = 0; i < rows; i++)
            {
                int fi = getFather(i);
                if (i == fi)
                {
                    result++;
                }
            }

            return result; 
        }
    }
}
