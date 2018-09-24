using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _788.Rotated_Digits___HashSet
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int RotatedDigits(int N)
        {
            if (N <= 0)
                return -1;

            int goodNumberCount = 0;
            int index = 1;

            var nonRotate = new HashSet<char>("347".ToCharArray());
            var rotateToOther = new HashSet<char>("2569".ToCharArray());

            while (index <= N)
            {
                var numbers = index.ToString();

                // determine if there is any digit from 3, 4, 7, 8
                var isGoodNumber = true;
                var findOne = false;
                foreach (var item in numbers)
                {
                    if (nonRotate.Contains(item))
                    {
                        isGoodNumber = false;
                        break;
                    }

                    if (!findOne && rotateToOther.Contains(item))
                    {
                        findOne = true;
                    }
                }

                if (isGoodNumber && findOne)
                    goodNumberCount++;

                index++;
            }

            return goodNumberCount;
        }
    }
}
