using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _299_bulls_and_cows
{
    class Program
    {
        static void Main(string[] args)
        {
            // secret = "1807", guess = "7810"
            var result = GetHint("1807","7810"); 
        }

        /// <summary>
        /// 299 bulls and cows
        /// 
        /// </summary>
        /// <param name="secret"></param>
        /// <param name="guess"></param>
        /// <returns></returns>
        public static string GetHint(string secret, string guess)
        {
            var secretCount = countDigits(secret);
            var guessCount  = countDigits(guess);

            var total = 0;
            for (int i = 0; i < 10; i++)
            {
                var real = secretCount[i];
                var guessed = guessCount[i];
                
                total += Math.Min(real, guessed);                
            }

            var bullCount = 0;
            for (int i = 0; i < secret.Length; i++)
            {
                if (secret[i] == guess[i])
                {
                    bullCount++; 
                }
            }

            var cowCount = total - bullCount;
            return bullCount.ToString() + "A" + cowCount.ToString() + "B";
        }

        private static int[] countDigits(string word)
        {
            var count = new int[10];
            foreach (var item in word)
            {
                int number = item - '0';
                count[number]++;
            }

            return count; 
        }
    }
}
