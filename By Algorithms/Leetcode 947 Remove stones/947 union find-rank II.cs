using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _947_remove_stones___union_join
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

        public static int[] Parent;        
        public static int[] Rank;       

        /// <summary>
        /// https://leetcode.com/contest/weekly-contest-112/ranking
        /// rank No. 12 tylerwang
        /// 
        /// </summary>
        /// <param name="stones"></param>
        /// <returns></returns>
        public static int RemoveStones(int[][] stones)
        {
            var length = stones.Length;

            Parent = new int[length];            
            Rank   = new int[length];

            for (int i = 0; i < length; i++)
            {
                Parent[i] = i;                
            }            

            for (int i = 0; i < length; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (stones[i][0] == stones[j][0] ||
                        stones[i][1] == stones[j][1])
                    {
                        union(i, j);            
                    }
                }
            }

            // count of disjoint sets
            var answer = new HashSet<int>();
            for (int i = 0; i < length; i++)
            {
                answer.Add(find(i));
            }

            return length - answer.Count; 
        }

        /// <summary>
        /// code review:
        /// union and rank is simplified, and this version of code is easy to follow
        /// Rule 1: Parent node has higher rank compared to its child node
        /// union is to connect two root nodes of tree, not input arguments i and j.  
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private static void union(int id1, int id2)
        {
            id1 = find(id1); // To avoid the bug to confuse id1 and find(id1), change id1's value
            id2 = find(id2);

            if (id1 == id2)
            {
                return;
            }

            var id2IsParent = Rank[id1] <= Rank[id2];

            if (id2IsParent)
            {
                Parent[id1] = id2;

                if (Rank[id1] == Rank[id2])
                {
                    Rank[id2]++;
                }
            }
            else
            {
                Parent[id2] = id1; 
            }            
        }

        /// <summary>
        /// code review:
        /// find is to search tree structure and find the root of tree the node stays
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private static int find(int id)
        {
            if (id != Parent[id])
            {
                Parent[id] = find(Parent[id]);
            }

            return Parent[id];
        }
    }
}
