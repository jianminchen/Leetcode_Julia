using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTreeLevelOrderTraversal5
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

    class BTreeLevelOrderTraversal5
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

            2. 层序访问更直接的方法是将当前层的节点和下一层的节点分别保存在两个container curLevel
               和nextLevel中（vector, queue, stack都可以，取决于具体要求）。每次扫描curLevel中的节点，
               并将其左右子节点更新到nextLevel中。当curLevel所有节点扫描过后，该层已经遍历完整，swap 
               curLevel和nextLevel即可继续访问。
         * Julia's comment:
         * 1. convert C++ code to C# code
         */

        public static IList<IList<int>> levelOrder(TreeNode root)
        {
            IList<IList<int>> levelNodeValues = new List<IList<int>>();

            if (root == null ) return levelNodeValues;

            IList<TreeNode> curLevel = new List<TreeNode>();
            IList<TreeNode> nextLevel = new List<TreeNode>();

            curLevel.Add(root);

            while (curLevel.Count != 0)
            {
                // scan curLevel, collect values of curLevel nodes, and generate nextLevel
                IList<int> curLevelValues = new List<int>();

                for (int i = 0; i < curLevel.Count; i++)
                {
                    TreeNode curNode = curLevel[i];

                    curLevelValues.Add(curNode.val);

                    if (curNode.left != null) 
                        nextLevel.Add(curNode.left);

                    if (curNode.right != null) 
                        nextLevel.Add(curNode.right);
                }

                levelNodeValues.Add(curLevelValues);

                //swap curLevel and nextLevel, and clear nextLevel
                IList<TreeNode> temp = curLevel;
                curLevel = nextLevel;
                nextLevel = temp;
                nextLevel.Clear();
            }

            return levelNodeValues;
        }
    }
}
