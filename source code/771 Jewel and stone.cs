using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _771_jewel_and_stone
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jewels"></param>
        /// <param name="stones"></param>
        /// <returns></returns>
        public int NumJewelsInStones(string jewels, string stones)
        {
            if (jewels == null || stones == null)
                return 0;

            var hashSet = new HashSet<char>(jewels);

            int count = 0;
            foreach (var item in stones)
            {
                if (hashSet.Contains(item))
                    count++;
            }

            return count;
        }
    }
}
