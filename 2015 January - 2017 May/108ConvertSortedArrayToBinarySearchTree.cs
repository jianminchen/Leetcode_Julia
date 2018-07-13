using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _108ConvertSortedArrayToBinarySearchTree
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
         * Reference for source code and analysis:
         * http://blog.csdn.net/linhuanmars/article/details/23904883
         * 
         * analysis from the above blog:
         * 这道题是二分查找树的题目，要把一个有序数组转换成一颗二分查找树。
         * 其实从本质来看，如果把一个数组看成一棵树（也就是以中点为根，左右为
         * 左右子树，依次下去）数组就等价于一个二分查找树。所以如果要构造这棵树，
         * 那就是把中间元素转化为根，然后递归构造左右子树。所以我们还是用二叉树
         * 递归的方法来实现，以根作为返回值，每层递归函数取中间元素，作为当前根
         * 和赋上结点值，然后左右结点接上左右区间的递归函数返回值。时间复杂度还是
         * 一次树遍历O(n)，总的空间复杂度是栈空间O(logn)加上结果的空间O(n)，
         * 额外空间是O(logn)，总体是O(n). 
         * 
         * 这是一道不错的题目，模型简单，但是考察了遍历和二分查找树的数据结构
         * 
         * Julis's comment: 
         *  1. use the array start and end index is smart choice, for diving two subtrees. 
         *  2. use the root index as variable, for two subtree calculation
         *  3. pass online judge
         *  32 / 32 test cases passed.
            Status: Accepted
            Runtime: 172 ms
         */
        public static TreeNode sortedArrayToBST(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return null;

            return helper(nums, 0, nums.Length - 1);
        }

        private static TreeNode helper(int[] nums, int start, int end)
        {
            if (start > end)
                return null;

            int root_I = (start + end) / 2;  // root index

            int l_Start = start;                // left subtree start index 
            int l_End = root_I - 1;          // right subtree end index 

            int r_Start = root_I + 1;
            int r_End = end; 

            TreeNode root = new TreeNode(nums[root_I]);

            root.left = helper(nums, l_Start, l_End);
            root.right = helper(nums, r_Start, r_End);

            return root;
        }  

    }
}
