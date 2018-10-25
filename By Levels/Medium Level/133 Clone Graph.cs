using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _133_clone_graph
{
    public class UndirectedGraphNode {
      public int label;
      public IList<UndirectedGraphNode> neighbors;
      public UndirectedGraphNode(int x) { label = x; neighbors = new List<UndirectedGraphNode>(); }
    };

    class Program
    {
        static void Main(string[] args)
        {
        }

        public UndirectedGraphNode CloneGraph(UndirectedGraphNode node)
        {
            if (node == null)
            {
                return null;
            }

            var queue = new Queue<UndirectedGraphNode>();
            var map = new Dictionary<UndirectedGraphNode, UndirectedGraphNode>();

            var newHead = new UndirectedGraphNode(node.label);

            queue.Enqueue(node);
            map.Add(node, newHead);

            while (queue.Count > 0)
            {
                var curr = (UndirectedGraphNode)queue.Dequeue();

                var currNeighbors = curr.neighbors;

                foreach (UndirectedGraphNode neighbor in currNeighbors)
                {
                    if (!map.ContainsKey(neighbor))
                    {
                        var copy = new UndirectedGraphNode(neighbor.label);

                        map.Add(neighbor, copy);

                        map[curr].neighbors.Add(copy);

                        queue.Enqueue(neighbor);
                    }
                    else
                    {
                        map[curr].neighbors.Add(map[neighbor]);
                    }
                }
            }

            return newHead;
        }
    }
}
