using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_119_Pascal_Triangle_II___bottom_up
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = GetRow(3); 
        }

        /// <summary>
        /// bottom up - no redundant calculation
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public static IList<int> GetRow(int rowIndex)
        {
            var result = new List<int>();

            if (rowIndex < 0)
            {
                return result;
            }

            if (rowIndex == 0)
            {
                result.Add(1);
                return result;
            }

            int index = 0;
            var previous = new int[] { 1 };
            var current  = new int[2];                       
            
            while(index < rowIndex)
            {
                var pLength = previous.Length;
                var cLength = current.Length;

                for (int i = 0; i < cLength; i++)
                {                                      
                    if (i == 0) // first one
                    {
                        current[0] = previous[0];
                    }
                    else if (i == cLength - 1) // last one
                    {
                        current[cLength - 1] = previous[pLength - 1];
                    }
                    else
                    {
                        current[i] = previous[i - 1] + previous[i];
                    }
                }

                index++; 
                previous = current;
                current  = new int[index + 2];
            }

            return new List<int>(previous);
        }
    }
}
