using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace permutation
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = Permute(new int[] { 1, 2});
        }

        public static IList<IList<int>> Permute(int[] nums)
        {
            if (nums == null)
                return new List<IList<int>>();

            var permutations = new List<IList<int>>();
            var set = new HashSet<int>();
            var list = new List<int>();

            runDFS(nums, set, list, permutations);

            return permutations;
        }

        //[1]
        //[1, 2]
        //[1, 2, 3]
        private static void runDFS(int[] numbers, HashSet<int> found, IList<int> list, List<IList<int>> result)
        {
            if (numbers.Length == list.Count) // true
            {
                var copy = new List<int>();
                foreach (var item in list)
                    copy.Add(item);

                result.Add(copy);// {1, 2}
                return;
            }

            for (int i = 0; i < numbers.Length; i++) //i = 1
            {
                var current = numbers[i]; // 2
                if (found.Contains(current)) //false
                {
                    continue;
                }

                // DFS 
                list.Add(current);// [1,2
                found.Add(current); // {1,2}

                runDFS(numbers, found, list, result); // 

                list.RemoveAt(list.Count - 1); // not remove, should be RemoveAt
                found.Remove(current); // remove 2           
            }
        }
    }
}
