using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _687_longest_univalue_path
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    class Program
    {
        public static void Main()
        {
            var node = new TreeNode(1);
            node.left = new TreeNode(4);
            node.right = new TreeNode(4);

            // node.left.left = new TreeNode(4);
            // node.left.right = new TreeNode(4);

            Console.WriteLine(LongestUnivaluePath(node));
        }    

        public static int LongestUnivaluePath(TreeNode root)
        {
            int max;
            var    number = cacluateLongestUnivaluePath(root, int.MaxValue, true, out max);

            return number <= 1 ? 0 : number - 1;
        }

        /// <summary>
        /// longest univalue path - count how many nodes
        /// </summary>
        /// <param name="root"></param>
        /// <param name="val"></param>
        /// <param name="rootToLeafMax">root to leaf node longest univalue path</param>
        /// <returns></returns>
        public static int cacluateLongestUnivaluePath(TreeNode root, int val, bool firstCall, out int rootToLeafMax)
        {           
            rootToLeafMax = 0;
            if (root == null)
            {
                return 0;
            }

            int rootToLeaf_MaxLeft;
            int rootToLeaf_MaxRight;

            int leftChild  = cacluateLongestUnivaluePath(root.left, root.val,  false, out rootToLeaf_MaxLeft);
            int rightChild = cacluateLongestUnivaluePath(root.right, root.val, false, out rootToLeaf_MaxRight);

            if (!firstCall && root.val == val)
            {
                rootToLeafMax = Math.Max(rootToLeaf_MaxLeft, rootToLeaf_MaxRight) + 1; 
            }

            int longestUnivaluePath = Math.Max(leftChild, rightChild);

            longestUnivaluePath = Math.Max(longestUnivaluePath, rootToLeaf_MaxLeft + rootToLeaf_MaxRight + 1); // 
            
            return longestUnivaluePath;
        }
    }
}
