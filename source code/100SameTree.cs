using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100SameTree
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
         * Leetcode: 100 same tree
         * 
         * Reference: 
         * http://blog.csdn.net/linhuanmars/article/details/22839819
         * 
         * Analysis from the above blog:
         * 这道题是树的题目，属于最基本的树遍历的问题。问题要求就是判断两个树是不是一样，
         * 基于先序，中序或者后序遍历都可以做完成，因为对遍历顺序没有要求。
         * 
         * 这里我们主要考虑一下结束条件，如果两个结点都是null，也就是到头了，那么返回true。
         * 如果其中一个是null，说明在一棵树上结点到头，另一棵树结点还没结束，即树不相同，
         * 或者两个结点都非空，并且结点值不相同，返回false。
         * 
         * 最后递归处理两个结点的左右子树，返回左右子树递归的与结果即可。
         * 这里使用的是先序遍历，算法的复杂度跟遍历是一致的，如果使用递归，时间复杂度是O(n)，
         * 空间复杂度是O(logn)
         * 
         * Julia's comment: 
         * 1. online judge:
         *  54 / 54 test cases passed.
            Status: Accepted
            Runtime: 176 ms
         */
        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)  // both nodes reaches the end
                return true;

            if (p == null || q == null)  // only one of them reaches the end
                return false;

            if (p.val != q.val)          // compare the value 
                return false;

            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);   // two subtrees comparison 
        }

        /*
         * Reference: 
         * http://www.cnblogs.com/lautsie/p/3247097.html
         * 
         * julia's comment: 
         * 1. online judge:
         *  54 / 54 test cases passed.
            Status: Accepted
            Runtime: 156 ms
         * 
         */
        public static bool IsSameTree_B(TreeNode p, TreeNode q)
        {           
            if (p == null && q == null) return true;

            if (p != null && q != null)
            {
                if (p.val == q.val &&
                    IsSameTree_B(p.left, q.left) &&
                    IsSameTree_B(p.right, q.right))
                    return true;
            }

            return false;
        }

        /*
         * Reference:          
         * http://www.cnblogs.com/lautsie/p/3247097.html
         * comment from the above blog: 
         * 非递归版本，使用了Queue，有点类似BFS。顺便说下Java里面的Queue真难用，
         * 连个empty()都没有，要用LinkedList（继承于Queue）
         * 
         * http://blog.csdn.net/sunbaigui/article/details/8981275
         * Analysis from the above blog:
         * 
         * julia's comment: 
         * 
         * 1. Read through C# LinkedList methods
         * 2. Try to find analog of Java LinkedList poll method in C#: 
         *    First, 
         *    RemoveFirst()
         * 3. First time, use LinkedListNode class in C#
         *    LinkedList
         *    LinkedListNode
         *    understand why there are two classes, difference from Java - later. 
         * 4. Java LinkedList offer - add the tail of list vs C# LinkedList  AddLast
         * 5. online judge:
         *      54 / 54 test cases passed.
                Status: Accepted
                Runtime: 168 ms
         * 6. The tree traversal is kind of level traversal, BFS, two trees are compared
         *    to level by level; 
         *    Julia argues that DFS search traversal does not work, counter example: 
         *    two tree can be different, but in-order traversal can be the same. 
         *     2                                                      3
         *    / \                                                    / \ 
         *   1   4       <- in order traversal both 1 2 3 4 - >     2   4 
         *      /                                                  /
         *     3                                                  1
         */
        public static bool isSameTree(TreeNode p, TreeNode q)
        {            
            LinkedList<TreeNode> left = new LinkedList<TreeNode>();
            LinkedList<TreeNode> right = new LinkedList<TreeNode>();

            left.AddFirst(p);   // java LinkedList offer vs C# LinkedList AddFirst ?
            right.AddFirst(q);

            while (left.Count > 0 && right.Count > 0)
            {
                LinkedListNode<TreeNode> l_f = left.First;
                LinkedListNode<TreeNode> r_f = right.First;
                
                left.RemoveFirst();
                right.RemoveFirst(); 

                TreeNode ln = l_f.Value;    
                TreeNode rn = r_f.Value;

                if (ln == null && rn == null) 
                    continue;

                if (ln == null || rn == null) 
                    return false;

                if (ln.val != rn.val) 
                    return false;

                left.AddLast(ln.left);
                left.AddLast(ln.right);

                right.AddLast(rn.left);
                right.AddLast(rn.right);
            }

            if (left.Count > 0 || right.Count > 0) 
                return false;

            return true;
        }
    }
}
