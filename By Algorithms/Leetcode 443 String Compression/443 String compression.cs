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
            int index = 0;

            int start = 0;
            char previous = chars[0];
            for (int i = 0; i < length; i++)
            {
                var current = chars[i];
                //if(i == 0 ||(current != chars[i - 1]))  // bug: chars[i - 1] is overwritten
                if (i == 0 || (current != previous))
                {
                    start = i; 
                }

                if (i == (length - 1) || current != chars[i + 1])
                {
                    chars[index] = current;

                    var number = i - start + 1;
                    if (number == 1)
                    {
                        index += 1;
                    }
                    else
                    {
                        var s = number.ToString();
                        var addLength = s.Length;
                       
                        for (int j = 0; j < addLength; j++)
                        {
                            chars[index + 1 + j] = s[j];
                        }

                        index += 1 + addLength;
                    }
                }

                previous = current;
            }

            return index; 
        }
    }
}
