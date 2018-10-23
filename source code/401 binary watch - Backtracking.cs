using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _401_binary_watch___backtracking
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// idea is from the following:
        /// https://leetcode.com/problems/binary-watch/discuss/122298/My-AC-java-solution-7ms-using-Backtracking.
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public IList<string> ReadBinaryWatch(int num)
        {
            var result = new List<string>();
            var binaryNumber = "0000000000";

            backTrack(num, 0, result, binaryNumber.ToCharArray());

            return result;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="givenNumber"></param>
        /// <param name="start"></param>
        /// <param name="list"></param>
        /// <param name="bitArray"></param>
        private static void backTrack(int givenNumber, int start, List<String> list, char[] bitArray)
        {
            if (givenNumber == 0)
            {
                var timeSeq = new string(bitArray);
                var hour = timeSeq.Substring(0, 4);
                hour = Convert.ToInt32(hour, 2).ToString(); // convert binary number to an integer

                var minutes = timeSeq.Substring(4);
                var number = Convert.ToInt32(minutes, 2);

                var minutesInTwoDigits = number < 10 ? "0" + number.ToString() : number.ToString();

                list.Add(hour + ":" + minutesInTwoDigits);
                return;
            }

            // each element in the array has two options - 0 or 1. 
            for (int i = start; i < bitArray.Length; i++)
            {
                bitArray[i] = '1';

                var checkTime = new string(bitArray);
                var checkHour = Convert.ToInt32(checkTime.Substring(0, 4), 2);
                var checkMin  = Convert.ToInt32(checkTime.Substring(4), 2);

                if (checkHour <= 11 && checkMin <= 59)
                {
                    backTrack(givenNumber - 1, i + 1, list, bitArray);
                }

                // backtracking
                bitArray[i] = '0';
            }
        }
    }
}
