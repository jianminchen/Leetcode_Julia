/**
 * Definition for an interval.
 * public class Interval {
 *     public int start;
 *     public int end;
 *     public Interval() { start = 0; end = 0; }
 *     public Interval(int s, int e) { start = s; end = e; }
 * }
 */
public class Solution
{
    public IList<Interval> Insert(IList<Interval> intervals, Interval newInterval)
    {
        var result = new List<Interval>();

        foreach (var interval in intervals)
        {
            if (interval.end < newInterval.start)
            {
                result.Add(interval);
            }
            else if (interval.start > newInterval.end)
            {
                result.Add(newInterval);
                newInterval = interval;
            }
            else if (interval.end >= newInterval.start ||
                    interval.start <= newInterval.end)
            {
                newInterval = new Interval(
                    Math.Min(interval.start, newInterval.start),
                    Math.Max(newInterval.end, interval.end));
            }
        }

        result.Add(newInterval);

        return result;
    }
}