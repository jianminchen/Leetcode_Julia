using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_257_Binary_tree_paths
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

        public IList<string> BinaryTreePaths(TreeNode root)
        {
            var paths = new List<string>();
            if (root == null)
                return paths;

            var pathsFound = new List<string>();

            inorderTraversal(root, "", pathsFound);

            return pathsFound; 
        }

        /// <summary>
        /// assume taht root is not null
        /// </summary>
        /// <param name="root"></param>
        /// <param name="prefix"></param>
        /// <param name="pathsFound"></param>
        private static void inorderTraversal(TreeNode root, string prefix, IList<string> pathsFound)
        {
            var value = root.val;
            var nextPrefix = prefix.Length == 0 ? value.ToString() : (prefix + ";" + value.ToString());

            if (root.left == null && root.right == null)
            {                
                var split = nextPrefix.Split(';'); 
                pathsFound.Add(string.Join("->", split));

                return; 
            }

            if (root.left != null)
                inorderTraversal(root.left, nextPrefix, pathsFound);

            if (root.right != null)
                inorderTraversal(root.right, nextPrefix, pathsFound);
        }
    }
}
