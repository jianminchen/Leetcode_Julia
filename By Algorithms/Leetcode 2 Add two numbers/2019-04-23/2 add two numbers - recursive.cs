using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace add_two_numbers
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

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            if (l1 == null)
                return l2;
            if (l2 == null)
                return l1;

            var next = new ListNode((l1.val + l2.val) % 10);

            var sumNode = AddTwoNumbers(l1.next, l2.next);

            if (l1.val + l2.val >= 10)
            {
                sumNode = AddTwoNumbers(new ListNode(1), sumNode);
            }

            next.next = sumNode;

            return next; 
        }
    }     
}
