// JavaScript source code
/**
 * Definition for a binary tree node.
 * function TreeNode(val) {
 *     this.val = val;
 *     this.left = this.right = null;
 * }
 */
/**
 * @param {TreeNode} root
 * @return {number}
 */
var distributeCoins = function(root) {
  
    let totalMoves = 0
  
    function getCoinsNeeded(node) {
    
        let leftCoinsNeeded = 0
        if(node.left) leftCoinsNeeded = getCoinsNeeded(node.left)
        let rightCoinsNeeded = 0
        if(node.right) rightCoinsNeeded = getCoinsNeeded(node.right)
    
        totalMoves += Math.abs(leftCoinsNeeded) + Math.abs(rightCoinsNeeded) 

        return node.val + leftCoinsNeeded + rightCoinsNeeded - 1
    
    }
  
    getCoinsNeeded(root)
  
    return totalMoves
    
};

let Node = function(val) {
    this.val = val
    this.left = this.right = null
}

let A = new Node(1)
let B = new Node(0)
let C = new Node(0)
let D = new Node(3)
A.left = B
A.right = C
B.right = D

console.log(distributeCoins(A))