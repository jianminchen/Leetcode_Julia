using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _109_convert_sorted_list_to_binary_search_tree
{
    /// <summary>
    /// review on 9/11/2018
    /// Review the blog:
    /// https://articles.leetcode.com/convert-sorted-list-to-balanced-binary/
    /// </summary>
    class Program
    {
        // Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        static void Main(string[] args)
        {
            var node1 = new ListNode(1);
            var node2 = new ListNode(2);
            var node3 = new ListNode(3);
            var node4 = new ListNode(4);
            var node5 = new ListNode(5);
            var node6 = new ListNode(6);
            var node7 = new ListNode(7);

            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            node5.next = node6;
            node6.next = node7;

            var root = SortedListToBST(node1);
        }       

        /// <summary>
        /// The time complexity will be O(N), N is the total number of nodes in the sorted linked list.
        /// Use bottom up approach to construct the binary search tree.
        /// 
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static TreeNode SortedListToBST(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            var iterate = head;
            int count = 0;
            while (iterate != null)
            {
                iterate = iterate.next;
                count++;
            }

            return InorderTraversalBottomUp(ref head, 0, count - 1);
        }

        /// <summary>
        /// BST inorder traversal - match the sorted linked list order
        /// In terms of constructing BST, the inorder traversal is applied. 
        /// https://articles.leetcode.com/convert-sorted-list-to-balanced-binary/
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private static TreeNode InorderTraversalBottomUp(ref ListNode list, int start, int end)
        {
            if (start > end)
                return null;

            int middle = (start + end) / 2;

            // enforce inorder traversal - left, root, right 
            // Left
            var left = InorderTraversalBottomUp(ref list, start, middle - 1);

            // Root 
            // each node in the sorted list will be visited one by one,
            // the node will be the root node of the tree. 
            var root = new TreeNode(list.val);

            root.left = left;

            // go to next one in the sorted linked list 
            list = list.next;

            // Right
            root.right = InorderTraversalBottomUp(ref list, middle + 1, end);

            return root;
        }
    }
}
