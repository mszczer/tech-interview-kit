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

public static class SortedArrayToBalancedBst
{
    public static BinaryTree<int> ConvertArrToBst(int[]? sortedArr)
    {
        if (sortedArr == null || sortedArr.Length == 0)
            return new BinaryTree<int>();

        var balancedBst = new BinaryTree<int>
        {
            Root = BuildNode(0, sortedArr.Length - 1, sortedArr)
        };

        return balancedBst;
    }

    private static int GetMiddle(int left, int right)
    {
        return left + (right - left + 1) / 2;
    }

    private static TreeNode<int>? BuildNode(int left, int right, int[] arr)
    {
        if (left > right) return null;

        var mid = GetMiddle(left, right);
        var node = new TreeNode<int>(arr[mid])
        {
            LeftNode = BuildNode(left, mid - 1, arr),
            RightNode = BuildNode(mid + 1, right, arr)
        };

        return node;
    }

    public static BinaryTree<int> ConvertArrToBstIterative(int[]? sortedArr)
    {
        if (sortedArr == null || sortedArr.Length == 0)
            return new BinaryTree<int>();

        var n = sortedArr.Length;
        var rootIndex = GetMiddle(0, n - 1);
        var root = new TreeNode<int>(sortedArr[rootIndex]);
        var balancedBst = new BinaryTree<int> { Root = root };

        // Stack holds tuples of (lowIndex, highIndex, node) representing the subarray and node to attach children for.
        var stack = new Stack<(int low, int high, TreeNode<int> node)>();
        stack.Push((0, n - 1, root));

        while (stack.Count > 0)
        {
            var (low, high, node) = stack.Pop();
            var mid = GetMiddle(low, high);

            // left range: low - mid-1
            if (low <= mid - 1)
            {
                var leftMid = GetMiddle(low, mid - 1);
                var leftNode = new TreeNode<int>(sortedArr[leftMid]);
                node.LeftNode = leftNode;
                stack.Push((low, mid - 1, leftNode));
            }

            // right range: mid+1 - high
            if (mid + 1 <= high)
            {
                var rightMid = GetMiddle(mid + 1, high);
                var rightNode = new TreeNode<int>(sortedArr[rightMid]);
                node.RightNode = rightNode;
                stack.Push((mid + 1, high, rightNode));
            }
        }

        return balancedBst;
    }

    public static BinaryTree<int> SortedLinkedListToBalancedBst(LinkedList<int>? sortedList)
    {
        if (sortedList == null || sortedList.Count == 0)
            return new BinaryTree<int>();

        var current = sortedList.First;

        TreeNode<int>? BuildFromRange(int left, int right)
        {
            if (left > right) return null;

            var mid = GetMiddle(left, right);

            // build left subtree
            var leftNode = BuildFromRange(left, mid - 1);

            // current node becomes root
            if (current == null) return null;
            var node = new TreeNode<int>(current.Value)
            {
                LeftNode = leftNode
            };

            // advance the list pointer
            current = current.Next;

            // build right subtree
            node.RightNode = BuildFromRange(mid + 1, right);

            return node;
        }

        var root = BuildFromRange(0, sortedList.Count - 1);
        return new BinaryTree<int> { Root = root };
    }

    /// <summary>
    ///     Returns the k-th smallest element in the given BST (1-based).
    ///     Uses an iterative in-order traversal (left, node, right) which visits nodes in ascending order for a BST.
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when <paramref name="bst" /> is null or the BST root is null (empty tree).</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Thrown when <paramref name="k" /> is not positive or is greater than the
    ///     number of nodes.
    /// </exception>
    public static int FindKthSmallestElementInBst(int k, BinaryTree<int> bst)
    {
        if (bst?.Root == null)
            throw new ArgumentException("BST is null or empty.", nameof(bst));
        if (k <= 0)
            throw new ArgumentOutOfRangeException(nameof(k), "k must be a positive integer.");

        var stack = new Stack<TreeNode<int>>();
        var current = bst.Root;
        var count = 0;

        while (stack.Count > 0 || current != null)
        {
            while (current != null)
            {
                stack.Push(current);
                current = current.LeftNode;
            }

            current = stack.Pop();
            count++;
            if (count == k)
                return current.Value;

            current = current.RightNode;
        }

        throw new ArgumentOutOfRangeException(nameof(k), "k is greater than the number of nodes in the BST.");
    }


    //ToDo:
    //  Sorted order printing of a given array that represents a BST
    //  Determine if a tree is a height-balanced tree or not
    //  Construct a complete binary tree from the given array
}