using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _508_most_frequence_subtree_sum
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

        /// <summary>
        /// traverse the tree and then save sum into hashmap
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int[] FindFrequentTreeSum(TreeNode root)
        {
            if (root == null)
                return new int[0];
            
            var map = new Dictionary<int, int>();

            traversalTree(root, map);

            return getFrequentSum(map);
        }

        /// <summary>
        /// post order traversal of the tree
        /// each node will be visted once, and then it's subtree sum will 
        /// be added to map
        /// </summary>
        /// <param name="root"></param>
        /// <param name="map"></param>
        /// <returns></returns>
        private static int traversalTree(TreeNode root, Dictionary<int, int> map)
        {
            if (root.left == null && root.right == null)
            {
                var value = root.val;
                if (!map.ContainsKey(value))
                {
                    map.Add(value, 0);
                }                
                
                map[value]++;                

                return root.val; 
            }

            var sum = root.val;

            if (root.left != null)
            {              
                sum += traversalTree(root.left, map);
            }

            if (root.right != null)
            {
                sum += traversalTree(root.right, map);
            }
            
            if (!map.ContainsKey(sum))
            {
                map.Add(sum, 0);
            }            
            
            map[sum]++;            

            return sum; 
        }

        private static int[] getFrequentSum(Dictionary<int, int> map)
        {
            var max = map.Values.Max();

            var list = new List<int>();
            foreach (var pair in map)
            {
                var value = pair.Value;
                if (value == max)
                {
                    list.Add(pair.Key); 
                }
            }

            return list.ToArray(); 
        }
    }
}
