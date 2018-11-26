using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _889_Construct_binary_tree_from_pre_and_post_order
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            RunTestcase3(); 
        }

        public static void RunTestcase1()
        {
            var pre  = new int[] { 1, 2, 4, 5, 3, 6, 7 };
            var post = new int[] { 4, 5, 2, 6, 7, 3, 1 };

            var root = ConstructFromPrePost(pre, post); 
        }

        public static void RunTestcase2()
        {
            var pre  = new int[] { 2, 1 };
            var post = new int[] { 1, 2 };

            var root = ConstructFromPrePost(pre, post); 
        }

        public static void RunTestcase3()
        {
            var pre = new int[] { 3, 4, 1, 2 };
            var post = new int[] { 1, 4, 2, 3 };

            var root = ConstructFromPrePost(pre, post);
        }

        /// <summary>
        /// find the root number from preorder array, which should be the first number. 
        /// Find left subtree by going over preorder array and post order array, 
        /// compare two hashset if they are the same, then left subtree is found. The idea is based
        /// on the fact that all numbers in the tree are distinct. 
        /// </summary>
        /// <param name="pre"></param>
        /// <param name="post"></param>
        /// <returns></returns>
        public static TreeNode ConstructFromPrePost(int[] pre, int[] post)
        {
            if (pre == null || post == null)
                return null;
            if (pre.Length != post.Length)
                return null;

            var length = pre.Length;

            return constructTree(pre, 0, length, post, 0);
        }

        /// <summary>
        /// based on the tree has distinct value for each node, left subtree can be determined by 
        /// comparison pre and post array subset. 
        /// </summary>
        /// <param name="pre"></param>
        /// <param name="start1"></param>
        /// <param name="end1"></param>
        /// <param name="post"></param>
        /// <param name="start2"></param>
        /// <param name="end2"></param>
        /// <returns></returns>
        private static TreeNode constructTree(int[] pre, int start1, int length, int[] post, int start2)
        {
            if (start1 >= pre.Length || length == 0)  // caught by online judge, missing base case length == 0
                return null;

            if (length == 1)
            {
                return new TreeNode(pre[start1]);
            }

            var root = new TreeNode(pre[start1]);
            
            var setPre = new HashSet<int>();
            var setPost = new HashSet<int>();

            // Find left subtree
            int index = 0;
            while (index < length)
            {
                setPre.Add(pre[start1 + 1 + index]); // caught by online judge, + 1, skip the root
                setPost.Add(post[start2 + index]);
                if (setPre.IsSubsetOf(setPost) && setPost.IsSubsetOf(setPre))
                {
                    break;
                }

                index++;
            }

            var leftSubtreeLength  = index + 1;
            var rightSubtreeLength = length - leftSubtreeLength - 1;
 
            root.left  = constructTree(pre, start1 + 1,                     leftSubtreeLength,  post, start2);
            root.right = constructTree(pre, start1 + 1 + leftSubtreeLength, rightSubtreeLength, post, start2 + leftSubtreeLength);

            return root; 
        }
    }
}
