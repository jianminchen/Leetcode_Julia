using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1024_video_stitching___II
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// study code - weekly contest rank No. 1 Dymonchyk
        /// https://leetcode.com/contest/weekly-contest-131/ranking
        /// 
        /// </summary>
        /// <param name="clips"></param>
        /// <param name="T"></param>
        /// <returns></returns>
        public static int VideoStitching(int[][] clips, int T)
        {
            int last = 0;
            int count = 0;

            // brute force solution is a good idea. 
            while (true)
            {
                if (last >= T)
                {
                    break;
                }

                bool found = false;
                int maxEnd = -1;

                for (int i = 0; i < clips.Length; ++i)
                {
                    if (clips[i][0] <= last)
                    {
                        maxEnd = Math.Max(maxEnd, clips[i][1]);
                    }
                }

                if (maxEnd > last)
                {
                    last = maxEnd;
                    ++count;
                    found = true;
                }

                if (!found) break;
            }

            if (last >= T)
            {
                return count;
            }

            return -1;
        }
    }
}
