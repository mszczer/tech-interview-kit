using Coding.Challenges.Common;

namespace Coding.Challenges.Tests.Easy;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class TestMinDifferenceInBst
{
    [Test]
    public void MinDiffInTree_SampleBst_ReturnsOne()
    {
        var tree = new BinaryTree<int>
        {
            Root = new TreeNode<int>(7)
            {
                LeftNode = new TreeNode<int>(3)
                {
                    LeftNode = new TreeNode<int>(2),
                    RightNode = new TreeNode<int>(5)
                },
                RightNode = new TreeNode<int>(10)
                {
                    LeftNode = new TreeNode<int>(8),
                    RightNode = new TreeNode<int>(12)
                }
            }
        };

        var result = MinDifferenceInBst.MinDiffInTree(tree);
        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void MinDiffInTree_NullTree_ReturnsZero()
    {
        BinaryTree<int>? tree = null;

        var result = MinDifferenceInBst.MinDiffInTree(tree);
        Assert.That(result, Is.Zero);
    }

    [Test]
    public void MinDiffInTree_SingleNode_ReturnsZero()
    {
        var tree = new BinaryTree<int>
        {
            Root = new TreeNode<int>(5)
        };

        var result = MinDifferenceInBst.MinDiffInTree(tree);
        Assert.That(result, Is.Zero);
    }

    [Test]
    public void MinDiffInTree_TwoNodes_ReturnsAbsoluteDifference()
    {
        var tree = new BinaryTree<int>
        {
            Root = new TreeNode<int>(5)
            {
                LeftNode = new TreeNode<int>(2)
            }
        };

        var result = MinDifferenceInBst.MinDiffInTree(tree);
        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void MinDiffInTree_DuplicateValues_ReturnsZero()
    {
        var tree = new BinaryTree<int>
        {
            Root = new TreeNode<int>(5)
            {
                RightNode = new TreeNode<int>(5)
            }
        };

        var result = MinDifferenceInBst.MinDiffInTree(tree);
        Assert.That(result, Is.Zero);
    }

    [Test]
    public void MinDiffInTree_NegativeValues_Works()
    {
        var tree = new BinaryTree<int>
        {
            Root = new TreeNode<int>(-8)
            {
                LeftNode = new TreeNode<int>(-10),
                RightNode = new TreeNode<int>(0)
            }
        };

        var result = MinDifferenceInBst.MinDiffInTree(tree);
        Assert.That(result, Is.EqualTo(2));
    }
}