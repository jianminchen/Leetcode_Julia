public class Solution
{
    public int MaxProfit(int[] prices)
    {
        if (prices == null || prices.Length <= 1)
        {
            return 0;
        }

        var filtered = removeDuplicate(prices);
        if (filtered.Length <= 1)
        {
            return 0;
        }

        // work on filtered array
        int length = filtered.Length;

        int buyPrice = 0;

        bool cycleStart = false;

        int profit = 0;

        for (int i = 0; i < length; i++)
        {
            var current = filtered[i];
            bool isLastItem = i == (length - 1);

            bool isPeak1 = i == 0 && current > filtered[i + 1];
            bool isPeak2 = i > 0 && current > filtered[i - 1] &&
                (isLastItem || current > filtered[i + 1]);

            if (cycleStart && (isPeak1 || isPeak2)) // skip first peak
            {
                profit += current - buyPrice;
                cycleStart = false;
            }

            bool isBottom1 = i == 0 && current < filtered[i + 1];
            bool isBottom2 = i > 0 && current < filtered[i - 1]
                && (i + 1 < length) && current < filtered[i + 1];

            if (!cycleStart && (isBottom1 || isBottom2))
            {
                buyPrice = current;
                cycleStart = true;
            }
        }

        return profit;
    }

    private static int[] removeDuplicate(int[] prices)
    {
        var filtered = new List<int>();

        for (int i = 0; i < prices.Length; i++)
        {
            if (i == 0 || prices[i] != prices[i - 1])
            {
                filtered.Add(prices[i]);
            }
            else if (prices[i] == prices[i - 1])
            {
                continue;
            }
        }

        return filtered.ToArray();
    }
}