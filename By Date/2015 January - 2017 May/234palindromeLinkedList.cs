using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace palindromeLinkedList
{
    class Program
    {
        public class ListNode
        {
            public int value;
            public ListNode next;

            public ListNode(int v)
            {
                value = v; 
            }
        }

        static void Main(string[] args)
        {
            // test case 1: 
            ListNode n1 = new ListNode(1);
            n1.next = new ListNode(2);
            n1.next.next = new ListNode(2);
            n1.next.next.next = new ListNode(1);

            bool res = isPalindrome(n1);

            // test case 2: 
            ListNode n2 = new ListNode(1);
            n2.next = new ListNode(2);
            n2.next.next = new ListNode(1);
           

            bool res2 = isPalindrome(n2);

        }

        /*
         * Leetcode: 
         * palindrome linked list 
         * soource code from blog:
         * http://www.programerhome.com/?p=26238
         * http://blog.csdn.net/xudli/article/details/46871949
         * comment from the blog:
         * 可以在找到中点后，将后半段的链表翻转一下，这样我们就可以按照回文的顺序比较了
         * convert Java to C#
         * Julis's comment:
         * 1. the code is very easy to follow
         * 
         */
        public static bool isPalindrome(ListNode head)
        {
            //input check  abcba abccba
            if (head == null || head.next == null) return true;

            ListNode middle = partition(head);
            middle = reverse(middle);

            while (head != null && middle != null)
            {
                if (head.value != middle.value) return false;
                head = head.next;
                middle = middle.next;
            }
            return true;
        }

        private static ListNode partition(ListNode head)
        {
            ListNode p = head;
            while (p.next != null && p.next.next != null)
            {
                p = p.next.next;
                head = head.next;
            }

            p = head.next;
            head.next = null;
            return p;
        }

        /**
         * Julia's comment: 
         * how to reverse a singly linked list 
         * pre -> cur -> nxt (3rd node)
         * 1. save 3rd node before break the link next of cur node
         * 2. reverse link of cur's next
         * 3. move pre, cur forward one step 
         */
        private static ListNode reverse(ListNode head)
        {
            if (head == null || head.next == null) return head;
            ListNode pre = head;
            ListNode cur = head.next;
            pre.next = null;
            ListNode nxt = null;

            while (cur != null)
            {
                nxt = cur.next;
                cur.next = pre;
                pre = cur;
                cur = nxt;
            }
            return pre;
        }
    }
}
