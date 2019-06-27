using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _402_remove_k_digits
{
    class Program
    {
        static void Main(string[] args)
        {
            //var result = RemoveKdigits("543213", 2);
            //var result2 = RemoveKdigits("1432219", 3);
            var result3 = RemoveKdigits("5337", 2); 
        }

        /// <summary>
        /// use sliding window, bucket sort idea
        /// </summary>
        /// <param name="number"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static string RemoveKdigits(string number, int k)
        {
            if (number == null || number.Length < k)
                return string.Empty;

            if (k == number.Length)
                return "0";

            var digits = new int[10];
            var length = number.Length;
            var start = 0;
            var end = Math.Min(k, length - 1); // caught by debugger

            for (int i = start; i < end + 1; i++)
            {
                var digit = number[i] - '0'; // add - '0'
                digits[digit]++;
            }

            var samllestLength = length - k;
            var smallest = new StringBuilder();

            while (start < length)
            {
                var smallestDigit = -1;
                
                for (int i = 0; i <= 9; i++)
                {
                    var count = digits[i];
                    if (count > 0)
                    {
                        smallest.Append((char)(i + '0'));
                        digits[i]--;
                        smallestDigit = i;  // caught by debugger  
                        break;
                    }                    
                }

                // remove digits 
                int index = start;
                while (index < length && k > 0)
                {
                    var value = number[index];
                    var digit = value - '0';
                       
                    if (digit == smallestDigit)
                    {
                        break;
                    }

                    if( (value - '0') > smallestDigit)
                    {
                        digits[number[index] - '0']--; // caught by debugger

                        start++;
                        index++;
                        k--;                        
                    }
                }                

                // skip one more
                start++;

                // make sure the size of window is K + 1
                while ((end - start + 1) < (k + 1) && (end + 1) < length)
                {
                    digits[number[end + 1] - '0']++;
                    end++;
                }

                // no more chars to be added - break
                if (smallest.ToString().Length == samllestLength)
                    break;

                // no more chars to remove - edge
                if (k == 0)
                {
                    for (int i = start; i < length; i++)
                    {
                        if (smallest.ToString().Length < length - k)
                        {
                            smallest.Append(number[i]);
                        }
                    }

                    break;
                }                
            }

            // remove leading zero
            var removeLeadingZeoro = new StringBuilder();
            var leadingZero = true;
            for (int i = 0; i < smallest.Length; i++)
            {
                if (leadingZero && smallest[i] == '0')
                {
                    continue;
                }                
                
                leadingZero = false;
                removeLeadingZeoro.Append(smallest[i]);                
            }

            return removeLeadingZeoro.Length == 0 ? "0" : removeLeadingZeoro.ToString();
        }
    }
}
