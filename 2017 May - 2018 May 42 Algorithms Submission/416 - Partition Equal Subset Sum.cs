public class Solution
{
    public bool CanPartition(int[] numbers)
    {
        // check edge case
        if (numbers == null || numbers.Length == 0)
        {
            return true;
        }

        // preprocess
        int volumn = 0;
        foreach (var num in numbers)
        {
            volumn += num;
        }

        if (volumn % 2 != 0)
        {
            return false;
        }

        int target = volumn /= 2;

        // dynamic programming defintion 
        bool[] dp = new bool[target + 1];

        // dynamic programming initialization
        dp[0] = true; // empty set, the sum is zero. 

        // dp transition
        for (int i = 0; i < numbers.Length; i++)
        {
            var visit = numbers[i];

            // for any sum bigger than visit value, current element in the array can contribute. 
            // if it is true, then continue; otherwise look up the value at sum - visit.
            for (int sum = target; sum >= visit; sum--)
            {
                // 0 1 backpack problem, include visit number or exclude the number. 
                dp[sum] = dp[sum] || dp[sum - visit];
            }
        }

        return dp[volumn];
    }
}