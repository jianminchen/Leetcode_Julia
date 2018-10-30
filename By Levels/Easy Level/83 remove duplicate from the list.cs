using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _83_remove_duplicate_from_list
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
        /// First submission: time limit exceeded - example 
        /// third submission: fail test case [1,1,1], return [1, 1], should be [1]
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null)
                return null;

            var set = new HashSet<int>();

            var current = head;
            var dummyHead = new ListNode(-1);

            var previous = dummyHead;
            dummyHead.next = current; // added after first submission
            while (current != null)
            {
                var value = current.val;
                if (set.Contains(value))
                {
                    // remove the current node from the list
                    previous.next = current.next;

                    // next iteration
                    current = current.next;
                }
                else
                {
                    set.Add(value);
                    previous = current;
                    current = current.next;                 
                }

                 
            }

            return dummyHead.next;
        }
    }
}
