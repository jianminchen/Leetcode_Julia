using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTreeLevelOrderTraversal3
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

    class BTreeLevelOrderTraversal3
    {
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
         * Latest update: July 23, 2015 
         * 
         * source code from blog:
         * http://fisherlei.blogspot.ca/2013/01/leetcode-binary-tree-level-order.html
         * convert it from C++ to C# code
         * Julia's comment: 
         *   1. Three variables / one list to help a queue to level order traversal using BFS algorithm: 
         *      track two levels, alternate the levels  
         *      1. countCurrentLevel:      first level, only one node, root, count value is 1; 
         *      2. countNextLevel:         every time, a new node is pushed into queue, increment the count. 
         *      3. countVisited_LevelWise: track nodes visited in current level, and then know 
         *                                 when to move to new level 
         *      4. tmpListLevel:           add visited node value to the list one by one in the same level, 
         *                                 and then create a new list copying the content from tmpListLevel,
         *                                 and then the new list is added to the result. 
         *   2. Each level visited node is added to list, but then, it is copies to another new list 
         *      which is added to the result. Avoid point problems. 
         *   
         *   Leetcode online judge: 
         *   34 / 34 test cases passed.
             Status: Accepted
             Runtime: 508 ms
         */
        public static IList<IList<int>> levelOrder(TreeNode root) {
            IList<IList<int>> result = new List<IList<int>>();  

            if(root == null) 
                return result;

            Queue<TreeNode> queue = new Queue<TreeNode>();  
            queue.Enqueue(root);
              
            int countCurrentLevel       = 1;
            int countNextLevel          = 0; 
            int countVisited_LevelWise  = 0; 

            IList<int> tmpListLevel = new List<int>();  

            while(queue.Count != 0)  
            {  
                // 1. current level: peek, dequeue, increment count variables, add value to tmp list, add each node
                //    child's L R child to the queue and then increments next level count variables. 

                //    Memorize steps: 1: peek, 2: dequeue, 3: increment count variables, 4. add value to tmp list
                //    5. add new node into queue 6. update count variables for those new added nodes. 
                //    update queue first (step 5, 6 first), and then, step 3, 4. 
                TreeNode node = queue.Peek();  // step 1
                queue.Dequeue();               // step 2                

                if(node.left != null)          
                {
                    queue.Enqueue(node.left);  // step 5
                    countNextLevel++;          // step 6
                }  

                if(node.right != null)  
                {
                    queue.Enqueue(node.right);  // step 5
                    countNextLevel++;           // step 6
                }

                countVisited_LevelWise++;      // step 3
                tmpListLevel.Add(node.val);    // step 4

                // 2. prepare for next level 
                bool prepareForNextLevel = countVisited_LevelWise == countCurrentLevel;

                if (prepareForNextLevel)  
                {                       
                    countCurrentLevel = countNextLevel;  
                    countNextLevel    = 0;
                    countVisited_LevelWise      = 0; 

                    List<int> l = new List<int>();  
                    l.AddRange(tmpListLevel);  
                    result.Add(l);  

                    tmpListLevel.Clear();  
                }  
            }  

            return result;  
        }  
    }
}
