using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _70CombinationStairs
{
    class climbingStairs
    {
        /**
         * Latest update:
         * July 28, 2015
         * 
         */
        static void Main(string[] args)
        {
            /**
             * test case: 
             * 
             */
            int r1 = climbStairs_A(1);
            int r2 = climbStairs_A(2);
            int r3 = climbStairs_A(3);
            int r4 = climbStairs_A(4);
            int r5 = climbStairs_A(5);

            /*
             * 
             */
            int res = climbStairs_R(4);
            int res2 = climbStairs_R(5);
            int res3 = climbStairs_R(6);
        }

        /**
         * Leetcode: climb stairs
         * problem statement: 
         * You are climbing a stair case. It takes n steps to reach to the top.
         * Each time you can either climb 1 or 2 steps. In how many distinct ways 
         * can you climb to the top?
         * source code from blog:
         * https://github.com/xiaoxq/leetcode-cpp/blob/master/src/ClimbingStairs.cpp
         * julia's comment: 
         * 1. while (--n)    C++ code causes compile error
         *  " cannot implicit convert int to bool "
         *    make change to while (--n >0 )
         */
        public static int climbStairs_A(int n)
        {
            if (n < 1)
                return 0;

            // the last step has 1 choice
            int nextStepChoice = 1,
                nextNextStepChoice = 1;
            // n-1 steps

            while (--n > 0)  // julia's update                            
            {
                int curStepChoice = nextStepChoice + nextNextStepChoice;
                nextNextStepChoice = nextStepChoice;
                nextStepChoice = curStepChoice;
            }
            return nextStepChoice;
        }

        /*
         * source code from blog:
         * http://blog.csdn.net/kenden23/article/details/17377869
         * comment from blog: 
         * 简单题目，相当于fibonacci数列问题，难点就是要会思维转换，转换成为
         * 递归求解问题，多训练就可以了。
           所以这种类型的题目相对于没有形成递归逻辑思维的人来说，应该算是难题。
           我的想法是：
           每次有两种选择，两种选择之后又是各有两种选择，如此循环，正好是递归
         * 求解的问题。
           写成递归程序其实非常简单，三个语句就可以：
         * 但是递归程序一般都是太慢了，因为像Fibonacci问题一样，重复计算了很多
         * 分支，我们使用动态规划法填表，提高效率，程序也很简单，如下：
         * Julia's comment:
         * 
         * */
        public static int climbStairsRecur(int n)
        {
            if (n == 1) return 1;
            if (n == 2) return 2;
            return climbStairsRecur(n - 1) + climbStairsRecur(n - 2);
        }

        /*
         * source code from blog:
         * http://blog.csdn.net/kenden23/article/details/17377869
         * julia's comment: 
         *  convert the code from C++ to C#
         */
        public int climbStairs(int n)
        {
            int[] res = new int[n + 1];
            res[0] = 1;
            res[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                res[i] = res[i - 1] + res[i - 2];
            }
            return res[n];
        }

        /*
         * source code from blog:
         * http://blog.csdn.net/kenden23/article/details/17377869
         * comment from blog:
         * 动态规划法用熟了，高手就需要节省空间了，如下
         * 
         * julia's comment: 
         * first time see using % in order to save variables used. 
         * */
        int climbStairs_B(int n)
        {
            int[] res = new int[3];
            res[0] = 1;
            res[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                res[i % 3] = res[(i - 1) % 3] + res[(i - 2) % 3];
            }
            return res[n % 3];
        }

        /*
         *  source code from blog:
         *  http://blog.csdn.net/kenden23/article/details/17377869 
        当然，不使用上面的数组也是可以的，直接使用三个变量保存结果也是一样的。
         * */
        int climbStairs_C(int n)
        {
            if (n < 4) return n;
            int a = 2, b = 3, c = 5;

            for (int i = 5; i <= n; i++)
            {
                a = c;
                c = b + c;
                b = a;
            }
            return c;
        }

        /*
         * source code from blog:
         * http://yucoding.blogspot.ca/2012/12/leetcode-question-15-climbing-stairs.html
           The easiest idea is a Fibonacci number. f(n) = f(n-1) + f(n-2). 
         * The nth stairs is from either n-1th the stair or the n-2th stair.
         * However recursive is time-consuming. We know that recursion can 
         * be written in loop, the trick here is not construct a length of 
         * n array, only three element array is enough.
         * 
         * julia's comment:
         * 1. array size dicussion - great idea to use 3 elements instead
         *    of array size n (+3 points)
         * 2. Using dynamic programming, instead of recursion (+2 points)
         * 3. Save a tmp variable in for loop (+1 point) 
         */
        public static int climbStairs_D(int n)
        {
            if (n < 3)
            {
                return n;
            }

            int f1 = 1;
            int f2 = 2;

            for (int i = 3; i <= n; i++)
            {
                f2 = f1 + f2;
                f1 = f2 - f1;
            }

            return f2;
        }

        /*
         * source code from blog:
         * http://yucoding.blogspot.ca/2012/12/leetcode-question-15-climbing-stairs.html
         * julia's comment: 
         * recursion can be written in loop, using iterative solution;
         * To make it better, avoid constructing a length of 
         * n array, only three element array is enough.
         * 
         * 1. add one more temporary varaible tmp
         */
        public static int climbStairs_E(int n)
        {
            if (n < 3)
            {
                return n;
            }

            int f1 = 1;
            int f2 = 2;

            for (int i = 3; i <= n; i++)
            {
                int tmp = f2;

                f2 = f1 + f2;
                f1 = tmp;
            }

            return f2;
        }

        /*
         * source code from blog:
            http://www.cnblogs.com/springfor/p/3886576.html
         * comment from blog: 
         * 这道题就是经典的讲解最简单的DP问题的问题。

           假设梯子有n层，那么如何爬到第n层呢，因为每次只能怕1或2步，那么爬到
         * 第n层的方法要么是从第n-1层一步上来的，要不就是从n-2层2步上来的，所以
         * 递推公式非常容易的就得出了：

            dp[n] = dp[n-1] + dp[n-2] 

            如果梯子有1层或者2层，dp[1] = 1, dp[2] = 2，如果梯子有0层，自然dp[0] = 0 
         * julia's comment: 
         * 1. The discussion of dp[0]=0 make sense. 
         */
        public int climbStairs_F(int n)
        {
            if (n == 0 || n == 1 || n == 2)
                return n;

            int[] dp = new int[n + 1];
            dp[0] = 0;
            dp[1] = 1;
            dp[2] = 2;

            for (int i = 3; i < n + 1; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            return dp[n];
        }

        /*
         * source code from blog:
         * http://siddontang.gitbooks.io/leetcode-solution/content/dynamic_programming/climbing_stairs.html
         * comment from blog:
         * 这道题目其实就是斐波那契数列问题，题目比较简单，我们很容易就能列出dp方程

            dp[n] = dp[n - 1] + dp[n - 2]

            初始条件dp[1] = 1, dp[2] = 2。
         * 
         * julia's comment: 
         * 1. C# complains that "use of unsigned local varaible fn" when fn is declared without 
         * initilization; so change "int fn = 0" instead. 
         * 2. notice that three variables are defined as f1, f2, fn, not f3; this is a smart tip. 
         * 3. n n-1 n-2 is represented as f2, f1, fn? little confusion about this name number
         * guessing:
         *             n    n-1  n-2
         *  numbers:   n     1    2
         *  varaible:  fn   f1   f2
         */
        public static int climbStairs_G(int n)
        {
            int f1 = 2;
            int f2 = 1;

            if (n == 1)
                return f2;
            else if (n == 2)
                return f1;

            int fn = 0;
            for (int i = 3; i <= n; i++)
            {
                fn = f1 + f2;
                f2 = f1;
                f1 = fn;
            }

            return fn;
        }

        /*
         * source code from blog:
        http://blog.unieagle.net/2012/08/26/leetcode%E9%A2%98%E7%9B%AE%EF%BC%9Aclimbing-stairs/
         * comment from blog:
         * 一开始是用简单的方法递归求解，程序很快完成，通过了小集合测试，但是大集合超时；
           然后发现了其中的规律，实际上就是一个x(n) = x(n-1) + x(n-2)的数列，
         * 又叫斐波纳契数列（Fibonacci Sequence）。
         * small 8ms, large 超时
         */
        public static int climbStairs_Recursive_H(int n)
        {
            if (n == 1)
                return 1;

            if (n == 2)
                return 2;

            //first take 1 step
            int first1 = climbStairs_Recursive_H(n - 1);
            //first take 2 step
            int first2 = climbStairs_Recursive_H(n - 2);
            return first1 + first2;
        }

        /*
            source code from blog:
            http://blog.unieagle.net/2012/08/26/leetcode%E9%A2%98%E7%9B%AE%EF%BC%9Aclimbing-stairs/
         *  comment from blog:
         *  small 0ms, large 4ms
         */
        int climbStairs_I(int n)
        {
            // Start typing your C/C++ solution below
            // DO NOT write int main() function
            int last = 0;
            int cur = 1;

            for (int i = 1; i <= n; ++i)
            {
                int temp = cur;
                cur = last + cur;
                last = temp;
            }

            return cur;
        }

        /*
         * source code from blog:
        http://my.oschina.net/u/811399/blog/141550
         * 
         * julia's comment: 
         * 1. Fibonacci formula can be looked up through this web page:
         * https://www.math.hmc.edu/funfacts/ffiles/10002.4-5.shtml
         * 2. When to use the formula? 
         */
        public int climbStairs_J(int n)
        {
            double s = Math.Sqrt(5);

            double tmp1 = Math.Pow(0.5 + s / 2, (double)n + 1);
            double tmp2 = Math.Pow(0.5 - s / 2, (double)n);

            return (int)Math.Floor(1 / s * (tmp1 - tmp2));
        }

        /*
         * source code from blog:
         * http://tech-wonderland.net/blog/leetcode-climbing-stairs.html
         * comment from the blog:
         * This is a very simple dp problem, consider the last steps we 
         * could take, we could take either 1 or 2 steps to reach the top, 
         * let f[n] denote   the number of different ways we climb to step n, 
         * then we have f[n] = f[n-1] + f[n-2], that is, we could take either 
         * 1 or 2 steps to reach n, obviously, this is the same formula as 
         * Fibonacci numbers, it could be solved in linear time and in constant
         * space. The following is the code accepted by LeetCode OJ to 
         * pass this Climbing Stairs problem:
         * 
         * julia's comment: 
         * 1. 3 local variables, a, b, c is defined; this is best solution so far I know. 
         * 2. The code is simple on base case, n<=1 is base case'
         * 3. 3 variable initialization is simple, all from 1; no calculation involved; So, it is beter
         *    than version climbStairs_G(...) base case, and varialbe definition. 
         * 4. Julia, please memorize this verison. 
         * 
         */

        int climbStairs_K(int n)
        {

            if (n <= 1) return 1;

            int a = 1, b = 1, c = 1;

            for (int i = 2; i <= n; ++i)
            {
                c = a + b;
                a = b;
                b = c;
            }

            return c;
        }

        /*
         * source code from blog:
         * http://tech-wonderland.net/blog/leetcode-climbing-stairs.html
         * comment from blog:
         * Furthermore, mathematically, we do have a closed form formula for calculating 
         * the n-th number in the Fibonacci sequence:
            formula  or closed form see the web page: 
            http://tech-wonderland.net/blog/leetcode-climbing-stairs.html
            So the following is the implementation based on the above formula 
            F(n) = ( phi^n – (1-phi)^n ) / sqrt(5)             

            which is also accepted by LeetCode OJ and can pass all the test cases for this 
            Climbing Stairs problem:
         * 
         * julia's comment:
         * 1. it makes no sense to save two local variables, julia adds two variables: tmp1 and tmp2 
         */
        int climbStairs_L(int n)
        {
            ++n;

            double root5 = Math.Sqrt(5);
            double phi = (1 + root5) / 2;

            double tmp1 = Math.Pow(phi, n);
            double tmp2 = Math.Pow(1 - phi, n);

            return (int)Math.Floor((tmp1 - tmp2) / root5);
        }

        /*
            source code from blog: 
            http://www.programering.com/a/MjN0kTMwATE.html   
         
            comment from blog:
            Direction: This is a Daofeibolaqi sequence problem. See the Fibonacci sequence will 
            naturally think of using recursion, but here the recursive efficiency is very low, 
            the number of honor calculation is increasing very fast, directly led to the emergence 
            of TLE (Time Limit Exceeded) error. This is because when the recursive many value 
            calculations have been repeated several times, according to the "C" and the pointer on 
            the Fibonacci sequence is introduced, in the n = 30, Fibonacci (3) values were calculated 
            317811 times. This is very terrible, so I'm using iterative method to write a set of code. 
            The iterative method is relatively simple, set the initial f (1) and f (2) values, the 
            results at each iteration two times before the addition as a result. The following 
            recursive code and code.
         * 
         *   julia's comment:
         *   1. change the variable to make it easy to read, abstract the variable name. 
         * */

        public static int climbStairs_M(int n)
        {
            //int CurrChoice, OlderChoice, OldestChoice;  -> from left to right direction 
            int cur, old, oldest;

            cur = old = oldest = 1;

            if (n == 0) return 1;
            if (n == 1) return 1;

            while (n > 1)
            {
                // move from left to right
                oldest = old;
                old = cur;
                cur = old + oldest;

                n--;
            }
            return cur;
        }

        /*
         *  source code from blog:
            http://www.acmerblog.com/leetcode-solution-climbing-stairs-6285.html
         *  comment from blog:
         *  设$f(n)$表示爬$n$阶楼梯的不同方法数，为了爬到第$n$阶楼梯，有两个选择：

            \item 从第$n-1$阶前进1步；
            \item 从第$n-1$阶前进2步；

            因此，有$f(n)=f(n-1)+f(n-2)$。

            这是一个斐波那契数列。

            方法1，递归，太慢；方法2，迭代。

            方法3，数学公式。斐波那契数列的通项公式为 
            $a_n=\dfrac{1}{\sqrt{5}}\left[\left(\dfrac{1+\sqrt{5}}{2}\right)^n-\left(\dfrac{1-\sqrt{5}}{2}\right)^n\right]$。
         * 迭代，时间复杂度O(n)，空间复杂度O(1)
         * 
         * julia's comment:
         * 1. The code is interesting, if n<1, then, return 1; 
         *    no explicit base case discussion at the begining of function. 
         *    
         * 2. two local variables, instead of 3; prev, cur
         *    in the for loop, there is a variable: tmp
         * 3. best solution in 3 variables versions, all versions
         */

        public static int climbStairs_N(int n)
        {

            int prev = 0;
            int cur = 1;

            for (int i = 1; i <= n; ++i)
            {

                int tmp = cur;

                cur += prev;
                prev = tmp;
            }

            return cur;
        }

        /*
        source code from blog: 
         * http://www.acmerblog.com/leetcode-solution-climbing-stairs-6285.html
           数学公式，时间复杂度O(1)，空间复杂度O(1)
        julia's comment:
         * 1. C# compile error: the expression assigned to s must be constant.
        */
        public static int climbStairs_O(int n)
        {

            //const double s = Math.Sqrt(5);
            double s = Math.Sqrt(5);

            return (int)Math.Floor((Math.Pow((1 + s) / 2, n + 1) + Math.Pow((1 - s) / 2, n + 1)) / s + 0.5);
        }

        /*
         * source code from blog:
         * http://bangbingsyb.blogspot.ca/2014/11/leetcode-climbing-stairs.html
         * comment from the blog:
         * 简单秒杀DP题。加入ret[i]表示到达step i的方法数，由于step i只能从step i-1或step i-1分别爬1和2步到达，所以：

            1. ret[i] = ret[i-1] + ret[i-2]
            2. 起始条件：ret[1] = 1, ret[2] = 2
            3. 事实上由于ret[i]只由前两个结果决定，并不需要储存整个队列。
         * 
         *  Julia's comment:
         *  1. base case is questionable: P(0) = 0
         *  see the blog:
         *  http://www.kangry.net/blog/?type=article&article_id=204
         *  这里有个trick，若n=0，那么应该返回什么？从题意上来说，0个台阶应该有1种走法，
         *  那就是不需要走。而且若n=2，为使d[2] = d[1]+d[0]，那么d[0]也应该等于1。
         *  2. Other than that, the code is perfect; p1, p2 two variables, one variable in for loop: temp
         *  
         */
        public static int climbStairs_P(int n)
        {
            if (n <= 0) return 0;

            int p1 = 1, p2 = 1;

            for (int i = 2; i <= n; i++)
            {
                int temp = p1 + p2;

                p1 = p2;
                p2 = temp;
            }

            return p2;
        }

        /*
         * source code from blog:
         * http://www.jianshu.com/p/acb4ad26b4c4
         * comment from blog: 
         * 我们先用递归的角度来看看这个题目：

            int a =4;

            public static int climbStairsRecur(int n) {
                if (n == 1) return 1;
                if (n == 2) return 2;
                return climbStairsRecur(n-1) + climbStairsRecur(n-2);
            }

            首先我们看看： 如果 n=3 的话，我们就需要调用F(2)和F(1),恰好 F(2)=2 and F(1) =1, 
            所以 n=3 的话 F(3) =3
            这里相当于把one step 和 two step 看做一个base case (解决这个问题的最小子问题）

            当我们只有一步的时候，我们只有一种解法，如果我们是采取两步的策略，那么我们就有两种解法，
            第一种是直接取一步，第二种是取两步。所以F(2)=2

            因为在这里，所有的问题都只是考虑一步和两步的问题。所以只有两种情况。
            再次说明：递归的base case 是最小的问题。

            Factorial:
            public staic int fac(int n) {
                if(n=0) return 1;
                else return n*fac(n-1);
            }

            在这里：
            base case =1;
            假设n =3
            那么程序内部的调用是： (这个是从上往下的过程）：
            3fac(2)  调用 fac(2)
            2fac(1)  调用 fac(1)
            1 * fac(0) 调用 fac(0) = base case

            这个时候fac(0) = 1，所以我们算出
            1 fac(0)=1;
            2 fac(1)=2;
            3* fac(2) =6; 这是一个从下往上的调用过程；
            但是递归的问题是在于重复计算：
            例如这里调用f(2), 就要重新算 f(1) 和 f(0)
            调用 f(1)，就要算f(0) 所以有些部分是重复的。

            所以在计算使用递归，时间复杂度是： O (2^n)
         
            例如斐波拉契数列：
            1 1 2 3 5 8 13 21 34 55...
            我们可以把前两位的数先储存起来：

            f[i] = f[i-1]+f[i-2];
            f[i-1] = f[1];
            f[i-2] = f[i-1];

           我们动态的把这个子问题 f[i]=f[i-1]+f[i-2]; 不断的存起来就可以计算了。
           这里我们看出 时间复杂度是： O(n) ,快了不少。
          
           回到了Climbing Stairs 这一题，我们怎么用动态规划的思想去做： 其实前面已经给出 
           递归(recursion)的方法，这里我们需要的是如何转换成DP而已，其实就是转换数组形式：
           因为我们知道最base 的 case 就是 f(1) == 1 f(2) == 2; 最小的子问题：
           然后我们按照斐波拉契数列的形式存储即可：

           stairs[i]=stairs[i-1]+stairs[i-2];
           假设n =3 , base[0]=1,base[1]=1
           那么stairs[2]=2我们就把这个解法已经存到数组里面了可以随时调用。 
           就不会再重复计算了。
          
          Julia's comment:
          1. the code is using array size of n, not most efficient;
          2. the comment is well written in Chinese. 
         */
        public static int climbStairs_Q(int n)
        {
            // write your code here
            int[] b = new int[n + 1];

            b[0] = 1;
            b[1] = 1;

            for (int i = 2; i < b.Length; i++)
            {
                b[i] = b[i - 1] + b[i - 2];
            }

            return b[n];
        }

        /*
         * source code from blog:
         * https://github.com/zwxxx/LeetCode/blob/master/Climbing_Stairs.cpp
         * comment from the blog:
         * Solution:

         * 
         * julia's comment: 
         */
        public static int[] memo = new int[100];

        public static int fib_R(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }

            memo[n - 1] = (memo[n - 1] == -1 ? fib_R(n - 1) : memo[n - 1]);
            memo[n - 2] = (memo[n - 2] == -1 ? fib_R(n - 2) : memo[n - 2]);

            return memo[n - 1] + memo[n - 2];
        }

        /*
         * source code from blog:
         * https://github.com/zwxxx/LeetCode/blob/master/Climbing_Stairs.cpp
         * comment from the blog:
         * Solution:

         * 
         * julia's comment: 
         * 1. C++ memset() <-> C# 
         * look up google "what is the equivalent of memset in C#"
         * C++
         * memset(memo, -1, sizeof(memo))
         * C#
         * Enumerable.Repeat(-1, 100).ToArray();
         * 
         */
        public static int climbStairs_R(int n)
        {

            memo = Enumerable.Repeat(-1, 100).ToArray();
            return fib_R(n);
        }


    }
}
