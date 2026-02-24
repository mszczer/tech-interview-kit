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
    public static int MinDiffInTree(BinaryTree<int>? tree)
    {
        if (tree?.Root == null) 
            return 0;

        var serializedTree = tree.SerializeInOrderTraversal();

        if (serializedTree.Count<2)
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

}