using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _67_Add_binary
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// code written in 2015
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string AddBinary(string a, string b)
        {
            int N = a.Length, M = b.Length, K = Math.Max(N, M);

            string kChars = new string(' ', K);
            StringBuilder res = new StringBuilder(kChars); // julia comment: cannot using string, readonly, and then, use StringBuilder        

            int carry = 0;
            int i = N - 1, j = M - 1, k = K - 1;

            while (i >= 0 || j >= 0)
            {
                int sum = carry;
                if (i >= 0) sum += a[i--] - '0';
                if (j >= 0) sum += b[j--] - '0';
                carry = sum / 2;
                res[k--] = (char)(sum % 2 + '0');  // julia comment C#: cannot convert implicitly, so add (char)(...)
            }

            if (carry == 1)
                res.Insert(0, '1');  // julia comment C#: first time, use insert function, 

            string s = res.ToString(); // julia comment: C#, convert StringBuilder to String before return

            return s;
        }
    }
}
