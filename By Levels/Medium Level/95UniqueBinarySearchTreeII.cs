using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _95UniqueBinarySearchTreeII
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int v)
        {
            val = v;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }

        /*
         * Reference:
         * http://www.programcreek.com/2014/05/leetcode-unique-binary-search-trees-ii-java/
         * 
         * julia's comment:
         * 1. pass online judge:
         *  9 / 9 test cases passed.
            Status: Accepted
            Runtime: 444 ms
         * 
         */
        public IList<TreeNode> generateTrees(int n)
        {
            return generateTrees(1, n);
        }

        public IList<TreeNode> generateTrees(int start, int end) {
            IList<TreeNode> list = new List<TreeNode>();
 
            if (start > end) {
                list.Add(null);
                return list;
            }
 
            for (int i = start; i <= end; i++) {
                IList<TreeNode> lefts = generateTrees(start, i - 1);
                IList<TreeNode> rights = generateTrees(i + 1, end);

                foreach (TreeNode l in lefts) {
                    foreach (TreeNode r in rights) {
                        TreeNode node = new TreeNode(i);
                        node.left = l;
                        node.right = r;
                        list.Add(node);
                    }
                }
            }
 
            return list;    
        }
    }
}
