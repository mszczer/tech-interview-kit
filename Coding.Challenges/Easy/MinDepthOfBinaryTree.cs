using Coding.Challenges.Common;

namespace Coding.Challenges.Easy;
/*
 * Difficulty: Easy
 * Problem:
 *  Given the root node of a binary tree, write a program to find its minimum depth.
 *  The minimum depth is the number of nodes along the shortest path from the nearest leaf node to the root.
 *  A leaf is a node with no children.
 */

public static class MinDepthOfBinaryTree
{
    public static int FindMinimumDepth(BinaryTree<int> tree)
    {
        return MinDepth(tree.Root);
    }

    private static int MinDepth(TreeNode<int>? node)
    {
        if (node == null) return 0;
        if (node.LeftNode == null && node.RightNode == null) return 1;
        if (node.LeftNode == null) return MinDepth(node.RightNode) + 1;
        if (node.RightNode == null) return MinDepth(node.LeftNode) + 1;
        return Math.Min(MinDepth(node.LeftNode), MinDepth(node.RightNode)) + 1;
    }
}