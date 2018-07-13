using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeTwoSortedList_No21
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

    class MergeTwoSortedList_No21
    {
        static void Main(string[] args)
        {
            ListNode l1 = new ListNode(1);
            l1.next = new ListNode(3);
            l1.next.next = new ListNode(5);

            ListNode l2 = new ListNode(2);
            l2.next = new ListNode(4);
            l2.next.next = new ListNode(6);

            ListNode test = mergeTwoLists_A(l1, l2);
          //  ListNode test2 = mergeTwoLists_B(l1, l2);  // dead loop 

            ListNode test3 = mergeTwoLists_C(l1, l2); 
        }

        /*
         * source code from:
         * http://www.cnblogs.com/springfor/p/3862040.html
         * 这道题是链表操作题，题解方法很直观。

            首先，进行边界条件判断，如果任一一个表是空表，就返回另外一个表。

            然后，对于新表选取第一个node，选择两个表表头最小的那个作为新表表头，指针后挪。

            然后同时遍历两个表，进行拼接。

            因为表已经是sorted了，最后把没有遍历完的表接在新表后面。

            由于新表也会指针挪动，这里同时需要fakehead帮助记录原始表头。
         * 
         * julia's comment:
         * 1. It works fine with the test case
         */
        public static ListNode mergeTwoLists_A(ListNode l1, ListNode l2) {
            if(l1==null)
                return l2;

            if(l2==null)
                return l1;
              
            ListNode lastNode;  // merge two list together - a new list's last node
            if(l1.val<l2.val){
                lastNode = l1;
                l1 = l1.next;
            }else{
                lastNode = l2;
                l2 = l2.next;
            }
         
            ListNode fakehead = new ListNode(-1);
            fakehead.next = lastNode;

            while(l1!=null && l2!=null){
                if(l1.val<l2.val){
                    lastNode.next = l1;
                    lastNode = lastNode.next;
                    l1 = l1.next;
                }else{
                    lastNode.next = l2;
                    lastNode = lastNode.next;
                    l2 = l2.next;
                }
            }
         
            if(l1!=null)
                lastNode.next = l1;
            if(l2!=null)
                lastNode.next = l2;
            return fakehead.next;
        }

        /*
         * http://www.cnblogs.com/springfor/p/3862040.html
         * 更简便的方法是，不需要提前选新表表头。

            对于新表声明两个表头，一个是fakehead，一个是会挪动的指针，用于拼接。
         *  同时，边界条件在后面的补拼中页解决了，所以开头没必要做边界判断，这样代码简化为：
         *  
         * julia's comment:
         * 1. dead loop, need fix it! 
         * 2. It is important to learn by practice, not just by reading. 
         */
         public static ListNode mergeTwoLists_B(ListNode l1, ListNode l2) {
              ListNode fakehead = new ListNode(-1);
              ListNode l3 = fakehead;

              while(l1!=null && l2!=null){
                  if(l1.val < l2.val){
                      l3.next = l1;
                      l3 = l3.next;
                      l1 = l1.next;
                  }else{
                     l3.next = l2;
                     l3 = l3.next;
                     l2 = l2.next;
                 }
             }
         
             if(l1!=null)
                 l3.next = l1;
             if(l2!=null)
                 l3.next = l2;

             return fakehead.next;
        }

         /*
          * http://www.cnblogs.com/springfor/p/3862040.html
          * 更简便的方法是，不需要提前选新表表头。

             对于新表声明两个表头，一个是fakehead，一个是会挪动的指针，用于拼接。
          *  同时，边界条件在后面的补拼中页解决了，所以开头没必要做边界判断，这样代码简化为：
          *  
          * julia's comment:
          * dead loop, need fix it! 
          */
         public static ListNode mergeTwoLists_C(ListNode l1, ListNode l2)
         {
             ListNode fakehead = new ListNode(-1);
             ListNode l3 = fakehead;

             while (l1 != null && l2 != null)
             {
                 if (l1.val < l2.val)
                 {
                     ListNode tmp = l1.next;   // save l1 next point, do not mix with l3

                     l3.next = l1;
                     l3 = l3.next;
                     l1 = tmp;
                 }
                 else
                 {
                     ListNode tmp = l2.next; 

                     l3.next = l2;
                     l3 = l3.next;
                     l2 = tmp;
                 }
             }

             if (l1 != null)
                 l3.next = l1;
             if (l2 != null)
                 l3.next = l2;

             return fakehead.next;
         }
    }
}
