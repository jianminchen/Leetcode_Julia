using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Union_Find_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// 2019-March 26
        /// Union API is updated. 
        /// 
        /// May 28, 2018
        /// 
        /// Julia likes to write her own union find algorithm
        /// The coach spent almost 100 minutes in the mock interview to show her 
        /// the solution, and also he wrote two functions called 
        /// QuickFind() and Union()
        /// 
        /// source code reference used:
        /// https://gist.github.com/jianminchen/cb889def70be4563581113daa8a8fb2a
        /// </summary>
        internal class QuickUnion
        {
            private int[] parent { get; set; }
            private int count { get; set; }

            public QuickUnion(int number)
            {
                if (number <= 0)
                {
                    return;
                }

                count = number;
                parent = new int[number];

                for (int i = 0; i < number; i++)
                {
                    parent[i] = i;
                }
            }

            public int GetCount()
            {
                return count;
            }

            /// <summary>
            /// Find group id given the node value
            /// </summary>
            /// <returns></returns>
            public int QuickFind(int search)
            {
                if (search < 0)
                {
                    return -1;
                }

                if (search == parent[search])
                {
                    return search;
                }

                return QuickFind(parent[search]);
            }

            /// <summary>
            /// Reset all parent node's to its original ancestor
            /// path compression - all node's parent will be reset to its ancestor
            /// </summary>
            /// <returns></returns>
            public int QuickFindAndPathCompression(int search)
            {
                if (search == parent[search])
                {
                    return search;
                }

                int root = QuickFindAndPathCompression(parent[search]);

                parent[search] = root;

                return root;
            }

            /// <summary>
            /// code review March 26, 2019
            /// </summary>
            /// <param name="p"></param>
            /// <param name="q"></param>
            public void Union(int p, int q)
            {
                //int pRoot = QuickFind(p);
                //int qRoot = QuickFind(q);

                int pRoot = QuickFindAndPathCompression(p);
                int qRoot = QuickFindAndPathCompression(q);

                if (pRoot == qRoot)
                {
                    return;
                }

                // set one tree to another tree's subtree
                parent[pRoot] = qRoot;

                // update count of groups
                count--;
            }

            /// <summary>
            /// code review March 6, 2019
            /// </summary>
            /// <param name="p"></param>
            /// <param name="q"></param>
            /// <returns></returns>
            public bool Connected(int p, int q)
            {
                return QuickFind(p) == QuickFind(q);
            }
        }
    }
}
