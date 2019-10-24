using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1016_binary_string
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static bool QueryString(string S, int N)
        {
            for (int i = 1; i <= N; i++)
            {
                var current = Convert.ToString(i, 2);
                if (!S.Contains(current))
                {
                    return false; 
                }
            }

            return true; 
        }
    }
}
