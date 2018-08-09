using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode501_FindModeInBST
{
    /// <summary>
    /// Leetcode 501 - Find mode in BST
    /// First practice took me 92 minutes in total 
    /// </summary>
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
            //RunSampleTestcase();  
            RunTestCase();
        }

        public static void RunSampleTestcase()
        {
            var root1 = new TreeNode(1);
            var root2 = new TreeNode(2);
            var root2B = new TreeNode(2);
            root1.right = root2;
            root2.left = root2B;

            var result = FindMode(root1); 
        }

        public static void RunTestCase()
        {
            var root1 = new TreeNode(1);
            var root2 = new TreeNode(2);
            
            root1.right = root2;            

            var result = FindMode(root1);
        }

        public static TreeNode previous;
        public static TreeNode current;
        public static int max = 0;        
       
        public static int currentCount = 0;
        public static HashSet<int> numbers; 

        public static int[] FindMode(TreeNode root)
        {            
            previous    = null;
            current = null;
            max = 0;          
            
            currentCount = 0; 
            numbers  = new HashSet<int>();

            inorderTraversal(root);

            return numbers.ToArray();
        }

        /// <summary>
        /// inorder traversal - left, root, right 
        /// </summary>
        /// <param name="root"></param>
        private static void inorderTraversal(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            inorderTraversal(root.left);

            // handling mode rules 
            current = root;
            var sameAsPrevious = previous != null && previous.val == current.val;
            var startNew = previous == null || previous.val != current.val;
            var lastOne = root.right == null;

            if (sameAsPrevious)
            {
                currentCount++;
            }

            if (startNew)
            {
                if (previous != null)
                {
                    var candidate = previous.val;

                    updateMode(candidate);
                }

                // start a new value                
                currentCount = 1; 
            }

            if (lastOne)
            {
                var candidate = current.val;
                updateMode(candidate);
            }

            // set current to previous
            previous = current;

            inorderTraversal(root.right); 
        }

        /// <summary>
        /// 
        /// </summary>
        private static void updateMode(int candidate)
        {
            // summarize the last value               
            if (currentCount > max)
            {
                max = currentCount;

                numbers.Clear();
                numbers.Add(candidate);
            }
            else if (currentCount > 0 && currentCount == max)
            {
                numbers.Add(candidate);
            }
        }
    }
}
