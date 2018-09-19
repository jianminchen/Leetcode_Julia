using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _738_self_dividing_number
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = SelfDividingNumbers(1, 22); 
        }

        /// <summary>
        /// not include digit 0
        /// divividable by every digit in the number
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static IList<int> SelfDividingNumbers(int left, int right)
        {
            if (left > right)
                return new List<int>();

            var selfDividingNumbers = new List<int>(); 

            for (int original = left; original <= right; original++)
            {
                // not include 0 
                // every digit is dividable by i 
                var current = original; 
                bool failed = false;
                if(current == 0)
                    failed = true;

                while (!failed && current > 0)
                {
                    var digit = current % 10;
                    if (digit == 0 || original % digit != 0)
                    {
                        failed = true;
                    }
                    else
                    {
                        current = current / 10;
                    }
                }

                if (!failed)
                {
                    selfDividingNumbers.Add(original); 
                }
            }

            return selfDividingNumbers;
        }
    }
}
