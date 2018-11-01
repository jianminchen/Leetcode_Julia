using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _92_reverse_linked_list_II
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

            var result = ReverseBetween(node1, 2, 4);
        }
        /// <summary>
        /// The idea can be looked up clearly from the following:
        /// https://leetcode.com/problems/reverse-linked-list-ii/discuss/30709/Talk-is-cheap-show-me-the-code-(and-DRAWING)
        /// 
        /// The code is based on the idea from 
        /// https://leetcode.com/problems/reverse-linked-list-ii/discuss/30676/6-10-lines-in-C%2B%2B
        /// </summary>
        /// <param name="head"></param>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static ListNode ReverseBetween(ListNode head, int m, int n)
        {
            var dummy = new ListNode(0);

            var prev = dummy;

            dummy.next = head;
            for (int i = 1; i < m; i++)
            {
                prev = prev.next;
            }
            
            var pivot = prev.next;
            
            for (int i = m; i < n; i++) {                
                var next = pivot.next;
                if (pivot.next != null)
                {
                    pivot.next = pivot.next.next;
                }

                var tmp = prev.next;
                prev.next = next;
                next.next = tmp;                
            }

            return dummy.next;
        }        
    }
}
