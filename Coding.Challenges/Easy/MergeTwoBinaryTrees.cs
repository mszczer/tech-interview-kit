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
 *
 * Solution:
 *  1. Call GetMergedTree(BinaryTree<int>?, BinaryTree<int>?) (or GetMergedTreeIterative(BinaryTree<int>?, BinaryTree<int>?)) with two BinaryTree<int>? inputs.
 *  2. If both inputs are null it returns an empty BinaryTree<int>(). If one is null it returns the other (note: it returns the same reference).
 *  3. Otherwise it merges starting from both roots and returns a new BinaryTree<int> whose Root is the merged root.
 */

public static class MergeTwoBinaryTrees
{
    /// <summary>
    /// Merge two binary trees using a recursive approach.
    /// If both inputs are null, returns an empty <see cref="BinaryTree{int}"/>.
    /// If one input is null, returns the non-null tree instance (no cloning in that branch).
    /// Otherwise merges starting from both roots and returns a new <see cref="BinaryTree{int}"/> whose root is the merged root.
    /// </summary>
    /// <param name="firstTree">First binary tree or null.</param>
    /// <param name="secondTree">Second binary tree or null.</param>
    /// <returns>
    /// A merged <see cref="BinaryTree{int}"/>. When one argument is null this method returns the non-null input reference.
    /// When both are null an empty tree is returned.
    /// </returns>
    /// <remarks>
    /// Complexity: visits at most all nodes from both trees (O(N) time). Recursive stack depth is O(H) where H is height.
    /// </remarks>
    public static BinaryTree<int>? GetMergedTree(BinaryTree<int>? firstTree, BinaryTree<int>? secondTree)
    {
        if (firstTree == null && secondTree == null)
            return new BinaryTree<int>();
        if (firstTree == null) return secondTree;
        if (secondTree == null) return firstTree;

        return MergeTreesFromRoots(firstTree.Root!, secondTree.Root!);
    }

    /// <summary>
    /// Create a new <see cref="BinaryTree{int}"/> with its root set to the merge of the two provided roots.
    /// </summary>
    /// <param name="firstRoot">Root node of the first tree (expected non-null).</param>
    /// <param name="secondRoot">Root node of the second tree (expected non-null).</param>
    /// <returns>A new <see cref="BinaryTree{int}"/> whose Root is the merged node.</returns>
    private static BinaryTree<int> MergeTreesFromRoots(TreeNode<int> firstRoot, TreeNode<int> secondRoot)
    {
        return new BinaryTree<int>
        {
            Root = MergeNodes(firstRoot, secondRoot)
        };
    }

    /// <summary>
    /// Recursively merge two tree nodes into a single node.
    /// Rules:
    /// - If both nodes are null, return null.
    /// - If one node is null, return a deep clone of the other node (so merged tree does not share nodes).
    /// - If both nodes are non-null, create a new node with the summed value and recurse for left/right children.
    /// </summary>
    /// <param name="firstTreeNode">Node from the first tree (may be null).</param>
    /// <param name="secondTreeNode">Node from the second tree (may be null).</param>
    /// <returns>A new merged <see cref="TreeNode{int}"/> or null.</returns>
    /// <remarks>
    /// Produces a freshly allocated subtree when merging overlapping nodes or cloning a single-side subtree.
    /// </remarks>
    private static TreeNode<int>? MergeNodes(TreeNode<int>? firstTreeNode, TreeNode<int>? secondTreeNode)
    {
        if (firstTreeNode == null && secondTreeNode == null)
            return null;

        if (firstTreeNode == null)
            return CloneNode(secondTreeNode);
        if (secondTreeNode == null)
            return CloneNode(firstTreeNode);

        return new TreeNode<int>(firstTreeNode.Value + secondTreeNode.Value)
        {
            LeftNode = MergeNodes(firstTreeNode.LeftNode, secondTreeNode.LeftNode),
            RightNode = MergeNodes(firstTreeNode.RightNode, secondTreeNode.RightNode)
        };
    }

    /// <summary>
    /// Deep-clone the provided node and its entire subtree (recursive).
    /// If <paramref name="node"/> is null, returns null.
    /// </summary>
    /// <param name="node">Source node to clone (may be null).</param>
    /// <returns>A deep copy of <paramref name="node"/> or null.</returns>
    private static TreeNode<int>? CloneNode(TreeNode<int>? node)
    {
        if (node == null) return null;

        return new TreeNode<int>(node.Value)
        {
            LeftNode = CloneNode(node.LeftNode),
            RightNode = CloneNode(node.RightNode)
        };
    }

