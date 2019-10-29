using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1238_circular_permutation
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// 1238 Circular Permutation in Binary Representation
        /// The idea is similar to Sudoku solver; Each step using DFS to search all options. 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public IList<int> CircularPermutation(int n, int start)
        {
            var result = new List<int>();

            var set = new HashSet<int>();
            result.Add(start);
            set.Add(start);

            runDFS(n, set, result, start);
            return result; 
        }

        /// <summary>
        /// similar to Sudoku solver
        /// backtracking 
        /// DFS path - mark visited
        /// </summary>
        /// <param name="n"></param>
        /// <param name="hashSet"></param>
        /// <param name="result"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        private static bool runDFS(int n, HashSet<int> hashSet, IList<int> result, int start)
        {
            if (hashSet.Count == (int)Math.Pow(2, n))
            {
                int x = result[result.Count - 1] ^ start; // XOR operator - first and last are different
                return (x & (x - 1)) == 0; 
            }

            var length = result.Count;
            int last = result[length - 1];

            for (int i = 0; i < 16; i++)
            {
                int next = last ^ (1 << i); // XOR operator - change ith bit 
                if (next <= (Math.Pow(2, n) - 1) && !hashSet.Contains(next))
                {
                    hashSet.Add(next);
                    result.Add(next); 

                    if(runDFS(n, hashSet, result, start))
                    {
                        return true; 
                    }

                    hashSet.Remove(next);
                    result.RemoveAt(result.Count - 1);
                }
            }

            return false; 
        }
    }
}
