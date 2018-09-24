using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _696.Count_Binary_Substrings
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int CountBinarySubstrings(string s)
        {
            if (s == null || s.Length <= 1)
                return 0;

            var length = s.Length;

            int start = 0;
            int previous = 0;
            int count = 0;
            for (int i = 0; i < length; i++)
            {
                if (i == 0 || s[i] != s[i - 1])
                {
                    start = i;
                }

                if (i == (length - 1) || s[i] != s[i + 1])
                {
                    int current = i - start + 1;
                    count += Math.Min(current, previous);
                    previous = current;
                }
            }

            return count;
        }
    }
}
