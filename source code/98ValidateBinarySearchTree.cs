using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _98ValidateBinarySearchTree
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
         * Spent over 4 hours to go over solutions, on August 28, August 29, 2015
         * A list of solutions tried:
         * 1. recursive, time O(n), using beta-alpha pruning? 
         * 2. recursive, use long Max value / min Value instead of int's to avoid the bug
         * 3. use inorder traversal output to help checking BST
         * 4. same as 3, value TreeNode variable
         * 5. sames as 3, 
         * 6. same as 3, 
         * 7. same as 3, but use iterative solution 
         * 8. Great analysis, brute force solution, time complexity O(n^2) vs beta-alpha pruning time O(n)
         */
        /*
         * Reference:
         * http://fisherlei.blogspot.ca/2013/01/leetcode-validate-binary-search-tree.html
         * 
         * analysis from the above blog:
         * 对于每一个子树，限制它的最大，最小值，如果超过则返回false。
           对于根节点，最大最小都不限制；
           每一层节点，左子树限制最大值小于根，右子树最小值大于根；
           但是比较有趣的是，在递归的过程中还得不断带入祖父节点的值。

           或者，中序遍历该树，然后扫描一遍看是否递增。
         * 红字部分是关键点。不把变量遗传下去的话，没法解决如下例子：
            {10,5,15,#,#,6,20}
         * 
         * julia's comment:
         * 1. Failed to pass online judge: 
         *  [2147483647] input, false, should be true
         */
        public static bool isValidBST(TreeNode root)
        {
            return IsValidBST(root, int.MinValue, int.MaxValue);
        }

        public static bool IsValidBST(TreeNode node, int MIN, int MAX)
        {
            if (node == null)
                return true;

            int v = node.val;
            bool rootInRange = v > MIN && v < MAX;                 // Range: (MIN, MAX) 
            if (!rootInRange)
                return false;

            bool l_BST = IsValidBST(node.left, MIN, v);  // left sub tree BST check: new Range: (MIN, v)
            if (!l_BST)
                return false;

            bool r_BST = IsValidBST(node.right, v, MAX); // right sub tree BST check: new Range: (v, MAX)
            if (!r_BST)
                return false;

            return true;
        }

        /*
         * julia's comment: 
         * 1. change int.MinValue to long.MinValue, int.MaxValue to long.MaxValue
         * 2. pass online judge: 
         *   74 / 74 test cases passed.
             Status: Accepted
             Runtime: 216 ms
         * 3. Some analysis about the binary search tree range: Maximum value and minimum value, thought process please:
         *    Go over an example, binary search tree: 
         *        A
         *      /    \
         *     B      C
         *    / \    /  \
         *   D   E  F    G
         *   Level 1: A,   A is in range: [long.MIN, long.MAX] <- tip: all nodes are int, to include int.MAX, int.MIN, use long range
         *   Level 2: 
         *            B,   B is in range: [long.MIN, A.value]   <- A, go to left , to B, update upper value. 
         *            C,   C is in range: [A.value, long.Max]   <- A, go to right, to C, update lower value.
         *   Level 3: 
         *            D,   D is in range: [long.MIN, B.value]
         *            E,   E is in range: [B.value,  A. value]
         *            ...
         *   How to think recursively? 
         *   Every step, there is a value range to maintain
         * 4. Read the alpha-beat pruning articles: 
         *    http://blog.csdn.net/likecool21/article/details/23271621
         *    http://web.cs.ucla.edu/~rosen/161/notes/alphabeta.html
         *    
         */
        public static bool isValidBST_B(TreeNode root)
        {
            return IsValidBST_B(root, long.MinValue, long.MaxValue);
        }

        public static bool IsValidBST_B(TreeNode node, long MIN, long MAX)
        {
            if (node == null)
                return true;

            int v = node.val;
            if (!(v > MIN && v < MAX))                            // Range: (MIN, MAX) 
                return false;

            if (!IsValidBST_B(node.left, MIN, v))                 // left sub tree BST check: new Range: (MIN, v)
                return false;

            if (!IsValidBST_B(node.right, v, MAX))                // right sub tree BST check: new Range: (v, MAX)
                return false;

            return true;
        }

        /*
         * Reference:
         * http://blog.csdn.net/likecool21/article/details/23271621
         * 
         * analysis from the above blog:
         * 还有一种方法：如果一棵树是BST，那么如果做一个in order traversal
         * 的话产生的数组应该是排好序的。这样就一边进行in order traversal,
         * 一边比较当前值是不是比前一个值大就行了。这里用了个static变量来记录
         * 之前的值，使其在递归时能被记住。如果用C++的话按引用传递就不需要static了。
         * 
         * julia's comment: 
         * 1. online judge: 
         *  38 / 74 test cases passed
         *  input: [0, -1], output: false, expected: true
         */
        public static long previous = long.MinValue;
        public static bool isValidBST_C(TreeNode root)
        {
            if (root == null)
                return true;

            if (isValidBST_C(root.left) == false)  // left subtree
                return false;

            if (root.val <= previous)              // the current node  
                return false;

            previous = root.val;

            if (isValidBST_C(root.right) == false) //the right subtree            
                return false;

            return true;
        }

        /*
         * reference:
         * http://www.cnblogs.com/yuzhangcmu/p/4177047.html
         * Analysis:
         * 使用一个全局变量，用递归的中序遍历来做，也很简单
         * 
         * julia's comment: 
         * 1. Cannot pass online judge
         * Failed test case:
           38 / 74 test cases passed
         * input: [0, -1], output: false, expected: true
         * 
         * 2. Compare the difference using this global variable of tree node to the above using previous value. 
         */
        public static TreeNode pre = null;

        public static bool isValidBST_D(TreeNode root)
        {
            // Just use the inOrder traversal to solve the problem.
            return dfs(root);
        }

        public static bool dfs(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }

            // Judge the left tree.
            if (!dfs(root.left))
            {
                return false;
            }

            // judge the sequence.
            if (pre != null && root.val <= pre.val)
            {
                return false;
            }
            pre = root;

            // Judge the right tree.
            if (!dfs(root.right))
            {
                return false;
            }

            return true;
        }


        /*
         * reference:
         * http://blog.welkinlan.com/2015/05/21/validate-binary-search-tree-leetcode-java/
         * 
         * 
         */
        private static bool isFirstNode = true;
        private static int lastVal = int.MinValue;
        public bool isValidBST_E(TreeNode root)
        {

            if (root == null)
            {
                return true;
            }

            if (!isValidBST_E(root.left))
            {
                return false;
            }

            if (!isFirstNode && root.val <= lastVal)
            {
                return false;
            }

            isFirstNode = false;
            lastVal = root.val;

            if (!isValidBST_E(root.right))
            {
                return false;
            }

            return true;
        }

        /*
         * Reference:
         * 
         * https://github.com/yuzhangcmu/LeetCode/blob/master/tree/IsValidBST_1221_2014.java
         * 
         * Just use the inOrder traversal to solve the problem.
         * 
         * Julia's comment: 
         * 1. review iterative solution inorder traversal algorithm 
         *  thought process, here is the script written: 
         *  
         *  Iterative solution, need a stack, and two nodes variables to help tracking. 
         *  Start from root node as cur, pre node is null
         *  Start a loop, 
         *  inside the loop, 
         *  1. push all the left  nodes into the stack;
         *  2. if stack is empty, time to exit the loop; 
         *  3. pop a node from the stack, since no left nodes, just deal with the current node. 
         *  4. check BST, a value check: based on assumption, inorder traversal output is increasing order.
         *  5. Recover for code reuse, next iteration, set cur to pre;
         *  6. go to the right node. 
         *  
         * 2. online judge passed:
         *      74 / 74 test cases passed.
                Status: Accepted
                Runtime: 172 ms
         */
        public bool isValidBST1(TreeNode root)
        {            
            if (root == null)            
                return true;            

            Stack<TreeNode> s = new Stack<TreeNode>();    

            TreeNode cur = root;                          
            TreeNode pre = null;

            while (true)                 
            {
                while (cur != null)    //  step 1 
                {
                    s.Push(cur);
                    cur = cur.left;
                }

                if (s.Count == 0 )    //  step 2                 
                    break;              

                cur = s.Pop();        //   step 3 

                if (pre != null && pre.val >= cur.val)  // step 4          
                    return false;                

                pre = cur;           // step 5 

                cur = cur.right;     // step 6 
            }

            return true;
        }

        /*
         * Reference:
         * http://www.lifeincode.net/programming/leetcode-validate-binary-search-tree-java/
         * 
         * Analysis from the above reference:
         * Algorithm 1: We have known what is a BST, so we can write a function to find the 
         * maximum value in the left subtree of root node, and the minimum value in the right 
         * subtree of root node, and compare them with value of root. We need to continue doing 
         * this for each node in the tree. But every time we find the maximum value or minimum 
         * value will costs O(n), and this algorithm will cost O(n^2) because we need to do this 
         * for every node, which is not efficient.

           Algorithm 2: For a node root, we know that all nodes in the left subtree is smaller 
         * than the value of root. We can pass this value to the left subtree, checking if the 
         * value of its left child is smaller than this value. Then we will update this passing 
         * value to the value of left child and keep passing it to next level. For the right 
         * subtree, we need to make sure that all values in the right subtree is larger than 
         * the value of root. In conclusion, we should pass two values, which is min and max, 
         * to the next level, and compare the value of nodes. Update the min and max, and pass it 
         * to next level until we reach the leaf node.

           Algorithm 3: The in-order traverse can helps us. Doing a in-order traverse on a BST, 
         * the output will be a increasing sequence.
         * 
         * Algorithm 2 and 3 complexity: time complexity: O(n), since each node is visited once. 
         *
         */
    }
}
