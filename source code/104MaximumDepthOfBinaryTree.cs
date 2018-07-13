using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _104MaximumDepthOfBinaryTree
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
         * http://blog.csdn.net/linhuanmars/article/details/19659525
         * 
         * julia's comment: 
         * 1. pass online judge:
         *  38 / 38 test cases passed.
            Status: Accepted
            Runtime: 180 ms
         * 
         */
        public static int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            return Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
        }

        /*
         * Reference: 
         * http://blog.csdn.net/linhuanmars/article/details/19659525
         * comment:
         * 非递归解法一般采用层序遍历(相当于图的BFS），因为如果使用其他遍历方式也需要同样的
         * 复杂度O(n). 层序遍历理解上直观一些，维护到最后的level便是树的深度。
         * 
         * julia's comment:
         * 
         * 1. use LinkedList to implement the queue 
         * 2. Read Java Queue poll method /remove method difference
         * 3. Let us describe the thought process here:
         * 
         *    Use two variable to help counting current level nodes left, next level num of nodes in the queue. 
         *    3rd variable is the level count starting from 0 
         *    tip: 
         *    1. queue will have at most two levels nodes, one is current level, one is next level; 
         *    2. visit current level node in the queue, and meanwhile, push next level node in the queue; 
         *    2. If the current level node's count to zero, then, switch to next level, set as current level. 
         *    
         * 4. online judge: 
         * 
         *    Time Limit Exceeded
         *    
         */
        public static int maxDepth_Iterative(TreeNode root)
        {
            if (root == null)
                return 0;

            int level = 0;
            LinkedList<TreeNode> queue = new LinkedList<TreeNode>();

            queue.AddFirst(root);

            int curNum = 1;    //num of nodes left in current level  
            int nextNum = 0;   //num of nodes in next level  
            while (queue.Count > 0 )
            {
                TreeNode n = queue.First();  // Java Queue Poll - find first, return null if not existed / C# Queue.Firist
                curNum--;

                if (n.left != null)
                {
                    queue.AddLast(n.left);
                    nextNum++;
                }

                if (n.right != null)
                {
                    queue.AddLast(n.right);
                    nextNum++;
                }

                if (curNum == 0)   // current level is complete, need to go to next level. 
                {
                    curNum = nextNum;
                    nextNum = 0;
                    level++;
                }
            }

            return level;
        }

        /*
         * reference:
         * http://joycelearning.blogspot.ca/2013/10/java-leetcode-maximum-depth-of-binary.html
         * 
         * julia's comment on August 27, 2015: 
         * 1. quickly try the idea using ArrayList in C# 
         * 2. online judge:
         *  38 / 38 test cases passed.
            Status: Accepted
            Runtime: 164 ms
         * 3. Interested and curious, why C# LinkedList failed but C# ArrayList success in online judge. 
         * 4. First time use C# ArrayList input argument as ArrayList as well. 
         * 5. chanage line 133 while use for, and make the loop easy to understand.
         * 6. Describe the process: 
         *   step 1:  base case handling
         *   step 2: create new ArrayList container for current level, 
         *        add root into container, set a variable depth iniitalization value 0
         *   step 3: Get into the loop, 
         *      A. create a new conainter for next level, 
         *      B. go through each node in the current level container, 
         *      C. add left and right child into next level if not null. 
         *      D. increment level variable; 
         *      E. if next level count is 0, break the loop; in other words, no more level. 
         *      F. copy the next level nodes into the current level. in other words, help to 
         *         get back to loop again, reuse the code. 
    
         */
        public static int maxDepth_Iterative_B(TreeNode root) {
            if(root == null)    return 0;
         
            // Non-recursive, use level order traversal
            ArrayList  q = new ArrayList ();
            q.Add(root);
            int depth = 0;

            for (; ; )
            {
                ArrayList next = new ArrayList();

                foreach (TreeNode nd in q)
                {
                    if (nd.left != null)
                        next.Add(nd.left);

                    if (nd.right != null)
                        next.Add(nd.right);
                }

                depth++;

                if (next.Count == 0)
                    break;

                q = new ArrayList(next);                                             
            }
         
            return depth;
        }
    }
}
