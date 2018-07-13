package eclipsePackage;

import java.util.*;
import java.util.ArrayList;


/*
 * January 15, 2016
 * 
 * code source:
 * http://buttercola.blogspot.ca/2016/01/leetcode-binary-tree-vertical-order.html
 * 
 * Problem statement: 
 * Binary Tree Vertical Order Traversal
 * 
 * analysis from the above blog:
 * 
 * Understand the problem:
	The problem can be solved like this:
	1. First find out the vertical order of the leftmost node and rightmost node. 
	2. Create a bucket with the size of rightmost order - leftmost order + 1. 
	   Each bucket should contain at least one node if the tree is a full tree. 
	3. Then do a level-order traversal of the binary tree to determine the vertical order of each node, 
	   assign each node to the corresponding bucket. Since the tree traversal is from left to right, 
	   top to bottom, we can guarantee the requirement of the problem. 
	   
   Julia's comment: 
   More reference:
   1. Leetcode 314: binary tree vertical order traversal 
   2. http://www.geeksforgeeks.org/print-binary-tree-vertical-order/
 */
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode(int x) { val = x; }
 * }
 */

public class BinaryTreeVerticalOrderTraversal_314 {

	private int leftMostOrder  = Integer.MAX_VALUE;
    private int rightMostOrder = Integer.MIN_VALUE;
    
    /*
     * Julia's comment:
     * 1. modify 1: 
     * use two function calls - make recursive function easy to read, one task only
     * 
     * 2. vertical order - 
     *    first, root node is at level 0, go to left child, negative number;  
     *    go to right child, positive number. 
     *    So, range is [leftMostOrder, rightMostOrder]
     *    And then, shift to the range [0, n-1]. 
     * 3. bug01 report:
     *    rightMostOrder = 0, should be 2
     */
    public List<List<Integer>> verticalOrder(TreeNode root) {
        List<List<Integer>> result = new ArrayList<>();
        if (root == null) {
            return result;
        }
         
        // Step 1: find the leftmost and rightmost (NON-NECESSARY LEAF) node
        TreeNode p = root;
        
        //findLeftRightMostOrder(p, 0);   // modify 1
        
        findLeftMostOrder(p, 0); 
        findRightMostOrder(p,0);      
        
        
        // Step 2: determine at most number of vertical orders
        int n = rightMostOrder - leftMostOrder + 1;
        List[] buckets = new List[n];
        
        for (int i = 0; i < n; i++) {
            buckets[i] = new ArrayList<>();
        }
         
        // Step 3: determine the vertical order for each tree node
        verticalOrderHelper(root, buckets, -leftMostOrder);
         
        // Step 4: form the result
        for (List bucket : buckets) {
            if (bucket.size() > 0) {
                result.add(bucket);
            }
        }
         
        return result;
    }
    
    /*
     *  Julia's comment:
     *  1. the function is design to traverse the tree by level, from top to down, 
     *     left to right
     *  2. Also, second task of the function:
     *     Store the visited node into container buckets list array
     *     Same vertical order level's node goes to the same list
     *     
     *  3. So, based on item 1 and 2, the function is performing: 
     *     visit the tree node using level order traverse, and then store all nodes
     *     into the container: an array of list, each vertical level is shifted to 0 to n-1
     *     range. 
     */
    private void verticalOrderHelper(TreeNode root, List[] buckets, int order) {
        Queue<TreeNode> nodeQueue = new LinkedList<>();
        Queue<Integer> orderQueue = new LinkedList<>();
        nodeQueue.offer(root);
        orderQueue.offer(order);
         
        while (!nodeQueue.isEmpty()) {
            TreeNode currNode = nodeQueue.poll();
            int currOrder = orderQueue.poll();
             
            buckets[currOrder].add(currNode.val);
             
            if (currNode.left != null) {
                nodeQueue.offer(currNode.left);
                orderQueue.offer(currOrder - 1);
            }
             
            if (currNode.right != null) {
                nodeQueue.offer(currNode.right);
                orderQueue.offer(currOrder + 1);
            }
        }
    }
     
    // Find out the leftMost order
    @Deprecated
    private void findLeftRightMostOrder(TreeNode root, int order) {
        if (root == null) {
            return;
        }
         
        leftMostOrder = Math.min(leftMostOrder, order);
        rightMostOrder = Math.max(rightMostOrder, order);
         
        findLeftRightMostOrder(root.left, order - 1);
        findLeftRightMostOrder(root.right, order + 1);
    }
    
    /*
     *  Julia's comment:
     *  1. Make the function short and easy to read
     *  2. Do not mix left most order/ right most order two tasks in one function
     *  3. Make the function so easy to follow, no way to hide a bug
     */
    private void findLeftMostOrder(TreeNode root, int order)
    {
    	if (root == null) 
            return;        
         
        leftMostOrder = Math.min(leftMostOrder, order);        
         
        findLeftMostOrder(root.left, order - 1);        
    }
    
    /*
     * 
     */
    private void findRightMostOrder(TreeNode root, int order)
    {
    	if (root == null) 
            return;        
         
    	rightMostOrder = Math.max(rightMostOrder, order);       
         
    	findRightMostOrder(root.right, order + 1);        
    }
    
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		TreeNode n1 = new TreeNode(1); 
		n1.left = new TreeNode(2); 
		n1.right = new TreeNode(3); 
		n1.left.left = new TreeNode(4); 
		n1.left.right = new TreeNode(5); 
		n1.right.left =  new TreeNode(6); 
		n1.right.right = new TreeNode(7); 
		
		BinaryTreeVerticalOrderTraversal_314 mySol = new BinaryTreeVerticalOrderTraversal_314(); 
		
		List<List<Integer>>  result  = mySol.verticalOrder(n1);
		
		/*
		 * verify the result:
		 * [[4], [2], [1, 5, 6], [3], [7]]
		 */
	}

}
