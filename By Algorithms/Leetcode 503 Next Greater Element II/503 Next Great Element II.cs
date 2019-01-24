using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _503_next_great_element_II___case_study
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// https://leetcode.com/problems/next-greater-element-ii/discuss/98262/Typical-ways-to-solve-circular-array-problems.-Java-solution.
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public int[] NextGreaterElements(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
                return new int[0];

            int max = numbers.Max();            
        
            int n = numbers.Length;

            var result = new int[n];
            var doubleSize = new int[n * 2];
        
            for (int i = 0; i < n * 2; i++) {
                doubleSize[i] = numbers[i % n]; // n -> 0, n+1->1, ...
            }
        
            // all numbers in the array should have next larger element except largest one.
            for (int i = 0; i < n; i++) 
            {
                result[i] = -1;
                
                if (numbers[i] == max)
                {
                    continue;
                }
            
                for (int j = i + 1; j < n * 2; j++) 
                {
                    if (doubleSize[j] > numbers[i]) 
                    {
                        result[i] = doubleSize[j];
                        break;
                    }
                }
            }
        
            return result;
        }
    }
}
