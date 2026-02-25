using System.Linq;
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

    [Test]
    public void FindMinAbsoluteDifferenceInTwoBst_NullFirstTree_ReturnsZero()
    {
        BinaryTree<int>? first = null;
        var second = new BinaryTree<int> { Root = new TreeNode<int>(5) };

        var result = MinDifferenceInBst.FindMinAbsoluteDifferenceInTwoBst(first, second);
        Assert.That(result, Is.Zero);
    }

    [Test]
    public void FindMinAbsoluteDifferenceInTwoBst_NullSecondTree_ReturnsZero()
    {
        var first = new BinaryTree<int> { Root = new TreeNode<int>(5) };
        BinaryTree<int>? second = null;

        var result = MinDifferenceInBst.FindMinAbsoluteDifferenceInTwoBst(first, second);
        Assert.That(result, Is.Zero);
    }

    [Test]
    public void FindMinAbsoluteDifferenceInTwoBst_SingleNodeTrees_ReturnsAbsDifference()
    {
        var first = new BinaryTree<int> { Root = new TreeNode<int>(5) };
        var second = new BinaryTree<int> { Root = new TreeNode<int>(9) };

        var result = MinDifferenceInBst.FindMinAbsoluteDifferenceInTwoBst(first, second);
        Assert.That(result, Is.EqualTo(4));
    }

    [Test]
    public void FindMinAbsoluteDifferenceInTwoBst_DuplicateValues_ReturnsZero()
    {
        var first = new BinaryTree<int> { Root = new TreeNode<int>(5) };
        var second = new BinaryTree<int> { Root = new TreeNode<int>(5) };

        var result = MinDifferenceInBst.FindMinAbsoluteDifferenceInTwoBst(first, second);
        Assert.That(result, Is.Zero);
    }

    [Test]
    public void FindMinAbsoluteDifferenceInTwoBst_SampleAndNearbyValue_ReturnsOne()
    {
        var first = CreateSampleTree();
        var second = new BinaryTree<int> { Root = new TreeNode<int>(6) }; // 6 is one away from 7 in sample tree

        var result = MinDifferenceInBst.FindMinAbsoluteDifferenceInTwoBst(first, second);
        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void FindMinAbsoluteDifferenceInTwoBst_NegativeValues_Works()
    {
        var first = new BinaryTree<int>
        {
            Root = new TreeNode<int>(-5)
            {
                LeftNode = new TreeNode<int>(-10)
            }
        };

        var second = new BinaryTree<int>
        {
            Root = new TreeNode<int>(-3)
            {
                RightNode = new TreeNode<int>(0)
            }
        };

        var result = MinDifferenceInBst.FindMinAbsoluteDifferenceInTwoBst(first, second);
        Assert.That(result, Is.EqualTo(2)); // -5 and -3 -> 2
    }

    [Test]
    public void FindNodesClosestToValueIterative_SpecificTree_ReturnsEightAndTen()
    {
        // Tree values: 10, 4, 15, 2, 8
        var tree = new BinaryTree<int>
        {
            Root = new TreeNode<int>(10)
            {
                LeftNode = new TreeNode<int>(4)
                {
                    LeftNode = new TreeNode<int>(2),
                    RightNode = new TreeNode<int>(8)
                },
                RightNode = new TreeNode<int>(15)
            }
        };

        var result = MinDifferenceInBst.FindNodesClosestToValueIterative(tree, 9);
        var values = result.Select(n => n.Value).OrderBy(x => x).ToList();

        // Nearest values to 9 are: 8 and 10
        Assert.That(values, Is.EqualTo(new List<int> { 8, 10 }));
    }

    [Test]
    public void FindNodesClosestToValue_SpecificTree_ReturnsEightAndTen()
    {
        // Tree values: 10, 4, 15, 2, 8
        var tree = new BinaryTree<int>
        {
            Root = new TreeNode<int>(10)
            {
                LeftNode = new TreeNode<int>(4)
                {
                    LeftNode = new TreeNode<int>(2),
                    RightNode = new TreeNode<int>(8)
                },
                RightNode = new TreeNode<int>(15)
            }
        };

        var result = MinDifferenceInBst.FindNodesClosestToValue(tree, 9);
        var values = result.Select(n => n.Value).OrderBy(x => x).ToList();

        // Nearest values to 9 are: 8 and 10
        Assert.That(values, Is.EqualTo(new List<int> { 8, 10 }));
    }

    [Test]
    public void FindNodesClosestToValueIterative_SingleNode_ReturnsThatNode()
    {
        var tree = new BinaryTree<int>
        {
            Root = new TreeNode<int>(5)
        };

        var result = MinDifferenceInBst.FindNodesClosestToValueIterative(tree, 7);
        var values = result.Select(n => n.Value).OrderBy(x => x).ToList();

        Assert.That(values, Is.EqualTo(new List<int> { 5 }));
    }

    [Test]
    public void FindNodesClosestToValue_SingleNode_ReturnsThatNode()
    {
        var tree = new BinaryTree<int>
        {
            Root = new TreeNode<int>(5)
        };

        var result = MinDifferenceInBst.FindNodesClosestToValue(tree, 7);
        var values = result.Select(n => n.Value).OrderBy(x => x).ToList();

        Assert.That(values, Is.EqualTo(new List<int> { 5 }));
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