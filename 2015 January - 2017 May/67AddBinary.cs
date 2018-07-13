using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _67
{
    class Program
    {
        static void Main(string[] args)
        {
            string test = addBinary("1","111"); 
        }
        /*
         * source code from blog:
         * http://www.jiuzhang.com/solutions/add-binary/
         * 
         * online judge:
         * 294 / 294 test cases passed.
            Status: Accepted
            Runtime: 128 ms
         */
        public static String addBinary(String a, String b)
        {
            int aLen = a.Length; 
            int bLen = b.Length; 

            if (aLen < bLen)  // swap a and b
            {
                String tmp = a;  // ensure that first argument a's length is longer than second argument string b. 
                a = b;
                b = tmp;
            }

            int pa = a.Length - 1;  // start from last one, decreasing order 
            int pb = b.Length - 1;

            int carries = 0;
            String rst = "";

            while (pb >= 0)
            {
                int num1 = a[pa] - '0';
                int num2 = b[pb] - '0';
                int sum = num1 + num2 + carries;

                rst = (sum % 2).ToString() + rst;  // ? 
                carries = sum / 2;
                pa--;
                pb--;
            }

            while (pa >= 0)
            {
                int num = a[pa] - '0';
                int sum = num + carries;
                rst = (sum % 2).ToString() + rst;
                carries = sum / 2;
                pa--;
            }

            if (carries == 1)
                rst = "1" + rst;

            return rst;
        }
    }
}
