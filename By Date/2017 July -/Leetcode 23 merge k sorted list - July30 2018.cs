using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_23_merge_k_sorted_list_2018_July
{
    /// <summary>
    /// Leetcode 23 - merge k sorted list 
    /// merge sort - divide and conquer - master theorem
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
            // 1 -> 4 -> 5
            var list1 = new ListNode(1);
            var node4 = new ListNode(4);
            var node5 = new ListNode(5);

            list1.next = node4;
            node4.next = node5; 

            // 1 -> 3 -> 4
            var list2 = new ListNode(1);
            var node3 = new ListNode(3);
            var node4B = new ListNode(4);

            list2.next = node3;
            node3.next = node4B;

            // 2 -> 6
            var list3 = new ListNode(2);
            var node6 = new ListNode(6);
            list3.next = node6;

            var merged = MergeKLists(new ListNode[]{list1, list2, list3}); 
        }

        /// <summary>
        /// use merge sort, apply master theorem. The time complexity can lower down O(n*k*logk). 
        /// Compared to naive merge, 1 and 2 merge, and then merge with list No.3, the time complexity
        /// will be O(1 + 2 + 3 + ...+ K) = O(k^2), actually O(k^2*n)
        /// Detail please review my blog here:
        /// http://juliachencoding.blogspot.com/2016/07/leetcode-23-merge-k-sorted-lists.html
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public static ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0)
                return null;

            var n = lists.Length;           

            while (n > 1)
            {
                int k = (n + 1) / 2;   // +1 is the secret to cover everything

                for (int i = 0; i < n / 2; i++)
                {
                    lists[i] = merge2list(lists[i], lists[i + k]); // ensure that i + k < n / 2 + (n+1)/2
                }

                n = k;
            }

            return lists[0];  // first list will contain everything
        }

        /// <summary>
        /// merge two lists, and then save the result into the first list
        /// </summary>
        /// <param name="head1"></param>
        /// <param name="head2"></param>
        /// <returns></returns>
        private static ListNode merge2list(ListNode head1, ListNode head2)
        {
            var dummyNode = new ListNode(0);
            var merged = dummyNode;

            // finish one of the two lists first
            while (head1 != null && head2 != null)
            {
                // two pointer technique - move the pointer one
                if (head1.val <= head2.val)
                {
                    merged.next = head1;
                    head1 = head1.next;
                }
                else
                {
                    merged.next = head2;
                    head2 = head2.next;
                }

                merged = merged.next;
            }

            // rest of list is simple, just connect to one of the lists
            if (head1 != null)
            {
                merged.next = head1;
            }
            else if (head2 != null)
            {
                merged.next = head2;
            }

            return dummyNode.next;
        }
    }
}
