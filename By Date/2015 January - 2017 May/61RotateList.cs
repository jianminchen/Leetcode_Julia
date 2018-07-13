using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _61RotateList
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

    class Program
    {
        static void Main(string[] args)
        {
        }

        /*
         * Leetcode: Rotate list
         * 
         * Given a list, rotate the list to the right by k places, where k is non-negative.
            For example:
            Given 1->2->3->4->5->NULL and k = 2,
            return 4->5->1->2->3->NULL.
         */
        /*
         * source code from blog:
         * 
         * http://bangbingsyb.blogspot.ca/2014/11/leetcode-rotate-list.html
         * comment from the above blog:
         * 向右转k次需要有两个操作。
            1. 将原list的头尾相连。
            2. 找到倒数第k+1个节点，并将它与倒数第k个节点断开。而倒数第k个节点为新的head。
               在1中找list的尾时已经计算出了list的总长n。从尾部开始走n-k步即为该点。

            corner case：
                1. k<=0 || head == NULL，直接返回。
                2. k>= L，L为list总长。对于例子中的list，当k=5时旋转后又回到原来状态。
                   所以实际旋转的次数为k%L。
            
         * julia's comment:
         * 1. Leetcode online judge:
         * 230 / 230 test cases passed.
            Status: Accepted
            Runtime: 156 ms
         */

        public static ListNode rotateRight(ListNode head, int k)
        {
            if (k < 1 || head == null) 
                return head;

            ListNode p = head;
            int len = 1;
            while (p.next != null)
            {    // get list length
                p = p.next;
                len++;
            }
                                
            p.next = head;     // now, p is the last node in the list, so p is the tail. Connect the tail to the head. 

            k = len - k % len;

            while (k > 0)
            {
                p = p.next;
                k--;
            }

            head = p.next;   // p is the tail of new list, and head of new list is p.next. 
            p.next = null;   // break new tail and new head's link:  set tail's link to null

            return head;
        }
    }
}
