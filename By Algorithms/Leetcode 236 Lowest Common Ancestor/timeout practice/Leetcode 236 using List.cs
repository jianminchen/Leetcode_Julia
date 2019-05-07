using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lowest_common_ancestor_235_timeout
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

        public static List<TreeNode> rootToP, rootToQ;

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || p == null || q == null)
                return null;

            rootToP = new List<TreeNode>();
            rootToQ = new List<TreeNode>();

            var newList = new List<TreeNode>();
            traversalPreorder(root, root, p, q, newList);

            if (rootToP.Count == 0 || rootToQ.Count == 0)
            {
                return null;
            }

            int index = 0;
            TreeNode ancestor = null;
            while (index < rootToP.Count && index < rootToQ.Count)
            {
                if (rootToP[index] == rootToQ[index])
                {
                    ancestor = rootToP[index];
                }
                else
                    break;
                //
                index++;
            }

            return ancestor;
        }

        private void traversalPreorder(TreeNode root, TreeNode current, TreeNode p, TreeNode q, List<TreeNode> prefix)
        {
            prefix.Add(current);

            if (current == p && current == q)
            {
                foreach (var item in prefix)
                {
                    rootToP.Add(item);
                    rootToQ.Add(item);
                }
            }

            if (current == p)
            {
                foreach (var item in prefix)
                {
                    rootToP.Add(item);
                }
            }

            if (current == q)
            {
                foreach (var item in prefix)
                {
                    rootToQ.Add(item);
                }
            }

            if (rootToQ.Count > 0 && rootToP.Count > 0)
                return;

            if (current.left != null)
            {
                var newList = new List<TreeNode>(prefix);

                traversalPreorder(root, current.left, p, q, newList);
            }

            if (current.right != null)
            {
                var newList = new List<TreeNode>(prefix);

                traversalPreorder(root, current.right, p, q, newList);
            }
        }
    }
}
