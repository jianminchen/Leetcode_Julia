using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace math
{
    class Program
    {
        static void Main(string[] args)
        {
            int cPrime1 = countPrimes2(10);
            int cPrime2 = countPrimes(100);
            int cPrime3 = countPrimes(1000);
        }

        /**
         * Latest update on June 22, 2015
         * Leetcode: 
         * source code: 
         * http://blog.csdn.net/angelazy/article/details/45561885
         * 二个优化: 1: 排除2的倍数
         *          2. 排除3的倍数
         *          依此类推
         *          还有, 就是, 如果不是素数, 那么有一个素数因子p, p*p<n
         *   我们知道2是最小的质数，那么2的倍数均不为质数（因为它们可以分解为一个数*2），所以我们可以将小于n的数中2的倍数，全部排除掉。
排除掉2的整数倍后，剩下的数中大于2的最小的数就是下一个质数，也就是3.
同样我们可以排除掉小于n的数中3的整数倍的数，得到下一个质数为5.
         *   这里还可以进行一个优化，即对于质数 p，排除掉p的整数倍后，剩下的元素中满足 p<k<p∗p的元素k均为质数。       
         * 
         */
        public static int countPrimes(int n)
        {
            if (n <= 2) return 0;

            bool[] p = new bool[n];  // julia comment: prime number array

            for (int i = 0; i < n; i++)
                p[i] = true;

            for (int i = 2; i * i < n; i++)  // filter 1
            {
                if (p[i])  // filter 2
                {
                    for (int j = 2; j * i < n; j++) // filter 3 
                        p[i * j] = false;
                }
            }

            int cnt = 0;
            for (int i = 2; i != n; i++)
                if (p[i]) cnt++;

            return cnt;
        }

        /**
         * Latest update: June 22, 2015
         * http://pisxw.com/algorithm/Count-Primes.html
         * 
         */
        public static int countPrimes2(int n)
        {
            if (n <= 2)
                return 0;
            bool[] flag = new bool[n];

            //首先对2进行画圈，然后去除到所有2的倍数
            flag[2] = false;
            for (int i = 3; i < n; i++)
            {
                if (i % 2 == 0)
                    flag[i] = true;
            }

            //对后面第一个没有被去除的数进行画圈，且去除其倍数
            for (int i = 3; i < n; i++)
            {
                if (flag[i] == false)
                {
                    if (i * i > n)
                        break;
                    else
                    {
                        for (int j = 2; j * i < n; j++)
                        {
                            flag[j * i] = true;
                        }
                    }
                }
            }

            //统计素数的个数
            int res = 0;
            for (int i = 2; i < n; i++)
            {
                if (flag[i] == false)
                    res++;
            }

            return res;
        }

        /**
         * Latest update: June 22, 2015 
         * Leetcode: count primes
         * 
         * http://www.zhuangjingyang.com/leetcode-count-primes/
         * Brute force solution
         * Exceed time limit, when n = 499979，就超时了
         * 
         */
        public static int countPrimesBruteForce(int n)
        {
            int count = 0;
            for (int i = 2; i < n; i++)
            {
                if (isPrime(i))
                    count++;
            }
            return count;
        }

        public static bool isPrime(int n){
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0)
                    return false;
            }

    	    Console.WriteLine(n + " is a prime");

    	    return true;
        }

        /**
         * Leetcode: count primes
         * http://blog.csdn.net/lisonglisonglisong/article/details/45309651
         * Good explanation about 厄拉多塞筛法(Sieve of Eeatosthese)
         * 
         */
        public static int countPrimes4(int n)
        {
            bool[] Del = new bool[n]; // 标记是否被划去
            Del[2] = false;

            // julia comment: every number is initialized by checking with %2
            for (int i = 3; i < n; ++i)
                if (i % 2 == 0)
                    Del[i] = true;  // 2的倍数全部划去
                else
                    Del[i] = false;

            
            for (int i = 3; i < n; i += 2)  // julia comment: skip even number
                if (!Del[i])  // 之后第一个未被划去
                {
                    if (i * i > n) break;  // 当前素数的平方大于n，跳出循环
                    for (int j = 2; i * j < n; ++j)
                        Del[i * j] = true;
                }

            int count = 0;
            for (int i = 2; i < n; ++i)
                if (!Del[i])
                    ++count;
            
            return count;
        }

       
    }
}
