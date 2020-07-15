using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _143_reorder_list
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        /// <summary>
        /// 143 reorder list 
        /// 1 -> 2 ->3 ->4 ->5
        /// result 1 ->5 ->2 ->4 -> 3
        /// next half reversed and then mix with the first half
        /// </summary>
        /// <param name="head"></param>
        public void ReorderList(ListNode head)
        {
            if (head == null)
                return;            

            var slow = head;
            var fast = head;

            while (fast != null)
            {
                if (fast.next == null)
                {
                    break;
                }

                fast = fast.next.next;
                slow = slow.next;
            }

            var reserve = slow.next;
            slow.next = null;

            var reverse = reserve;
            var stack = new Stack<ListNode>(); 

            while (reverse != null)
            {
                var copy = reverse.next;
                reverse.next = null;  // break the link please

                stack.Push(reverse);

                reverse = copy; 
            }

            // mix linked list with the nodes in the stack
            var headCopy = head;

            while (headCopy != null && stack.Count > 0)
            {
                var copy = headCopy.next;
                headCopy.next = null;

                var pop = stack.Pop();
                headCopy.next = pop;

                pop.next = copy;

                // next iteration
                headCopy = copy; 
            }            
        }
    }
}
