using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1234_study_code_II
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Leetcode 1234 study code
        /// rank No. 2, weekly contest 159, nhho
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int BalancedString(string s)
        {
            const int MAX = 100005; 
            var x = new int[MAX][]; // 4
            for(int i = 0; i < MAX; i++)
            {
                x[i] = new int[4];
            }

            int n = s.Length;

            // "QWER" - 0, 1, 2, 3
            for (int i = 0; i < n; i++) 
            {
                x[i + 1][0] = x[i][0];
                x[i + 1][1] = x[i][1];
                x[i + 1][2] = x[i][2];
                x[i + 1][3] = x[i][3];

                var current = s[i];
                var index = "QWER".IndexOf(current);
                x[i + 1][index]++;                
            }

            int answer = Int32.MaxValue;
            for (int i = 0; i < n; i++) 
            {
                int low = i;
                int high = n + 1;

                while (low < high) 
                {
                    int middle = (low + high) / 2;
                    bool averageCheck = true;

                    for (int j = 0; j < 4; j++)
                    {
                        // 0 - i - middle - n
                        if (x[n][j] - x[middle][j] + x[i][j] > n / 4)
                        {
                            averageCheck = false;
                            break;
                        }
                    }

                    if (averageCheck)
                    {
                        high = middle;
                    }
                    else
                    {
                        low = middle + 1;
                    }
                }

                if (low != n + 1)
                {
                    answer = Math.Min(answer, low - i);
                }
            }

            return answer;
        }
    }
}
