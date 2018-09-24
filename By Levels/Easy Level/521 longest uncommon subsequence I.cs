using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _521.Longest_Uncommon_Subsequence_I
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int FindLUSlength(string a, string b)
        {
            if ((a == null || a.Length == 0) &&
                (b == null || b.Length == 0))
                return -1;

            if (a == null || a.Length == 0)
                return b.Length;
            if (b == null || b.Length == 0)
                return a.Length;

            if (a.CompareTo(b) == 0)
                return -1;

            var lengthA = a.Length;
            var lengthB = b.Length;
            if (lengthA > lengthB)
                return FindLUSlength(b, a);

            return lengthB;
        }   
    }
}
