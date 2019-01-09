using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _971_Flip_binary_tree_to_match_preorder_traversal
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
        static void Main(string[] args)
        {
        }

        public IList<int> FlipMatchVoyage(TreeNode root, int[] voyage)
        {
            if (root == null)
                return new List<int>();

            var succeeded = true;

            if (root.val != voyage[0])
                return new List<int>(new int[] { -1 });
            var list = new List<int>();

            preorderTraversal(root, voyage, 1, ref succeeded, list);
            if (!succeeded)
                return new List<int>(new int[] { -1 });

            return list;
        }

        /// <summary>
        /// need to consider left child is null
        /// flip left and right node
        /// </summary>
        /// <param name="root"></param>
        /// <param name="voyage"></param>
        /// <param name="index"></param>
        /// <param name="succeeded"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private static int preorderTraversal(TreeNode root, int[] voyage, int index, ref bool succeeded, List<int> result)
        {
            if (index >= voyage.Length || succeeded == false)
            {
                return voyage.Length + 1;
            }

            var current = voyage[index];

            var lastIndex = index;

            if (root.left != null)
            {
                if (root.left.val != current)
                {
                    if (root.right == null || root.right.val != current)
                    {
                        succeeded = false;
                        return voyage.Length;
                    }
                    else
                    {
                        // flip
                        var tmp = root.left;

                        root.left = root.right;
                        root.right = tmp;

                        result.Add(root.val);
                    }
                }

                lastIndex = preorderTraversal(root.left, voyage, index + 1, ref succeeded, result);
            }

            if (root.right != null)
            {
                if (lastIndex >= voyage.Length || root.right.val != voyage[lastIndex])
                {
                    succeeded = false;
                    return voyage.Length;
                }

                lastIndex = preorderTraversal(root.right, voyage, lastIndex + 1, ref succeeded, result);
            }

            return lastIndex;
        }
    }
}
