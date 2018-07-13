using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreePostOrderIterative
{
    public class Node
    {
        public int val;
        public Node left;
        public Node right;

        public Node(int v)
        {
            val = v;
        }
    }

    class TreePostOrderIterative_PrevVarirable
    {
        static void Main(string[] args)
        {
            Node n1 = new Node('F');
            n1.left = new Node('B');
            n1.right = new Node('G');
            n1.left.left = new Node('A');
            n1.left.right = new Node('D');
            n1.left.right.left = new Node('C');
            n1.left.right.right = new Node('E');

            n1.right.right = new Node('I');
            n1.right.right.left = new Node('H');

            ArrayList test = postOrderTraversalIterative(n1); 
        }
        /*
         * August 23, 2015
         * 
         * Binary tree post order iterative solution 
         * 
         */
        /*
         * source code from blog:
         * 
         * http://articles.leetcode.com/2010/10/binary-tree-post-order-traversal.html
         * 
         * Analysis from the above blog:
         * 
         *              F
         *            /  \
         *          B      G
         *         / \       \
         *        A   D      I
         *          /   \   / 
         *          C    E H 
         *          
         *   Post-order traversal sequence: A, C, E, D, B, H, I, G, F
         *   
         * We use a prev variable to keep track of the previously-traversed node. 
         * 
         * Let’s assume curr is the current node that’s on top of the stack. 
         * When prev is curr's parent, we are traversing down the tree. 
         * In this case, 
         * we try to traverse to curr's left child if available 
         * (ie, push left child to the stack). 
         * If it is not available, we look at curr's right child. 
         * If both left and right child do not exist (ie, curr is a leaf node), we 
         * print curr's value and pop it off the stack.

           If prev is curr's left child, we are traversing up the tree from 
         * the left. We look at curr's right child. If it is available, then traverse 
         * down the right child (ie, push right child to the stack), otherwise print 
         * curr's value and pop it off the stack.

           If prev is curr's right child, we are traversing up the tree from 
         * the right. 
         * In this case, we print curr's value and pop it off the stack.
         * 
         * julia's comment: 
         * 1. Count 3 cases, 
         *    case 1: prev is curr's parent
         *    case 2: prev is curr's left child
         *    case 3: prev is curr's right child
         * 2. convert C++ code to C#  
         * 
         */

        public static ArrayList  postOrderTraversalIterative(Node root)
        {
            ArrayList res = new ArrayList(); 

            if (root == null) 
                return res;

            Stack s = new Stack();
            s.Push(root);

            Node prev = null;

            while (s.Count >0)
            {
                Node curr = (Node)s.Peek();

                if (prev == null || prev.left == curr || prev.right == curr)  // case 1 (going downward): prev is a parent node, like root node
                {
                    if (curr.left != null)
                        s.Push(curr.left);
                    else if (curr.right != null)
                        s.Push(curr.right);
                }
                else if (curr.left == prev)  // case 2 (left child->parent->right child, stage 2)
                {
                    if (curr.right != null)  // if there is a right child, get child into stack
                        s.Push(curr.right);
                }
                else                         // prev is curr.right, and then, output the node, pop it from stack; since children are visited. 
                {
                    res.Add(Convert.ToChar(curr.val));
 
                    s.Pop();
                }

                prev = curr;  // important, set curr to prev - do not forget!
            }

            return res; 
        }
    }
}
