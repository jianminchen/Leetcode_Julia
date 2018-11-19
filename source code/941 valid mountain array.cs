using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _941_valid_mountain_array
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public bool ValidMountainArray(int[] A)
        {
            if (A == null || A.Length < 3)
            {
                return false;
            }

            int peakCount = 0;
            int valleyCount = 0;

            int previous = A[0];
            int length = A.Length;

            for (int i = 1; i < length; i++)
            {
                var current = A[i];
                var notLast = (i + 1) < length;
                var isPeak = current > previous && notLast && current > A[i + 1];
                var isValley = current < previous && notLast && current < A[i + 1];
                if (isPeak)
                {
                    peakCount++;
                }
                if (isValley)
                {
                    valleyCount++;
                }

                if (current == previous)
                    return false;

                previous = current;
            }

            return peakCount == 1 && valleyCount == 0;
        }
    }
}
