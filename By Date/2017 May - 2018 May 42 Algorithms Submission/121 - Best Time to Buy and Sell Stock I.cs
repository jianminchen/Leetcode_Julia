public class Solution
{
    public int MaxProfit(int[] prices)
    {
        if (prices == null || prices.Length == 0)
        {
            return 0;
        }

        int minimumPrice = prices[0];
        int maxProfit = 0;

        for (int i = 1; i < prices.Length; i++)
        {
            var current = prices[i];

            bool currentIsBigger = current > minimumPrice;
            bool currentIsMinimum = current < minimumPrice;

            if (currentIsBigger)
            {
                var currentProfit = current - minimumPrice;
                bool currentIsMax = currentProfit > maxProfit;

                maxProfit = currentIsMax ? currentProfit : maxProfit;
            }

            if (currentIsMinimum)
            {
                minimumPrice = prices[i];
            }
        }

        return maxProfit;
    }
}