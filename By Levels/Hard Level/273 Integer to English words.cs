using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _273_Integer_to_English_words
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static string[] Thousands = new string[] { "Billion", "Million", "Thousand", "" };
        public static string[] Digits = new string[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        public static string[] TwoDigits = new string[] { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        public static string[] Bigger20 = new string[] { "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        public string NumberToWords(int number)
        {
            if (number == 0)
                return "Zero";

            var words = new StringBuilder();

            // 10^9, 10^6, 10^3
            var dividends = new int[] { 1000 * 1000 * 1000, 1000 * 1000, 1000, 1 };
            var workingNumber = number;

            for (int i = 0; i < dividends.Length; i++)
            {
                var currentDividend = dividends[i];

                var current = workingNumber / currentDividend;

                // current three digits only
                // zero - ignore
                if (current == 0)
                    continue;

                words.Append(toThreeDigitsWord(current) + " ");

                workingNumber = workingNumber - current * currentDividend;

                words.Append(Thousands[i] + " ");
            }

            return words.ToString().Trim();
        }

        /// <summary>
        /// test cases: 
        /// 100
        /// 85
        /// 900
        /// 13
        /// 345
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        private static string toThreeDigitsWord(int current)
        {
            var words = new StringBuilder();

            var thirdDigit = current / 100; // 13 -> 0
            if (thirdDigit > 0)
                words.Append(Digits[thirdDigit] + " Hundred "); // 

            var residue = current - thirdDigit * 100; // 13

            var secondDigit = residue / 10; // 1
            var biggerThan19 = secondDigit >= 2;
            var fromTenTo19 = secondDigit == 1;
            var lessThan10 = secondDigit == 0;

            if (biggerThan19)
            {
                words.Append(Bigger20[secondDigit - 1] + " "); // Eighty

                residue = residue - secondDigit * 10; // 5
                if (residue > 0)
                    words.Append(Digits[residue] + " "); // 5 -> Five
            }

            if (fromTenTo19)
            {
                words.Append(TwoDigits[residue - 10] + " "); // 13 - 10 = 3
            }

            if (lessThan10 && residue > 0)
            {
                words.Append(Digits[residue] + " ");
            }

            return words.ToString().TrimEnd();
        }
    }
}
