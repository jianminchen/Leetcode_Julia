using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _237_delete_a_node
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

        /// <summary>
        /// assume that node is not the last node in the list
        /// </summary>
        /// <param name="node"></param>
        public void DeleteNode(ListNode node)
        {
            if (node == null)
                return;

            if (node.next != null)
            {
                node.val = node.next.val;
                node.next = node.next.next;
            }          
        }
    }
}
