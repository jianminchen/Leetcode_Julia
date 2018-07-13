public class Solution
{
    public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
    {

        if (t < 0)
        {
            return false;
        }

        var binarySearchTree = new SortedSet<long>();
        for (int i = 0; i < nums.Length; i++)
        {
            var visit = (long)nums[i];

            if (binarySearchTree.GetViewBetween(visit - t, visit + t).Count > 0)
            {
                return true;
            }

            binarySearchTree.Add(nums[i]);

            // remove node
            if (i >= k)
            {
                // move the node out of tree by the range - k, one node a time
                var nodeKStepAway = nums[i - k];

                binarySearchTree.Remove(nodeKStepAway);
            }
        }

        return false;
    }
}