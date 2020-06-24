using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_longest_substring_2015_4
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// code review on June 24, 2020
        /// code written on April 2015
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstring(string s)
        {

            int start = 0, end = 0;
            int maxLen = 0;
            int maxStart = 0, maxEnd = 0;

            bool setOneMaximum = false;

            int[] lastSeen = new int[256];

            for (int i = 0; i < 256; i++)
                lastSeen[i] = 0;

            for (int i = 0; i < s.Length; i++)
            {
                char cur = s[i];

                bool firstVisit = lastSeen[cur] == 0;

                if (firstVisit)
                {
                    //first time to visit cur, add it to the array, keep the log
                    lastSeen[cur]++;
                    end++;

                    int lastOne = s.Length - 1;
                    bool isLastOne = (i == lastOne);
                    if (isLastOne)
                    {
                        // need to compare the one with setOneMaximum
                        // test case: string testStr = "abcdcefg";   
                        // string ends with non-duplicate char
                        if (setOneMaximum)
                        {
                            int curLen = end - start;
                            bool curLonger = curLen > maxLen;
                            if (curLonger)
                            {
                                maxLen = curLen;
                                maxStart = start;
                                maxEnd = end;
                            }
                        }
                    }
                }
                else
                {
                    // this is duplicate one. Second time to visit 
                    // 1. First thing, compare to the largest one
                    char duplicateCh = cur;
                    end++;
                    if (setOneMaximum)
                    {
                        // need to compare the current one with maximum one, and then keep the longer one
                        int curLen = end - start - 1;
                        bool curLonger = curLen > maxLen;
                        if (curLonger)
                        {
                            maxLen = curLen;
                            maxStart = start;
                            maxEnd = end;
                        }
                    }
                    else
                    {
                        // First time, need to set up maximum one 
                        setOneMaximum = true;
                        maxLen = end - start - 1;   // bug2: end-start-1, not end-start
                        maxStart = start;
                        maxEnd = end;
                    }

                    // Need to move the start postion of new possible string 
                    int startPos = start;
                    for (int j = startPos; j < end; j++)
                    {
                        char removeCh = s[j];
                        if (s[j] != duplicateCh)
                        {
                            lastSeen[removeCh] = 0;  // bug: removeCh, not j
                            start++;
                        }

                        if (removeCh == duplicateCh)  // remove the first duplicated char as well, then stop 
                        {
                            lastSeen[removeCh] = 1;   // bug: removeCh, not j
                            start++;  // make sure to adjust the start position
                            break;
                        }
                    }
                }
            }

            // For this case, no duplicate char in the string - only do the work once
            if (!setOneMaximum)
            {
                maxLen = s.Length;
                maxStart = 0;
                maxEnd = s.Length;
            }

            return maxLen;
        }
    }
}
