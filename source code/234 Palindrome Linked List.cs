using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_234_Palindrome_Linked_List
{
    /// <summary>
    /// Leetcode 234 Palindrome linked list 
    /// https://leetcode.com/problems/palindrome-linked-list/description/
    /// Could you do it in O(n) time and O(1) space?
    /// </summary>
    class Program
    {
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        static void Main(string[] args)
        {
            RunTestcase();
        }

        public static void RunTestcase()
        {
            var head  = new ListNode(1);
            var node2 = new ListNode(2);           

            head.next = node2;           

            var result = IsPalindrome(head);
        }

        public static void RunTestcase2()
        {
            var head = new ListNode(1);
            var node2 = new ListNode(2);
            var node3 = new ListNode(2);
            var node4 = new ListNode(1);

            head.next = node2;
            node2.next = node3;
            node3.next = node4;

            var result = IsPalindrome(head);
        }

        /// <summary>
        /// design function using three API
        /// 1. reverse linked list
        /// 2. get length of linked list
        /// 3. get kth linked list node
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static bool IsPalindrome(ListNode head)
        {
            if (head == null)
                return true;

            if (head.next == null)
                return true;

            var length = getLinkedListLength(head);
            var isEven = length % 2 == 0;
            var back = head;
            var front = getNodeGivenK(head, length/ 2);
            if (!isEven)
            {
                front = front.next;
            }
            
            var reversed = reverseLinkedList(front);

            // compare two linked list one element a time 
            var index = 0;
            while (index < length / 2)
            {
                if (back.val != reversed.val)
                    return false;

                back = back.next;
                reversed = reversed.next;
                index++;
            }

            return true;
        }

        /// <summary>
        /// reverse a linked list using O(N) time and O(1) space
        /// </summary>
        /// <param name="head"></param>
        private static ListNode reverseLinkedList(ListNode head)
        {
            if (head == null)
                return null;
            if (head.next == null)
                return head;

            var next = head.next;
            var reversed = reverseLinkedList(next);

            head.next = null;
            next.next = head;

            return reversed;
        }

        private static ListNode getNodeGivenK(ListNode head, int k)
        {
            if (k == 0)
                return head;

            int index = 0;
            var iterate = head;
            while (index < k)
            {
                iterate = iterate.next;
                index++;
            }

            return iterate;
        }

        private static int getLinkedListLength(ListNode head)
        {
            if (head == null)
                return 0;

            var index = 0; 
            var iterate = head;
            while (iterate != null)
            {
                index++;

                iterate = iterate.next;
            }

            return index; 
        }
    }
}
