using Coding.Challenges.Common;

namespace Coding.Challenges.Easy;

/*
 * Difficulty: Easy
 * Problem:
 *  Given an array, arr[] having all the elements sorted in ascending order,
 *  write a program to convert it to a height balanced BST.
 * Note:
 *  The height-balanced binary tree is defined as a binary tree in which the maximum depth
 *  of the two subtrees of every node is 1.
 * Example 1:
 *  Input: arr[] = [1, 2, 3]
 *  Output: A Balanced BST
 *          2
 *        /  \
 *       1    3
 *
 * Example 2:
 *  Input: arr[] = [1, 2, 3, 4]
 *  Output: A Balanced BST
 *          3
 *        /  \
 *       2    4
 *     /
 *    1
 */

public class SortedArrayToBalancedBst
{
    public static TestBinaryTree<int> ConvertArrToBst(int[]? sortedArr)
    {
        if (sortedArr == null || sortedArr.Length == 0)
            return new TestBinaryTree<int>();

        var balancedBst = new TestBinaryTree<int>
        {
            Root = BuildNode(0, sortedArr.Length - 1, sortedArr)
        };

        return balancedBst;
    }

    private static TreeNode<int>? BuildNode(int left, int right, int[] arr)
    {
        if (left > right) return null;
        
        var mid = (left + right + 1) / 2;
        var node = new TreeNode<int>(arr[mid])
        {
            LeftNode = BuildNode(left, mid - 1, arr),
            RightNode = BuildNode(mid + 1, right, arr)
        };

        return node;
    }
}