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
        var binarySearchTree = new SortedSet<Interval>(Comparer<Interval>.Create((a, b) => a.start == b.start ? a.end - b.end : a.start - b.start));

        // put all intervals into the binary search tree
        foreach (var node in intervals)
        {
            binarySearchTree.Add(node);
        }

        binarySearchTree.Add(newInterval);

        while (binarySearchTree.Count() > 0)
        {
            bool hasOnlyOneNode = binarySearchTree.Count() == 1;

            if (hasOnlyOneNode)
            {
                result.Add(binarySearchTree.Min);
                break;
            }

            // assuming that there are at least two nodes in the BST
            var node1 = binarySearchTree.Min;
            binarySearchTree.Remove(node1);

            var node2 = binarySearchTree.Min;
            binarySearchTree.Remove(node2);

            if (node1.end >= node2.start) // overlap - merge two intervals 
            {
                binarySearchTree.Add(new Interval(node1.start, Math.Max(node1.end, node2.end)));
            }
            else
            {
                // the first one goes to the output result, and the second will go back to the tree
                result.Add(node1);
                binarySearchTree.Add(node2);
            }
        }

        return result;
    }
}