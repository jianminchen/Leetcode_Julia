using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _344.Reverse_String
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public string ReverseString(string s)
        {
            if (s == null)
                return s;

            var length = s.Length;
            var charArray = s.ToCharArray();

            int start = 0;
            int end = length - 1;
            while (start < end)
            {
                var tmp = charArray[start];
                charArray[start] = charArray[end];
                charArray[end] = tmp;
                start++;
                end--;
            }

            return new string(charArray);
        }
    }
}
