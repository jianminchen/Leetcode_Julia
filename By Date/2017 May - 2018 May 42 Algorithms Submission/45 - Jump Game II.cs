public class Solution
{
    public int Jump(int[] nums)
    {
        int lastIndex = nums.Length - 1;
        int step = 0;
        int i;

        while (lastIndex != 0)
        {
            for (i = 0; i < lastIndex; i++)
                if (i + nums[i] >= lastIndex)
                    break;
            if (i == lastIndex)
                return -1;
            lastIndex = i;
            step++;
        }

        return step;
    }
}