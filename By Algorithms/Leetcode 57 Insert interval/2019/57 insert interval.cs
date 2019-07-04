using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _57_Merge_intervals
{
    class Program
    {
        public class Interval {
            public int start;
            public int end;
            public Interval() { start = 0; end = 0; }
            public Interval(int s, int e) { start = s; end = e; }
        }

        static void Main(string[] args)
        {
        }

        /// <summary>
        /// code review July 4, 2019
        /// </summary>
        /// <param name="intervals"></param>
        /// <param name="newInterval"></param>
        /// <returns></returns>
        public IList<Interval> Insert(IList<Interval> intervals, Interval newInterval)
        {
            var result = new List<Interval>();
            var sorted = new SortedSet<Interval>(Comparer<Interval>.Create((a, b) => a.start == b.start ? a.end - b.end : a.start - b.start));

            // put all intervals into the binary search tree
            foreach (var node in intervals)
            {
                sorted.Add(node);
            }
            
            sorted.Add(newInterval);

            while (sorted.Count() > 0)
            {                
                if (sorted.Count() == 1)
                {
                    result.Add(sorted.Min);
                    break;
                }

                // assuming that there are at least two nodes in the BST
                var node1 = sorted.Min;
                sorted.Remove(node1);

                var node2 = sorted.Min;
                sorted.Remove(node2);

                if (node1.end >= node2.start) // overlap - merge two intervals 
                {
                    sorted.Add(new Interval(node1.start, Math.Max(node1.end, node2.end)));
                }
                else
                {
                    // the first one goes to the output result, and the second will go back to the tree
                    result.Add(node1);
                    sorted.Add(node2);
                }
            }

            return result;
        }
    }
}
