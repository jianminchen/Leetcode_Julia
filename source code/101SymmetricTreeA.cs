using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _101SymmetricTreeA
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
         * http://www.cnblogs.com/TenosDoIt/p/3440729.html
         * 
         * Analysis from the above blog:
         * 算法1：递归解法，判断左右两颗子树是否对称，只要两颗子树的根节点值相同，
         * 并且左边子树的左子树和右边子树的右子树对称 且左边子树的右子树和右边子
         * 树的左子树对称         
         * 
         * julia's comment:
         * 1. online judge:
         *  192 / 192 test cases passed.
            Status: Accepted
            Runtime: 176 ms
         */
        public static bool isSymmetric(TreeNode root)
        {
            if (root == null)
                return true;

            return isSymmetricRecur(root.left, root.right);
        }

        /**
         * 
         */
        public static bool isSymmetricRecur(TreeNode r1, TreeNode r2)
        {
            if (r1 != null && r2 != null)      // neither of two nodes is null 
            {
                if (r1.val == r2.val &&
                    isSymmetricRecur(r1.left, r2.right) &&
                    isSymmetricRecur(r1.right, r2.left))
                    return true;
                else
                    return false;

            }
            else if (r1 != null || r2 != null)  // one of them is not null, but at least one is null
                return false;
            else                                     // two of them are null
                return true;

        }


        /*
         * code reference: 
         * http://www.cnblogs.com/TenosDoIt/p/3440729.html
         * Iterative solution:
           算法2：非递归解法，用两个队列分别保存左子树节点和右子树节点，每次从两个队列中
         * 分别取出元素，如果两个元素的值相等，则继续把他们的左右节点加入左右队列。要注意
         * 每次取出的两个元素，左队列元素的左孩子要和右队列元素的右孩子要同时不为空或者
         * 同时为空，否则不可能对称，同理左队列元素的右孩子要和右队列元素的左孩子也一样。
         * 
         * julia's comment:
         * 1. online judge:
            192 / 192 test cases passed.
            Status: Accepted
            Runtime: 156 ms
         * 2. The code can be improved by removing duplicated checking
         *    1st node'left child vs 2nd node's right child 
         *    1st node'right child vs 2nd node's right child
         *    
         *   The rewrite version is called isSymmetric_Iterative_ShortVersion
         */
        public static bool isSymmetric_Iterative(TreeNode root)
        {
            if (root == null)
                return true;

            Queue lQ = new Queue(),
                  rQ = new Queue();

            if (root.left != null)
                lQ.Enqueue(root.left);

            if (root.right != null)
                rQ.Enqueue(root.right);

            while (lQ.Count > 0 && rQ.Count > 0)
            {
                TreeNode l_nd = (TreeNode)lQ.Peek();   // l_nd: left queue node 
                TreeNode r_nd = (TreeNode)rQ.Peek();   // r_nd: right queue node

                lQ.Dequeue();
                rQ.Dequeue();

                if (l_nd.val == r_nd.val)
                {
                    // l_nd (node from 1st queue) left child vs right queue (node from 2nd queue) right child 
                    if (l_nd.left != null && r_nd.right != null)   // neither is null 
                    {
                        lQ.Enqueue(l_nd.left);
                        rQ.Enqueue(r_nd.right);
                    }
                    else if (l_nd.left != null || r_nd.right != null)  // one of them is null, another is not null
                        return false;

                    // 1st queue's node's right child  vs  2nd queue's node's left child 
                    if (l_nd.right != null && r_nd.left != null)
                    {
                        lQ.Enqueue(r_nd.left);
                        rQ.Enqueue(l_nd.right);
                    }
                    else if (r_nd.left != null || l_nd.right != null)
                        return false;
                }
                else return false;
            }

            if (lQ.Count == 0 && rQ.Count == 0)
                return true;
            else
                return false;
        }

        /*
         * julia's comment: 
         * make iterative solution short 
         * 1. abstract code using two nodes: n1, n2
         * 2. make a loop iteration two times. 
         * 3. think about how to make code more simple, readable, maintainable. 
         *    
         */
        public static bool isSymmetric_Iterative_ShortVersion(TreeNode root)
        {
            if (root == null)
                return true;

            Queue lQ = new Queue(),
                  rQ = new Queue();

            if (root.left != null)
                lQ.Enqueue(root.left);

            if (root.right != null)
                rQ.Enqueue(root.right);

            while (lQ.Count > 0 && rQ.Count > 0)
            {
                TreeNode l_nd = (TreeNode)lQ.Peek();   // l_nd: left queue node 
                TreeNode r_nd = (TreeNode)rQ.Peek();   // r_nd: right queue node

                lQ.Dequeue();
                rQ.Dequeue();

                if (l_nd.val == r_nd.val)
                {                    
                    for (int i = 0; i < 2; i++)
                    {
                        TreeNode n1 = l_nd.left;
                        TreeNode n2 = r_nd.right;

                        if (i == 1)
                        {
                            n1 = l_nd.right;
                            n2 = r_nd.left;
                        }

                        if (n1 != null && n2 != null)       // neither is null 
                        {
                            lQ.Enqueue(n1);
                            rQ.Enqueue(n2);
                        }
                        else if (n1 != null || n2 != null)  // one of them is null, another is not null
                            return false;
                    }                    
                }
                else 
                    return false;
            }

            if (lQ.Count == 0 && rQ.Count == 0)             // both two queues are empty
                return true;
            else
                return false;
        }
    }
}
