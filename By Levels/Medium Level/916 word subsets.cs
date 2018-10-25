using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _916.Word_Subsets
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public IList<string> WordSubsets(string[] A, string[] B)
        {
            if (A == null || B == null || A.Length == 0 || B.Length == 0)
                return new List<string>();

            var maxCountOfB = getMaximumCount(B);
            var wordsFound = new List<string>();

            foreach (var word in A)
            {
                var current = new int[26];
                foreach (var item in word)
                {
                    current[item - 'a']++;
                }

                var findException = false;
                for (int i = 0; i < 26; i++)
                {
                    if (current[i] < maxCountOfB[i])
                    {
                        findException = true;
                        break;
                    }
                }

                if (findException)
                    continue;

                wordsFound.Add(word);
            }

            return wordsFound;
        }

        private static int[] getMaximumCount(string[] B)
        {
            var maxCount = new int[26];

            foreach (var word in B)
            {
                var current = new int[26];
                foreach (var item in word)
                {
                    current[item - 'a']++;
                }

                for (int i = 0; i < 26; i++)
                {
                    if (current[i] > maxCount[i])
                        maxCount[i] = current[i];
                }
            }

            return maxCount;
        }    
    }
}
