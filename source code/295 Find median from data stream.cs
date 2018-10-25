using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _295_Find_median_from_Data_stream
{
    class MedianFinder
    {
       /** initialize your data structure here. */
    public MedianFinder() {
        
    }
    
    private int counter = 0;

        private SortedSet<int[]> setLow = new SortedSet<int[]>(
            Comparer<int[]>.Create((a, b) => a[0] == b[0] ? a[1] - b[1] : a[0] - b[0]));

        private SortedSet<int[]> setHigh = new SortedSet<int[]>(
            Comparer<int[]>.Create((a, b) => a[0] == b[0] ? a[1] - b[1] : a[0] - b[0]));
            
    public void AddNum(int num) {
        var newNum = new int[2] { num, counter++ };

            bool twoTreesSameSize = setLow.Count == setHigh.Count;          

            if (twoTreesSameSize)
            {
                if (setLow.Count == 0 || newNum[0] <= setLow.Max[0])
                {
                    setLow.Add(newNum);
                }
                else
                {
                    setHigh.Add(newNum);

                    // move the minimum number from setHigh to setLow. 
                    setLow.Add(setHigh.Min);
                    setHigh.Remove(setHigh.Min);
                }
            }
            else if (newNum[0] <= setLow.Max[0])
            {
                setLow.Add(newNum);

                // move the maximum number from setLow to setHigh
                setHigh.Add(setLow.Max);
                setLow.Remove(setLow.Max);
            }
            else
            {
                setHigh.Add(newNum);
            }
    }
    
    public double FindMedian() {
        if (setLow.Count == 0)
            {
                return 0;
            }

            if (setLow.Count == setHigh.Count)
            {
                return (setLow.Max[0] + setHigh.Min[0]) / 2d;
            }
            else
            {
                return setLow.Max[0];
            }
    }
    }
}
