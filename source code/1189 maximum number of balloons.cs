using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1189_maximum_number_of_balloons
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// 1189 maximum number of balloons
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public int MaxNumberOfBalloons(string text)
        {
            if(text == null || text.Length == 0)
                return 0; 

            // "ablon" - balloon - b1, a1, l2, o2, n1
            var count = new int[5];

            foreach (var item in text)
            {
                switch (item)
                {
                    case 'a':
                        count[0]++;
                        break;
                    case 'b':
                        count[1]++;
                        break;
                    case 'l':
                        count[2]++;
                        break;
                    case 'o':
                        count[3]++;
                        break;
                    case 'n':
                        count[4]++;
                        break;
                }                              
            }

            count[2] /= 2;
            count[3] /= 2;

            return count.Min(); 
        }
    }
}
