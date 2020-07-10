using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frog_jump
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = CanCross(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });
        }

        /// <summary>
        /// July 10, 2020
        /// The idea is to use dynamic programming, bottom up, and then build the solution
        /// The challenge is to understand the problem statement. There are frog, stones, water, 
        /// jump with three choice of last jump. 
        /// The second challenge is to make code readable, simple as possible, 
        /// How to set up hashmap using given stones, so that it is easy to figure out
        /// how many stones are reachable. 
        /// I will mark those places as tips to look into
        /// The success of problem solving is to make a check list of tasks. 
        /// 1. From bottom up, dynamic programming
        /// 2. Jump - good understanding of three choices, only forward
        /// 3. Possible jumps may not make it on a stone stopper, skip the choice
        /// 4. Each stone stopper may come from different previous stone stopers with different jumps
        /// 5. Go over the code to make sure that it is easy to read, remove redundant code
        /// </summary>
        /// <param name="stones"></param>
        /// <returns></returns>
        public static bool CanCross(int[] stones) {
            if(stones == null || stones.Length == 0) 
            {
                return false; 
            }
        
            var length = stones.Length; //8       
        
            var dp = new Dictionary<int, List<int>>();        
        
            // tip 1: put those stones into hashmap
            for(int i = 0; i < length; i++)
            {           
                dp.Add(stones[i], new List<int>()); 
            }
        
            // dynamic programming from bottom up
            // [0,1,3,5,6,8,12,17]
            //         dp[0].Add(0); // [0]
            //         // dp[17]
            //         {
            //             0 , 1, 2, 3 .. length
            //         }
        
            //         hash table? 
            //         {
            //             0 : list
            //             1 : list
            //             3 : list
            //                 ...
            //             17: list.length > 0
            //         }              
        
            // [0, 1, 3, ..., 17
            // base case
            dp[0].Add(0); 

            for(int i = 0; i < length; i++) // tip 2: Do not mix index with stones[index]
            {
                // stones are in the river, so we give a good name called stoneStop
                var stoneStop = stones[i]; 
            
                var list = dp[stoneStop].ToList(); // tip 4: Make a copy, original one is changing
                foreach(var jump in list)  // tip 3: list of jumps
                {
                    // same, +1, -1 jump                 
                    var sameStep = jump;
                    var plusOne  = jump + 1; 
                    var minusOne = jump - 1; 
                
                    var choices = new int[]{sameStep, plusOne, minusOne};
                
                    /// tip 4: make the code flat - so remove nested if statement using negative checking, 
                    /// call continue statement
                    foreach(var item in choices)
                    {
                        // item are the available k units
                        // You want to make sure the item are forward                                       
                        if( item <= 0)
                        {
                            continue; 
                        }
                    
                        var target = stoneStop + item;
                        
                        if(!dp.ContainsKey(target))
                        {
                            continue; 
                        }                                                   
                        
                        // stone number = not index
                        dp[stoneStop + item].Add(item);

                        // return early - TLE concern
                        if (dp[stones[length - 1]].Count > 0)
                            return true; 
                    }                                
                }            
            }
        
            return dp[stones[length - 1]].Count > 0;         
        }
    }
}
