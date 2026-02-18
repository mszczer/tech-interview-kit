using System.Collections.Generic;
using Coding.Challenges.Common;
using NUnit.Framework;

namespace Coding.Challenges.Common.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class TestBinaryTree
{
    private static BinaryTree<int> CreateTree(params int[] values)
    {
        var tree = new BinaryTree<int>();
        foreach (var v in values)
        {
            tree.Insert(v);
        }

        return tree;
    }

    private static BinaryTree<int> CreatePerfectTree()
    {
        var tree = CreateTree(1);
        tree.InsertChild(1, 2, insertRight: false);
        tree.InsertChild(1, 3, insertRight: true);
        tree.InsertChild(2, 4, insertRight: false);
        tree.InsertChild(2, 5, insertRight: true);
        tree.InsertChild(3, 6, insertRight: false);
        tree.InsertChild(3, 7, insertRight: true);
        return tree;
    }

    // Helper to create a tree by manually wiring nodes.
    // Usage: CreateTreeFromStructure(rootValue, (parent, value, insertRight), ...)
    private static BinaryTree<int> CreateTreeFromStructure(int rootValue, params (int parent, int value, bool insertRight)[] edges)
    {
        var tree = new BinaryTree<int>();
        tree.Root = new TreeNode<int>(rootValue);
        var nodes = new Dictionary<int, TreeNode<int>> { [rootValue] = tree.Root };

        foreach (var edge in edges)
        {
            if (!nodes.TryGetValue(edge.parent, out var parentNode))
            {
                // parent not yet created - create and add (this supports out-of-order edges if needed)
                parentNode = new TreeNode<int>(edge.parent);
                nodes[edge.parent] = parentNode;
            }

            var childNode = new TreeNode<int>(edge.value);
            if (edge.insertRight)
            {
                parentNode.RightNode = childNode;
            }
            else
            {
                parentNode.LeftNode = childNode;
            }

            nodes[edge.value] = childNode;
        }

        return tree;
    }

    [Test]
    public void Insert_ShouldSetRoot_WhenTreeIsEmpty_RootIsNotNull()
    {
        var tree = CreateTree(10);
        Assert.That(tree.Root, Is.Not.Null);
    }

    [Test]
    public void Insert_ShouldSetRoot_WhenTreeIsEmpty_RootValueIsCorrect()
    {
        var tree = CreateTree(10);
        Assert.That(tree.Root!.Value, Is.EqualTo(10));
    }

    [Test]
    public void Insert_ShouldSetRoot_WhenTreeIsEmpty_CountIsOne()
    {
        var tree = CreateTree(10);
        Assert.That(tree.Count, Is.EqualTo(1));
    }

    [Test]
    public void Insert_ShouldAddNodes_LevelOrder_CountIsThree()
    {
        var tree = CreateTree(1, 2, 3);
        Assert.That(tree.Count, Is.EqualTo(3));
    }

    [Test]
    public void Insert_ShouldAddNodes_LevelOrder_RootIsNotNull()
    {
        var tree = CreateTree(1, 2, 3);
        Assert.That(tree.Root, Is.Not.Null);
    }

    [Test]
    public void Insert_ShouldAddNodes_LevelOrder_RootValueIsCorrect()
    {
        var tree = CreateTree(1, 2, 3);
        Assert.That(tree.Root!.Value, Is.EqualTo(1));
    }

    [Test]
    public void Insert_ShouldAddNodes_LevelOrder_LeftNodeIsNotNull()
    {
        var tree = CreateTree(1, 2, 3);
        Assert.That(tree.Root!.LeftNode, Is.Not.Null);
    }

    [Test]
    public void Insert_ShouldAddNodes_LevelOrder_LeftNodeValueIsCorrect()
    {
        var tree = CreateTree(1, 2, 3);
        Assert.That(tree.Root?.LeftNode?.Value, Is.EqualTo(2));
    }

    [Test]
    public void Insert_ShouldAddNodes_LevelOrder_RightNodeIsNotNull()
    {
        var tree = CreateTree(1, 2, 3);
        Assert.That(tree.Root?.RightNode, Is.Not.Null);
    }

    [Test]
    public void Insert_ShouldAddNodes_LevelOrder_RightNodeValueIsCorrect()
    {
        var tree = CreateTree(1, 2, 3);
        Assert.That(tree.Root?.RightNode?.Value, Is.EqualTo(3));
    }

    [Test]
    public void InsertChild_ShouldInsertLeftChild_WhenLeftIsNull_ResultIsTrue()
    {
        var tree = CreateTree(1);
        var result = tree.InsertChild(1, 2, insertRight: false);
        Assert.That(result, Is.True);
    }

