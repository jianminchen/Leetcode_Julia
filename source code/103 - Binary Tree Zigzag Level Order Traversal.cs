/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution
{
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
    {
        var zigzagLevelNumbers = new List<IList<int>>();

        if (root == null)
            return zigzagLevelNumbers;

        var currentStack = new Stack<TreeNode>();
        var nextStack = new Stack<TreeNode>();

        currentStack.Push(root);

        var leftFirst = true;  // left and right

        int levelIndex = 0;
        var temp = new List<int>();

        while (currentStack.Count != 0)
        {
            // new level starts by checking levelIndex
            if (zigzagLevelNumbers.Count == levelIndex)
            {
                temp = new List<int>();
                zigzagLevelNumbers.Add(temp);
            }

            while (currentStack.Count != 0)
            {
                var node = currentStack.Pop();
                var left = node.left;
                var right = node.right;

                var hasLeftChild = left != null;
                var hasRightChild = right != null;

                temp.Add(node.val);

                if (leftFirst)
                {
                    if (hasLeftChild)
                    {
                        nextStack.Push(left);
                    }

                    if (hasRightChild)
                    {
                        nextStack.Push(right);
                    }
                }
                else
                {
                    if (hasRightChild)
                    {
                        nextStack.Push(right);
                    }

                    if (hasLeftChild)
                    {
                        nextStack.Push(left);
                    }
                }
            }

            if (currentStack.Count == 0)
            {
                // swap levels
                var tmp = currentStack;
                currentStack = nextStack;
                nextStack = tmp;

                // change the order
                leftFirst = !leftFirst;

                levelIndex++;
            }
        }

        return zigzagLevelNumbers;
    }
}