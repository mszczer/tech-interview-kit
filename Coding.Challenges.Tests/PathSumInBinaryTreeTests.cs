using Coding.Challenges.Common;

namespace Coding.Challenges.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class PathSumInBinaryTreeTests
{
    [TestCase(22, true)]
    [TestCase(100, false)]
    public void IsTargetSumInAnyPath_VariousSums_ReturnsExpected(int sum, bool expected)
    {
        var tree = BuildSampleTree();
        var result = PathSumInBinaryTree.IsTargetSumInAnyPath(tree, sum);

        Assert.That(result, Is.EqualTo(expected));
    }

    private static BinaryTree<int> BuildSampleTree()
    {
        var tree = new BinaryTree<int>
        {
            Root = new TreeNode<int>(6)
            {
                LeftNode = new TreeNode<int>(4)
                {
                    LeftNode = new TreeNode<int>(10)
                    {
                        LeftNode = new TreeNode<int>(8),
                        RightNode = new TreeNode<int>(2)
                    }
                },
                RightNode = new TreeNode<int>(8)
                {
                    LeftNode = new TreeNode<int>(14),
                    RightNode = new TreeNode<int>(3)
                    {
                        RightNode = new TreeNode<int>(1)
                    }
                }
            }
        };

        return tree;
    }
}