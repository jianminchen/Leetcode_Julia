using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _725_split_linked_list_in_parts
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
            //RunTestcase2();
            SplitListToParts(null, 3);
        }

        public static void RunTestcase1()
        {
            var node1 = new ListNode(1);
            var node2 = new ListNode(2);
            var node3 = new ListNode(3);
            node1.next = node2;
            node2.next = node3;

            var result = SplitListToParts(node1, 5); 
        }

        public static void RunTestcase2()
        {
            var node1 = new ListNode(1);
            var node2 = new ListNode(2);
            var node3 = new ListNode(3);
            var node4 = new ListNode(4);
            var node5 = new ListNode(5);
            var node6 = new ListNode(6);
            var node7 = new ListNode(7);

            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            node5.next = node6;
            node6.next = node7; 

            var result = SplitListToParts(node1, 3); 
        }

        /// <summary>
        /// assume that k > 0 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static ListNode[] SplitListToParts(ListNode root, int k)
        {
            if (k <= 0)
            {
                return new ListNode[0];
            }

            if (root == null)
            {
                var list = new ListNode[k];
                for (int i = 0; i < k; i++)
                    list[i] = null;

                return list;
            }

            int length = getLength(root);

            var split = new List<ListNode>();

            int partLength = length / k;
            int residue = length % k;
           
            int kPart = 0; 
            int listIndex = 0;
            int start = 0; 
            while (root != null)
            {
                if (listIndex == start) // head node of list
                {
                    split.Add(root);
                }

                // reach the end of part
                var firstKExtraNode = residue > 0 && kPart < residue;
                var lastOneExtraOne = listIndex == (start + partLength);
                var lastOne = listIndex == (start + partLength - 1);

                if ((firstKExtraNode && lastOneExtraOne) || 
                    (!firstKExtraNode && lastOne)) // logic error
                {
                    var tmp = root.next;
                    root.next = null;
                    root = tmp;

                    start = listIndex + 1;
                    kPart++;
                }
                else
                {
                    root = root.next;
                }

                listIndex++;
            }

            // edge case - add empty nodes if need
            var found = split.Count;

            for (int i = found; i < k; i++)
            {
                split.Add(null);
            }

            return split.ToArray();
        }

        private static int getLength(ListNode node)
        {
            int index = 0;
            while (node != null)
            {
                node = node.next;
                index++;
            }

            return index; 
        }
    }
}
