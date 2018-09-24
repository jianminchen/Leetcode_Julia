using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_203_remove_linked_list_elements
{
    /// <summary>
    /// Leetcode 203: remove linked list elements
    /// https://leetcode.com/problems/remove-linked-list-elements/description/
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
        }

        
        //Definition for singly-linked list.
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int x) 
            { val = x; }
        } 

        /// <summary>
        /// July 20, 2018
        /// empty list
        /// one node with value val
        /// </summary>
        /// <param name="head"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public ListNode RemoveElements(ListNode head, int val)
        {
            if (head == null)
                return null;

            var current = head.val;

            if (current == val)
                return RemoveElements(head.next, val);

            head.next = RemoveElements(head.next, val);
            return head;
        }
    }
}
