using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode190_reverse_bits
{
    /// <summary>
    /// Leetcode 190: reverse bits
    /// http://www.cnblogs.com/grandyang/p/4321355.html
    /// source code is based on the blog
    /// http://www.cnblogs.com/grandyang/p/4321355.html
    /// 
    /// 首先将n右移i位，然后通过‘与’1来提取出该位，然后将其左移 (32 - i) 位，然后‘或’上结果res，就是其翻转后应该在的位置
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var test = reverseBits(4); 
        }

        /// <summary>
        /// the design is the following:
        /// first n right shift i bit, and then and operation with 1 to get its value; 
        /// left shift to (32 - i) bit, and then or operation with the res, which is the position which should be.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static uint reverseBits(uint n)
        {
            uint reverse = 0;

            for (int i = 0; i < 32; ++i)
            {
                //      or   get ith bit      move to reverse position
                reverse |= ((n >> i) & 1) << (31 - i);
            }

            return reverse;
        }
    }
}
