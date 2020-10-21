using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _358_Heap_LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "aaadbbcc";
            var result = rearrangeString(s, 2);
        }

        /// <summary>
        /// Oct. 21, 2020
        /// code study
        /// https://protegejj.gitbook.io/algorithm-practice/leetcode/heap/358-rearrange-string-k-distance-apart
        /// First count character and it's occurrence. Declare array size 256. 
        /// Design a maximum heap and put all the character's into maximum heap, define sorting rules. 
        /// Design an extra buffer for removed characters using double linked list, if the size of list is k, 
        /// then the head of list is ready to join maximum heap again to compete for another round of removal. 
        /// Data structures used for the design using C#:
        /// 1. Tuple<char, int> - char, count
        /// 2. Maximum heap - SortedSet
        /// 3. Buffer - using LinkedList<Tuple<char, int>>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static string rearrangeString(string s, int k)
        {
            if (k == 1)
            {
                return s;
            }

            var count = new int[256];
            foreach (var item in s)
            {
                count[item - 'a']++; 
            }

            // Create a sorted set using the ByOccurrences comparer.
            var maxHeap = new SortedSet<Tuple<char, int>>(new ByOccurrences());
            for (int i = 0; i < 256; i++)
            {
                if (count[i] != 0)
                {
                    maxHeap.Add(new Tuple<char, int>((char)('a'+i), count[i])); 
                }
            }

            var buffer = new LinkedList<Tuple<char, int>>(); 
            var result = new StringBuilder(); 

            while(maxHeap.Count > 0)
            {
                var maximum = maxHeap.Last();
                maxHeap.Remove(maximum); // time complexity O(1)?

                result.Append(maximum.Item1);

                var number = maximum.Item2 -1;
                buffer.AddLast(new Tuple<char, int>(maximum.Item1, number));

                // add a character back to maximum heap
                if (buffer.Count == k)
                {
                    var first = buffer.First;  // LinkedListNode
                    buffer.RemoveFirst();
                    if (first.Value.Item2 > 0) // check LinkedListNode.Value
                    {
                        maxHeap.Add(first.Value);
                    }
                }
            }

            return result.Length == s.Length ? result.ToString() : "";
        }

        // https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.sortedset-1?view=netcore-3.1
        // Defines a comparer to create a sorted set
        // that is sorted by the file extensions.
        public class ByOccurrences : IComparer<Tuple<char, int>>
        {            
            public int Compare(Tuple<char, int> x, Tuple<char, int> y)
            {
                var valueX = x.Item2;
                var valueY = y.Item2;
                if (valueX != valueY)
                {   // ascending order by number - maximum heap
                    return valueX - valueY;
                }
                else
                {   // lexicographic descending order by character - maximum heap
                    return (y.Item1 - x.Item1); 
                }
            }
        }
    }
}
