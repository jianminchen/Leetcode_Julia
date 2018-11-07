using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _86_partition_list
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
        
        public class Solution
        {
            public ListNode Partition(ListNode head, int x)
            {
                if (head == null)
                    return head;
                var dummyHead       = new ListNode(-1);               
                var dymmyHeadBigger = new ListNode(-1);

                var node  = head;
                var small = dummyHead;
                var big   = dymmyHeadBigger; 

                while (node != null)
                {
                    var value = node.val;
                    if (value < x)
                    {
                        small.next = node;

                        // next iteration
                        small = node;                        
                    }
                    else
                    {
                        big.next = node;

                        // next iteration
                        big = node;                        
                    }

                    node = node.next; 
                }

                small.next = dymmyHeadBigger.next;
                big.next = null;

                return dummyHead.next; 
            }
        }
    }
}
