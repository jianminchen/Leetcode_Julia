using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reverseNodesInK_Groups
{
    class ListNode
    {
        public int val; 
        public ListNode next;
        public ListNode(int x) {
            val = x; 
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * test case 1: 
             * 1->2
             * k = 3 
             */
            ListNode n1 = new ListNode(1);
            n1.next = new ListNode(2);

            ListNode r1 = reverseKGroup(n1, 3); 

            /*
             * test case 2: 
             * 1->2->3->4->5
             * k = 2 
             * 2->1->4->3->5
             */
            ListNode b1 = new ListNode(1);
            b1.next = new ListNode(2);
            b1.next.next = new ListNode(3);
            b1.next.next.next = new ListNode(4);
            b1.next.next.next.next = new ListNode(5);

            ListNode r2 = reverseKGroup(b1, 2); 
        }

        /*
         * Latest update: August 4, 2015
         * 
         * 
         * source code from blog:
         * 
         * http://blog.csdn.net/linhuanmars/article/details/19957455       
         *                     
         * comment from blog:
           这道题是Swap Nodes in Pairs的扩展，Swap Nodes in Pairs其实是这道题
         * k=2的特殊情况，大家可以先练习一下。不过实现起来还是比较不一样的，因为
         * 要处理比较general的情形。基本思路是这样的，我们统计目前节点数量，如果到达k，
         * 就把当前k个结点reverse，这里需要reverse linked list的subroutine。这里
         * 我们需要先往前走，到达k的时候才做reverse，所以总体来说每个结点会被访问两次。
         * 总时间复杂度是O(2*n)=O(n)，空间复杂度是O(1)。
         * 
         * 有朋友可能会说为什么不边走边reverse，这样可以省一个pass。但是问题是这个题目
         * 的要求中最后如果不足k个不需要reverse，所以没法边走边倒。
         * 
         * julia's comment:
         * 1. convert Java code to C# code 
         * 2. 
         */
        public static ListNode reverseKGroup(ListNode head, int k)
        {
            if (head == null)
            {
                return null;
            }

            ListNode dummy = new ListNode(0);
            dummy.next = head;
            int count = 0;
            ListNode pre = dummy;
            ListNode cur = head;
            while (cur != null)
            {
                count++;
                ListNode next = cur.next;
                if (count == k)
                {
                    pre = reverse(pre, next);
                    count = 0;
                }
                cur = next;
            }
            return dummy.next;
        }

        private static ListNode reverse(ListNode pre, ListNode end)
        {
            if (pre == null || pre.next == null)
                return pre;

            ListNode head = pre.next;
            ListNode cur = pre.next.next;
            while (cur != end)
            {
                ListNode next = cur.next;
                cur.next = pre.next;
                pre.next = cur;
                cur = next;
            }

            head.next = end;
            return head;
        }  
    }
}
