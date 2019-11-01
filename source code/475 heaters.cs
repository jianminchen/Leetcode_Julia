using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _475_heaters___binary_search
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = FindRadius(new int[]{1, 2, 3}, new int[]{2}); 
        }

        /// <summary>
        /// 475 heaters
        /// binary search review 
        /// https://docs.microsoft.com/en-us/dotnet/api/system.array.binarysearch?view=netframework-4.8
        /// If the Array does not contain the specified value, the method returns a negative integer. 
        /// You can apply the bitwise complement operator (~ in C#, Not in Visual Basic) to the 
        /// negative result to produce an index. If this index is one greater than the upper bound 
        /// of the array, there are no elements larger than value in the array. Otherwise, it is 
        /// the index of the first element that is larger than value.
        /// 
        /// Time complexity: maximum of values {nlogn, mlogm, nlogm}, n is length of houses, m is length of heaters
        /// </summary>
        /// <param name="houses"></param>
        /// <param name="heaters"></param>
        /// <returns></returns>
        public static int FindRadius(int[] houses, int[] heaters)
        {
            if (houses == null || houses.Length == 0 ||
                heaters == null || heaters.Length == 0)
            {
                return 0;
            }

            var minumumRadius = Int32.MinValue;

            Array.Sort(houses);
            Array.Sort(heaters); 

            foreach (var item in houses)
            {
                // For each house, find minimum distance to one of heaters
                var minimumValue = Int32.MaxValue;

                var index = Array.BinarySearch(heaters, item);

                var length = heaters.Length;

                if (index >= 0)  // should be >=, not > - caught by online judge
                {
                    minimumValue = 0;
                }
                else
                {
                    var firstLarger = ~index; // ~ complement operator
                    if (firstLarger >= heaters.Length)
                    {
                        minimumValue = Math.Abs(item - heaters[length - 1]);
                    }
                    else
                    {
                        minimumValue = Math.Abs(item - heaters[firstLarger]);
                        if (firstLarger - 1 >= 0)
                        {
                            minimumValue = Math.Min(Math.Abs(item - heaters[firstLarger - 1]), minimumValue); 
                        }                       
                    }
                }

                // From all houses, choose maximum one from the distance to heater.
                if (minimumValue > minumumRadius)
                {
                    minumumRadius = minimumValue;
                }
            }

            return minumumRadius;
        }
    }
}
