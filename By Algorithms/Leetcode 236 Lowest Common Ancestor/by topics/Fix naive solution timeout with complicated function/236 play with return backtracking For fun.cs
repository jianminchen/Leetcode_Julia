using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lowest_common_ancestor_236_timeout
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
            runTestcase();
        }

        public static void runTestcase()
        {
            var root0 = new TreeNode(0);
            var root1 = new TreeNode(1);
            var root2 = new TreeNode(2);
            var root3 = new TreeNode(3);
            var root4 = new TreeNode(4);
            var root5 = new TreeNode(5);
            var root6 = new TreeNode(6);
            var root7 = new TreeNode(7);
            var root8 = new TreeNode(8);

            root3.left  = root5;
            root3.right = root1;

            root5.left  = root6;
            root5.right = root2;

            root2.left  = root7;
            root2.right = root4;

            root1.left  = root0;
            root1.right = root8;

            var result = LowestCommonAncestor(root3, root5, root1);
        }

        public static List<TreeNode> rootToP, rootToQ;
        public static bool findP, findQ; 
        /// <summary>
        /// Leetcode 236 lowest common ancestor in binary tree
        /// - in general case, I like to propose the idea to find both nodes in the tree first, 
        /// and also the path infomration will be recorded. 
        /// 
        /// Problem found: 
        /// Time out in one of test cases
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || p == null || q == null)
                return null;

            rootToP = new List<TreeNode>();
            rootToQ = new List<TreeNode>();
            findP = false;
            findQ = false;

            traversalPreorder(root, p, q, rootToP, rootToQ);

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

        /// <summary>
        /// I like to solve timeout problem, and space complexity O(height of tree)
        /// 1. remove current argument
        /// 2. remove array copy
        /// 3. remove ...
        /// Design return:
        /// 0 - return false
        /// 1 - true - find p
        /// 2 - true - find q
        /// Training purposes:
        /// 1. understand backtracking
        /// 2. build good habit to use back track for a few benefits
        /// </summary>
        /// <param name="root"></param>
        /// <param name="current"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <param name="prefix"></param>
        private static void traversalPreorder(TreeNode root, TreeNode p, TreeNode q, List<TreeNode> prefixP, List<TreeNode> prefixQ)
        {
            if (root == null)
            {
                return;
            }

            if (!findP)
                prefixP.Add(root);

            if (!findQ)
                prefixQ.Add(root);

            if (root == p)
            {
                findP = true;
            }

            if (root == q)
            {
                findQ = true;
            }

            traversalPreorder(root.left,  p, q, prefixP, prefixQ);
            traversalPreorder(root.right, p, q, prefixP, prefixQ);

            if (!findP)
                prefixP.RemoveAt(prefixP.Count - 1);

            if (!findQ)
                prefixQ.RemoveAt(prefixQ.Count - 1);

            return;
        }
    }
}
