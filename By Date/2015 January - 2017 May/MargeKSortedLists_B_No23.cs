using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MargeKSortedLists_2
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int v)
        {
            val = v;
        }
    }

    class MargeKSortedLists_B_No23
    {
        static void Main(string[] args)
        {
            ListNode l1 = new ListNode(1);
            l1.next = new ListNode(4);
            l1.next.next = new ListNode(7);

            ListNode l2 = new ListNode(2);
            l2.next = new ListNode(5);
            l2.next.next = new ListNode(8);

            ListNode l3 = new ListNode(3);
            l3.next = new ListNode(6);

            ListNode l4 = new ListNode(4);
            l4.next = new ListNode(9); 

           /* ListNode[] lists = new ListNode[3] { l1, l2, l3 };
            ListNode test = mergeKLists(lists);
            * */

            ListNode[] lists2 = new ListNode[4] { l1, l2, l3, l4 };
            ListNode test2 = mergeKLists(lists2); 

        }

        /*
         * from blog: 
         * http://www.cnblogs.com/TenosDoIt/p/3673188.html
         * 
         * 算法2：利用分治的思想把合并k个链表分成两个合并k/2个链表的任务，一直划分，
         * 知道任务中只剩一个链表或者两个链表。可以很简单的用递归来实现。
         * 因此算法复杂度为T(k) = 2T(k/2) + O(nk),很简单可以推导得到算法复杂度为O（nklogk）

           递归的代码就不贴了。下面是非递归的代码非递归的思想是（以四个链表为例）：                   
         * 本文地址

            1、3合并，合并结果放到1的位置

            2、4合并，合并结果放到2的位置

            再把1、2合并（相当于原来的13 和 24合并）
         * 
         * Julia's comment: 
         * 1. pass online judge
         * 130 / 130 test cases passed.
            Status: Accepted
            Runtime: 204 ms
         */

        public static ListNode mergeKLists(ListNode[] lists) {
            int n = lists.Length;

            if(n == 0)
                return null;

            while(n >1)
            {
                int k = (n+1)/2;
                for(int i = 0; i < n/2; i++)
                    lists[i] = merge2list(lists[i], lists[i + k]);
                n = k;
            }

            return lists[0];
        }
    
        private static ListNode merge2list(ListNode head1, ListNode head2)
        {
            ListNode node = new ListNode(0), 
                res = node;

            while(head1 != null  && head2 != null)
            {
                if(head1.val <= head2.val)
                {
                    res.next = head1;
                    head1 = head1.next;
                }
                else
                {
                    res.next = head2;
                    head2 = head2.next;
                }

                res = res.next;
            }
            if(head1 != null)
                res.next = head1;
            else if(head2 != null)
                res.next = head2;

            return node.next;
        }
    }
}
