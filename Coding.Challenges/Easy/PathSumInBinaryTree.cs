using Coding.Challenges.Common;

namespace Coding.Challenges.Easy;
/*
 * Difficulty: Easy
 * Problem:
 *  Given the root node of a binary tree and a sum, write a program
 *  to determine if there exists a path in the tree from root-to-leaf
 *  such that the sum of all the values along the path equals the given sum.
 *
 * Solution:
 *  Method HasPathSum that performs recursive DFS.
 *  Checks for null node (base case).
 *  Checks if the node is a leaf and compares its value to the remaining sum.
 *  Recursively calls itself for left and right children, subtracting the current node's value from the target sum.
 *  The main method delegates to this helper, starting from the tree's root.
 */

public abstract class PathSumInBinaryTree
{
    public static bool IsTargetSumInAnyPath(BinaryTree<int> tree, int sum)
    {
        return HasPathSum(tree.Root, sum);
    }

    private static bool HasPathSum(TreeNode<int>? node, int targetSum)
    {
        if (node == null)
            return false;

        // Check if it's a leaf node
        if (node.LeftNode == null && node.RightNode == null)
            return node.Value == targetSum;

        // Recursively check the left and right subtrees with the updated target sum
        var remainingSum = targetSum - node.Value;
        return HasPathSum(node.LeftNode, remainingSum) || HasPathSum(node.RightNode, remainingSum);
    }
}