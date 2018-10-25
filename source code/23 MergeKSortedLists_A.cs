using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeKSortedLists
{
    public class ListNode{
        public int val; 
        public ListNode next; 

        public ListNode(int v)
        {
            val = v; 
        }
    }

    class MergeKSortedLists_A_No23
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

            ListNode[] lists = new ListNode[3]{l1, l2, l3};
            ListNode test = mergeKLists(lists); 
        }
        /*
         * Leetcode 23: Merge K Sorted Lists
        Merge k sorted linked lists and return it as one sorted list. Analyze and describe its complexity.

        合并k个有序的链表，我们假设每个链表的平均长度是n。这一题需要用到合并两个有序的链表子过程
         */
        /*
         * http://www.cnblogs.com/TenosDoIt/p/3673188.html
         * 算法1： Naive solution 

            最傻的做法就是先1、2合并，12结果和3合并，123结果和4合并，…,123..k-1结果和k合并，我们计算一下复杂度。

            1、2合并，遍历2n个节点

            12结果和3合并，遍历3n个节点

            123结果和4合并，遍历4n个节点

            …

            123..k-1结果和k合并，遍历kn个节点

            总共遍历的节点数目为n(2+3+…+k) = n*(k^2+k-2)/2, 因此时间复杂度是O(n*(k^2+k-2)/2) = O(nk^2)，代码如下：
         */
        public static ListNode mergeKLists(ListNode[] lists) {
            if(lists.Length == 0)
                return null;

            ListNode res = lists[0];

            for(int i = 1; i < lists.Length; i++)
                res = merge2list(res, lists[i]);

            return res;
        }
    
        public static ListNode merge2list(ListNode head1, ListNode head2)
        {
            ListNode node = new ListNode(0), 
                     res  = node;

            while(head1 != null && head2 != null )
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

                res = res.next;   // it is delayed to reset to next one, after head1, head2 resets to its next. 
            }

           if(head1 != null)
                res.next = head1;
           else if(head2 != null)
                res.next = head2;

           return node.next;
        }
    }
}
