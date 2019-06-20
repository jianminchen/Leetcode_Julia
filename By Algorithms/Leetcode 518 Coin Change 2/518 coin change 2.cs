using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _518_Coin_Change_2
{
    class Program
    {
        static void Main(string[] args)
        {
           // var result = Change(3, new int[]{1, 2, 5}); // should be 2
           // var result2 = Change(5, new int[] { 1, 2, 5 }); // should be 3
            var result3 = Change(3, new int[]{2});
        }

        /// <summary>
        /// 518 coin change 2
        /// first get all sequences with duplicate first, and then
        /// remove duplicate count 
        /// 
        /// Time out: 
        /// 500, [1, 2, 5]
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="coins"></param>
        /// <returns></returns>
        public static int Change(int amount, int[] coins)
        {
            if (coins == null || amount < 0)
                return 0;

            if (amount == 0) // caught by online judge: 0,[] should be 1, not 0
                return 1; 

            var F = new int[amount + 1];            
            
            var sequences = new Dictionary<int, List<List<int>>>();
            F[0] = 0;
            sequences.Add(0, new List<List<int>>());

            for (int target = 1; target < amount + 1; target++)
            {
                var newList = new List<List<int>>();
                foreach (var coin in coins)
                {
                    if (coin > target)
                        continue;

                    var search = target - coin;
                    if (!sequences.ContainsKey(search))
                        continue;
                    var list = sequences[search];
                    //var copyList = new List<List<int>>(list); // caught by online judge
                    var copyList = new List<List<int>>();
                    foreach (var subList in list)
                    {
                        var copySubList = new List<int>(subList);
                        copyList.Add(copySubList);
                    }

                    if (copyList.Count == 0)
                    {
                        if (coin == target) // caught by failed test case: 3, [2] should be 0, return 1 instead
                        {
                            var subList = new List<int>(); // caught by debugger
                            subList.Add(coin);
                            copyList.Add(subList);
                        }
                    }
                    else
                    {                        
                        foreach (var sublist in copyList)
                        {
                            sublist.Add(coin);
                        }
                    }

                    newList.AddRange(copyList);
                }

                sequences.Add(target, newList);
            }

            var result = sequences[amount];
            // now it is time to remove duplicate count 
            var hashset = new HashSet<string>();
            int count = 0; 
            foreach (var subList in result)
            {
                // count sort
                var values = new int[coins.Length];
                var lookupMap = new Dictionary<int, int>();
                for (int i = 0; i < coins.Length; i++)
                {
                    lookupMap.Add(coins[i], i);
                }

                foreach (var value in subList)
                {
                    values[lookupMap[value]]++;
                }

                var key = string.Join("-", values);
                if (hashset.Contains(key))
                    continue;
                hashset.Add(key);
                count++;
            }

            return count; 
        }
    }
}
