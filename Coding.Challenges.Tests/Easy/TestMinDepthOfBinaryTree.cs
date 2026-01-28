using Coding.Challenges.Common;

namespace Coding.Challenges.Tests.Easy;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class TestMinDepthOfBinaryTree
{
    [Test]
    public void FindMinimumDepth_ReturnsExpected()
    {
        var tree = BuildSampleTree();
        var result = Challenges.Easy.MinDepthOfBinaryTree.FindMinimumDepth(tree);
        Assert.That(result, Is.EqualTo(2));
    }

    [Test]
    public void FindMinimumDepth_EmptyTree_ReturnsZero()
    {
        var tree = new TestBinaryTree<int>();
        var result = Challenges.Easy.MinDepthOfBinaryTree.FindMinimumDepth(tree);
        Assert.That(result, Is.Zero);
    }

    [Test]
    public void FindMinimumDepth_SingleNodeTree_ReturnsOne()
    {
        var tree = new TestBinaryTree<int> { Root = new TreeNode<int>(42) };
        var result = Challenges.Easy.MinDepthOfBinaryTree.FindMinimumDepth(tree);
        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void FindMinimumDepth_LeftSkewedTree_ReturnsDepth()
    {
        var tree = new TestBinaryTree<int>
        {
            Root = new TreeNode<int>(1)
            {
                LeftNode = new TreeNode<int>(2)
                {
                    LeftNode = new TreeNode<int>(3)
                }
            }
        };
        var result = Challenges.Easy.MinDepthOfBinaryTree.FindMinimumDepth(tree);
        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void FindMinimumDepth_RightSkewedTree_ReturnsDepth()
    {
        var tree = new TestBinaryTree<int>
        {
            Root = new TreeNode<int>(1)
            {
                RightNode = new TreeNode<int>(2)
                {
                    RightNode = new TreeNode<int>(3)
                }
            }
        };
        var result = Challenges.Easy.MinDepthOfBinaryTree.FindMinimumDepth(tree);
        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void FindMinimumDepth_UnbalancedTree_ReturnsShortestLeafDepth()
    {
        var tree = new TestBinaryTree<int>
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
        var result = Challenges.Easy.MinDepthOfBinaryTree.FindMinimumDepth(tree);
        Assert.That(result, Is.EqualTo(2));
    }

    private static TestBinaryTree<int> BuildSampleTree()
    {
        var tree = new TestBinaryTree<int>
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