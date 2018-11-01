using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _328_odd_even_linked_list
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var node1 = new ListNode(1);
            var node2 = new ListNode(2);
            var node3 = new ListNode(3);
            var node4 = new ListNode(4);
            var node5 = new ListNode(5);
            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;

            var result = OddEvenList(node1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ListNode OddEvenList(ListNode head)
        {
            var dummyOddHead  = new ListNode(0);
            var dummyEvenHead = new ListNode(0);

            var oddPrevious  = dummyOddHead;
            var evenPrevious = dummyEvenHead;
            var iterate = head;
            int index = 1; 
            while (iterate != null)
            {
                if (index % 2 == 0)
                {
                    evenPrevious.next = iterate;
                    evenPrevious = iterate;
                }
                else
                {
                    oddPrevious.next = iterate;
                    oddPrevious = iterate;
                }

                // work on iteration
                iterate = iterate.next;
                index++;
            }

            oddPrevious.next = dummyEvenHead.next;
            evenPrevious.next = null; // added after the testing

            return dummyOddHead.next;
        }
    }
}
