using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_830_Positions_of_large_group
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = LargeGroupPositions("abcdddeeeeaabbbcd");  
        }

        public static IList<IList<int>> LargeGroupPositions(string S)
        {
            var largeGroups = new List<IList<int>>();
            if (S == null || S.Length == 0)
                return largeGroups;

            var length = S.Length;            

            var count = 0;
            var start = 0;
             
            for (int i = 0; i < length; i++)
            {
                var current = S[i];                

                if (i == 0 || current != S[i - 1])
                {
                    count = 0;
                    start = i;
                }
                else
                {
                    count++;
                    if (count >= 2)
                    {                        
                        var size = largeGroups.Count;

                        if (count == 2)
                        {                            
                            var list = new List<int>();
                            list.Add(start);
                            list.Add(i);

                            largeGroups.Add(list);
                        }
                        else
                        {
                            largeGroups[size - 1][1] = i;
                        }
                    }
                }
            }            

            return largeGroups;
        }
    }
}
