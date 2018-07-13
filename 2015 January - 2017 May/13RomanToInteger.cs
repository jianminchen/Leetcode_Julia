using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13RomanToInteger
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        /*
         * source code from blog:
         * http://codeganker.blogspot.ca/2014/02/roman-to-integer-leetcode.html
         * comment from the above blog:
         * 思路也比较简单，就是维护一个整数，然后如果1下一个字符是对应位的5或者10则减对应位的1，
         * 否则加之。遇到5或者10就直接加上对应位的5或者10。时间复杂度是O(字符串的长度)，空间复杂度是O(1)。
         * 
         * julia's comment: 
         * 1. convert it to C# programing language
         */
        public static int romanToInt(String s)
        {
            int len = s.Length; 
            if (s == null || len == 0)
                return 0;

            int res = 0;
            for (int i = 0; i < len; i++)
            {
                char iNextC = s[i + 1]; 
                switch (s[i])
                {                       
                    case 'I':
                        if (i < len - 1 && (iNextC == 'V' || iNextC == 'X'))
                        {
                            res -= 1;
                        }
                        else
                        {
                            res += 1;
                        }
                        break;
                    case 'V':
                        res += 5;
                        break;
                    case 'X':
                        if (i < len - 1 && (iNextC == 'L' || iNextC == 'C'))
                        {
                            res -= 10;
                        }
                        else
                        {
                            res += 10;
                        }
                        break;
                    case 'L':
                        res += 50;
                        break;
                    case 'C':
                        if (i < len - 1 && (iNextC == 'D' || iNextC == 'M'))
                        {
                            res -= 100;
                        }
                        else
                        {
                            res += 100;
                        }
                        break;
                    case 'D':
                        res += 500;
                        break;
                    case 'M':
                        res += 1000;
                        break;
                    default:
                        return 0;
                }
            }

            return res;
        }
    }
}
