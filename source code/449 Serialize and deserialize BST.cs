using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _449_serialize_and_deserialize_BST
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Codec
    {
        public static void Main(string[] args)
        {
            var node3 = new TreeNode(3);
            var node2 = new TreeNode(2);
            var node1 = new TreeNode(1);

            node3.left = node2;
            node2.right = node1;

            var codec = new Codec();
            var serializeString = codec.serialize(node3);
            var root = codec.deserialize(serializeString); 
        }

        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            if (root == null)
                return string.Empty;

            var sb = new StringBuilder();

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            sb.Append(root.val + ";");

            while (queue.Count > 0)
            {
                var levelSize = queue.Count;

                var levelString = new StringBuilder();
                var hasAtLeastOneChild = false;

                for (int i = 0; i < levelSize; i++)
                {
                    var node = queue.Dequeue();                    

                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                        levelString.Append(node.left.val + ";");
                        hasAtLeastOneChild = true; 
                    }
                    else
                    {
                        levelString.Append("+;"); // + symbol of empty node
                    }

                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                        levelString.Append(node.right.val + ";");
                        hasAtLeastOneChild = true;
                    }
                    else
                    {
                        levelString.Append("+;");
                    }
                }

                if (hasAtLeastOneChild)
                {
                    sb.Append(levelString.ToString());
                }
            }

            return sb.ToString();
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (data == null || data.Length == 0)
                return null;

            var split = data.Split(';');  // last ; do not count

            var root = new TreeNode(Convert.ToInt32(split[0]));
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            int index = 1; 
            while (queue.Count > 0)
            {
                var levelSize = queue.Count;

                for (int i = 0; i < levelSize; i++)
                {
                    var visit = queue.Dequeue();
                    if (index >= split.Length - 1)  // -1 since last ; do not count
                        break;

                    var left = split[index++];
                    var right = split[index++];

                    if (left.CompareTo("+") != 0)
                    {
                        visit.left = new TreeNode(Convert.ToInt32(left));
                        queue.Enqueue(visit.left);
                    }

                    if (right.CompareTo("+") != 0)
                    {
                        visit.right = new TreeNode(Convert.ToInt32(right));
                        queue.Enqueue(visit.right);
                    }
                }
            }

            return root;
        }
    }

    // Your Codec object will be instantiated and called as such:
    // Codec codec = new Codec();
    // codec.deserialize(codec.serialize(root));
}
