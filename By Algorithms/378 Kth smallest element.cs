using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _738_kth_smallest_element
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Oct. 26, 2020
        /// study code
        /// https://leetcode.com/problems/kth-smallest-element-in-a-sorted-matrix/discuss/85202/C-version-by-SortedList
        /// This may not be an optimal solution, but it works. 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int KthSmallest(int[][] matrix, int k)
        {
            int result = 0;

            var rows    = matrix.Length;
            var columns = matrix[0].Length;

            var s = new SortedList<int, Tuple<int, int>>(new DuplicateKeyComparer<int>());

            for (int col = 0; col < columns; col++)
            {
                s.Add(matrix[col][0], new Tuple<int, int>(col, 0));
            }
            
            while (k > 0)
            {
                result = s.First().Key;
                int x = s.First().Value.Item1;
                var y = s.First().Value.Item2;

                s.RemoveAt(0);

                if (y < columns - 1)
                {   // go to next column 
                    s.Add(matrix[x][y + 1], new Tuple<int, int>(x, y + 1));
                }

                k--; 
            }

            return result;
        }
    }

    /// <summary>
    /// need to look up syntax 
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public class DuplicateKeyComparer<TKey> : IComparer<TKey> where TKey : IComparable
    {
        public int Compare(TKey x, TKey y)
        {
            int result = x.CompareTo(y);
            return result == 0 ? 1 : result;
        }
    }    
}
