using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102_tree_level_traveral___using_extra_null_node
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        /// <summary>
        /// code review on Oct. 5, 2018
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var nodesByLevel = new List<IList<int>>();

            if (root == null)
            {
                return (IList<IList<int>>)nodesByLevel;
            }

            var list = new List<int>();

            var queue = new Queue<TreeNode>();

            queue.Enqueue(root);
            queue.Enqueue(null);

            while (true)
            {
                var current = queue.Peek();
                queue.Dequeue();                

                // end of the level 
                if (current == null)
                {
                    var tmpList = new List<int>();                      
                    tmpList.AddRange(list);   
                    nodesByLevel.Add(tmpList);

                    if (queue.Count == 0)
                    {
                        break;
                    }
                    
                    list.Clear();

                    queue.Enqueue(null);
                }
                else
                {
                    list.Add(current.val);
                    if (current.left != null)
                    {
                        queue.Enqueue(current.left);
                    }

                    if (current.right != null)
                    {
                        queue.Enqueue(current.right);
                    }
                }
            }

            return nodesByLevel;
        }
    }
}