    [Test]
    public void InsertChild_ShouldInsertLeftChild_WhenLeftIsNull_LeftNodeIsNotNull()
    {
        var tree = CreateTree(1);
        tree.InsertChild(1, 2, insertRight: false);
        Assert.That(tree.Root!.LeftNode, Is.Not.Null);
    }

    [Test]
    public void InsertChild_ShouldInsertLeftChild_WhenLeftIsNull_LeftNodeValueIsCorrect()
    {
        var tree = CreateTree(1);
        tree.InsertChild(1, 2, insertRight: false);
        Assert.That(tree.Root?.LeftNode?.Value, Is.EqualTo(2));
    }

    [Test]
    public void InsertChild_ShouldInsertLeftChild_WhenLeftIsNull_CountIsTwo()
    {
        var tree = CreateTree(1);
        tree.InsertChild(1, 2, insertRight: false);
        Assert.That(tree.Count, Is.EqualTo(2));
    }

    [Test]
    public void InsertChild_ShouldInsertRightChild_WhenRightIsNull_ResultIsTrue()
    {
        var tree = CreateTree(1);
        var result = tree.InsertChild(1, 3, insertRight: true);
        Assert.That(result, Is.True);
    }

    [Test]
    public void InsertChild_ShouldInsertRightChild_WhenRightIsNull_RightNodeIsNotNull()
    {
        var tree = CreateTree(1);
        tree.InsertChild(1, 3, insertRight: true);
        Assert.That(tree.Root!.RightNode, Is.Not.Null);
    }

    [Test]
    public void InsertChild_ShouldInsertRightChild_WhenRightIsNull_RightNodeValueIsCorrect()
    {
        var tree = CreateTree(1);
        tree.InsertChild(1, 3, insertRight: true);
        Assert.That(tree.Root?.RightNode?.Value, Is.EqualTo(3));
    }

    [Test]
    public void InsertChild_ShouldInsertRightChild_WhenRightIsNull_CountIsTwo()
    {
        var tree = CreateTree(1);
        tree.InsertChild(1, 3, insertRight: true);
        Assert.That(tree.Count, Is.EqualTo(2));
    }

    [Test]
    public void InsertChild_ShouldReturnFalse_WhenParentNotFound_ResultIsFalse()
    {
        var tree = CreateTree(1);
        var result = tree.InsertChild(99, 2, insertRight: false);
        Assert.That(result, Is.False);
    }

    [Test]
    public void InsertChild_ShouldReturnFalse_WhenParentNotFound_CountIsOne()
    {
        var tree = CreateTree(1);
        tree.InsertChild(99, 2, insertRight: false);
        Assert.That(tree.Count, Is.EqualTo(1));
    }

    [Test]
    public void InsertChild_ShouldReturnFalse_WhenChildAlreadyExists_ResultIsFalse()
    {
        var tree = CreateTree(1);
        tree.InsertChild(1, 2, insertRight: false);
        var result = tree.InsertChild(1, 3, insertRight: false);
        Assert.That(result, Is.False);
    }

    [Test]
    public void InsertChild_ShouldReturnFalse_WhenChildAlreadyExists_CountIsTwo()
    {
        var tree = CreateTree(1);
        tree.InsertChild(1, 2, insertRight: false);
        tree.InsertChild(1, 3, insertRight: false);
        Assert.That(tree.Count, Is.EqualTo(2));
    }

    [Test]
    public void InsertChild_ShouldReturnFalse_WhenChildAlreadyExists_LeftNodeValueIsCorrect()
    {
        var tree = CreateTree(1);
        tree.InsertChild(1, 2, insertRight: false);
        tree.InsertChild(1, 3, insertRight: false);
        Assert.That(tree.Root!.LeftNode!.Value, Is.EqualTo(2));
    }

    [Test]
    public void InsertChild_ShouldReturnFalse_WhenTreeIsEmpty_ResultIsFalse()
    {
        var tree = new BinaryTree<int>();
        var result = tree.InsertChild(1, 2, insertRight: false);
        Assert.That(result, Is.False);
    }

    [Test]
    public void InsertChild_ShouldReturnFalse_WhenTreeIsEmpty_CountIsZero()
    {
        var tree = new BinaryTree<int>();
        tree.InsertChild(1, 2, insertRight: false);
        Assert.That(tree.Count, Is.Zero);
    }

