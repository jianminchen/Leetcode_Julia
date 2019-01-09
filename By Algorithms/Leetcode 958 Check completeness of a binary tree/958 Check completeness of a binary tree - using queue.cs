using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _958_check_completeness_of_a_binary_tree___3
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

        public bool IsCompleteTree(TreeNode root)
        {
            if (root == null)
                return true;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var visit = queue.Dequeue();

                if (visit == null)
                {
                    // all nodes in the queue should be null
                    var list = queue.ToArray();
                    foreach (var item in list)
                    {
                        if (item != null)
                            return false;
                    }

                    return true; 
                }

                queue.Enqueue(visit.left);
                queue.Enqueue(visit.right);
            }

            return true; 
        }
    }
}
