using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _655_Print_binary_tree
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class MyNode
    {
        public TreeNode Node  { get; set; }
        public int      Index { get; set; }
        public int Size { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            RunTestcase2();
        }

        public static void RunTestcase1()
        {
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(2);

            node1.left = node2;

            var result = PrintTree(node1); 
        }

        public static void RunTestcase2()
        {
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);
            var node4 = new TreeNode(4);

            node1.left  = node2;
            node1.right = node3;
            node2.right = node4;

            var result = PrintTree(node1); 
        }

        /// <summary>
        /// count depth of the tree first, and then the column value can be determined. 
        /// Now we need to go level by level to populate each node's value in specific column
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static IList<IList<string>> PrintTree(TreeNode root)
        {
            if (root == null)
            {
                return new List<IList<string>>(); 
            }

            var depth = getDepth(root);
            int columns = (int)(Math.Pow(2, depth)  - 1);

            var list = new List<IList<string>>();

            //use queue to traverse the tree level by level
            //need to map each node to the position in the array 
            var myNode = new MyNode();
            myNode.Node = root;
            myNode.Index = columns/2;
            myNode.Size = columns;

            var queue = new Queue<MyNode>();
            queue.Enqueue(myNode);

            int level = 0;                               

            while (queue.Count > 0)
            {
                var levelSize = queue.Count();
                
                var array     = new string[columns];
                for (int i = 0; i < columns; i++)
                {
                    array[i] = "";
                }                

                for (int i = 0; i < levelSize; i++)
                {
                    var current = queue.Dequeue();
                    var node = current.Node;
                    var index = current.Index;
                    var size  = current.Size;                   
                    
                    array[index] = node.val.ToString();                    

                    if (node.left != null)
                    {
                        var newNode = new MyNode();
                        newNode.Node = node.left;
                        var half = size / 2;
                        newNode.Index = index - half/ 2 - 1;  // center of size/ 2
                        newNode.Size = size / 2;

                        queue.Enqueue(newNode); 
                    }

                    if (node.right != null)
                    {
                        var newNode = new MyNode();
                        newNode.Node = node.right;
                        var half = size / 2; 
                        newNode.Index = index + half/2 + 1;
                        newNode.Size = size / 2;

                        queue.Enqueue(newNode); 
                    }
                }

                list.Add(array.ToList()); 
                level++; 
            }

            return list; 
        }                

        private static int getDepth(TreeNode root)
        {
            if (root == null)
                return 0;

            return 1 + Math.Max(getDepth(root.left), getDepth(root.right));
        }
    }
}
