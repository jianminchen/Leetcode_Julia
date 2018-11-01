using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_nth_node_to_the_end
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

            var result = RemoveNthFromEnd(node1, 2);
        }
        /// <summary>
        /// two nodes, one node is ahead of the another n steps away
        /// </summary>
        /// <param name="head"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head == null)
                return head;

            var dummyHead = new ListNode(-1); 
            dummyHead.next = head;

            var front = dummyHead;
            ListNode back = dummyHead;
            ListNode previous = dummyHead;

            int index = 0;
            while (front != null)
            {
                front = front.next;
                if (index >= n)  // n = 1, 
                {                    
                    // next iteration
                    previous = back; 
                    back = back.next;

                    if (front == null)
                    {
                        previous.next = back.next;
                    }
                }

                index++;
            }

            return dummyHead.next; 
        }
    }
}
