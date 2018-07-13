using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertIntervalToGivenSortedIntervals
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTestcase();
        }
        /// <summary>
        /// It is a good idea to work on a simple test case and then design how to implement the algorithm
        /// intervals: [1, 3] and [4, 6] 
        /// inserted interval: [2, 5]
        /// how to insert the interval to the above intervals. 
        /// Iterate the intervals, the current interval overlaps the inserted interval. 
        /// Make the merged two intervals to new inserted interval, [1, 5].
        /// </summary>
        public static void RunTestcase()
        {
            var intervals = new List<int[]>();
            intervals.Add(new int[] { 1, 3 });
            intervals.Add(new int[] { 4, 6 });

            var afterInsert = InsertIntervalGivenSortedIntervals(intervals, new int[] { 2, 5 });
            Debug.Assert(afterInsert[0][0] == 1);
            Debug.Assert(afterInsert[0][1] == 6);
        }

        /// <summary>
        /// mock interview on May 29, 2018 8:40 PM
        /// </summary>
        /// <param name="intervals"></param>
        /// <param name="inserted"></param>
        /// <returns></returns>
        public static IList<int[]> InsertIntervalGivenSortedIntervals(IList<int[]> intervals, int[] inserted)
        {
            if (inserted == null)
            {
                return intervals;
            }

            var newOnes = new List<int[]>();

            if (intervals == null || intervals.Count == 0)
            {
                newOnes.Add(inserted);
                return newOnes;
            }

            var length = intervals.Count;

            for (int index = 0; index < length; index++)
            {
                var insertStart = inserted[0];
                var insertEnd = inserted[1];

                var current = intervals[index];

                var currentStart = current[0];
                var currentEnd = current[1];

                var overlapStart = Math.Max(currentStart, insertStart);
                var overlapEnd = Math.Min(currentEnd, insertEnd);

                var overlap = overlapEnd > overlapStart;  // true 

                // check if inserted interval is front of current / after current
                if (overlap)
                {
                    inserted[0] = Math.Min(insertStart, currentStart);
                    inserted[1] = Math.Max(insertEnd, currentEnd);
                }
                else
                {
                    // if inserted interval is front of current
                    if (insertEnd < currentStart)
                    {
                        newOnes.Add(inserted);
                        inserted = current;
                    }
                    else
                    {
                        newOnes.Add(current);
                    }
                }
            }

            //edge case
            if (inserted[1] - inserted[0] > 0)
            {
                newOnes.Add(inserted);
            }

            return newOnes;
        }
    }
}