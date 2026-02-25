using Coding.Challenges.Common;

namespace Coding.Challenges.Easy;

/*
 * Difficulty: Easy
 * Problem:
 *  Given a binary search tree with root node having non-negative values, write a program to find the minimum
 *  absolute difference between values of any two nodes.
 * Note:
 *  There are at least two nodes in the BST.
 * Example:
 *  Input: Given binary search tree
 *            7
 *          /   \
 *         3     10
 *        / \   / \
 *       2   5 8   12
 *
 *  Output: 1
 *  Explanation: The minimum absolute difference is 1, which is the difference between 8 and 7 (or between 2 and 3).
 */

public static class MinDifferenceInBst
{
    /// <summary>
    ///     Returns the minimum absolute difference between values of any two nodes in the given BST.
    ///     When the tree is null or contains fewer than two values, returns 0.
    /// </summary>
    public static int MinDiffInTree(BinaryTree<int>? tree)
    {
        if (tree?.Root == null)
            return 0;

        var serializedTree = tree.SerializeInOrderTraversal();

        if (serializedTree.Count < 2)
            return 0;

        var minDiff = int.MaxValue;
        for (var i = 1; i < serializedTree.Count; i++)
        {
            var diff = serializedTree[i] - serializedTree[i - 1];
            if (diff < minDiff)
                minDiff = diff;
        }

        return minDiff;
    }

    /// <summary>
    ///     Determines whether there exists a pair of distinct nodes in the BST whose values sum to
    ///     <paramref name="givenSum" />.
    /// </summary>
    public static bool FindPairWithGivenSumInBst(BinaryTree<int>? tree, int givenSum)
    {
        if (tree?.Root == null)
            return false;

        var serializedTree = tree.SerializeInOrderTraversal();

        if (serializedTree.Count < 2)
            return false;

        for (var i = 0; i < serializedTree.Count - 1; i++)
        for (var j = 1; j < serializedTree.Count; j++)
        {
            var sum = serializedTree[i] + serializedTree[j];
            if (sum == givenSum)
                return true;
        }

        return false;
    }

    /// <summary>
    ///     Returns the minimum absolute difference between any value from firstTree and any value from secondTree.
    ///     If either tree is null or empty, returns 0.
    /// </summary>
    public static int FindMinAbsoluteDifferenceInTwoBst(BinaryTree<int>? firstTree, BinaryTree<int>? secondTree)
    {
        if (firstTree?.Root == null || secondTree?.Root == null)
            return 0;

        var left = firstTree.SerializeInOrderTraversal();
        var right = secondTree.SerializeInOrderTraversal();

        if (left.Count == 0 || right.Count == 0)
            return 0;

        // Both lists are sorted because SerializeInOrderTraversal performs in-order traversal of BST.
        var i = 0;
        var j = 0;
        var minDiff = int.MaxValue;

        while (i < left.Count && j < right.Count)
        {
            var a = left[i];
            var b = right[j];
            var diff = Math.Abs(a - b);
            if (diff < minDiff)
                minDiff = diff;

            if (minDiff == 0)
                return 0;

            // advance the pointer that points to the smaller value to try to reduce difference
            if (a < b)
                i++;
            else
                j++;
        }

        return minDiff;
    }

    /// <summary>
    ///     Finds node(s) in the provided binary tree whose values have the minimum absolute difference
    ///     to <paramref name="givenValue"/>. 
    ///     Works for any binary tree (does not rely on BST ordering).
    /// </summary>
    /// <param name="tree">The binary tree to search. Must not be null and must have a root node.</param>
    /// <param name="givenValue">The value to compare against node values.</param>
    /// <returns>
    ///     A list of <see cref="TreeNode{Int32}"/> instances that have the smallest absolute difference
    ///     to <paramref name="givenValue"/>. The list will contain at least one node.
    /// </returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="tree"/> is null or empty.</exception>
    public static List<TreeNode<int>> FindNodesClosestToValue(BinaryTree<int>? tree, int givenValue)
    {
        if (tree?.Root == null)
            throw new ArgumentException("BST is null or empty.", nameof(tree));

        var nodes = new List<TreeNode<int>>();
        var minDiff = int.MaxValue;

        MinDiffToGivenValue(tree.Root);
        return nodes;

        void MinDiffToGivenValue(TreeNode<int>? node)
        {
            if (node == null)
                return;

            var diff = Math.Abs(node.Value - givenValue);
            if (diff < minDiff)
            {
                minDiff = diff;
                nodes.Clear();
                nodes.Add(node);
            }
            else if (diff == minDiff)
            {
                nodes.Add(node);
            }

            MinDiffToGivenValue(node.LeftNode);
            MinDiffToGivenValue(node.RightNode);
        }
    }

    /// <summary>
    ///     Iterative variant of <see cref="FindNodesClosestToValue"/>. Uses an explicit stack to perform
    ///     DFS and avoids recursion. Applicable to any binary tree and returns the same results as the
    ///     recursive implementation.
    /// </summary>
    /// <param name="tree">The binary tree to search. Must not be null and must have a root node.</param>
    /// <param name="givenValue">The value to compare against node values.</param>
    /// <returns>
    ///     A list of <see cref="TreeNode{Int32}"/> instances that have the smallest absolute difference
    ///     to <paramref name="givenValue"/>. The list will contain at least one node.
    /// </returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="tree"/> is null or empty.</exception>
    public static List<TreeNode<int>> FindNodesClosestToValueIterative(BinaryTree<int>? tree, int givenValue)
    {
        if (tree?.Root == null)
            throw new ArgumentException("BST is null or empty.", nameof(tree));

        var nodes = new List<TreeNode<int>>();
        var minDiff = int.MaxValue;

        var stack = new Stack<TreeNode<int>>();
        stack.Push(tree.Root);

        while (stack.Count > 0)
        {
            var node = stack.Pop();
            var diff = Math.Abs(node.Value - givenValue);

            if (diff < minDiff)
            {
                minDiff = diff;
                nodes.Clear();
                nodes.Add(node);
            }
            else if (diff == minDiff)
            {
                nodes.Add(node);
            }

            if (node.RightNode != null)
                stack.Push(node.RightNode);
            if (node.LeftNode != null)
                stack.Push(node.LeftNode);
        }

        return nodes;
    }
}

// ToDo:
//  Find a pair with a given sum in two different BSTs.