using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTreeLevelOrderTraversal7
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

    class BTreeLevelOrderTraversal7
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
         * source code from the blog:
         * http://bangbingsyb.blogspot.ca/2014/11/leetcode-binary-tree-level-order.html
         * comment from blog:
         * 这两题实际是一回事，考察的都是树的层序访问。无非就是在I得到结果后做一次reverse就能得到
         * II要求的结果。无论是树还是图，层序访问最直接的方法就是BFS。

            1. BFS可以用一个queue实现，但是难以跟踪每个节点究竟是在第几层。解决办法是除了压入节点
              指针外，还同时压入节点所在的层数，即压入pair<TreeNode*, int>。
          
         * Julia's comment:
         * 1. convert C++ code to C# code
         * 2. 单个queue的迭代解法 - using queue, iteratively solution
         * 3. 在压入root后，需要额外压入一个NULL来标记第i层尾, 最后一层不用. 
         */
        public static IList<IList<int>> levelOrder(TreeNode root)
        {
            IList<IList<int>> levelNodeValues  = new List<IList<int>>();

            if (root == null) return levelNodeValues;

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            q.Enqueue(null);

            int curLevel = 0;

            while (q.Count >0)
            {
                TreeNode cur = q.Peek();
                q.Dequeue();

                if (cur == null)
                {
                    curLevel++;
                    if (q.Count > 0)   // ensure the checking, avoid dead loop 
                        q.Enqueue(null);
                }
                else
                {
                    if (curLevel == levelNodeValues.Count)
                        levelNodeValues.Add(new List<int>());

                    levelNodeValues[curLevel].Add(cur.val);

                    if (cur.left != null)
                        q.Enqueue(cur.left);

                    if (cur.right != null)
                        q.Enqueue(cur.right);
                }
            }

            return levelNodeValues;
        }
    }
}
