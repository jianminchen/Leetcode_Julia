using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _876_middle_of_the_linked_list
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
        /// If the linked list is only one node, then the node is returned. 
        /// If there are two nodes in linked list, then the second node is returned. 
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode MiddleNode(ListNode head)
        {
            if (head == null)
                return null;

            var length = getLength(head);
            if (length == 0)
                return null;

            int index = 0;
            var node = head;
            ListNode middle = null;
            while (index <= length / 2) // two nodes, return second node; three nodes, return second node
            {
                middle = node;
                node = node.next;
                index++;
            }

            return middle; 
        }

        private static int getLength(ListNode head)
        {
            int length = 0; 
            var iterate = head;
            while (iterate != null)
            {
                length++;
                iterate = iterate.next;
            }

            return length;
        }
    }
}
