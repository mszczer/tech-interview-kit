using Coding.Challenges.Common;

namespace Coding.Challenges.Tests.Easy;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class TestMinDifferenceInBst
{
    [Test]
    public void MinDiffInTree_SampleBst_ReturnsOne()
    {
        var tree = CreateSampleTree();

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

    [Test]
    [TestCase(12, true)]
    [TestCase(25, false)]
    public void FindPairWithGivenSumInBst_SampleBst_VariousSums_ReturnsExpected(int givenSum, bool expected)
    {
        var tree = CreateSampleTree();

        var result = MinDifferenceInBst.FindPairWithGivenSumInBst(tree, givenSum);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void FindPairWithGivenSumInBst_NullTree_ReturnsFalse()
    {
        BinaryTree<int>? tree = null;

        var result = MinDifferenceInBst.FindPairWithGivenSumInBst(tree, 10);
        Assert.That(result, Is.False);
    }

    [Test]
    public void FindPairWithGivenSumInBst_SingleNode_ReturnsFalse()
    {
        var tree = new BinaryTree<int>
        {
            Root = new TreeNode<int>(5)
        };

        var result = MinDifferenceInBst.FindPairWithGivenSumInBst(tree, 10);
        Assert.That(result, Is.False);
    }

    [Test]
    public void FindPairWithGivenSumInBst_DuplicateValues_ReturnsTrue()
    {
        var tree = new BinaryTree<int>
        {
            Root = new TreeNode<int>(5)
            {
                RightNode = new TreeNode<int>(5)
            }
        };

        var result = MinDifferenceInBst.FindPairWithGivenSumInBst(tree, 10);
        Assert.That(result, Is.True);
    }

    [Test]
    public void FindPairWithGivenSumInBst_NegativeValues_Works()
    {
        var tree = new BinaryTree<int>
        {
            Root = new TreeNode<int>(-6)
            {
                LeftNode = new TreeNode<int>(-7),
                RightNode = new TreeNode<int>(-5)
            }
        };

        var result = MinDifferenceInBst.FindPairWithGivenSumInBst(tree, -12);
        Assert.That(result, Is.True);
    }

    private static BinaryTree<int> CreateSampleTree()
    {
        return new BinaryTree<int>
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
    }
}