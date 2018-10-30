using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _206_reverse_linked_list___iterative
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
            Run5NodeList();
            //Run3NodeList();
        }

        public static void Run3NodeList()
        {
            var node1 = new ListNode(1);
            var node2 = new ListNode(2);
            var node3 = new ListNode(3);

            node1.next = node2;
            node2.next = node3;
            node3.next = null;

            var result = ReverseList(node1);
        }

        public static void Run2NodeList()
        {
            var node1 = new ListNode(1);
            var node2 = new ListNode(2);            

            node1.next = node2;
            node2.next = null;           

            var result = ReverseList(node1);
        }

        public static void Run5NodeList()
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
            node5.next = null;

            var result = ReverseList(node1);
        }

        /// <summary>
        /// reverse linked list
        /// iterative solution 
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ListNode ReverseList(ListNode head)
        {
            if (head == null)
                return null;

            if (head.next == null) // one node in linked list
                return head;         

            var current = head;           

            ListNode newHead  = null;
            ListNode lastNode = null;
            while (current.next != null) 
            {
                var tmp = current.next.next;

                current.next.next = current;
                if (tmp == null) // two nodes in the linked list
                {                    
                    newHead = current.next;
                    current.next = lastNode;
                    break;
                }
                else
                {                    
                    var nextLastNode = current.next;
                    current.next = lastNode;  

                    current = tmp;

                    // if current.next == null - three nodes in the linked list, need to terminate
                    if (current.next == null)
                    {
                        newHead = current;
                        current.next = nextLastNode;                        

                        break;
                    }

                    lastNode = nextLastNode;
                }                
            }

            return newHead;
        }
    }
}
