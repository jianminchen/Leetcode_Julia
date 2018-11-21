using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _863_all_nodes_distance_k_in_binary_tree
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            RunTestcase();
        }        

        /// <summary>
        /// Input: root = [3,5,1,6,2,0,8,null,null,7,4], target = 5, K = 2
        /// Output: [7,4,1]
        /// </summary>
        public static void RunTestcase()
        {
            var node0 = new TreeNode(0);
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);
            var node4 = new TreeNode(4);
            var node5 = new TreeNode(5);
            var node6 = new TreeNode(6);
            var node7 = new TreeNode(7);                        
            var node8 = new TreeNode(8);                      

            node3.left  = node5;
            node3.right = node1;
            node5.left  = node6;
            node5.right = node2;
            node1.left  = node0;
            node1.right = node8;
            node2.left  = node7;
            node2.right = node4;

            var result = DistanceK(node3, node5, 2);
        }

        /// <summary>
        /// The idea is to build a graph using Dictionary<TreeNode, HashSet<TreeNode>>>.
        /// Traversal the whole tree once and build the graph represented by Dictionary data structure first. 
        /// And then go through the target node, using Queue to find neighbor in K steps away
        /// </summary>
        /// <param name="root"></param>
        /// <param name="target"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public static IList<int> DistanceK(TreeNode root, TreeNode target, int K)
        {
            if (root == null)
                return new List<int>();

            var graph = new Dictionary<TreeNode, HashSet<TreeNode>>(); 

            traverseTree(root, graph);

            var queue = new Queue<TreeNode>();

            if (!graph.ContainsKey(target))
            {
                return new List<int>();
            }

            var visited = new HashSet<TreeNode>(); 
            visited.Add(target);
            queue.Enqueue(target);

            var kStepsNodes = new List<int>(); 

            int index = 0; 
            while (queue.Count > 0 && index <= K)
            {
                var size = queue.Count;
                var isKSteps = index == K;

                for (int i = 0; i < size; i++)
                {
                    var node = queue.Dequeue();
                    if (isKSteps)
                    {
                        kStepsNodes.Add(node.val);
                    }

                    foreach(var item in graph[node])
                    {
                        if (visited.Contains(item))
                            continue;

                        queue.Enqueue(item);
                        visited.Add(item);
                    }
                }

                index++;
            }

            return kStepsNodes; 
        }

        private static void traverseTree(TreeNode root, Dictionary<TreeNode, HashSet<TreeNode>> graph)
        {
            if (root == null)
                return;
            
            if (root.left != null)
            {
                addNodeToGraph(graph, root, root.left);

                traverseTree(root.left, graph);
            }

            if (root.right != null)
            {
                addNodeToGraph(graph, root, root.right);

                traverseTree(root.right, graph);
            }
        }

        private static void addNodeToGraph(Dictionary<TreeNode, HashSet<TreeNode>> graph, TreeNode node1, TreeNode node2)
        {
            // node1 -> node2
            if (!graph.ContainsKey(node1))
            {
                graph.Add(node1, new HashSet<TreeNode>());
            }
            
            graph[node1].Add(node2);            

            // node2 -> node1
            if (!graph.ContainsKey(node2))
            {
                graph.Add(node2, new HashSet<TreeNode>());
            }            
            
            graph[node2].Add(node1);            
        }
    }
}
