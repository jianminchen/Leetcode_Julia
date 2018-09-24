using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _893.Groups_of_Special_Equivalent_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int NumSpecialEquivGroups(string[] A)
        {
            if (A == null)
                return 0;

            var keys = new HashSet<string>();

            foreach (var item in A)
            {
                var countLetterEven = new int[26];
                var countLetterOdd = new int[26];

                for (int i = 0; i < item.Length; i++)
                {
                    var current = item[i];
                    var isEven = i % 2 == 0;
                    if (isEven)
                    {
                        countLetterEven[current - 'a']++;
                    }
                    else
                        countLetterOdd[current - 'a']++;
                }

                var key = createKey(countLetterEven, countLetterOdd);
                if (!keys.Contains(key))
                    keys.Add(key);
            }

            return keys.Count;
        }

        private static string createKey(int[] even, int[] odd)
        {
            var key = "";
            for (int i = 0; i < 26; i++)
            {
                key += even[i] + " " + odd[i] + ";";
            }

            return key;
        }
    }
}
