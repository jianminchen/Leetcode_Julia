using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1207_unique_number_of_occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public bool UniqueOccurrences(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return true;

            var length = arr.Length;
            var dict = new Dictionary<int, int>();

            for (int i = 0; i < length; i++)
            {
                var key = arr[i];
                if (!dict.ContainsKey(key))
                {
                    dict.Add(key, 0);
                }

                dict[key]++;
            }

            var hashSet = new HashSet<int>();
            foreach (var pair in dict)
            {
                if (hashSet.Contains(pair.Value))
                {
                    return false;
                }
                hashSet.Add(pair.Value);
            }

            return true;
        }
    }
}
