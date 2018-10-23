using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _401_binary_watch
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// idea is from the following:
        /// https://leetcode.com/problems/binary-watch/discuss/88456/3ms-Java-Solution-Using-Backtracking-and-Idea-of-%22Permutation-and-Combination%22
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public IList<string> ReadBinaryWatch(int num)
        {
            var result = new List<string>();

            var hourNumbers   = new int[] { 8,   4, 2, 1 };
            var minuteNumbers = new int[] { 32, 16, 8, 4, 2, 1 };

            for (int i = 0; i <= num; i++)
            {
                var listHours   = generateDigits(hourNumbers, i);
                var listMinutes = generateDigits(minuteNumbers, num - i);

                foreach (var hours in listHours)
                {
                    if (hours >= 12)
                    {
                        continue; 
                    }

                    foreach (var minutes in listMinutes)
                    {
                        if (minutes >= 60)
                        {
                            continue; 
                        }

                        var minuteTwoDigits = minutes.ToString();
                        var minutesText = minutes < 10 ? "0" + minuteTwoDigits : minuteTwoDigits;

                        result.Add(hours + ":" + minutesText); 
                    }
                }
            }

            return result; 
        }

        private static List<int> generateDigits(int[] numbers, int count)
        {
            var result = new List<int>();

            generateDigitsBySteps(numbers, count, 0, 0, result);

            return result; 
        }

        /// <summary>
        /// count how many ways to construct the digits:
        /// var hourNumbers   = new int[] { 8, 4, 2, 1 };
        /// 2 numbers
        /// First number is bigger than second number. 
        /// First number has 4 options, 8 or 4 or 2 or 1, denote as index i
        /// Second number has 3 - i, 
        /// total options are i * (3 - i)
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="count"></param>
        /// <param name="start"></param>
        /// <param name="sum"></param>
        /// <param name="result"></param>
        private static void generateDigitsBySteps(int[] numbers, int count, int start, int sum, List<int> result)
        {
            if (count == 0)
            {
                result.Add(sum); 
            }

            // enumerate all options for the next digit, from start to last number
            for (int i = start; i < numbers.Length; i++)
            {
                generateDigitsBySteps(numbers, count - 1, i + 1, sum + numbers[i], result); 
            }
        }
    }
}
