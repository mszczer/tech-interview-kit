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

        return MergeTreesFromRoots(firstTree.Root!, secondTree.Root!);
    }

    private static BinaryTree<int> MergeTreesFromRoots(TreeNode<int> firstRoot, TreeNode<int> secondRoot)
    {
        return new BinaryTree<int>
        {
            Root = MergeNodes(firstRoot, secondRoot)
        };
    }

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

    private static TreeNode<int>? CloneNode(TreeNode<int>? node)
    {
        if (node == null) return null;

        return new TreeNode<int>(node.Value)
        {
            LeftNode = CloneNode(node.LeftNode),
            RightNode = CloneNode(node.RightNode)
        };
    }

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