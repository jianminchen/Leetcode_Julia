using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _874_walking_robot_simulation
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        // clock wise, north, east, south, west
        private static int[][] directions = { new int[]{ -1, 0 }, new int[]{ 0, 1 }, new int[]{ 1, 0 }, new int[]{ 0, -1 } };

        /// <summary>
        /// the idea is from 
        /// https://leetcode.com/problems/walking-robot-simulation/discuss/155682/Logical-Thinking-with-Clear-Code
        /// </summary>
        /// <param name="commands"></param>
        /// <param name="obstacles"></param>
        /// <returns></returns>
        public int RobotSim(int[] commands, int[][] obstacles)  {

            var obstaclesRowToCols = new HashSet<string>();

            foreach (var obstacle in obstacles) {
                obstaclesRowToCols.Add(obstacle[0] + " " + obstacle[1]);
            }

            int x = 0;
            int y = 0;
            int direction = 1;
            int maxDistSquare = 0;

            for (int i = 0; i < commands.Length; i++) 
            {
                var current = commands[i];

                // turn left
                if (current == -2) 
                {
                    direction--;
                    if (direction < 0) { // -1 -> 3
                        direction += 4;
                    }
                }
                else if (current == -1) // turn right
                {
                    direction++;
                    direction %= 4; // 4 -> 0 
                } 
                else 
                {
                    int step = 0;
                    int incrementX = directions[direction][0];
                    int incrementY = directions[direction][1];

                    while (step < current &&
                    (!obstaclesRowToCols.Contains((x + incrementX) + " " + (y + incrementY)))) 
                        {
                            x += incrementX;
                            y += incrementY;

                            step++;
                        }
                }

                maxDistSquare = Math.Max(maxDistSquare, x * x + y * y);
            }

            return maxDistSquare;
        }
    }
}
