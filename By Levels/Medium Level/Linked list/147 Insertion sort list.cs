using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _147_insertion_sort_list
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

            node4.next = node2;
            node2.next = node1;
            node1.next = node3;
            node3.next = null;

            var result = InsertionSortList(node4); 
        }

        /// <summary>
        /// Insertion sort ->
        /// 
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ListNode InsertionSortList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            var dummyHead = new ListNode(-1);
            dummyHead.next = head;

            int sorted = 1;
            var selected = head.next; // two nodes in the list  dummyHead -> 2 -> 1 -> null
            var previousSelected = head; // 2

            while (selected != null) // selected: 1
            {
                // go over the list from index 0 to sorted - 1                
                var value = selected.val; // 1                

                int index = 0;
                var iterate = dummyHead.next; // 2
                var previous = dummyHead;
                var hasInsertion = false; 

                while (index < sorted) // 0 < 1
                {
                    var current = iterate.val; // 2
                    if (value < current) // 1 < 2
                    {
                        // insert a new node
                        previous.next = new ListNode(value);
                        previous.next.next = iterate; // insert the node before the iterate
                     
                        // remove the old node
                        previousSelected.next = selected.next;
                        hasInsertion = true; 
                        break; 
                    }
                    
                    // next iteration
                    previous = iterate;
                    iterate = iterate.next;
                    index++;
                }

                // next iteration 
                previousSelected = hasInsertion? previousSelected : selected; 
                selected = selected.next;
                sorted++;
            }

            return dummyHead.next; 
        }
    }
}
