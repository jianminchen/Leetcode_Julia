using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _160_intersection_of_two_linked_lists
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
            var node2 = new ListNode(2);
            var node3 = new ListNode(3);

            var headA = node2;
            headA.next = node3;
            var headB = node3;

            var result = GetIntersectionNode(headA, headB);
        }

        public static ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null)
                return null;

            var lengthA = getLength(headA);
            var lengthB = getLength(headB);

            if (lengthA > lengthB)
                return GetIntersectionNode(headB, headA);

            int index = 0;
            var iterateB = headB;            

            // linked list B is longer one
            while (index < lengthB - lengthA)
            {
                iterateB = iterateB.next;
                index++;
            }

            // two lists should end the same node if there is an intersection.
            var iterateA = headA; 
            while (index < lengthB)
            {
                if (iterateA == iterateB)
                    return iterateA;

                iterateA = iterateA.next;
                iterateB = iterateB.next;

                index++; 
            }

            return null;
        }

        private static int getLength(ListNode node)
        {
            var index = 0;
            while (node != null)
            {
                node = node.next;
                index++;
            }

            return index; 
        }
    }
}
