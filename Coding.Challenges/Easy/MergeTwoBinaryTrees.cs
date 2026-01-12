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
 *  3. Otherwise, it merges starting from both roots and returns a new BinaryTree<int> whose Root is the merged root.
 */

public static class MergeTwoBinaryTrees
{
    /// <summary>
    /// Merge two binary trees using a recursive approach.
    /// If both inputs are null, returns an empty <see cref="BinaryTree{int}"/>.
    /// If one input is null, returns the non-null tree instance (no cloning in that branch).
    /// Otherwise, merges starting from both roots and returns a new <see cref="BinaryTree{int}"/> whose root is the merged root.
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
    /// <param name="firstTreeNode">Node from the first tree (it may be null).</param>
    /// <param name="secondTreeNode">Node from the second tree (it may be null).</param>
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
    /// <param name="node">Source node to clone (it may be null).</param>
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
    /// Otherwise, builds a new merged tree using an explicit stack to avoid recursion.
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
    /// <param name="node">Source subtree root to clone (it may be null).</param>
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

    /// <summary>
    /// Merge two binary search trees into a new binary search tree containing all values from both inputs.
    /// </summary>
    /// <param name="firstBst">First BST or null.</param>
    /// <param name="secondBst">Second BST or null.</param>
    /// <returns>
    /// A merged <see cref="BinaryTree{int}"/> containing all values from both trees. If one argument is null, returns the non-null reference.
    /// If both are null returns an empty tree.
    /// </returns>
    /// <remarks>
    /// This implementation serializes both trees in level-order, concatenates and sorts values, then inserts them into a new BST allowing duplicates.
    /// Time complexity is O(N log N) dominated by sorting and insertions; additional space O(N) is used for the value lists.
    /// </remarks>
    public static BinaryTree<int>? MergeBinarySearchTrees(BinaryTree<int>? firstBst, BinaryTree<int>? secondBst)
    {
        if (firstBst == null && secondBst == null)
            return new BinaryTree<int>();
        if (firstBst == null) return secondBst;
        if (secondBst == null) return firstBst;

        var firstTreeValues = firstBst.SerializeLevelOrder();
        var secondTreeValues = secondBst.SerializeLevelOrder();
        var resultList = new List<int>();
        resultList.AddRange(firstTreeValues);
        resultList.AddRange(secondTreeValues);
        resultList.Sort();

        var resultBst = new BinaryTree<int>();
        foreach (var value in resultList)
            resultBst.InsertBinarySearchAllowDuplicates(value);

        return resultBst;
    }

    /// <summary>
    /// Determines whether two binary trees are mirror images of each other.
    /// </summary>
    /// <param name="firstTree">First tree or null.</param>
    /// <param name="secondTree">Second tree or null.</param>
    /// <returns>True if both trees are mirrors; otherwise false.</returns>
    /// <remarks>
    /// Null trees are considered mirrors when both are null. Uses a recursive helper to compare mirrored children.
    /// </remarks>
    public static bool AreTwoBinaryTreesMirrors(BinaryTree<int>? firstTree, BinaryTree<int>? secondTree) =>
        (firstTree?.Root, secondTree?.Root) switch
        {
            (null, null) => true,
            (null, _) or (_, null) => false,
            (TreeNode<int> f, TreeNode<int> s) => CompareMirrorNodes(f, s)
        };

    /// <summary>
    /// Recursively compares two nodes to determine mirror symmetry.
    /// </summary>
    private static bool CompareMirrorNodes(TreeNode<int>? firstNode, TreeNode<int>? secondNode) =>
        (firstNode == null && secondNode == null) || (firstNode != null && secondNode != null && (firstNode.Value == secondNode.Value &&
            CompareMirrorNodes(firstNode.LeftNode, secondNode.RightNode) &&
            CompareMirrorNodes(firstNode.RightNode, secondNode.LeftNode)));

    /// <summary>
    /// Determines whether two binary trees are identical in structure and node values.
    /// </summary>
    /// <param name="firstTree">The first tree to compare, or null.</param>
    /// <param name="secondTree">The second tree to compare, or null.</param>
    /// <returns>
    /// True if both trees are structurally identical and every corresponding node has the same value; otherwise false.
    /// </returns>
    public static bool AreTwoBinaryTreeIdentical(BinaryTree<int>? firstTree, BinaryTree<int>? secondTree) =>
        (firstTree?.Root, secondTree?.Root) switch
        {
            (null, null) => true,
            (null, _) or (_, null) => false,
            (TreeNode<int> f, TreeNode<int> s) => CompareNodes(f, s)
        };

    /// <summary>
    /// Recursively compares two nodes for structural and value equality.
    /// </summary>
    private static bool CompareNodes(TreeNode<int>? firstNode, TreeNode<int>? secondNode) =>
        (firstNode == null && secondNode == null) || (firstNode != null && secondNode != null && (firstNode.Value == secondNode.Value &&
            CompareNodes(firstNode.LeftNode, secondNode.LeftNode) &&
            CompareNodes(firstNode.RightNode, secondNode.RightNode)));

