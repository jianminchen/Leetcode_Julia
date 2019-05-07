using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lowest_common_ancestor
{
    public class TreeNode {
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

        public static StringBuilder rootToP, rootToQ;

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || p == null || q == null)
                return null;

            rootToP = new StringBuilder();
            rootToQ = new StringBuilder();

            var newList = new StringBuilder();
            newList.Append('0');
            traversalPreorder(root, root, p, q, newList);

            if (rootToP.ToString().Length == 0 || rootToQ.ToString().Length == 0)
            {
                return null;
            }

            int index = 0;
            TreeNode ancestor = null;
            var pStr = rootToP.ToString();
            var qStr = rootToQ.ToString();

            while (index < rootToP.ToString().Length && index < rootToQ.ToString().Length)
            {
                if (pStr[index] != qStr[index])
                {
                    break;
                }
                
                var numbers = rootToP.ToString();
                var current = numbers[index];
                if (index == 0)
                {
                    ancestor = root;
                }
                else
                {
                    if (current == 0)
                        ancestor = ancestor.left;
                    else
                        ancestor = ancestor.right;
                }
                
                //
                index++;
            }

            return ancestor;
        }

        private void traversalPreorder(TreeNode root, TreeNode current, TreeNode p, TreeNode q, StringBuilder prefix)
        {                        
            if (current == p)
            {
                rootToP = new StringBuilder();
                rootToP.Append(prefix.ToString());                
            }

            if (current == q)
            {
                rootToQ = new StringBuilder();
                rootToQ.Append(prefix.ToString()); 
            }

            if (rootToQ.ToString().Length > 0 && rootToP.ToString().Length > 0)
                return;

            if (current.left != null)
            {
                var newList = new StringBuilder();
                newList.Append(prefix.ToString());
                newList.Append('0');

                traversalPreorder(root, current.left, p, q, newList);
            }

            if (current.right != null)
            {
                var newList = new StringBuilder();
                newList.Append(prefix.ToString());
                newList.Append('1');

                traversalPreorder(root, current.right, p, q, newList);
            }
        }
    }
}
