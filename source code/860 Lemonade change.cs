using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _860_lemonade_change
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// use greedy algorithm, count how many $5 and $10's, 
        /// if the bill is $5, then take it;
        /// if the bill is $10, then pay back $5;
        /// if the bill is $20, then pay back one $10, one $5. 
        /// Pay using 10 first if the bill is $20
        /// </summary>
        /// <param name="bills"></param>
        /// <returns></returns>
        public bool LemonadeChange(int[] bills)
        {
            if (bills == null || bills.Length == 0)
                return true;

            var count = new int[2]; // 0 - $5.00, 1 - 10.00

            var length = bills.Length;

            for (int i = 0; i < length; i++)
            {
                var current = bills[i];

                if (current == 5)
                {
                    count[0]++; 
                }
                else if (current == 10)
                {
                    if (count[0] == 0)
                    {
                        return false;
                    }
                    else
                    {
                        count[0]--;
                        count[1]++;
                    }
                }
                else // $20.00 
                {   // pay using $5.00 only or using one 5 or one 10
                    var noFive = count[0];
                    var noTen = count[1];

                    if (noTen >= 1 && noFive >= 1)
                    {
                        // change - one five dollar, one ten dollar
                        count[0]--;
                        count[1]--;
                    }
                    else if (noFive >= 3)
                    {
                        // change - three of five dollars
                        count[0] -= 3;
                    }
                    else
                    {
                        return false; 
                    }
                }
            }

            return true; 
        }
    }
}
