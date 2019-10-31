using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _475_heaters
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// 475 heaters
        /// </summary>
        /// <param name="houses"></param>
        /// <param name="heaters"></param>
        /// <returns></returns>
        public int FindRadius(int[] houses, int[] heaters)
        {
            if (houses  == null || houses.Length == 0 || 
                heaters == null || heaters.Length == 0)
            {
                return 0; 
            }

            var minumumRadius = Int32.MinValue;

            foreach (var item in houses)
            {
                // For each house, find minimum distance to one of heaters
                var minimumValue = Int32.MaxValue; 
                foreach(var heater in heaters)
                {
                    var current = Math.Abs(item - heater);
                    minimumValue = current < minimumValue ? current : minimumValue; 
                }

                // From all houses, choose maximum one from the distance to heater.
                if (minimumValue > minumumRadius)
                {
                    minumumRadius = minimumValue;
                }
            }

            return minumumRadius; 
        }
    }
}
