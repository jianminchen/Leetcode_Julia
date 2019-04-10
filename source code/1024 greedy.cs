using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1024_video_stitching
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTestcase1();
        }

        public static void RunTestcase1()
        {
            //[0,2],[4,6],[8,10],[1,9],[1,5],[5,9]
            var clips = new int[6][]{
                new int[]{0, 2},
                new int[]{4, 6},
                new int[]{8, 10},
                new int[]{1, 9},
                new int[]{1, 5},
                new int[]{5, 9}
            };

            var result = VideoStitching(clips, 10); 
        }

        public class IntervalComparer : IComparer  
        {
            // Call CaseInsensitiveComparer.Compare with the parameters reversed.
            int IComparer.Compare(object x, object y)  
            {
                var x1 = (int[])x;
                var y1 = (int[])y;

                if (x1[0] != y1[0])
                {
                    return x1[0] - y1[0];
                }
                else
                {
                    return x1[1] - y1[1]; 
                }
            }
        }
        /// <summary>
        /// The idea is from 
        /// http://www.noteanddata.com/leetcode-5019-Video-Stitching-java-solution-note.html
        /// 1. sort clips by start time;
        /// 2. find the first interval with start time is 0
        /// 3. In all intervals with start time 0, it is best to find largest end time;
        /// 4. Find the first end time, then search all start <= endTime, similar idea in step 3. 
        /// </summary>
        /// <param name="clips"></param>
        /// <param name="T"></param>
        /// <returns></returns>
        public static int VideoStitching(int[][] clips, int T)
        {
            Array.Sort(clips, new IntervalComparer());

            int count = 0;
            int currentEnd = 0;
            var length = clips.Length;

            int index = 0;
            while(index < length)
            {
                if(clips[index][0] > currentEnd) 
                {
                    return -1;
                }

                int maxend = currentEnd;

                // while one clip's start is before or equal to current end
                while (index < length && clips[index][0] <= currentEnd)
                {
                    // find out the one with the max possible end
                    maxend = Math.Max(maxend, clips[index][1]); 

                    index++;
                }

                count++;
                currentEnd = maxend;
                if(currentEnd >= T) 
                {
                    return count;    
                }
            }

            return -1;
        }
    }
}
