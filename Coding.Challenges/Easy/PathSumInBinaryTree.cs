using Coding.Challenges.Common;

namespace Coding.Challenges.Easy;
/*
 * Difficulty: Easy
 * Problem:
 *  Given the root node of a binary tree and a sum, write a program
 *  to determine if there exists a path in the tree from root-to-leaf
 *  such that the sum of all the values along the path equals the given sum.
 */

public abstract class PathSumInBinaryTree
{
    public static bool IsTargetSumInAnyPath(BinaryTree<int> tree, int sum)
    {
        throw new NotImplementedException();
    }
}

/*
 * solution 1: recursive depth-first search (DFS)
 * function that takes a TreeNode and an integer sum as input
 * checks if the current node is null
 * if it is, returns false
 * if not, checks if the current node is a leaf node
 * sums the value of the current node to the sum
 * until it reaches a leaf node
 * compares the sum to the target sum
 * if not a leaf node, recursively calls itself on the left and right child nodes
 * and returns true if either call returns true
 *
 */