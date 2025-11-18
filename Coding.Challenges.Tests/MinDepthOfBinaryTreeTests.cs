using Coding.Challenges.Common;

namespace Coding.Challenges.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class MinDepthOfBinaryTreeTests
{
    [Test]
    public void FindMinimumDepth_ReturnsExpected()
    {
        var tree = BuildSampleTree();
        var result = MinDepthOfBinaryTree.FindMinimumDepth(tree);
        Assert.That(result, Is.EqualTo(2));
    }

    [Test]
    public void FindMinimumDepth_EmptyTree_ReturnsZero()
    {
        var tree = new BinaryTree<int>();
        var result = MinDepthOfBinaryTree.FindMinimumDepth(tree);
        Assert.That(result, Is.Zero);
    }

    [Test]
    public void FindMinimumDepth_SingleNodeTree_ReturnsOne()
    {
        var tree = new BinaryTree<int> { Root = new TreeNode<int>(42) };
        var result = MinDepthOfBinaryTree.FindMinimumDepth(tree);
        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void FindMinimumDepth_LeftSkewedTree_ReturnsDepth()
    {
        var tree = new BinaryTree<int>
        {
            Root = new TreeNode<int>(1)
            {
                LeftNode = new TreeNode<int>(2)
                {
                    LeftNode = new TreeNode<int>(3)
                }
            }
        };
        var result = MinDepthOfBinaryTree.FindMinimumDepth(tree);
        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void FindMinimumDepth_RightSkewedTree_ReturnsDepth()
    {
        var tree = new BinaryTree<int>
        {
            Root = new TreeNode<int>(1)
            {
                RightNode = new TreeNode<int>(2)
                {
                    RightNode = new TreeNode<int>(3)
                }
            }
        };
        var result = MinDepthOfBinaryTree.FindMinimumDepth(tree);
        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void FindMinimumDepth_UnbalancedTree_ReturnsShortestLeafDepth()
    {
        var tree = new BinaryTree<int>
        {
            Root = new TreeNode<int>(1)
            {
                LeftNode = new TreeNode<int>(2),
                RightNode = new TreeNode<int>(3)
                {
                    RightNode = new TreeNode<int>(4)
                    {
                        RightNode = new TreeNode<int>(5)
                    }
                }
            }
        };
        var result = MinDepthOfBinaryTree.FindMinimumDepth(tree);
        Assert.That(result, Is.EqualTo(2));
    }

    private static BinaryTree<int> BuildSampleTree()
    {
        var tree = new BinaryTree<int>
        {
            Root = new TreeNode<int>(10)
            {
                LeftNode = new TreeNode<int>(5),
                RightNode = new TreeNode<int>(15)
                {
                    LeftNode = new TreeNode<int>(11),
                    RightNode = new TreeNode<int>(6)
                }
            }
        };

        return tree;
    }
}