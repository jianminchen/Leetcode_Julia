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
    public void Flatten(TreeNode root)
    {
        if (root == null)
        {
            return;
        }

        bool hasLeftChild = root.left != null;
        bool hasRightChild = root.right != null;
        if (hasLeftChild)
        {
            var left = root.left;

            Flatten(left);
        }

        if (hasRightChild)
        {
            var right = root.right; // added after failed online judge
            Flatten(right);

            // set left child to null
            right.left = null;
        }

        if (hasLeftChild)
        {
            var left = root.left;
            var end = getEnd(left);

            var tmp = root.right;

            root.right = left;
            end.right = tmp;

            // set left child to null
            root.left = null; // set left child to null  
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="root"></param>
    public static TreeNode getEnd(TreeNode root)
    {
        bool hasRightChild = root.right != null;
        if (hasRightChild)
        {
            return getEnd(root.right);
        }
        else
        {
            return root;
        }
    }
}