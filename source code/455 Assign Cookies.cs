using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _455_assign_cookies
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// sort both arrays first, 
        /// and then linear scan both array from left to right to find maximum numbers
        /// </summary>
        /// <param name="minimumSizes"></param>
        /// <param name="sizes"></param>
        /// <returns></returns>
        public int FindContentChildren(int[] minimumSizes, int[] sizes)
        {
            if (minimumSizes == null || sizes == null || minimumSizes.Length == 0 || sizes.Length == 0)
            {
                return 0; 
            }

            Array.Sort(minimumSizes);
            Array.Sort(sizes);

            var length1 = minimumSizes.Length;
            var length2 = sizes.Length;

            int index1 = 0;
            int index2 = 0;
            int count = 0; 
            while (index1 < length1 && index2 < length2)
            {
                if (minimumSizes[index1] <= sizes[index2])
                {
                    count++;
                    index1++;
                    index2++;
                }
                else
                {
                    index2++; 
                }
            }

            return count; 
        }
    }
}
