using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTreeLevelOrderTraversal
{     
    class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x)
        {
            val = x;
            left = null;
            right = null;
        }
    };

    class BTreeLevelOrderTraversal
    {
        const Int16 NULL_INT = 0;
        static void Main(string[] args)
        {
            /*Latest update: July 23, 2015 
             * Test the code  
             */
            TreeNode n1 = new TreeNode(1);
            n1.left = new TreeNode(2);
            n1.right = new TreeNode(3);
            n1.left.left = new TreeNode(4);
            n1.left.right = new TreeNode(5);
            n1.right.left = new TreeNode(6);
            n1.right.right = new TreeNode(7);          
            
            
            IList<IList<int>> result3 = levelOrder(n1);

        }                    

        /*
           Latest update: July 23, 2015 
         * Leetcode question: Binary tree level order traversal 
         * 
         * 1. Practice more using Interface instead of actual class, like ArrayList in function return
         * 2. Change the return using IList<IList<int>>
         * 3. Test the code using leetcode online judge
         * Read the website about ArrayList vs List:
         * https://social.msdn.microsoft.com/Forums/vstudio/en-US/37c64e16-69e9-4935-abaa-ee8987230240/arraylist-vs-ilistobject?forum=netfxbcl&prof=required
         *   julia now understands the importance to use the interface, more generic, and less type casting,
         *   quick running time. 
         *   
         *   Leetcode online result:
         *   34 / 34 test cases passed.
             Status: Accepted
             Runtime: 536 ms
         */
        public static IList<IList<int>> levelOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();

            if (root == null)
                return (IList<IList<int>>)result;

            List<int> level = new List<int>();

            Queue<TreeNode> toVisit = new Queue<TreeNode>();

            toVisit.Enqueue(root);
            toVisit.Enqueue(null);

            while (true)
            {
                TreeNode cur = toVisit.Peek();
                toVisit.Dequeue();
                // end a level

                if (cur == null)
                {
                    List<int> list = new List<int>(); // julia: bug fix                    
                    list.AddRange(level);  // julia: bug fix 
                    result.Add(list);

                    if (toVisit.Count == 0)
                        break;

                    // add a new End-Of-Level                    
                    level.Clear();

                    toVisit.Enqueue(null);
                }
                else
                {
                    level.Add(cur.val);
                    if (cur.left != null)
                        toVisit.Enqueue(cur.left);
                    if (cur.right != null)
                        toVisit.Enqueue(cur.right);
                }
            }

            return (IList<IList<int>>)result;
        }
    }
}
