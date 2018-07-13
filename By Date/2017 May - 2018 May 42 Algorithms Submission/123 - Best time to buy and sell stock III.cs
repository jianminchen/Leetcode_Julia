public class Solution
{
    public int MaxProfit(int[] prices)
    {
        if (prices.Length <= 1)
        {
            return 0;
        }

        int K = 2; // number of max transation allowed
        int maxProfit = 0;

        int length = prices.Length;

        var profit = new int[K + 1][];
        for (int i = 0; i < K + 1; i++)
        {
            profit[i] = new int[length];
        }

        for (int i = 1; i < K + 1; i++)
        { // at most K =2 transaction, i is number of transaction
            int maximum = profit[i - 1][0] - prices[0];  // maximum value for all possible purchase time
            for (int j = 1; j < prices.Length; j++)
            {    // j - time stamp
                // maximum subproblem
                var lastPurchaseTime = j;
                var current = profit[i - 1][lastPurchaseTime] - prices[lastPurchaseTime];
                maximum = Math.Max(maximum, current);

                // recurrence formula 
                profit[i][j] = Math.Max(profit[i][j - 1], prices[j] + maximum);

                maxProfit = Math.Max(profit[i][j], maxProfit);
            }
        }

        return maxProfit;
    }

}