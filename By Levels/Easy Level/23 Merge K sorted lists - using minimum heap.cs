using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_23_Merge_K_Sorted_Lists
{
    /// <summary>
    /// Leetcode 23 Merge K Sorted Lists
    /// https://leetcode.com/problems/merge-k-sorted-lists/discuss/10630/C-Using-MinHeap-(PriorityQueue)-Implemented-Using-SortedDictionary
    /// </summary>
    class Program
    {          
        public class ListNode {
            public int       val;
            public ListNode  next;
            public ListNode(int x) 
            { 
                val = x; 
            }
        } 

        public class MinHeap
        {
            /// <summary>
            /// We need to keep track of the heads of all lists at all times and be able 
            /// to do the following operations efficiently:
            /// 1- Get/Remove Min
            /// 2- Add (once you remove the head of one list, you need to add the next from that list)

            /// A min heap (or a priority queue) is obviously the data structure we need here, 
            /// where the key of the dictionary is the value of the ListNode, and the value of the 
            /// dictionary is a queue of ListNodes having that value. (we need to queue the ones with 
            /// the same value since Dictionary cannot have dupes)
            /// 
            /// Using a SortedDictionary of queues.
            /// SortedDictionary is internally implemented using a binary tree, and provides O(logn) 
            /// for Add() and O(1) for PopMin(), so it's as efficient as it gets.
            /// </summary>
            public SortedDictionary<int, Queue<ListNode>> map = new SortedDictionary<int, Queue<ListNode>>();

            public void Add(int val, ListNode node)
            {
                if (!map.ContainsKey(val))
                {
                    map.Add(val, new Queue<ListNode>());
                }

                map[val].Enqueue(node);
            }

            public ListNode PopMin()
            {
                int minKey = map.First().Key;
                var node   = map[minKey].Dequeue();

                if (map[minKey].Count == 0)
                {
                    map.Remove(minKey);
                }

                return node;
            }
        }

        static void Main(string[] args)
        {
            var node1 = new ListNode(1);
            var node2 = new ListNode(2);
            var node3 = new ListNode(3);
            var node4 = new ListNode(4);
            var node5 = new ListNode(5);
            var node6 = new ListNode(6);
            var node7 = new ListNode(7);
            var node8 = new ListNode(8);
            var node9 = new ListNode(9);

            node1.next = node3;
            node3.next = node5;

            node2.next = node4;
            node4.next = node6;

            node7.next = node8;
            node8.next = node9;

            var merged = MergeKLists(new ListNode[] { node7, node1, node2 }); 
        }

        /// <summary>
        /// https://leetcode.com/problems/merge-k-sorted-lists/discuss/10630/C-Using-MinHeap-(PriorityQueue)-Implemented-Using-SortedDictionary
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public static ListNode MergeKLists(ListNode[] lists)
        {
            var heap = new MinHeap();

            /// put all nodes into minimum heap first one time
            foreach (var node in lists)
            {
                if (node == null)
                {
                    continue;
                }

                heap.Add(node.val, node);
            }

            ///and then build a linked list using the ascending order
            ListNode curr = null, newHead = null;

            while (heap.map.Count > 0)
            {
                var node = heap.PopMin();

                if (node.next != null)
                {
                    heap.Add(node.next.val, node.next);
                }

                if (curr == null)
                {
                    curr = node;
                    newHead = curr;
                }
                else
                {
                    curr.next = node;
                    curr = curr.next;
                }
            }

            return newHead;
        }
    }
}
