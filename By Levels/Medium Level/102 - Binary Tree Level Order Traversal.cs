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
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        var nodes = new List<IList<int>>();
        if (root == null)
        {
            return nodes;
        }

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        queue.Enqueue(null);

        var currentLevel = new List<int>();

        while (queue.Count > 0)
        {
            var node = queue.Peek();
            queue.Dequeue();

            if (node != null)
            {
                currentLevel.Add(node.val);

                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }
            else
            {
                nodes.Add(currentLevel);

                if (queue.Count > 0)
                {
                    currentLevel = new List<int>();
                    queue.Enqueue(null);
                }
            }
        }

        return nodes;
    }
}