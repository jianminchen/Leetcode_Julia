using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1037_valid_boomerang
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// code review May 8, 2019
        /// written in weekly contest, 34 minutes spent. 
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public bool IsBoomerang(int[][] points)
        {
            int rows = points.Length;
            int x1 = points[0][0];
            int y1 = points[0][1];

            int x2 = points[1][0];
            int y2 = points[1][1];

            int x3 = points[2][0];
            int y3 = points[2][1];

            if (twoPointsSame(x1, y1, x2, y2) ||
               twoPointsSame(x1, y1, x3, y3) ||
               twoPointsSame(x2, y2, x3, y3))
            {
                return false;
            }

            return ((y2 - y1) * (x3 - x1)) != ((x2 - x1) * (y3 - y1));

        }

        private static bool twoPointsSame(int x1, int y1, int x2, int y2)
        {
            return x1 == x2 && y1 == y2;
        }
    }
}
