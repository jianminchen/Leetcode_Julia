using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _947_remove_stones_Rank_176
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTestcase1();
        }

        public static void RunTestcase1()
        {
            var stones = new int[7][]{
                new int[]{3, 2},
                new int[]{0, 0},
                new int[]{3, 3},
                new int[]{2, 1},
                new int[]{2, 3},
                new int[]{2, 2},
                new int[]{0, 2}
            };

            var number = RemoveStones(stones); 
        }

        // [[3,3],[4,4],[1,4],[1,5],[2,3],[4,3],[2,4]]
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

        /// <summary>
        /// study code weekly contest 112
        /// Rank 176 
        /// https://leetcode.com/contest/weekly-contest-112/ranking/8/
        /// </summary>
        /// <param name="stones"></param>
        /// <returns></returns>
        public static int RemoveStones(int[][] stones)
        {
            var length = stones.Length;

            for (int i = 0; i < length; i++)
            {
                Parent[i] = i;              
            }           

            for (int i = 0; i < length; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (stones[i][0] == stones[j][0] || stones[i][1] == stones[j][1])
                    {
                        if (Parent[i] != Parent[j])
                        {
                            union(i, j);
                        }
                    }
                }
            }
            
            int number = 0;
            for (int i = 0; i < length; i++)
            {
                if(i == Parent[i])
                {
                    number++;
                }
            }

            return length - number; 
        }

        public static int[] Parent = new int[1005];
        public static int[] Rank   = new int[1005];

        /// <summary>
        /// path compression
        /// https://algs4.cs.princeton.edu/15uf/QuickUnionPathCompressionUF.java.html
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private static int getParent_Obsolete(int x)
        {           
            while (Parent[x] != x)
            {
                x = Parent[x];
            }
          
            return x; 
        }

        /// <summary>
        /// study code from 
        /// https://algs4.cs.princeton.edu/15uf/QuickUnionPathCompressionUF.java.html
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int getParent(int p)
        {
            int root = p;
            while (root != Parent[root])
            {
                root = Parent[root];
            }

            while (p != root)
            {
                int newp = Parent[p];
                Parent[p] = root;
                p = newp;
            }

            return root;
        }

        /// <summary>
        /// this function has a bug 
        /// var root1 = Parent[id1] -- should be -> var root1 = getParent(id1)
        /// In other words, I need to separate intermediate node from root node of tree.
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        private static void union_Buggy(int id1, int id2)
        {
            var root1 = Parent[id1];
            var root2 = Parent[id2];            

            Parent[root2] = root1;            
        }

        private static void union(int id1, int id2)
        {
            var root1 = getParent(id1);
            var root2 = getParent(id2);

            Parent[root2] = root1;
        }
    }
}
