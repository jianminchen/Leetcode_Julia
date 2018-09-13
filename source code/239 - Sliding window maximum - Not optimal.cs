public class Solution
{
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        if (k < 1 || nums.Length == 0)
        {
            return new int[0];
        }

        var result = new int[nums.Length - k + 1];

        var map = new Dictionary<int, int>(nums.Length);

        var binarySearchTree = new SortedSet<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            var visit = nums[i];

            binarySearchTree.Add(visit);   // O(LogK)

            map[visit] = i;       // O(1), duplicate number will be updated with latest index

            if (i < k - 1)
            {
                continue;
            }

            if (i >= k && map[nums[i - k]] == (i - k))  // O(1)
            {
                var kStepAway = nums[i - k];

                binarySearchTree.Remove(kStepAway);    // O(logK)

                map.Remove(kStepAway);        // O(1)
            }

            result[i - k + 1] = binarySearchTree.Max;    // O(1)
        }

        return result;
    }
}