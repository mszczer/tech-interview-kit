using Coding.Challenges.Common;

namespace Coding.Challenges.Easy;
/*
 * Difficulty: Easy
 * Problem:
 *  Given two binary trees and imagine that when you put one of them to cover the other,
 *  some nodes of the two trees are overlapped while the others are not.
 *  Write a program to merge them into a new binary tree.
 * Note:
 *  The merge rule is that if two nodes overlap, then sum node values up as the new value of the merged node.
 *  Otherwise, the NOT null node will be used as the node of the new tree.
 *  The merging process must start from the root nodes of both trees.
 *
 *  Input:
 *           Tree 1                     Tree 2
 *              1                         2
 *             / \                       / \
 *            6   2                     1   3
 *           /                           \   \
 *          5                             4   7
 *  Output: Merged tree
 *    	     3
 *    	    / \
 *    	   7   5
 *    	  / \   \
 *    	 5   4   7
 */

public static class MergeTwoBinaryTrees
{
    public static BinaryTree<int>? GetMergedTree(BinaryTree<int>? firstTree, BinaryTree<int>? secondTree)
    {
        if (firstTree == null && secondTree == null)
            return new BinaryTree<int>();
        if (firstTree == null) return secondTree;
        if (secondTree == null) return firstTree;

        return MergeBinaryTrees(firstTree.Root, secondTree.Root);
    }

    private static BinaryTree<int> MergeBinaryTrees(TreeNode<int>? firstTreeNode, TreeNode<int>? secondTreeNode)
    {
        var result = new BinaryTree<int>
        {
            Root = MergeNodes(firstTreeNode, secondTreeNode)
        };

        return result;
    }

    private static TreeNode<int>? MergeNodes(TreeNode<int>? firstTreeNode, TreeNode<int>? secondTreeNode)
    {
        // If both are null, nothing to merge
        if (firstTreeNode == null && secondTreeNode == null)
            return null;

        // Compute value: if one node is null, use the other's value; otherwise sum both
        var value = (firstTreeNode?.Value ?? 0) + (secondTreeNode?.Value ?? 0);

        var newNode = new TreeNode<int>(value)
        {
            // Recur for left and right children
            LeftNode = MergeNodes(firstTreeNode?.LeftNode, secondTreeNode?.LeftNode),
            RightNode = MergeNodes(firstTreeNode?.RightNode, secondTreeNode?.RightNode)
        };

        return newNode;
    }
}