using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_119_pasal_triangle_II_optimal
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = GetRow(3); 
        }

        /// <summary>
        /// understand the design
        /// source code is based on 
        /// https://leetcode.com/problems/pascals-triangle-ii/discuss/38420/Here-is-my-brief-O(k)-solution
        /// August 21, 2018
        /// use one array and work on backward so that it is no need to 
        /// use two arrays - previous and current
        /// current array is based on previous array, consider last element in the current array first, 
        /// backward to the first one instead. 
        /// No need to copy previous array to current array -> same array, in place technique
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public static IList<int> GetRow(int rowIndex)
        {
             var result = new int[rowIndex + 1];
             result[0] = 1;

             for (int row = 1; row < rowIndex + 1; row++)
             {
                 // go over each row
                 for (int col = row; col >= 1; col--)
                 {
                     result[col] += result[col - 1];
                 }
             }

             return result;
        }
    }
}
