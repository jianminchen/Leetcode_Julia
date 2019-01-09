using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _971_Flip_binary_tree_to_match_preorder_traversal_2
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

        public static IList<int> FlipMatchVoyage(TreeNode root, int[] voyage)
        {
            if (root == null)
                return new List<int>();

            var list = new List<int>();
            int index = 0; 

            var result = preorderTraversal(root, voyage, ref index, list);
            if(result)
            {
                return list; 
            }
            else 
            {
                return new int[]{-1}.ToList<int>();
            }
        }

        /// <summary>
        /// Keep my work to minimum
        /// Ask myself what to work on. 
        /// 1. Check root node's value, return false in my code
        /// 2. Iterate to next position
        /// 3. Swap left and right node
        /// 4. if step 3 is true, add root node's value to the list
        /// 5. Recursive check all subtrees. 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="voyage"></param>
        /// <param name="index"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        private static bool preorderTraversal(TreeNode root, int[] voyage, ref int index, List<int> list)
        {
            if (root == null)
                return true;

            // root node's value should equal to the value in the array
            if (root.val != voyage[index])
            {
                return false;
            }

            index++;

            if (root.left != null && root.left.val != voyage[index])
            {
                // swap left and right child of root
                var tmp = root.left;
                root.left = root.right;
                root.right = tmp;
                list.Add(root.val); 
            }

            return preorderTraversal(root.left, voyage, ref index, list) && 
                   preorderTraversal(root.right,voyage, ref index, list);
        }
    }
}
