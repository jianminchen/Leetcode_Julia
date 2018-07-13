public class Solution
{
    public int MaxCoins(int[] numbers)
    {
        var length = numbers.Length;
        var size = length + 2;
        var preprocessed = new int[size];
        preprocessed[0] = 1;
        preprocessed[length + 1] = 1;

        for (int i = 0; i < length; i++)
        {
            preprocessed[i + 1] = numbers[i];
        }

        var dp = new int[size, size];

        for (int i = 0; i + 1 < size; i++)
        {
            // dp[i, i + 1] = preprocessed[i] * preprocessed[i + 1]; // bug - should be one instead
            //dp[i, i + 1] = 1; // bug - should be zero
            dp[i, i + 1] = 0;
        }

        for (int i = 0; i + 2 < size; i++)
        {
            dp[i, i + 2] = preprocessed[i] * preprocessed[i + 1] * preprocessed[i + 2];
        }

        for (int range = 3; range < size; range++)
        {
            for (int start = 0; start + range < size; start++)
            {
                // start, end -> calculate dp[start, end] 
                var end = start + range;
                dp[start, end] = calculateMaxByLastBurst(dp, start, end, preprocessed);
            }
        }

        return dp[0, size - 1];
    }
    private static int calculateMaxByLastBurst(int[,] dp, int start, int end, int[] numbers)
    {
        var max = int.MinValue;
        var startValue = numbers[start];
        var endValue = numbers[end];

        for (int lastBurst = start + 1; lastBurst < end; lastBurst++)
        {
            var current = startValue * endValue * numbers[lastBurst];
            current += dp[start, lastBurst] + dp[lastBurst, end];

            if (current > max)
                max = current;
        }

        return max;
    }
}