    /// <summary>
    /// Determines whether the specified <see cref="BinaryTree{int}"/> is a binary search tree (BST).
    /// </summary>
    /// <param name="tree">The tree to validate, or <c>null</c>.</param>
    /// <returns>
    /// <c>true</c> when <paramref name="tree"/> is <c>null</c> or its nodes satisfy BST ordering
    /// (every left subtree node &lt; parent &lt; every right subtree node); otherwise <c>false</c>.
    /// </returns>
    /// <remarks>
    /// Uses a range-check helper that enforces strict ordering (no duplicate keys are allowed).
    /// The helper uses 64-bit bounds to avoid integer overflow when propagating limits.
    /// </remarks>
    public static bool IsTreeBinarySearchTree(BinaryTree<int>? tree) =>
        tree?.Root == null || IsBstNode(tree.Root, long.MinValue, long.MaxValue);

    /// <summary>
    /// Recursively validates that the subtree rooted at <paramref name="node"/> satisfies BST ordering
    /// with all values in the exclusive range (<paramref name="min"/>, <paramref name="max"/>).
    /// </summary>
    private static bool IsBstNode(TreeNode<int>? node, long min, long max)
    {
        if (node == null) return true;
        if (node.Value <= min || node.Value >= max) return false;
        return IsBstNode(node.LeftNode, min, node.Value) &&
               IsBstNode(node.RightNode, node.Value, max);
    }

    /// <summary>
    /// Count all rooted subtrees within <paramref name="tree"/> that are valid binary search trees (BST).
    /// </summary>
    /// <param name="tree">Binary tree to inspect, or <c>null</c>.</param>
    /// <returns>
    /// Number of nodes in <paramref name="tree"/> that serve as a root of a subtree which is a valid BST.
    /// Returns 0 when <paramref name="tree"/> is <c>null</c> or empty.
    /// </returns>
    public static int CountBinarySearchTreesInTree(BinaryTree<int>? tree)
    {
        return tree?.Root == null ? 0 : CountBinarySearchTrees(tree.Root);
    }

    /// <summary>
    /// Recursive helper that counts how many rooted subtrees in the subtree under <paramref name="node"/> are BSTs.
    /// </summary>
    private static int CountBinarySearchTrees(TreeNode<int>? node)
    {
        if (node == null) return 0;

        var count = IsBstNode(node, long.MinValue, long.MaxValue) ? 1 : 0;
        count += CountBinarySearchTrees(node.LeftNode);
        count += CountBinarySearchTrees(node.RightNode);

        return count;
    }

    /// <summary>
    /// Return a new tree that is the mirror (left/right inverted) of the provided tree.
    /// If <paramref name="tree"/> is null or empty returns the same reference.
    /// The returned tree is a deep-clone — no nodes are shared with the source.
    /// </summary>
    public static BinaryTree<int>? FlipBinaryTree(BinaryTree<int>? tree)
    {
        if (tree?.Root == null)
            return tree;

        return new BinaryTree<int> { Root = MirrorClone(tree.Root) };
    }

    /// <summary>
    /// Deep-clone the subtree rooting at <paramref name="node"/> while swapping left and right children,
    /// producing the mirrored subtree root or null if <paramref name="node"/> is null.
    /// </summary>
    private static TreeNode<int>? MirrorClone(TreeNode<int>? node)
    {
        if (node == null) return null;

        return new TreeNode<int>(node.Value)
        {
            LeftNode = MirrorClone(node.RightNode),
            RightNode = MirrorClone(node.LeftNode)
        };
    }

    /// <summary>
    /// Determine whether the specified <see cref="BinaryTree{int}"/> contains a node with the given value.
    /// </summary>
    /// <param name="tree">Tree to search or <c>null</c>. If <c>null</c> the method returns <c>false</c>.</param>
    /// <param name="value">Value to search for.</param>
    /// <returns><c>true</c> when any node in <paramref name="tree"/> has <paramref name="value"/>; otherwise <c>false</c>.</returns>
    /// <remarks>
    /// Time complexity: O(N) where N is the number of nodes visited.
    /// Space complexity: O(H) where H is the tree height due to the explicit stack used by the helper.
    /// </remarks>
    public static bool SearchForValueInTree(BinaryTree<int>? tree, int value) =>
        tree?.Root != null && IsValueInTree(tree.Root, value);

    /// <summary>
    /// Iteratively searches the subtree rooted at <paramref name="node"/> for <paramref name="value"/>.
    /// </summary>
    /// <param name="node">Root of the subtree to search. Passing <c>null</c> returns <c>false</c>.</param>
    /// <param name="value">Value to find.</param>
    /// <returns><c>true</c> if a node with <paramref name="value"/> is found; otherwise <c>false</c>.</returns>
    /// <remarks>
    /// This implementation uses an explicit stack (DFS) instead of recursion to avoid potential stack-overflow
    /// on very deep trees and to keep the search iterative. Nodes are visited in preorder order (root, left, right).
    /// Time complexity: O(N). Space complexity: O(H).
    /// </remarks>
    private static bool IsValueInTree(TreeNode<int>? node, int value)
    {
        if (node == null)
            return false;

        var stack = new Stack<TreeNode<int>>();
        stack.Push(node);

        while (stack.Count > 0)
        {
            var curr = stack.Pop();
            if (curr.Value == value)
                return true;

            // Push right first so left is processed next (preorder).
            if (curr.RightNode != null)
                stack.Push(curr.RightNode);
            if (curr.LeftNode != null)
                stack.Push(curr.LeftNode);
        }

        return false;
    }


    // ToDo:
    // public static TreeNode<int>? LowestCommonAncestor(BinaryTree<int>? tree, int value1, int value2);
    // public static int DistanceBetweenNodes(BinaryTree<int>? tree, int value1, int value2);

}


