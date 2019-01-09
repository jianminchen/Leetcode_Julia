using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _958_Check_completeness_of_a_binary_tree
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

        public bool IsCompleteTree(TreeNode root)
        {
            if (root == null)
                return true;
            var height = getHeight(root);

            bool firstOne = false;
            bool isComplete = true;

            preOrder(root, height, 1, ref firstOne, ref isComplete);
            return isComplete;
        }

        private static void preOrder(TreeNode root, int height, int level, ref bool firstOneMissingOne, ref bool isComplete)
        {
            // base case - leaf node 
            if (root.left == null && root.right == null)
            {
                if (level == height)
                {
                    if (firstOneMissingOne)
                    {
                        isComplete = false;
                    }

                    return;
                }
                else if (level == height - 1)
                {
                    if (!firstOneMissingOne)
                    {
                        firstOneMissingOne = true;
                    }
                }
                else
                {
                    isComplete = false;
                }

                return;
            }

            var missingLeftOnly = root.left == null && root.right != null;
            var oneIsNull = root.right == null;

            if (missingLeftOnly || (oneIsNull && height != (level + 1)))
            {
                isComplete = false;
                return;
            }


            preOrder(root.left, height, level + 1, ref firstOneMissingOne, ref isComplete);

            if (root.right == null)
            {
                firstOneMissingOne = true;
            }
            else
                preOrder(root.right, height, level + 1, ref firstOneMissingOne, ref isComplete);
        }

        private static int getHeight(TreeNode root)
        {
            var index = 0;
            while (root != null)
            {
                root = root.left;
                index++;
            }

            return index;
        }
    }
}