    [Test]
    public void InsertChild_ShouldReturnFalse_WhenTreeIsEmpty_RootIsNull()
    {
        var tree = new BinaryTree<int>();
        tree.InsertChild(1, 2, insertRight: false);
        Assert.That(tree.Root, Is.Null);
    }

    [Test]
    public void SerializeInOrderTraversal_ShouldReturnInOrderSequence_ForPerfectBinaryTree()
    {
        var tree = CreatePerfectTree();
        var result = tree.SerializeInOrderTraversal();
        var expected = new List<int?> { 4, 2, 5, 1, 6, 3, 7 };
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void SerializePreOrderTraversal_ShouldReturnInOrderSequence_ForPerfectBinaryTree()
    {
        var tree = CreatePerfectTree();
        var result = tree.SerializePreOrderTraversal();
        var expected = new List<int?> { 1, 2, 4, 5, 3, 6, 7 };
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void SerializePostOrderTraversal_ShouldReturnInOrderSequence_ForPerfectBinaryTree()
    {
        var tree = CreatePerfectTree();
        var result = tree.SerializePostOrderTraversal();
        var expected = new List<int?> { 4, 5, 2, 6, 7, 3, 1 };
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void SerializeLevelOrderTraversal_ShouldReturnInOrderSequence_ForPerfectBinaryTree()
    {
        var tree = CreatePerfectTree();
        var result = tree.SerializeLevelOrderTraversal();
        var expected = new List<int?> { 1, 2, 3, 4, 5, 6, 7 };
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void IsTreeHeightBalanced_ShouldReturnTrue_ForEmptyTree()
    {
        var tree = new BinaryTree<int>();
        Assert.That(tree.IsTreeHeightBalanced(), Is.True);
    }

    [Test]
    public void IsTreeHeightBalanced_ShouldReturnTrue_ForSingleNode()
    {
        var tree = CreateTree(1);
        Assert.That(tree.IsTreeHeightBalanced(), Is.True);
    }

    [Test]
    public void IsTreeHeightBalanced_ShouldReturnTrue_ForPerfectTree()
    {
        var tree = CreatePerfectTree();
        Assert.That(tree.IsTreeHeightBalanced(), Is.True);
    }

    [Test]
    public void IsTreeHeightBalanced_ShouldReturnFalse_ForLeftHeavyChain()
    {
        // Chain of left children: 1 -> 2 -> 3 -> 4 (unbalanced)
        var tree = CreateTreeFromStructure(1, (1, 2, false), (2, 3, false), (3, 4, false));
        Assert.That(tree.IsTreeHeightBalanced(), Is.False);
    }

    [Test]
    public void IsTreeHeightBalanced_ShouldReturnFalse_ForUnbalancedSubtree()
    {
        // Left subtree is deeper by more than 1 due to a deep chain under left child
        // Structure:
        //      1
        //     / \
        //    2   3
        //   /
        //  4
        // /
        //5   => node 1 left height 3, right height 0 -> unbalanced
        var tree = CreateTreeFromStructure(1, (1, 2, false), (1, 3, true), (2, 4, false), (4, 5, false));
        Assert.That(tree.IsTreeHeightBalanced(), Is.False);
    }

    [Test]
    public void IsTreeHeightBalanced_ShouldReturnTrue_ForDifferentShapes_Balanced()
    {
        // Different shapes but balanced:
        //    1
        //   / \
        //  2   3
        // /     \
        //4       5
        var tree = CreateTreeFromStructure(1, (1, 2, false), (1, 3, true), (2, 4, false), (3, 5, true));
        Assert.That(tree.IsTreeHeightBalanced(), Is.True);
    }

    private static IEnumerable<TestCaseData> GetDepthCases()
    {
        yield return new TestCaseData(
            CreateTreeFromStructure(
                12,
                (12, 8, false),
                (12, 18, true),
                (8, 5, false),
                (8, 11, true)
            ),
            2
        ).SetName("GetDepth_ShouldReturnTwo_ForGivenTree_Case1");

        yield return new TestCaseData(
            CreateTreeFromStructure(
                1,
                (1, 2, false),
                (1, 3, true),
                (2, 4, false),
                (3, 5, true),
                (5, 6, false),
                (5, 7, true)
            ),
            3
        ).SetName("GetDepth_ShouldReturnThree_ForGivenTree_Case2");
    }

    [Test]
    [TestCaseSource(nameof(GetDepthCases))]
    public void GetDepth_ShouldReturnExpected_ForGivenTree(BinaryTree<int> tree, int expected)
    {
        Assert.That(tree.GetDepth(), Is.EqualTo(expected));
    }
}