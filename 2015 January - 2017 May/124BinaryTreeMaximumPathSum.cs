using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _124BinaryTreeMaximumPathSum
{
    public class TreeNode{
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
         * http://fisherlei.blogspot.ca/2013/01/leetcode-binary-tree-maximum-path-sum.html
         * Analysis from the above blog:
         * For each node like following, there should be four ways existing for max path:

            1. Node only
            2. L-sub + Node
            3. R-sub + Node
            4. L-sub + Node + R-sub

            Keep trace the four path and pick up the max one in the end.
         * 
           Julia's comment:
         * 1. Pass online judge: 
         *  92 / 92 test cases passed.
            Status: Accepted
            Runtime: 188 ms
         */
        public static int maxPathSum(TreeNode root) {  
          
          int maxAcrossRoot = Int16.MinValue;  

          int maxEndByRoot = GetMax(root, ref maxAcrossRoot);  

          return Math.Max(maxAcrossRoot, maxEndByRoot);  
        }  

        private static int GetMax(TreeNode node, ref int maxAcrossRoot)  
        {  
          if(node == null) 
              return 0;  

          int left = GetMax(node.left, ref maxAcrossRoot);  
          int right = GetMax(node.right, ref maxAcrossRoot);  

          int cMax = node.val;  
          
          if(left > 0)  
            cMax += left;  

          if(right > 0)  
            cMax+=right;  

          maxAcrossRoot = Math.Max(maxAcrossRoot, cMax);  

          int val = node.val; 
          int maxLR = Math.Max(node.val+left, node.val+right);

          return Math.Max( val, maxLR);  
        }

        /*
         * another version
         * 1.Julia's comment:
         *   pass online judge
         *   
         * Write down thought process, but I cannot recall anything on August 25, 2015, worked on the 
         * problem more than a month ago:
         * 1. read a few of blogs, and try to figure out. 
         * http://www.jiuzhang.com/solutions/binary-tree-maximum-path-sum/
         * 
         * use this blog's analysis, and see if I complete my thought process script.
         * 
         * http://www.cnblogs.com/zuoyuan/p/3745606.html
         
         * 解题思路：这道题是在树中寻找一条路径，这条路径上的节点的和为最大，起点和终点只要是树里面
         * 的节点就可以了。这里需要注意的一点是：节点值有可能为负值。解决这道二叉树的题目还是来使用递归。例如下面这棵树：

　　　　　　　　　　　　   1

　　　　　　　　　　   /     \

　　　　　　　　　　 2        3

    　　　　　　　 /  \      /   \

　　　　　　　　　4     5    6    7

          对于这棵树而言，和为最大的路径为：5->2->1->3->7。

          那么这条路径是怎么求出来的呢？这里需要用到一个全局变量Solution.max，可以随时被更大的路径和替换掉。
          在函数递归到左子树时：最大的路径为：4->2->5。但此时函数的返回值应当为4->2和5->2这两条路径中和最大的一条。
          右子树同理。
          
          而Solution.max用来监控每个子树中的最大路径和。那么思路就是：（左子树中的最大路径和，右子树中的最大路径和，
          以及左子树中以root.left为起点的最大路径（需要大于零）+ 右子树中以root.right为起点的最大路径（需要大于零）+root.val），
          这三者中的最大值就是最大的路径和。
         
         * Julia's work on the thought process: 
         * Cannot complete in 10 minutes, leave it for future work. 
         */
        public static int MaxPathSum_B(TreeNode root)
        {
            int max = Int32.MinValue;

            dfs(root, ref max);

            return max;
        }

        public static int dfs(TreeNode root, ref int max)
        {
            if (root == null) return 0;

            int l = dfs(root.left, ref max);
            int r = dfs(root.right, ref max);

            int m = root.val;

            if (l > 0) m += l;
            if (r > 0) m += r;

            if (m > max) max = m;

            return Math.Max(l, r) > 0 ? Math.Max(l, r) + root.val : root.val;
        }
    }
}
