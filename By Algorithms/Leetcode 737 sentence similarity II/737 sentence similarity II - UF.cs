using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _737_sentence_similarity_II__UF
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Nov. 19, 2020
        /// 
        /// study code
        /// https://leetcode.com/problems/sentence-similarity-ii/solution/
        /// </summary>
        /// <param name="words1"></param>
        /// <param name="words2"></param>
        /// <param name="pairs"></param>
        /// <returns></returns>
        public bool AreSentencesSimilarTwo(string[] words1, string[] words2, IList<IList<string>> pairs) 
        {   
            var length1 = words1.Length;
            var length2 = words2.Length;
            var pLength = pairs.Count; 

            if (length1 != length2)
            {
                return false;
            }

            // index -> indexMap better name?
            var indexMap = new Dictionary<string, int>();

            int count = 0;

            var dsu = new DSU(2 * pLength);

            foreach (var pair in pairs) 
            {
                // go through two words in one pair 
                foreach (var p in pair)
                {
                    if (!indexMap.ContainsKey(p))
                    {
                        indexMap.Add(p, count++);
                    }
                }

                dsu.Union(indexMap[pair[0]], indexMap[pair[1]]);
            }

            for (int i = 0; i < length1; ++i) 
            {
                var w1 = words1[i];
                var w2 = words2[i];

                if (w1.CompareTo(w2) == 0)
                {
                    continue;
                }

                if (!indexMap.ContainsKey(w1) ||
                    !indexMap.ContainsKey(w2) ||
                    dsu.Find(indexMap[w1]) != dsu.Find(indexMap[w2]))
                {
                    return false;
                }
            }

            return true;        
        }

        /// <summary>
        /// Union Find class
        /// I should be able to write it in less than 10 minutes
        /// </summary>
        class DSU
        {
            private int[] parent;

            // Every node is it's parent
            public DSU(int N)
            {
                parent = new int[N];

                for (int i = 0; i < N; ++i)
                {
                    parent[i] = i;
                }
            }

            // if it is not root node, continue to find parent...
            // update all children's parent node to root node
            public int Find(int x)
            {
                if (parent[x] != x)
                {
                    parent[x] = Find(parent[x]);
                }

                return parent[x];
            }

            /// <summary>
            /// It is just to assign one's parent's parent to other node's parent. 
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            public void Union(int x, int y)
            {
                parent[Find(x)] = Find(y);
            }
        }
    }
}
