using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRU_double_linked_list
{
    class Program
    {
        static void Main(string[] args)
        {
            //[[2],[1,1],[2,2],[1],[3,3],[2],[4,4],[1],[3],[4]]
            // output: [null,null,null,1,null,2,null,-1,3,4]
            // expected: [null,null,null,1,null,-1,null,-1,3,4]

            var cache = new LRUCache(2);
            cache.Put(1, 1);
            cache.Put(2, 2);
            var value1 = cache.Get(1);
            cache.Put(3, 3);
            var value = cache.Get(2);
            cache.Put(4, 4);
            cache.Get(1);
            cache.Get(3);
            cache.Get(4);
        }

        public class LRUCache
        {            
            private Dictionary<int, Node> map;
            private LRUDoubleLinkedList list;
            private int capacity;

            public LRUCache(int capacity)
            {
                this.capacity = capacity;

                list = new LRUDoubleLinkedList();
                map  = new Dictionary<int, Node>();
            }

            /// <summary>
            /// LRU - put least recently used - last one out
            /// </summary>
            /// <param name="key"></param>
            /// <returns></returns>
            public int Get(int key)
            {
                if (!map.ContainsKey(key))
                {
                    return -1;
                }

                var node = map[key];

                list.RemoveNode(node);
                list.AddToFront(node);

                // tip 1: node is still the same in map, no need to update
                return node.Value;
            }

            /// <summary>
            /// code review:
            /// I like to learn from discussion post:
            /// https://leetcode.com/problems/lru-cache/discuss/753750/C-Implementation-using-Dictionary-and-Double-Linked-List
            /// </summary>
            /// <param name="key"></param>
            /// <param name="value"></param>
            public void Put(int key, int value)
            {
                var update = map.ContainsKey(key);
                var reachMaximum = map.Count == capacity;

                if (update)
                {
                    list.RemoveNode(map[key]);
                    map[key].Value = value;     // update

                    list.AddToFront(map[key]);
                }
                else
                {
                    if (reachMaximum)
                    {
                        var removed = list.RemoveLRUNode();
                        map.Remove(removed.Key);

                        // insert a new node
                        var node = new Node(key, value);
                        list.AddToFront(node);
                        map.Add(key, node);
                    }
                    else
                    {
                        // insert a new node
                        var node = new Node(key, value);
                        list.AddToFront(node);
                        map.Add(key, node);
                    }                    
                }
            }
        }

        class Node
        {
            public Node next, prev;
            public int Key { get; set; }
            public int Value { get; set; }

            public Node(int key, int value)
            {
                this.Key = key;
                Value = value;
            }

            // added on Sept. 22, 2020
            public Node()
            {
            }
        }

        /// <summary>
        /// Time for me to warmup object-oriented design
        /// </summary>
        class LRUDoubleLinkedList
        {
            // dummy head and tail
            private Node head;
            private Node tail;

            public LRUDoubleLinkedList()
            {
                head = new Node();
                tail = new Node();

                // connect to dummy head and tail
                head.next = tail;
                tail.prev = head;
            }

            // Insert node after head node
            public void AddToFront(Node node)
            {
                node.next = head.next;
                node.prev = head;

                head.next.prev = node;
                head.next = node;
            }

            public void RemoveNode(Node node)
            {
                if (node == null || node.prev == null || node.next == null)
                    return;

                node.prev.next = node.next;
                node.next.prev = node.prev;
            }

            /// <summary>
            /// LRU - leastly used node is in the tail
            /// return Node - need it to update HashMap
            /// </summary>
            public Node RemoveLRUNode()
            {
                var target = tail.prev;
                RemoveNode(target);
                return target;
            }
        }
    }
}
