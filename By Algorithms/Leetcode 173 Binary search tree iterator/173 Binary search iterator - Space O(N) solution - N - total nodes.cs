using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _173_Binary_search_iterator
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    /// <summary>
    /// my design:
    /// Space is O(N), N is total number of nodes in the tree
    /// Time complexity for Next, HasNext is O(1). 
    /// </summary>
    public class BSTIterator
    {
        private int index;
        private int size; 
        private IList<TreeNode> nodes;

        public BSTIterator(TreeNode root)
        {
            if (root == null)
                return;

            nodes = new List<TreeNode>(); 
            inorderTraverse(root);
        }

        private void inorderTraverse(TreeNode root)
        {
            if (root == null)
                return;

            inorderTraverse(root.left);

            nodes.Add(root);
            size++;

            inorderTraverse(root.right);
        }

        /** @return whether we have a next smallest number */
        public bool HasNext()
        {
            return index < size; 
        }

        /** @return the next smallest number */
        public int Next()
        {
            if (HasNext())
            {
                var value = nodes[index].val;
                index++;
                return value;
            }
            else
            {
                return -1; 
            }
        }
    }

    /**
     * Your BSTIterator will be called like this:
     * BSTIterator i = new BSTIterator(root);
     * while (i.HasNext()) v[f()] = i.Next();
     */
}
