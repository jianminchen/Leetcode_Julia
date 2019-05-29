using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1026_Maximum_Difference
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

        /// <summary>
        /// the code was written in weekly contest 132
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxAncestorDiff(TreeNode root)
        {
            var maxDiff = 0;
            var hashSet = new HashSet<int>();
            preorderTraversal(root, hashSet, ref maxDiff);

            return maxDiff;
        }

        /// <summary>
        /// all leaf nodes will be tested. 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="hashSet"></param>
        /// <param name="maxDiff"></param>
        private static void preorderTraversal(TreeNode root, HashSet<int> hashSet, ref int maxDiff)
        {
            hashSet.Add(root.val);

            if (root.left == root.right)
            {
                var array = hashSet.ToArray();
                var diff = Math.Abs(array.Max() - array.Min());
                maxDiff = maxDiff < diff ? diff : maxDiff;

                hashSet.Remove(root.val);
                return;
            }

            if (root.left != null)
            {
                var newSet = new HashSet<int>(hashSet);
                preorderTraversal(root.left, newSet, ref maxDiff);
            }

            if (root.right != null)
            {
                var newSet = new HashSet<int>(hashSet);
                preorderTraversal(root.right, newSet, ref maxDiff);
            }


        }
    }
}
