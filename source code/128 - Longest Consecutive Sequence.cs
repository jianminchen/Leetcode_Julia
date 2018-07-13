public class Solution
{
    public int LongestConsecutive(int[] nums)
    {
        if (nums == null || nums.Length == 0)
        {
            return 0;
        }

        var binarySearchTree = new SortedSet<int>(nums);

        int maxSequence = 1;
        int currentSequence = 1;

        int lastNumber = int.MaxValue;

        foreach (var number in binarySearchTree)
        {
            if (lastNumber != int.MaxValue && number == lastNumber + 1)
            {
                currentSequence++;
            }
            else
            {
                currentSequence = 1;
            }

            maxSequence = Math.Max(maxSequence, currentSequence);
            lastNumber = number;
        }

        return maxSequence;
    }
}