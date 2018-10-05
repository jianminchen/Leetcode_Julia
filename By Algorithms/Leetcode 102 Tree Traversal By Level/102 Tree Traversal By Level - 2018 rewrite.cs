using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102_tree_level_traversal
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
        /// code review based on submission in 2015
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var nodesByLevel = new List<IList<int>>();

            if (root == null)
            {
                return nodesByLevel;
            }

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            int countByLevel = 1;
            int countNextLevel = 0;
            int countVisited = 0;

            // overall, the structure of code is hard to work with. 
            // no place to determine the level start/ end 
            var list = new List<int>();

            while (queue.Count != 0)
            {                
                var current = queue.Peek();  
                queue.Dequeue();                             

                if (current.left != null)
                {
                    queue.Enqueue(current.left);  
                    countNextLevel++;          
                }

                if (current.right != null)
                {
                    queue.Enqueue(current.right);  
                    countNextLevel++;           
                }

                countVisited++;  
                list.Add(current.val);
                 
                var endOfLevel = countVisited == countByLevel;

                if (endOfLevel)
                {
                    countByLevel   = countNextLevel;

                    countNextLevel = 0;
                    countVisited   = 0;
                    
                    // 
                    var tmpList = new List<int>();
                    tmpList.AddRange(list);
                    nodesByLevel.Add(tmpList);

                    // start a new level
                    list.Clear();
                }
            }

            return nodesByLevel;
        }
    }
}
