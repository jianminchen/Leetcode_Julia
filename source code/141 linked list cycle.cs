using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _141_linked_list_cycle
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

        public bool HasCycle(ListNode head)
        {
            if (head == null)
            {
                return false;
            }

            var slow = head;
            var fast = head;
            int index = 0; 

            while (fast != null)
            {
                if (index != 0 && fast == slow)
                {
                    return true; 
                }

                if (fast.next == null || fast.next.next == null)
                    return false;

                fast = fast.next.next;
                slow = slow.next;

                index++;
            }

            return false;
        }
    }
}