    /// <summary>
    /// Merge two binary trees using an iterative (stack-based) approach.
    /// If both inputs are null, returns an empty <see cref="BinaryTree{int}"/>.
    /// If one input is null, returns the non-null tree instance (no cloning in that branch).
    /// Otherwise builds a new merged tree using an explicit stack to avoid recursion.
    /// </summary>
    /// <param name="firstTree">First binary tree or null.</param>
    /// <param name="secondTree">Second binary tree or null.</param>
    /// <returns>A merged <see cref="BinaryTree{int}"/>. When one argument is null this method returns the non-null input reference.</returns>
    /// <remarks>
    /// The algorithm creates summed nodes when both sides exist, and clones entire subtrees when only one side exists using <see cref="CloneNodeIterative"/>.
    /// Time complexity is O(N), uses O(H) auxiliary stack space.
    /// </remarks>
    public static BinaryTree<int>? GetMergedTreeIterative(BinaryTree<int>? firstTree, BinaryTree<int>? secondTree)
    {
        if (firstTree == null && secondTree == null)
            return new BinaryTree<int>();
        if (firstTree == null) return secondTree;
        if (secondTree == null) return firstTree;

        var firstRoot = firstTree.Root!;
        var secondRoot = secondTree.Root!;

        var newRoot = new TreeNode<int>(firstRoot.Value + secondRoot.Value);
        var result = new BinaryTree<int> { Root = newRoot };

        var stack = new Stack<(TreeNode<int> NewNode, TreeNode<int> FirstNode, TreeNode<int> SecondNode)>();
        stack.Push((newRoot, firstRoot, secondRoot));

        while (stack.Count > 0)
        {
            var (currNew, firstNode, secondNode) = stack.Pop();

            // Left child
            var firstLeft = firstNode.LeftNode;
            var secondLeft = secondNode.LeftNode;
            if (firstLeft != null || secondLeft != null)
            {
                if (firstLeft != null && secondLeft != null)
                {
                    var leftNew = new TreeNode<int>(firstLeft.Value + secondLeft.Value);
                    currNew.LeftNode = leftNew;
                    stack.Push((leftNew, firstLeft, secondLeft));
                }
                else
                {
                    currNew.LeftNode = CloneNodeIterative(firstLeft ?? secondLeft);
                }
            }

            // Right child
            var firstRight = firstNode.RightNode;
            var secondRight = secondNode.RightNode;
            if (firstRight != null || secondRight != null)
            {
                if (firstRight != null && secondRight != null)
                {
                    var rightNew = new TreeNode<int>(firstRight.Value + secondRight.Value);
                    currNew.RightNode = rightNew;
                    stack.Push((rightNew, firstRight, secondRight));
                }
                else
                {
                    currNew.RightNode = CloneNodeIterative(firstRight ?? secondRight);
                }
            }
        }

        return result;
    }

    /// <summary>
    /// Iteratively deep-clone a subtree using an explicit stack.
    /// Returns null if <paramref name="node"/> is null.
    /// </summary>
    /// <param name="node">Source subtree root to clone (may be null).</param>
    /// <returns>A deep copy of the source subtree root or null.</returns>
    /// <remarks>
    /// This non-recursive clone is used by the iterative merge to attach an entire subtree when the other side is missing.
    /// </remarks>
    private static TreeNode<int>? CloneNodeIterative(TreeNode<int>? node)
    {
        if (node == null) return null;

        var newRoot = new TreeNode<int>(node.Value);
        var stack = new Stack<(TreeNode<int> Source, TreeNode<int> Dest)>();
        stack.Push((node, newRoot));

        while (stack.Count > 0)
        {
            var (src, dst) = stack.Pop();

            if (src.LeftNode != null)
            {
                var leftDst = new TreeNode<int>(src.LeftNode.Value);
                dst.LeftNode = leftDst;
                stack.Push((src.LeftNode, leftDst));
            }

            if (src.RightNode != null)
            {
                var rightDst = new TreeNode<int>(src.RightNode.Value);
                dst.RightNode = rightDst;
                stack.Push((src.RightNode, rightDst));
            }
        }

        return newRoot;
    }
}