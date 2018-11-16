using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _939_minimum_area_rectangle
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// first submission:
        /// failed test case: 
        /// [[3,2],[3,1],[4,4],[1,1],[4,3],[0,3],[0,2],[4,0]]
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public int MinAreaRect(int[][] points)
        {
            if (points == null)
                return 0;

            var rows = points.Length;
            var columns = points[0].Length;

            var map = new HashSet<string>();
            for (int row = 0; row < rows; row++)
            {
                var xValue = points[row][0];
                var yValue = points[row][1];

                map.Add(getKey(xValue, yValue));                
            }

            var minArea = -1; 
            for (int index1 = 0; index1 < rows - 1; index1++)
            {
                var x1 = points[index1][0];
                var y1 = points[index1][1];

                map.Add(getKey(x1, y1));   

                for (int index2 = index1 + 1; index2 < rows - 1; index2++)
                {
                    var x2 = points[index2][0];
                    var y2 = points[index2][1];

                    map.Add(getKey(x2, y2));   

                    if (x1 == x2 || y1 == y2)
                        continue;

                    if(map.Contains(getKey(x1, y2)) && map.Contains(getKey(x2,y1)))
                    {
                        var area = Math.Abs((x1 - x2) * (y1 - y2));
                        minArea = minArea == -1 ? area : (area < minArea ? area : minArea);
                    }
                }
            }

            return minArea == -1 ? 0 : minArea; // failed test case
        }

        private static string getKey(int x, int y)
        {
            return x + "-" + y; 
        }
    }
}
