using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21_Merge_two_sorted_lists
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
        /// Splice together the nodes of the first two lists.
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {            
            if (l1 == null)
                return l2;
            if (l2 == null)
                return l1;

            var tmp1 = l1.next;
            var tmp2 = l2.next;
            if (l2.val > l1.val)
            {
                l1.next = MergeTwoLists(tmp1, l2);               

                return l1; 
            }

            l2.next = MergeTwoLists(l1, tmp2);           
            return l2;                        
        }
    }
}
