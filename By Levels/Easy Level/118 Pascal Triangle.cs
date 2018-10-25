using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_118_Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = Generate(5); 
        }

        /// <summary>
        /// The design is based on Leetcode 119 my practice using optimal solution. 
        /// All I have to do is to save all rows from the top row first. 
        /// </summary>
        /// <param name="numsRow"></param>
        /// <returns></returns>
        public static IList<IList<int>> Generate(int numsRow)             
        {
            var rows = new List<IList<int>>();

            var result = new int[numsRow ];
            result[0] = 1;

            rows.Add(new List<int>(new int[]{1}));

            for (int row = 1; row < numsRow; row++)
            {
                // go over each row
                for (int col = row; col >= 1; col--)
                {
                    result[col] += result[col - 1];
                }
                var currentNumbers = new int[row + 1];

                Array.Copy(result, 0, currentNumbers, 0, row + 1);
                rows.Add(currentNumbers);
            }

            return rows;
        }
    }
}
