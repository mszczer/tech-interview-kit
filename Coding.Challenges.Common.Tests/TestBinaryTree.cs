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
}