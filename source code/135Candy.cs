using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candy
{
    class Program
    {
        static void Main(string[] args)
        {
            // test result: total candy is 15
            // test result: 1 2 3 4 5 
            int[] ratings = { 1, 2, 3, 4, 5 };
            int result = candy(ratings);

            // test result: total candy is 7
            // test result: 1 2 1 2 1
            int[] ratings2 = { 1, 3, 2, 5, 4 };             
            int result2 = candy(ratings2); 

            // 
            int[] ratings3 = { 2, 1 };
            int result3 = candy2(ratings3); 
        }

        /**
         *  There are N children standing in a line. Each child is assigned a rating value. 
         *  You are giving candies to these children subjected to the following requirements:
            1. Each child must have at least one candy.
            2. Children with a higher rating get more candies than their neighbors.

            What is the minimum candies you must give?
         *  O(N) algorithm 
         *  Test cases: -- Latest update on June 8, 2015  
         *  1. int[] ratings = { 1, 2, 3, 4, 5 };
         *     test result: total candy is 15
               Candies: 1 2 3 4 5 
         *  2. int[] ratings2 = { 1, 3, 2, 5, 4 };
         *     test result: total candy is 7 
         *     candies: 1 2 1 2 1
         *     Verify the result to satisfy the requirement
         *     
         */
        public static int candy(int[] ratings)
        {
            int len = ratings.Length;
            if (ratings == null || len == 0)
            {
                return 0;
            }

            int[] candies = new int[len];
            candies[0] = 1;

            // from let to right, ascending rating discussion: current > previous 
            // (first one set value 1, starting from second one), 
            // and then, candies of current = candies of previous + 1;
            // otherwise, set default value 1
            for (int i = 1; i < len; i++)
            {
                int current = i;
                int previous = i - 1;

                if (ratings[current] > ratings[previous])
                {
                    candies[current] = candies[previous] + 1;
                }
                else
                {
                    // if not ascending, assign 1
                    candies[current] = 1;
                }
            }

            int result = candies[len - 1];

            // from right to left
            // ascending rate discussion: current > next, and then, 
            // candies of current = max(candies of current, candies of next); 
            // In the sames time, calculate the sum of candies
            for (int i = len - 2; i >= 0; i--)
            {
                int current = i;
                int previous = i + 1;

                int value = 1;                 
                  
                if (ratings[current] > ratings[previous])
                {
                    value = candies[previous] + 1;
                }

                candies[current] = Math.Max(value, candies[current]);                
              
                result += candies[current];                 
            }

            return result;
        }

        /**
        * The right to left loop, the code is more clear to follow.
        *  So, share this version of code
        *  http://siddontang.gitbooks.io/leetcode-solution/content/greedy/candy.html
        */
        public static int candy2(int[] ratings)
        {
            int len = ratings.Length;
            if (ratings == null || len == 0)
            {
                return 0;
            }

            int[] candies = new int[len];
            candies[0] = 1;

            // from let to right, ascending rating discussion: current > previous 
            // (first one set value 1, starting from second one), 
            // and then, candies of current = candies of previous + 1;
            // otherwise, set default value 1
            for (int i = 1; i < len; i++)
            {
                int current = i;
                int previous = i - 1;

                if (ratings[current] > ratings[previous])
                {
                    candies[current] = candies[previous] + 1;
                }
                else
                {
                    // if not ascending, assign 1
                    candies[current] = 1;
                }
            }

            int result = candies[len - 1];

            // from right to left
            // ascending rate discussion: current > next, and then, 
            // candies of current = max(candies of current, candies of next); 
            // In the sames time, calculate the sum of candies
            for (int i = len - 2; i >= 0; i--)
            {
                int current = i;
                int previous = i + 1;
                
                if (ratings[current] > ratings[previous] && candies[current] <= candies[previous])
                {
                    candies[current] = candies[previous] + 1;
                }
                result += candies[current];
            }

            return result;
        }
    }   
}
