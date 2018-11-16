using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _939_minimum_area_rectangle_II
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Learn the time out issue related to using string as key: x + "-" + y
        /// The right away is to use hashset for y value, avoid string concatenation. 
        /// 
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public int MinAreaRect(int[][] points)
        {
            var map = new Dictionary<int, HashSet<int>>();

            foreach (var point in points) {
                var x = point[0];
                var y = point[1];

                if (!map.ContainsKey(x)) {
                    map.Add(x, new HashSet<int>());
                }

                map[x].Add(y);
            }

            int min = Int32.MaxValue;

            foreach (var p1 in points) {
                int x1 = p1[0];
                int y1 = p1[1];

                foreach (var p2 in points) {
                    int x2 = p2[0];
                    int y2 = p2[1];

                    if (x1 == x2 || y1 == y2) { // if have the same x or y
                        continue;
                    }

                    // find other two points                                     
                    if (map[x1].Contains(y2) && map[x2].Contains(y1)) { 
                        min = Math.Min(min, Math.Abs((x1 - x2) * (y1 - y2)));
                    }
                }
            }

            return min == Int32.MaxValue ? 0 : min;
        }
    }
}
