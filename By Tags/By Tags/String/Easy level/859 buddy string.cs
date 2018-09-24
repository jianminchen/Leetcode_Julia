using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _859_buddy_string
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// lowercase letters 
        /// alternative idea: 
        /// instead of using Array.Max(), can check letterCount size in the for loop. 
        /// Instead of using letterCount array, use HashSet; no need to know which letter 
        /// is duplicated at least once. 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        bool buddyStrings(string A, string B)
        {
            if (A == null || B == null || A.Length != B.Length)
                return false;

            var lengthA = A.Length;           

            var positions = new int[2];
            var letterCount = new int[26];

            int index = 0; 
            for (int i = 0; i < lengthA; i++)
            {
                letterCount[A[i] - 'a']++;

                if (A[i] != B[i])
                {
                    if (index >= 2)
                    {
                        return false;
                    }

                    positions[index] = i;
                    index++;                    
                }
            }

            return (index == 2 && A[positions[0]] == B[positions[1]] && B[positions[0]] == A[positions[1]]) ||
                (index == 0 && letterCount.Max() >= 2);
        }
    }
}
