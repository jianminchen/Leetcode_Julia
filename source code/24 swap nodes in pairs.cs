using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24_swap_nodes_in_pairs
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
        }

        public ListNode SwapPairs(ListNode head)
        {
            if (head == null)
                return head;

            var dummyHead = new ListNode(-1);
            dummyHead.next = head;

            var previous = dummyHead;
            var current = head;

            while (current != null && current.next != null)
            {
                // swap current and current.next two nodes
                var tmp = current.next.next;
                previous.next = current.next;
                previous.next.next = current;
                current.next = tmp;

                previous = current;
                current = tmp;
            }

            return dummyHead.next;
        }
    }
}
