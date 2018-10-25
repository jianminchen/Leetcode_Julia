using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _56_Merge_intervals
{
    
    public class Interval {
        public int start;
        public int end;
        public Interval() { start = 0; end = 0; }
        public Interval(int s, int e) { start = s; end = e; }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }

        /*
         * IntervalComparer is to compare the interval start value, but if
         * the two have the same value, then compare end value. 
         * 
         */
        public class IntervalComparer : IComparer<Interval>
        {
            public int Compare(Interval leftHandSide, Interval rightHandSide)
            {
                if (leftHandSide.start == rightHandSide.start)
                {
                    return leftHandSide.end.CompareTo(rightHandSide.end);
                }

                return leftHandSide.start.CompareTo(rightHandSide.start);
            }
        }

        public IList<Interval> Merge(IList<Interval> intervals)
        {
            var sortedIntervals = new SortedSet<Interval>(intervals, new IntervalComparer());

            for (int i = 0; i < sortedIntervals.Count - 1; i++)
            {
                Interval current = sortedIntervals.ElementAt(i);
                Interval next = sortedIntervals.ElementAt(i + 1);

                // two intervals are overlapped
                if (next.start - current.end < 1)
                {
                    // set current interval's end, and then remove next interval
                    current.end = Math.Max(current.end, next.end);
                    sortedIntervals.Remove(next);

                    i--; // go back to old index, continue
                }
            }

            return sortedIntervals.ToList();
        }
    }
}
