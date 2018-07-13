public class Solution
{
    public IList<int> TopKFrequent(int[] nums, int k)
    {
        // O(n)
        // Build up a dictionary that stores the number of references to each value in nums.
        var dic = new Dictionary<int, int>(nums.Length);
        foreach (int value in nums)
        {
            if (dic.ContainsKey(value))
            {
                dic[value]++;   // Increase the noOfReferences for this value.
            }
            else
            {
                dic[value] = 1; // This is the first reference to this value.
            }
        }

        // O(n)
        // Create an array, which will later be sorted, and which contains the noOfReferences we just collected.
        // (Later, we will will sort the array and then find the k most referenced keys.)
        int[] arrayOfNoOfReferences = new int[dic.Keys.Count];
        int i = 0;
        foreach (var value in dic.Values)
        {
            arrayOfNoOfReferences[i] = value;
            i++;
        }

        // O(n log n)
        Array.Sort(arrayOfNoOfReferences);

        // O(n)
        // Now we have a sorted array of noOfReferences.
        // Find the kth highest noOfReferences: (Assumption: The items each appear a different number of times.)
        var kthNoOfReferences = arrayOfNoOfReferences[arrayOfNoOfReferences.Length - k];
        // Anything referenced more than this kthNoOfReferences should be included in our results. 
        var results = new List<int>();
        foreach (var key in dic.Keys)
        {
            int noOfReferences = dic[key];
            if (noOfReferences >= kthNoOfReferences)
            {
                results.Add(key);
            }
        }
        return results;

    }
}