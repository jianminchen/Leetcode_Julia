using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1080_insufficient_nodes_in_root_to_leaf_paths
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// 1080 Insufficient Nodes in Root to Leaf Paths
        /// Code is written in weekly contest, but failed large test case
        /// </summary>
        /// <param name="root"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public TreeNode SufficientSubset(TreeNode root, int limit)
        {
            var dummyParent = new TreeNode(-1);
            dummyParent.left = root;

            var path = new List<TreeNode>();
            var parentMap = new Dictionary<TreeNode, TreeNode>();
            parentMap.Add(root, dummyParent);

            var result = preorderTraversal(root, limit, path, parentMap, 0, true);

            return dummyParent.left;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="limit"></param>
        /// <param name="path"></param>
        /// <param name="map"></param>
        private bool preorderTraversal(TreeNode root, int limit, List<TreeNode> path, Dictionary<TreeNode, TreeNode> map, long sum, bool isLeft)
        {
            if (root.left == root.right)
            {
                sum += root.val;
                if (sum < limit)
                {
                    var parentNode = map[root];
                    if (isLeft)
                        parentNode.left = null;
                    else
                        parentNode.right = null;

                    return false;
                }

                return true;
            }

            path.Add(root);
            sum += root.val;

            bool left = false;
            bool right = false;

            if (root.left != null)
            {
                map.Add(root.left, root);
                left = preorderTraversal(root.left, limit, path, map, sum, true);
            }

            if (root.right != null)
            {
                map.Add(root.right, root);
                right = preorderTraversal(root.right, limit, path, map, sum, false);
            }

            // back tracking
            path.RemoveAt(path.Count - 1);

            if (!(left || right) && sum < limit)
            {
                var parentNode = map[root];
                if (isLeft)
                    parentNode.left = null;
                else
                    parentNode.right = null;

                return false;
            }

            return true;
        }
    }
}
