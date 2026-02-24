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
}


// ToDo:
//  Find the minimum absolute difference in two different BSTs.
//  Find the node whose absolute difference with an element X gives minimum value.
//  Find a pair with a given sum in two different BSTs.