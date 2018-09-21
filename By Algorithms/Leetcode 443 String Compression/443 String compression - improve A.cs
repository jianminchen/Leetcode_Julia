using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _443_string_compression
{
    class Program
    {
        static void Main(string[] args)
        {
            var chars = "x77222f'4}".ToCharArray();

            var result = Compress(chars);
        }

        /// <summary>
        /// compress the string
        /// </summary>
        /// <param name="chars"></param>
        /// <returns></returns>
        public static int Compress(char[] chars)
        {
            if (chars == null || chars.Length == 0)
                return 0;

            var length = chars.Length;                      
            char previous = chars[0];

            int count = 0;  

            int index = 0;
            int totalUsed = 0; 
            while(index < length)
            {
                var current = chars[index];
                
                while(index < length && chars[index] == current )
                {
                    count++; 
                    index++;
                }

                if (count == 1)
                {
                    chars[totalUsed] = current;
                    totalUsed++;
                }
                else
                {
                    chars[totalUsed++] = current;
                    var numbers = count.ToString();
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        chars[totalUsed++] = numbers[i];
                    }
                }

                count = 0;                 
            }

            return index;
        }
    }
}
