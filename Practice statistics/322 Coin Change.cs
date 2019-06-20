using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _322_Coin_Change
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = CoinChange(new int[]{2}, 3); 
        }

        /// <summary>
        /// June 20, 2019
        /// Use dynamic programming, bottom up 
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static int CoinChange(int[] coins, int amount)
        {
            if (coins == null || amount < 0)
                return 0;

            var F = new int[amount + 1];
            F[0] = 0;

            for (int target = 1; target <= amount; target++)
            {
                var list = new List<int>();
                foreach (var item in coins)
                {
                    if (item <= target)
                    {
                        var previous = F[target - item];

                        if (previous == -1)
                            continue;
                        
                        list.Add(1 + previous);
                    }
                }

                if (list.Count == 0)
                    F[target] = -1;
                else
                    F[target] = list.Min();
            }

            return F[amount];
        }
    }
}
