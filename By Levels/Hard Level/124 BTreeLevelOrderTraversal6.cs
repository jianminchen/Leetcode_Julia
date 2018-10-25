using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTreeLevelOrderTraversal6
{
    class LevelNode {
        public TreeNode node;
        public int level;
        public LevelNode(TreeNode nd, int lvl)
        {
            node    = nd;
            level   = lvl;
        }
    };

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

    class BTreeLevelOrderTraversal6
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
         * 2. 单个queue的迭代解法 - using queue, iteratively solution
         * 3. 注意需要检查当前节点是否在新的一层，如果是新的一层
              第一个节点，则要相应增加levelNodeValues的尺寸。(line 90, line 91 )
         *    comment from the above blog - good tip to practice using List class in C# 
         *    tip to avoid runtime exception: add an empty list, otherwise, index out of range error.
         * 3. Learn to use List<IList<int>> class, add new list first, and then, 
         *    access it using operator []
         */
        public static IList<IList<int>> levelOrder(TreeNode root)
        {
            IList<IList<int>> levelNodeValues = new List<IList<int>>();

            if(root == null) return levelNodeValues;
        
            Queue<LevelNode> q = new Queue<LevelNode>();
            q.Enqueue(new LevelNode(root,0));
        
            while(q.Count > 0) {
                LevelNode curLevelNode  = q.Peek();
                TreeNode  curNode       = curLevelNode.node;
                int curLevel = curLevelNode.level;
                q.Dequeue();            
                
                if(curLevel == levelNodeValues.Count)
                    levelNodeValues.Add(new List<int>());                                                            

                levelNodeValues[curLevel].Add(curNode.val);
            
                if(curNode.left  != null) q.Enqueue(new LevelNode(curNode.left, curLevel+1));
                if(curNode.right != null) q.Enqueue(new LevelNode(curNode.right,curLevel+1));
            }
        
            return levelNodeValues;        
        }
    }
}
