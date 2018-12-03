using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _173_binary_search_iterator_optimal_space
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
    /// Space is O(h), h is the height of the tree
    /// Time complexity for Next - O(h), HasNext is O(1). 
    /// </summary>
    public class BSTIterator
    {       
        private Stack<TreeNode> nodes;

        public BSTIterator(TreeNode root)
        {
            nodes = new Stack<TreeNode>();
            if (root == null)
                return;

            var left = root;
            while (left != null)
            {
                nodes.Push(left);
                left = left.left; 
            }
        }       

        /** @return whether we have a next smallest number */
        public bool HasNext()
        {
            return nodes.Count > 0;   
        }

        /** @return the next smallest number */
        public int Next()
        {
            if (HasNext())
            {
                var visit = nodes.Pop();
                var iterate = visit.right;
                while (iterate != null)
                {
                    nodes.Push(iterate);
                    iterate = iterate.left;
                }

                return visit.val;
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
