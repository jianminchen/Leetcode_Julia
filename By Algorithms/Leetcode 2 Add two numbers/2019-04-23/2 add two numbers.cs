using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Add_Two_numbers
{
    public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// written on 4/23/2019
        /// I was so nervous since I only have 37 minutes to complete in the mock interview code screen
        /// on leetcode.com
        /// But I should consider to write a recursive solution instead, it will be much shorter and less time. 
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            if (l1 == null)
                return l2;
            if (l2 == null)
                return l1;

            var dummyHead = new ListNode(-1);

            ListNode head1 = l1;
            ListNode head2 = l2;

            ListNode sumNode = dummyHead;

            var carry = 0;
            while (head1 != null || head2 != null)
            {
                var sum = carry;
                if (head1 != null)
                    sum += head1.val;

                if (head2 != null)
                    sum += head2.val;

                var head = new ListNode(sum % 10);
                sumNode.next = head;

                if (head1 != null)
                    head1 = head1.next;

                if (head2 != null)
                    head2 = head2.next;

                // next iteration
                carry = sum / 10;
                sumNode = head;
            }

            if (carry > 0)
            {
                var node = new ListNode(1);
                sumNode.next = node;
            }

            return dummyHead.next;
        }
    }
}
