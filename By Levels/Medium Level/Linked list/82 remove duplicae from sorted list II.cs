using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _82_remove_duplicate_from_sorted_list_II
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
            var node1  = new ListNode(1);
            var node2  = new ListNode(2);
            var node2B = new ListNode(2);
            
            node1.next = node2;
            node2.next = node2B;

            var result = DeleteDuplicates(node1);
        }

        public static ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null)
                return head;

            var dummyHead = new ListNode(-1);            

            var previous = dummyHead;
            var current = head;

            var newList = dummyHead;

            while (current != null)
            {
                var previousChecking = previous == dummyHead || previous.val != current.val;
                var nextChecking = current.next == null || current.val != current.next.val;
                
                if(previousChecking && nextChecking)
                {
                    newList.next = current;
                    newList = current;                      
                }

                previous = current;
                current = current.next; 
            }

            //previous.next = null;   // failed test case [1, 2, 2] -> [1]
            newList.next = null; 

            return dummyHead.next;
        }
    }
}
