using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1221_split_a_string_in_balanced_strings
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int BalancedStringSplit(string s)
        {
            var length = s.Length;

            int sum = 0;
            int count = 0;
            for (int i = 0; i < length; i++)
            {
                var visit = s[i];
                var isL = visit == 'L';
                if (isL)
                {
                    sum -= 1;
                }
                else
                {
                    sum += 1;
                }

                if (sum == 0)
                {
                    count++;
                    sum = 0;
                }
            }

            return count;
        }
    }
}
