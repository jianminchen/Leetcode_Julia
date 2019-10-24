using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryString
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var result = QueryString("0110100100110010110101011001101100111101", 20); 
        }

        public static bool QueryString(string S, int N)
        {
            var hashset = new HashSet<int>();

            for (int i = 1; i <= N; i++)
            {
                hashset.Add(i);
            }

            var length = S.Length;
            for (int start = 0; start < length; start++)
            {
                for (int end = start; end < length; end++)
                {                    
                    var substring = S.Substring(start, end - start + 1).TrimStart(new Char[] { '0' });
                    
                    if (substring == "" || substring.Length > 32)
                        continue; 

                    hashset.Remove(Convert.ToInt32(substring, 2));
                }
            }

            return hashset.Count == 0;
        }
    }
}
