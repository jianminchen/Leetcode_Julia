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
            var end   = Math.Min(k, length - 1); // caught by debugger, slide window size maximum is k + 1. 

            for (int i = start; i < end + 1; i++)
            {
                var digit = number[i] - '0'; // add - '0'
                digits[digit]++;
            }

            var smallestLength = length - k; // k is changable, so need to declare a variable
            var smallest = new StringBuilder();

            while (start < length)
            {
                var smallestDigit = -1;
                
                for (int digit = 0; digit <= 9; digit++)
                {
                    var count = digits[digit];
                    if (count > 0)
                    {
                        smallest.Append((char)(digit + '0'));
                        digits[digit]--;
                        smallestDigit = digit;  // caught by debugger  
                        break;
                    }                    
                }

                // remove digits 
                // smallestDigit - skip digit until smallest digit is met
                int index = start;
                while (index < length && k > 0)
                {
                    var value = number[index];
                    var digit = value - '0';
                       
                    if (digit == smallestDigit)
                    {
                        break;
                    }

                    digits[digit]--; // caught by debugger

                    start++;
                    index++;
                    k--;                                            
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
                if (smallest.ToString().Length == smallestLength)
                    break;

                // no more chars to remove - edge
                if (k == 0)
                {
                    for (int i = start; i < length; i++)
                    {                        
                        smallest.Append(number[i]);                       
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

            // return "0" intead of ""
            return removeLeadingZeoro.Length == 0 ? "0" : removeLeadingZeoro.ToString();
        }
    }
}
