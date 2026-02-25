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

        // Iterative in-order traversal to compute adjacent differences without materializing full list.
        var minDiff = int.MaxValue;
        int? previous = null;

        var stack = new Stack<TreeNode<int>>();
        var node = tree.Root;

        while (stack.Count > 0 || node != null)
        {
            while (node != null)
            {
                stack.Push(node);
                node = node.LeftNode;
            }

            node = stack.Pop();

            if (previous.HasValue)
            {
                var diff = node.Value - previous.Value;
                if (diff < minDiff)
                    minDiff = diff;
            }

            previous = node.Value;
            node = node.RightNode;
        }

        return minDiff == int.MaxValue ? 0 : minDiff;
    }

    /// <summary>
    ///     Determines whether there exists a pair of distinct nodes in the BST whose values sum to
    ///     <paramref name="givenSum" />.
    /// </summary>
    public static bool FindPairWithGivenSumInBst(BinaryTree<int>? tree, int givenSum)
    {
        if (tree?.Root == null)
            return false;

        var values = tree.SerializeInOrderTraversal();

        if (values.Count < 2)
            return false;

        // Two-pointer on sorted in-order list
        var left = 0;
        var right = values.Count - 1;

        while (left < right)
        {
            var sum = values[left] + values[right];
            if (sum == givenSum)
                return true;

            if (sum < givenSum)
                left++;
            else
                right--;
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
    ///     to <paramref name="givenValue" />.
    ///     Works for any binary tree (does not rely on BST ordering).
    /// </summary>
    /// <param name="tree">The binary tree to search. Must not be null and must have a root node.</param>
    /// <param name="givenValue">The value to compare against node values.</param>
    /// <returns>
    ///     A list of <see cref="TreeNode{Int32}" /> instances that have the smallest absolute difference
    ///     to <paramref name="givenValue" />. The list will contain at least one node.
    /// </returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="tree" /> is null or empty.</exception>
    public static List<TreeNode<int>> FindNodesClosestToValue(BinaryTree<int>? tree, int givenValue)
    {
        if (tree?.Root == null)
            throw new ArgumentException("Binary tree is null or empty.", nameof(tree));

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
    ///     Iterative variant of <see cref="FindNodesClosestToValue" />. Uses an explicit stack to perform
    ///     DFS and avoids recursion. Applicable to any binary tree and returns the same results as the
    ///     recursive implementation.
    /// </summary>
    /// <param name="tree">The binary tree to search. Must not be null and must have a root node.</param>
    /// <param name="givenValue">The value to compare against node values.</param>
    /// <returns>
    ///     A list of <see cref="TreeNode{Int32}" /> instances that have the smallest absolute difference
    ///     to <paramref name="givenValue" />. The list will contain at least one node.
    /// </returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="tree" /> is null or empty.</exception>
    public static List<TreeNode<int>> FindNodesClosestToValueIterative(BinaryTree<int>? tree, int givenValue)
    {
        if (tree?.Root == null)
            throw new ArgumentException("Binary tree is null or empty.", nameof(tree));

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

    public static bool FindPairWithGivenSumInTwoBst(BinaryTree<int>? firstTree, BinaryTree<int>? secondTree,
        int givenSum)
    {
        if (firstTree?.Root == null || secondTree?.Root == null)
            return false;

        var left = firstTree.SerializeInOrderTraversal();
        var right = secondTree.SerializeInOrderTraversal();

        if (left.Count == 0 || right.Count == 0)
            return false;

        // Two-pointer across two sorted lists. left ascending, right ascending — start right pointer at end.
        var i = 0;
        var j = right.Count - 1;

        while (i < left.Count && j >= 0)
        {
            var sum = left[i] + right[j];
            if (sum == givenSum)
                return true;

            if (sum < givenSum)
                i++;
            else
                j--;
        }

        return false;
    }
}