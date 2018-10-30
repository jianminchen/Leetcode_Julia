using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _206_reverse_linked_list
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
        /// reverse linked list
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseList(ListNode head)
        {
            if (head == null)
                return null;

            if (head.next == null)
                return head;

            var next = head.next; 
            var rest = ReverseList(head.next);
            next.next = head;
            head.next = null;

            return rest;
        }
    }
}
