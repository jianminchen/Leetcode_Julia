using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode2_AddTwoNumbers
{
    /// <summary>
    /// Leetcode 2: Add two numbers
    /// https://leetcode.com/problems/add-two-numbers/description/
    /// 
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

        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            if (l1 == null || l2 == null)
            {
                return l1 == null ? l2 : l1;
            }

            int value = l1.val + l2.val;            

            var result = new ListNode(value % 10);

            result.next = AddTwoNumbers(l1.next, l2.next);

            if (value >= 10)
            {
                // make this carry as a linked list as well 
                result.next = AddTwoNumbers(new ListNode(value / 10), result.next);
            }

            return result;
        }        
    }
}
