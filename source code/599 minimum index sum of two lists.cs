using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _599.Minimum_Index_Sum_of_Two_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public string[] FindRestaurant(string[] list1, string[] list2)
        {
            if (list1 == null || list2 == null)
                return new string[0];

            var dict1 = saveToDictionary(list1);
            var dict2 = saveToDictionary(list2);

            var minSum = dict1.Count + dict2.Count;
            var keys = new List<string>();
            foreach (var word in dict1.Keys)
            {
                if (dict2.ContainsKey(word))
                {
                    var current = dict1[word];
                    var current2 = dict2[word];
                    var sum = current + current2;
                    if (minSum > sum)
                    {
                        minSum = sum;
                        keys.Clear();
                        keys.Add(word);
                    }
                    else if (minSum == sum)
                    {
                        keys.Add(word);
                    }
                }
            }

            return keys.ToArray();
        }

        private static IDictionary<string, int> saveToDictionary(string[] list)
        {
            var dict = new Dictionary<string, int>();

            for (int i = 0; i < list.Length; i++)
            {
                dict.Add(list[i], i);
            }

            return dict;
        }
    }
}
