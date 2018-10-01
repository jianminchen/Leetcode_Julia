using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _915.Partition_Array_into_Disjoint_Intervals
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int PartitionDisjoint(int[] A)
        {
            if (A == null || A.Length < 2)
                return -1;

            var length = A.Length;

            var maxArray = new int[length];
            var max = int.MinValue;
            for (int i = 0; i < length; i++)
            {
                var current = A[i];
                maxArray[i] = max;
                if (current > max)
                {
                    max = current;
                    maxArray[i] = max;
                }
            }

            var minArray = new int[length];
            var min = int.MaxValue;
            for (int i = length - 1; i >= 0; i--)
            {
                var current = A[i];
                minArray[i] = min;
                if (current < min)
                {
                    min = current;
                    minArray[i] = min;
                }
            }

            int minLength = length;
            for (int i = 0; i < length - 1; i++)
            {
                if (maxArray[i] <= minArray[i + 1])
                {
                    return i + 1;
                }
            }

            return -1;
        }
    }
}
