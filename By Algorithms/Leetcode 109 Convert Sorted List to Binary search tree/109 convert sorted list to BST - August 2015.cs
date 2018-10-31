using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _109_Convert_sorted_list_to_binary_search_tree_3
{
    public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
    }

    public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }

        public TreeNode SortedListToBST(ListNode head)
        {
            return sortedListToBST(head, listLength(head));
        }

        /// <summary>
        /// solution was written in August 2015
        /// So excited to review the solution 
        /// </summary>
        /// <param name="head"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public TreeNode sortedListToBST(ListNode head, int len)
        {
            if (len == 0) return null;

            if (len == 1) return
                new TreeNode(head.val);

            // put all calculations here - think about how to spend shortest time on the calculation 
            int rootIndex = len / 2;       // starting from 0, 
            int rightTreeHeadIndex = len / 2 + 1;  // example: len is even, 1, 2, 3, 4 four node
            // left tree, 1, 2, then, root index: 

            int leftTreeLen = len / 2;        
            int rightTreeLen = len - len / 2 - 1; // leftTreeLen + rightTreeLen + 1 = len; 
            // len can be even or odd, so len%2 can be 1 or 0 

            ListNode nthNode = nth_node(head, rootIndex);

            TreeNode root = new TreeNode(nthNode.val);   
            // Julia's comment: cost of calculation: O(n/2) , 
            // go through the list node one by one starting from head. 
            // how many times: O(log n), height of tree
            // time complexity: O(n logn) 
            // if the root node can be random accessed like array, hashmap, O(1)
            // then, this algorithm will not be best in time complexity. 
            // this should be considered when you choose the algorithm, 
            // this is called top-down

            root.left = sortedListToBST(head, leftTreeLen);

            ListNode secondHalf = nth_node(head, rightTreeHeadIndex);
            root.right = sortedListToBST(secondHalf, rightTreeLen);

            return root;
        }

        private int listLength(ListNode node)
        {
            int n = 0;
            while (node != null)
            {
                ++n;
                node = node.next;
            }

            return n;
        }

        private ListNode nth_node(ListNode node, int n)
        {
            while (n > 0)
            {
                node = node.next;

                n--;
            }

            return node;
        }
    }
}
