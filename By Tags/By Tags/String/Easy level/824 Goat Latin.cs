using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _824.Goat_Latin
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public string ToGoatLatin(string S)
        {
            if (S == null)
                return S;

            var split = S.Split(' ');
            var vowels = "aeiouAEIOU";
            var sb = new StringBuilder();
            var length = split.Length;

            for (int i = 0; i < length; i++)
            {
                var current = split[i];
                var isVowel = vowels.IndexOf(current[0]) != -1;
                if (isVowel)
                {
                    sb.Append(current);
                }
                else
                {
                    if (current.Length == 1)
                        sb.Append(current);
                    else
                    {
                        sb.Append(current.Substring(1));
                        sb.Append(current[0].ToString());
                    }
                }

                sb.Append("ma");
                var repeat = i;
                while (repeat >= 0)
                {
                    sb.Append("a");
                    repeat--;
                }

                if (i < length - 1)
                {
                    sb.Append(' ');
                }
            }

            return sb.ToString();
        }
    }
}
