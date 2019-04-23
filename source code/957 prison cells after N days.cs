using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _957_prison_cells_after_N_days
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// 957 prison cells after N days
        /// </summary>
        /// <param name="cells"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public int[] PrisonAfterNDays(int[] cells, int N)
        {
            var length = cells.Length;
            var current = new int[length];

            for (int i = 0; i < length; i++)
                current[i] = cells[i];

            var dict = new Dictionary<string, int>();
            var resultDict = new Dictionary<int, int[]>();

            var originalKey = string.Join(" ", current);

            dict.Add(string.Join(" ", current), 0);
            resultDict.Add(0, cells);

            int index = 1;

            int start = 0;
            int end = 0;

            while (true)
            {
                var next = new int[length];
                for (int i = 0; i < length; i++)
                {
                    var item = current[i];

                    if (i == 0 || i == length - 1)
                    {
                        next[i] = 0;
                    }
                    else
                    {
                        var previous = current[i - 1];
                        var nextNo = current[i + 1];
                        next[i] = previous == nextNo ? 1 : 0;
                    }
                }

                var key = string.Join(" ", next);
                if (dict.ContainsKey(key))
                {
                    start = dict[key];
                    end = index;
                    break;
                }

                dict.Add(key, index);
                resultDict.Add(index, next);

                index++;

                // next iteration 
                for (int i = 0; i < length; i++)
                    current[i] = next[i];
            }

            if (N < end)
            {
                return resultDict[N];
            }
            else
            {
                var no = (N - start) % (end - start);
                return resultDict[start + no];
            }
        }
    }
}
