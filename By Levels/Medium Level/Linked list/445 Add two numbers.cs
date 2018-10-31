using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _455_Add_two_numbers_II
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
        /// use stacks to help me to calculate the result
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

            var stack1 = pushToStack(l1);
            var stack2 = pushToStack(l2);
            var sumStack = new Stack<int>();
            int carry = 0; 
            while (stack1.Count != 0 || stack2.Count != 0)
            {
                var value1 = 0; 
                if (stack1.Count != 0)
                {
                   value1 = stack1.Pop(); 
                }

                var value2 = 0;
                if (stack2.Count != 0)
                {
                    value2 = stack2.Pop(); 
                }

                var sum = value1 + value2 + carry;

                sumStack.Push(sum % 10);
                carry = sum / 10; 
            }

            if (carry == 1)
            {
                sumStack.Push(1); 
            }

            // transfer value from stack to a linked list
            var dummyHead = new ListNode(-1);
            var previous = dummyHead;
            while (sumStack.Count > 0)
            {
                var value = sumStack.Pop();
                var current = new ListNode(value);
                previous.next = current;

                previous = current; 
            }

            previous.next = null;

            return dummyHead.next; 
        }

        private static Stack<int> pushToStack(ListNode head)
        {
            var stack = new Stack<int>(); 

            while(head != null)
            {
                stack.Push(head.val); 
                head = head.next; 
            }

            return stack;
        }
    }
}
