using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1123_LCA_deepest_level
{
    public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
          this.val = val;
          this.left = left;
          this.right = right;
      }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);
            var node4 = new TreeNode(4);

            node1.left  = node2;
            node1.right = node3;
            node2.left  = node4;

            var lca = LcaDeepestLeaves(node1); 
        }

        /// <summary>
        /// August 26, 2020
        /// 1. Find all leaf nodes using direction chars 0 or 1 to record the path from 
        /// root to leaf
        /// 2. Find those deepest leaf nodes
        /// 3. Find the lowest common ancestor for those nodes
        /// 4. If only one node, then LCA is itself.
        /// 5. Find LCA node using 0 and 1's string
        /// unit test:
        /// 1. tree with one node value 1, LCA = 1
        /// 2. [1, 2, 3, 4], LCA = [4], not []
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static TreeNode LcaDeepestLeaves(TreeNode root)
        {
            if (root == null)
                return null;

            var paths = new List<List<int>>();
            var path  = new List<int>();

            // direction - 0 - left, 1 - right, 2 - ignore
            runPreorderTraversal(root, 2, path, paths);

            var length = paths.Count; 
            var deepestLeafSet = new HashSet<int>();
            var max = 0; 

            // Find deepest leaf nodes
            for (int i = 0; i < length; i++)
            {
                var current = paths[i];
                var height = current.Count;
                if (height > max)
                {
                    deepestLeafSet.Clear();
                    max = height;
                    deepestLeafSet.Add(i);
                }
                else if (height == max)
                {
                    deepestLeafSet.Add(i);
                }
            }

            //Find LCA 
            var directionSet = new HashSet<int>();
            var found = false;
            var pathToLCA = new List<int>();

            // Do not mix deepestLeafSet with directionSet
            for (int depth = 0; depth < max; depth++)
            {
                directionSet.Clear();

                for (int i = 0; i < length; i++)
                {
                    if (!deepestLeafSet.Contains(i))
                    {
                        continue;
                    }

                    var direction = paths[i][depth];
                    directionSet.Add(direction);

                    if (directionSet.Count > 1)
                    {
                        found = true;
                        break; 
                    }
                }

                if (!found)
                {
                    pathToLCA.Add(directionSet.ToList()[0]);
                }
            }

            var LCA = root;             
            for(int i = 0; i < pathToLCA.Count; i++)
            {
                var current = pathToLCA[i];
                if (current == 0)
                {
                    LCA = LCA.left;
                }
                else
                    LCA = LCA.right;
            }

            return LCA;
        }

        /// <summary>
        /// preorder traversal of tree
        /// </summary>
        /// <param name="root"></param>
        /// <param name="path"></param>
        /// <param name="paths"></param>
        private static void runPreorderTraversal(TreeNode root, int direction, List<int> path, List<List<int>> paths)
        {
            if (root == null)
            {
                return;
            }

            if (direction != 2)
            {
                path.Add(direction);
            }

            var isLeaf = root.left == null && root.right == null;
            if (isLeaf)
            {
                var copy = new List<int>(path);
                paths.Add(copy);
            }

            runPreorderTraversal(root.left,  0, path, paths);
            runPreorderTraversal(root.right, 1, path, paths);

            if (direction != 2)
            {
                path.RemoveAt(path.Count - 1);
            }
        }
    }
}
