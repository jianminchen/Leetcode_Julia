using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateParentheses_No22
{
    class GenerateParentheses_No22
    {
        static void Main(string[] args)
        {
            ArrayList test = generateParenthesis(2);
            ArrayList test2 = generateParenthesis(3); 
        }

        /*
         * blog:
         * http://blog.csdn.net/fightforyourdream/article/details/14159435
         * 要点：必须满足左括号数目要大等于右括号数目
         */
        /*
         *  http://blog.csdn.net/fightforyourdream/article/details/14159435
        一种新的写法，left，right表示手上有的左右括号括号数量。因此条件要改变一些。
         * */
        public static ArrayList generateParenthesis(int n)
        {
            ArrayList ret = new ArrayList();

            rec(n, n, "", ret);
            return ret;
        }  

        public static void rec(int left, int right, String s, ArrayList ret)
        {
            if (left == 0 && right == 0)
            {
                ret.Add(s);
                return;
            }

            if (left == 0)
            {
                rec(left, right - 1, s + ")", ret);
                return;
            }

            if (right == 0)
            {
                return;
            }

            if (left > right)
            {
                return;
            }

            rec(left - 1, right, s + "(", ret);
            rec(left, right - 1, s + ")", ret);
        }  
    }
}
