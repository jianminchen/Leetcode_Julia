using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strobogrammaticNumberII
{
    /// <summary>
    /// Strobogrammatic number II
    /// source code is based on
    /// https://segmentfault.com/a/1190000005991969
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// code review July 1, 2018
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public IList<String> FindRotate180UpsideDownLookSame(int n, int m)
        {
            var sameStrings = new List<string>();
            if (n == 0)
            {
                sameStrings.Add("");
                return sameStrings;
            }

            if (n == 1)
            {
                sameStrings.Add("0");
                sameStrings.Add("1");
                sameStrings.Add("8");

                return sameStrings;
            }

            var list = FindRotate180UpsideDownLookSame(n - 2, m);
            var result = new List<String>();

            for (int i = 0; i < list.Count(); i++)
            {
                var current = list[i];

                if (n != m)
                {
                    result.Add("0" + current + "0");
                }

                result.Add("1" + current + "1");
                result.Add("8" + current + "8");
                result.Add("6" + current + "9");
                result.Add("9" + current + "6");
            }

            return result;
        }

        public IList<String> findStrobogrammatic(int n)
        {
            return FindRotate180UpsideDownLookSame(n, n);
        }
    }
}
