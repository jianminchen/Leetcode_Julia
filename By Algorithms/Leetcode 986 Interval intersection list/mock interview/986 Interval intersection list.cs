using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _986_Interval_intersection_list
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// 986 interval intersection list
        /// mock interview version
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public int[][] IntervalIntersection(int[][] A, int[][] B)
        {
            var merged = new List<int[]>();

            var rows1 = A.Length;
            var rows2 = B.Length;

            var start1 = 0;
            var start2 = 0;

            while (start1 < rows1 && start2 < rows2)
            {
                var intervalStart1 = A[start1][0];
                var intervalEnd1 = A[start1][1];

                var intervalStart2 = B[start2][0];
                var intervalEnd2 = B[start2][1];

                var maxStart = Math.Max(intervalStart1, intervalStart2);
                var minEnd = Math.Min(intervalEnd1, intervalEnd2);

                var hasIntersection = maxStart <= minEnd;
                if (hasIntersection)
                {
                    merged.Add(new int[] { maxStart, minEnd });
                }

                if (intervalEnd1 < intervalEnd2)
                {
                    start1++;
                }
                else
                    start2++;
            }

            var count = merged.Count;
            var result = new int[count][];

            for (int i = 0; i < count; i++)
            {
                result[i] = new int[2];
                result[i][0] = merged[i][0];
                result[i][1] = merged[i][1];
            }

            return result;
        }
    }
}
