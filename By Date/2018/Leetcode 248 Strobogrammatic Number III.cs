using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrobogrammaticNumberIII
{
    /// <summary>
    /// Leetcode 248: Strobogrammatic Number III
    /// source code is based on the blog:
    /// https://segmentfault.com/a/1190000005991969
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
        }

        public IList<String> FindRotate180UpsideDownLookSame(int n, int max)
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

            var list = FindRotate180UpsideDownLookSame(n - 2, max);
            var result = new List<String>();

            for (int i = 0; i < list.Count(); i++)
            {
                var current = list[i];

                if (n != max)
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

        public int strobogrammaticInRange(String low, String high) {
            int count = 0;

            var result = new List<String>();

            for (int i = low.Length; i <= high.Length; i++) {
                result.AddRange(FindRotate180UpsideDownLookSame(i, i));
            }

            foreach (string str in result) {
                var length     = str.Length;
                var lowLength  = low.Length;
                var highLength = high.Length;

                if (length == lowLength  && str.CompareTo(low)  < 0 ||
                    length == highLength && str.CompareTo(high) > 0)
                {
                    continue;
                }

                count++;
            }

            return count;
        }
    }
}
