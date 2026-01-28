using Coding.Challenges.Common;

namespace Coding.Challenges.Tests.Easy;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class TestPathSumInBinaryTree
{
    [TestCase(22, true)]
    [TestCase(100, false)]
    public void IsTargetSumInAnyPath_VariousSums_ReturnsExpected(int sum, bool expected)
    {
        var tree = BuildSampleTree();
        var result = Challenges.Easy.PathSumInBinaryTree.IsTargetSumInAnyPath(tree, sum);

        Assert.That(result, Is.EqualTo(expected));
    }

    private static TestBinaryTree<int> BuildSampleTree()
    {
        var tree = new TestBinaryTree<int>
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