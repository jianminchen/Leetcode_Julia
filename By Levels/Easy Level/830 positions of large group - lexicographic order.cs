using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_830____lexicograph_order
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
            var positions = new List<int[]>[26];

            var count = 0;
            var start = 0;
            for (int i = 0; i < length; i++)
            {
                var current = S[i];
                int index = current - 'a';

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
                        if (positions[index] == null)
                        {
                            positions[index] = new List<int[]>();
                        }

                        var size = positions[index].Count;

                        if (count == 2)
                        {
                            positions[index].Add(new int[] { start, i });
                        }
                        else
                        {
                            positions[index][size - 1][1] = i;
                        }
                    }
                }
            }

            foreach (var item in positions)
            {
                if (item == null) // bug found by online judge
                    continue;

                foreach (var subItems in item)
                {
                    var positionList = new List<int>();
                    positionList.Add(subItems[0]);
                    positionList.Add(subItems[1]);
                    largeGroups.Add(positionList);
                }
            }

            return largeGroups;
        }
    }
}
