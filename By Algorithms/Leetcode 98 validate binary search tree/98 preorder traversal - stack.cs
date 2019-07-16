using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _98_validate_BST___using_stack
{
    class Program
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        static void Main(string[] args)
        {
        }

        /// <summary>
        /// code review 
        /// July 16, 2019
        /// preorder traversal of BST
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsValidBST(TreeNode root)
        {
            if (root == null)
                return true;

            var stack = new Stack<TreeNode>();

            TreeNode current = root;
            TreeNode previous = null;

            while (true)
            {
                while (current != null)    
                {
                    stack.Push(current);
                    current = current.left;  // Left
                }

                if (stack.Count == 0)                     
                    break;

                // root 
                current = stack.Pop();         

                if (previous != null && previous.val >= current.val)            
                    return false;

                previous = current;            

                // right
                current = current.right;      
            }

            return true;
        }
    }
}
