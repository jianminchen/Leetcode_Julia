public class Solution
{
    public IList<IList<int>> CombinationSum(int[] numbers, int target)
    {
        var subsets = new List<IList<int>>();
        var subset = new List<int>();

        findSubsetWithSum(subsets, subset, numbers, target, 0);

        return subsets;
    }

    /// <summary>
    /// using recursive function to conduct depth first search
    /// </summary>
    /// <param name="allSubsets"></param>
    /// <param name="subset"></param>
    /// <param name="numbers"></param>
    /// <param name="remaining"></param>
    /// <param name="start"></param>
    private void findSubsetWithSum(
        IList<IList<int>> allSubsets,
        IList<int> subset,
        int[] numbers,
        int remaining,
        int start)
    {
        // boundary check - sum value
        if (remaining < 0)
        {
            return;
        }

        // base case 
        if (remaining == 0)
        {
            allSubsets.Add(subset);
            return;
        }

        // depth first search using recusive function 
        for (int i = start; i < numbers.Length; i++)
        {
            var visit = numbers[i];
            var current = i;

            var newList = new List<int>(subset);
            newList.Add(visit);
            findSubsetWithSum(allSubsets, newList, numbers, remaining - visit, current);
        }
    }
}