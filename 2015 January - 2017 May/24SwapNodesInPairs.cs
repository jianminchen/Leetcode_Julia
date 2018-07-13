using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24SwapNodesInPairs
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
         * source code from the blog: 
         * http://fisherlei.blogspot.ca/2013/01/leetcode-swap-nodes-in-pairs.html
         * analysis from the above blog:
         * [解题思路]
            双指针互换，要考虑一些边界条件，比如链表为空，链表长度为1，链表长度为2.
            加一个safeGuard可以避开链表长度为2的检测。
         */
        /*
         * julia's comment: 
         * 1. work on thought process about the solution: 
         *   Recursive solution - good idea to solve it in short time
         *   step 1: base case, head is null or only one node in the list
         *   step 2: prepare for next pair node pointer, and new head point
         *   head->head.next->head.next.next
         *     1     2          3
         *   swap 1 and 2, and build connection from 1 and 3;
         *   tips I can tell right now: 
         *   1. 2->3 link, before breaking the link, save pointer of 3 first, denoted as nextPair pointer
         *   2. new head is 2, so before breaking the link 1->2, save pointer of 2 first, denoted as head pointer
         *   3. reverse link 1->2, so head.next (2).next = head; 
         *      head.next (head is (new 2)) should be return of swapPairs(nextPair)
         *   Confused? Sort it out later. 
         *    
         */
        public static ListNode swapPairs(ListNode head) {  
          if (head == null || head.next == null) {  
            return head;  
          }  

          ListNode nextPair = head.next.next;  
          ListNode newHead = head.next;  
          head.next.next = head;  
          head.next = swapPairs(nextPair);  
          return newHead;  
        }

        /*
         * source code from blog:
         * http://blog.csdn.net/linhuanmars/article/details/19948569
         * comment from the above blog:
         * 
         * 就是每次跳两个节点，后一个接到前面，前一个接到后一个的后面，最后现在的后一个
         * （也就是原来的前一个）接到下下个结点（如果没有则接到下一个）
         * 用了一个辅助指针作为表头，这是链表中比较常用的小技巧，因为这样可以避免处理head
         * 的边界情况，一般来说要求的结果表头会有变化的会经常用这个技巧，
         * 因为这是一遍过的算法，时间复杂度明显是O(n)，空间复杂度是O(1)。
         * 
         * 
         */
        public static ListNode swapPairs2(ListNode head) {  
            if(head == null)  
                return null;  

            ListNode fakeHead = new ListNode(0);  
            fakeHead.next = head;  
            ListNode pre = fakeHead;  
            ListNode cur = head;  

            while(cur!=null && cur.next!=null)  
            {  
                ListNode tmpNext = cur.next.next;     // pre  cur  next , swap cur and next
                cur.next.next = cur;  
                pre.next = cur.next; 
 
                if(tmpNext!=null && tmpNext.next!=null)  
                    cur.next = tmpNext.next;  
                else  
                    cur.next = tmpNext;  

                pre = cur;  
                cur = tmpNext;  
            }  

            return fakeHead.next;  
        }  


    }
}
