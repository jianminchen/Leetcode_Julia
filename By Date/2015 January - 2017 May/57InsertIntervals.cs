using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _57InsertIntervals
{
    public class Interval {
      public int start;
      public int end;
      public Interval() { 
          start = 0; 
          end = 0; 
      }

      public Interval(int s, int e) { 
          start = s; 
          end = e; 
      }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
        /*
         * Given a set of non-overlapping intervals, insert a new interval into the intervals (merge if necessary).

            You may assume that the intervals were initially sorted according to their start times.

            Example 1:
            Given intervals [1,3],[6,9], insert and merge [2,5] in as [1,5],[6,9].

            Example 2:
            Given [1,2],[3,5],[6,7],[8,10],[12,16], insert and merge [4,9] in as [1,2],[3,10],[12,16].

            This is because the new interval [4,9] overlaps with [3,5],[6,7],[8,10].
         */
        /*
         * source code from blog:
         * http://simpleandstupid.com/2014/10/29/insert-interval-leetcode-%E8%A7%A3%E9%A2%98%E7%AC%94%E8%AE%B0/
         * 
         * 
         */
        public static ArrayList insert(ArrayList intervals, Interval newInterval)
        {
  
            ArrayList result = new ArrayList();

            foreach (Interval interval in intervals)
            {
                if(interval.end < newInterval.start){
                    result.Add(interval);
                }else if(interval.start > newInterval.end){
                    result.Add(newInterval);
                    newInterval = interval;        
                }else if(interval.end >= newInterval.start || 
                         interval.start <= newInterval.end){
                    newInterval = new Interval(
                        Math.Min(interval.start, newInterval.start), 
                        Math.Max(newInterval.end, interval.end));
                }
            }

            result.Add(newInterval); 
  
            return result;
        }

        /*
         * Julia's comment: 
         * 1. First, review the thought process:
         *    Go over all the intervals one by one; In each iteration, 
         *    compare to the two intervals.
         *    
         *    3 cases:
         *    case 1: the interval ends before new interval starts ->
         *      action: add the interval to the return result container
         *      
         *    case 2: the interval starts after new interval ends ->
         *      action: add new interval to the return result container, 
         *      and set the interval as the new one
         *      
         *    case 3: the interval overlaps with new interval -> 
         *      action: merge two intervals, and save it as 
         *      new interval. 
         *      
         * 2. Secondly, the code has a few of issues. Let us improve the code. 
         *    1. Abstract code, no more interval word in variable name; 
         *    2. Make it easy to go over test cases; 
         *       Case stands out easily in the code. 
         *       Code is more testable. 
         *    
         *    step 1: Make the function a simple math, not interval business.  
         *    step 2: Two intervals, R1 (stands for come and go one in the loop), 
         *    R2 (stand for extra range for next iteration). 
         *    
         *    tip: R2 one can be understandable by going through the test cases:
         *    Given [1,2],[3,5],[6,7],[8,10],[12,16], insert and merge [4,9] in as [1,2],[3,10],[12,16]
         *    R1       R2
         *    [1,2]    [4,9]   -> R1 is added to return container: {[1,2]}
         *    [3,5]    [4,9]   -> R1 and R2 overlaps, then, R2 = [3,9] 
         *    [6,7]    [3,9]   -> R1 and R2 overlaps, then, R2 = [3,9]
         *    [8,10]   [3,9]   -> R1 and R2 overlaps, then, R2 = [3, 10]
         *    [12, 16] [3,10]  -> R2 is added to return container, so it is {[1,2],[3,10]}; 
         *                        R2 = R1 = [12, 16]
         *    Now add R2 to the return container, so the result: {[1,2], [3,10], [12, 16]}
         */
        public static ArrayList insert_B(ArrayList arry, Interval newOne)
         {
             ArrayList result = new ArrayList();

             Interval R2 = newOne;         
             foreach (Interval R_i in arry)
             {
                 Interval R1 = R_i;   // Range 1, come and go                 

                 bool isR1R2    = R1.end   < R2.start;          // R1 is before R2
                 bool isR2R1    = R1.start > R2.end;            // R2 is before R1
                 bool needMerge = R1.end   >= R2.start ||       // R1 overlaps R2 
                                  R1.start <= R2.end;

                 if (isR1R2)
                 {
                     result.Add(R1);                     
                 }
                 else if (isR2R1)
                 {
                     result.Add(R2);
                     R2 = R1;  
                 }
                 else if (needMerge)
                 {
                     R2 = new Interval(
                         Math.Min(R1.start, R2.start),
                         Math.Max(R1.end, R2.end));
                 }
             }

             result.Add(R2);

             return result;
         }
    }
}
