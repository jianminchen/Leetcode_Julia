using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _944_Delete_column_to_make_it_sorted
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int MinDeletionSize(string[] digits)
        {
            if (digits == null || digits.Length == 0)
                return 0;

            var length = digits[0].Length;

            var number = digits.Length;
            int count = 0;
            for (int index = 0; index < length; index++)
            {
                for (int i = 0; i < number - 1; i++)
                {
                    var current = digits[i][index];
                    var next = digits[i + 1][index];

                    if (current > next)
                    {
                        count++;
                        break;
                    }
                }
            }

            return count;
        }
    }
}
