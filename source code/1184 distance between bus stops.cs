using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1184_distance_between_bus_stops
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// 1184 distance between bus stops
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="start"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public int DistanceBetweenBusStops(int[] distance, int start, int destination)
        {
            var total = distance.Sum();

            var smaller = Math.Min(start, destination);
            var bigger = Math.Max(start, destination);

            var partial = 0;
            for (int i = smaller; i < bigger; i++)
            {
                partial += distance[i];
            }

            return Math.Min(total - partial, partial);
        }
    }
}
