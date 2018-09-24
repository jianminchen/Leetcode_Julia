using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _788_Rotated_Digits___HashSet_IsSubsetOf
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// convert integer to string
        /// go over each string to determine if it is a good number
        /// 0, 1, 8 -> rotate to itself
        /// 2<->5
        /// 6<->9
        /// 3, 4, 7, 8 does not apply rotation
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public int RotatedDigits(int N)
        {
            if (N <= 0)
                return -1;

            int goodNumberCount = 0;

            var rotateToItself = new HashSet<char>("018".ToCharArray());
            var rotable = new HashSet<char>("2569018".ToCharArray());

            for (int i = 1; i <= N; i++)
            {
                var digits = new HashSet<char>(i.ToString().ToCharArray());
                if (digits.IsSubsetOf(rotable) && !digits.IsSubsetOf(rotateToItself))
                    goodNumberCount++;
            }

            return goodNumberCount;
        }
    }
}
