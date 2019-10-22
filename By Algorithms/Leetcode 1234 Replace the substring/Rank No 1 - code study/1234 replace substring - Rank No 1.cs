using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1234_replace_substring___rank_No_1
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int BalancedString(string s)
        {
            const string CHARS = "QWER";
            int length = s.Length;
            var prefixCounts = new int[4][];

            for (int i = 0; i < 4; i++)
            {
                prefixCounts[i] = new int[length + 1];

                for (int j = 0; j < length; j++)
                {
                    prefixCounts[i][j + 1] = prefixCounts[i][j] + (s[j] == CHARS[i] ? 1 : 0);
                }
            }

            int low = 0;
            int high = length;

            while (low < high)
            {
                int middle = low + (high - low) / 2;
                var seriesCheck = false;

                for (int i = 0; i + middle <= length; i++)
                {
                    var now = new int[4];
                    var averageCheck = true;

                    for (int j = 0; j < 4; j++)
                    {
                        now[j] = prefixCounts[j][i] + (prefixCounts[j][length] - prefixCounts[j][i + middle]);

                        if (now[j] > length / 4)
                        {
                            averageCheck = false;
                        }
                    }
                    /* if any one from i = 0 to length - middle is true */
                    seriesCheck = seriesCheck || averageCheck;
                }

                if (seriesCheck)
                {
                    high = middle;
                }
                else
                {
                    low = middle + 1;
                }
            }

            return low;
        }
    }
}
