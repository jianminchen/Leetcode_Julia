public class Solution
{
    public int LargestRectangleArea(int[] height)
    {
        var stack = new Stack<int>();

        var index = 0;
        var largestArea = 0;

        int length = height.Length; // 6

        while (index < length) // true; index = 1; index = 2;
        {
            //     stack empty            going upward
            if (stack.Count == 0 || height[stack.Peek()] < height[index]) // index = 1, false;
            {
                stack.Push(index++); // 0, index = 1;
            }
            else
            {
                // going downward and then pop stack, calculate rectangle.
                popStackAndCalculate(ref largestArea, stack, height, index);
            }
        }

        while (stack.Count > 0)
        {
            popStackAndCalculate(ref largestArea, stack, height, length);
        }

        return largestArea;
    }

    /// <summary>
    /// downward and then pop stack to calculate the rectangle
    /// </summary>
    /// <param name="largestArea"></param>
    /// <param name="stack"></param>
    /// <param name="height"></param>
    private static void popStackAndCalculate(ref int largestArea, Stack<int> stack, int[] height, int rightIndex)
    {
        int length = height.Length; // 6

        int lastHeight = height[stack.Pop()]; // 2
        int width = stack.Count == 0 ? rightIndex : rightIndex - stack.Peek() - 1; // 1

        largestArea = Math.Max(largestArea, lastHeight * width); // 2 * 1
    }
}