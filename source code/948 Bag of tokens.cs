using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _948_Bag_of_tokens
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tokens"></param>
        /// <param name="power"></param>
        /// <returns></returns>
        public int BagOfTokensScore(int[] tokens, int power)
        {
            if (power <= 0 || tokens == null || tokens.Length == 0)
                return 0;

            var maxPoints = 0;
            var currentPoints = 0;

            Array.Sort(tokens);
            var length = tokens.Length;

            int start = 0;
            int end = length - 1;

            var currentPower = power;

            var available = new HashSet<int>();
            for (int i = 0; i < length; i++)
                available.Add(i);

            while (start <= end)
            {
                if (!available.Contains(start))
                    break;

                var current = tokens[start];


                if (currentPower >= current)
                {
                    currentPoints++;
                    available.Remove(start);
                    currentPower -= current;
                    maxPoints = currentPoints > maxPoints ? currentPoints : maxPoints;
                    start++;
                }
                else
                {
                    if (currentPoints == 0)
                    {
                        return maxPoints;
                    }
                    else
                    {
                        currentPoints--;
                        if (available.Contains(end))
                        {
                            currentPower += tokens[end];
                            available.Remove(end);

                            end--;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            return maxPoints;
        }
    }
}
