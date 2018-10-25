using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _106ConstructuBTreeFromInorderPostOrderTraversal
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
         * Leetcode: 
         * 106 Construct Binary Tree from Inorder and Post order traversal 
         * 
         * code reference: 
         * http://siddontang.gitbooks.io/leetcode-solution/content/tree/construct_binary_tree.html
         * 
         * analysis from the above blog:
         Given inorder and postorder traversal of a tree, construct the binary tree.
        要知道如何构建二叉树，首先我们需要知道二叉树的几种遍历方式，譬如有如下的二叉树：

                        1
                --------|-------
                2               3
            ----|----       ----|----
            4       5       6       7
        前序遍历 1245367
        中序遍历 4251637
        后续遍历 4526731
         
        具体到上面这一题，我们知道了一个二叉树的中序遍历以及后序遍历的结果，那么如何构建这颗二叉树呢？

        仍然以上面那棵二叉树为例，我们可以发现，对于后序遍历来说，最后一个元素一定是根节点，也就是1。然后我们在
        中序遍历的结果里面找到1所在的位置，那么它的左半部分就是其左子树，有半部分就是其右子树。

        我们将中序遍历左半部分425取出，同时发现有序遍历的结果也在相应的位置上面，只是顺序稍微不一样，也就是452。
        我们可以发现，后序遍历中的2就是该子树的根节点。

        上面说到了左子树，对于右子树，我们取出637，同时发现后序遍历中对应的数据偏移了一格，并且顺序也不一样，为673。
        而3就是这颗右子树的根节点。

        重复上述过程，通过后续遍历找到根节点，然后在中序遍历数据中根据根节点拆分成两个部分，同时将对应的后序遍历的数据
        也拆分成两个部分，重复递归，就可以得到整个二叉树了。
         
        这里我们需要注意，为了保证快速的在中序遍历结果里面找到根节点，我们使用了hash map。
         
         
         * Julia's comment: 
         * 1. Practice the algorithm using C#
         * 2. Try to pass online judge
         * 3. Try to improve the code for more reable, testable, maintainable. 
         * 4. C++ unordered_map<int, int>  vs C# hashtable 
         * 5. hashtable is extra space used for storing inorder array's node value as key, position as value, 
         *    extra space depends on the hashtable size. 
         *    assuming that the value is unique in the inorder traversal array. Why? 
         *    
         *    Compare to alternative solution, if in the build function, go through 
         *    the array one by one to find the root position, time is O(N), then, in total, 
         *    at least O(ln N) recursive calls, so this time complexity is O(N lnN).
         *    
         *    So, the hashtable is a great idea to set up once, and use for every recursive
         *    calls.
         * 6. 9/13/2015: add more notes after code is complete
         *    post order traversal array: Left subtree, right subtree, root node
         *    in order traversal array: left subtree, root node, right subtree
         *    So, find root node is O(1) using post order traversal array, 
         *    and then, use the value to find its position in the in order traversal array, 
         *    preprocessing a hashtable to store inorder traversal array, then, find position using O(1) only 
         *    in each recusive call. 
         *    
         *    Then, work on left subtree, right subtree, only thing is to find the root for each of them. 
         * 
         */
        static Hashtable htable = new Hashtable();

        public static TreeNode buildTree(int[] inorder, int[] postorder) {
            int p_l = postorder.Length; 
            if(p_l == 0 ) {
                return null;
            }

            int i_l = inorder.Length;     
            for(int i = 0; i < i_l; i++) {
                htable[inorder[i]] = i;
            }

            return build(inorder, 0, i_l - 1,
                postorder, 0,  p_l- 1);
        }

        /*
         *     
                        
                        1
                --------|-------
                2               3
            ----|----       ----|----
            4       5       6       7
         
        preorder traversal:   1245367
        inorder traversal:    4251637
        postorder traversal:  4526731
         * 
         * code reference: 
         * http://siddontang.gitbooks.io/leetcode-solution/content/tree/construct_binary_tree.html
         * 
         * Julia's comment: 
         * 1. thought process: 
         *    only 3 things to do in order to construct the tree: 
         *    1. Find the root
         *    2. Find root's left child
         *    3. Find root's right child
         *    and then, 
         *      the root is the last element of post order traversal, 
         *      remember, the post order traversal, is 
         *      4, 5->2 (from down to up), 6, 7->3->1 (from down to up) 
         *      So, find the node in the in order traversal array, denote as rootPos.  
         *      and then, use recursive call to find root's left child, smiliar the step 1: find the root, 
         *          because it is to find the root of left subtree, in other words, find the root of a tree. 
         *      and then, use recursive call to find root's right child, smiliar the stpe 1: find the root
         *      Only need to calculate the post order traversal start / end index accordingly, using rootPos variable. 
         *      That is all. 
         *      
         *  Please count how many minutes to do the calculation of two recursive call - start /end position 
         *   in order traversal   s0  (mid-1)  mid  (mid+1)  e0 
         *                                      ^
         *                                      |  
         *     left subtree length / count of nodes is num = mid - s0
         *                                     
         *   post order traversal s1   ?  ?  (e1-1)
         *   since post oder first part should be same length of in order traversal left part,
         *   [s1, s1 + num -1], 
         *   second part is 
         *   [s1+num, e1-1] 
         *   
         *   Or, remember: 
         *   in order traversal array, only root node is not in the recursive call; the position is retrieved from hashtable, rootPos; 
         *   post order traversal array, only root node, last node is not in the recursive call. 
         *   
         *   The time to prepare recursive calls - inorder/ postorder traversal array is julia's traing area, 
         *    nornally, it will take julia 20 minutes / need to cut down 2-3 minutes
         *    
         *    tips to cut the calculation
         *    how to prepare the interval without error
         *    what is most important test case to run through for those two intervals 
         *   
         *   another training, use recursive call to find left child and right child, it is the same task, use recursive call. 
         *   The decision has to be made quickly and firmly, in 1-2 minutes. 
         *   
         * The interval should be encapsulated in the class/structure/interface, then, it is not easy to miss
         * any mistake when writing. Here is the second version of C# solution: (9/13/2015)
         * https://github.com/jianminchen/Leetcode_C-/blob/master/106ConstructBTreeFromInOrderPostOrderTraversal_B.cs
         * 
         * 2. online judge:
         *  202 / 202 test cases passed.
            Status: Accepted
            Runtime: 176 ms
         */
        public static TreeNode build(int[] inorder, int s0, int e0,
            int[] postorder, int s1, int e1) {
            if(s0 > e0 || s1 > e1) {
                return null;
            }

            TreeNode root = new TreeNode(postorder[e1]);

            int v = postorder[e1];              // v - root value 
            int p = (int)htable[v];             // p - root position in inorder traversal array 

            int count = p - s0;                 // count - the size of left subtree, how many nodes 

            int start1 = s0;                
            int end1   = p - 1;         
            int start2 = s1;                
            int end2   = s1 + count - 1;    

            root.left = build(inorder, start1, end1, postorder, start2, end2);

            start1 = p + 1;               
            end1   = e0;
            start2 = s1 + count;
            end2   = e1 - 1; 

            root.right = build(inorder, p + 1, e0, postorder, s1 + count, e1 - 1);

            return root;
        }
    }
}
