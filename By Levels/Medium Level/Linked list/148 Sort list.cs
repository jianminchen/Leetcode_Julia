using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _148_Sort_list
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

        public ListNode SortList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            // step 1. cut the list to two halves
            ListNode prev = null;
            var slow = head;
            var fast = head;

            while (fast != null && fast.next != null)
            {
                prev = slow;
                slow = slow.next;
                fast = fast.next.next;
            }

            prev.next = null;

            // step 2. sort each half
            var list  = SortList(head);
            var list2 = SortList(slow);

            // step 3. merge l1 and l2
            return merge(list, list2);
        }

        ListNode merge(ListNode list1, ListNode list2)
        {
            var dummyNode = new ListNode(0);
            var iterate = dummyNode;

            while (list1 != null && list2 != null)
            {
                if (list1.val < list2.val)
                {
                    iterate.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    iterate.next = list2;
                    list2 = list2.next;
                }

                iterate = iterate.next;
            }

            if (list1 != null)
            {
                iterate.next = list1;
            }

            if (list2 != null)
            {
                iterate.next = list2;
            }

            return dummyNode.next;
        }
    }
}
