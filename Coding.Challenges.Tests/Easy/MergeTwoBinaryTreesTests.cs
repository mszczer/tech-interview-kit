using Coding.Challenges.Common;

namespace Coding.Challenges.Tests.Easy;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class MergeTwoBinaryTreesTests
{
    private static readonly List<int> ExpectedSerialized = GetExpectedSerialized();

    [Test]
    public void MergeResult_MatchesExpectedStructure_LevelOrder()
    {
        var merged = MergeTwoBinaryTrees.GetMergedTree(BuildFirstTree(), BuildSecondTree());
        var actual = BinaryTree<int>.SerializeLevelOrder(merged?.Root);
        Assert.That(actual, Is.EqualTo(ExpectedSerialized));
    }

    [Test]
    public void MergeIterativeResult_MatchesExpectedStructure_LevelOrder()
    {
        var mergedIterative = MergeTwoBinaryTrees.GetMergedTreeIterative(BuildFirstTree(), BuildSecondTree());
        var actual = BinaryTree<int>.SerializeLevelOrder(mergedIterative?.Root);
        Assert.That(actual, Is.EqualTo(ExpectedSerialized));
    }

    [Test]
    public void GetMergedTree_BothNull_ReturnsInstance()
    {
        var result = MergeTwoBinaryTrees.GetMergedTree(null, null);
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void GetMergedTree_BothNull_RootIsNull()
    {
        var result = MergeTwoBinaryTrees.GetMergedTree(null, null);
        Assert.That(result?.Root, Is.Null);
    }

    [Test]
    public void GetMergedTree_FirstNull_ReturnsSecondInstance()
    {
        var second = new BinaryTree<int> { Root = N(42) };
        var result = MergeTwoBinaryTrees.GetMergedTree(null, second);
        Assert.That(result, Is.SameAs(second));
    }

    [Test]
    public void GetMergedTree_SecondNull_ReturnsFirstInstance()
    {
        var first = new BinaryTree<int> { Root = N(17) };
        var result = MergeTwoBinaryTrees.GetMergedTree(first, null);
        Assert.That(result, Is.SameAs(first));
    }

    [Test]
    public void GetMergedTree_SingleNodeTrees_SumRoots()
    {
        var a = new BinaryTree<int> { Root = N(3) };
        var b = new BinaryTree<int> { Root = N(4) };
        var merged = MergeTwoBinaryTrees.GetMergedTree(a, b);
        var serialized = BinaryTree<int>.SerializeLevelOrder(merged?.Root);
        Assert.That(serialized, Is.EqualTo(new List<int> { 7 }));
    }

    [Test]
    public void GetMergedTreeIterative_FirstNull_ReturnsSecondInstance()
    {
        var second = new BinaryTree<int> { Root = N(9) };
        var result = MergeTwoBinaryTrees.GetMergedTreeIterative(null, second);
        Assert.That(result, Is.SameAs(second));
    }

    [Test]
    public void MergeBinarySearchTrees_BothNull_ReturnsInstance()
    {
        var result = MergeTwoBinaryTrees.MergeBinarySearchTrees(null, null);
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void MergeBinarySearchTrees_BothNull_RootIsNull()
    {
        var result = MergeTwoBinaryTrees.MergeBinarySearchTrees(null, null);
        Assert.That(result?.Root, Is.Null);
    }

    [Test]
    public void MergeBinarySearchTrees_FirstNull_ReturnsSecondInstance()
    {
        var second = BuildBstFromValues(new[] { 5 });
        var result = MergeTwoBinaryTrees.MergeBinarySearchTrees(null, second);
        Assert.That(result, Is.SameAs(second));
    }

    [Test]
    public void MergeBinarySearchTrees_SecondNull_ReturnsFirstInstance()
    {
        var first = BuildBstFromValues(new[] { 7 });
        var result = MergeTwoBinaryTrees.MergeBinarySearchTrees(first, null);
        Assert.That(result, Is.SameAs(first));
    }

    [Test]
    public void AreTwoBinaryTreesMirrors_ReturnsTrue()
    {
        var tree = BuildFirstTree();
        var mirrorTree = BuildMirrorTree();
        var result = MergeTwoBinaryTrees.AreTwoBinaryTreesMirrors(tree, mirrorTree);
        Assert.That(result, Is.True);
    }

    [Test]
    public void AreTwoBinaryTreesMirrors_ReturnsFalse_WhenNotMirrors()
    {
        var tree = BuildFirstTree();
        var notMirror = BuildNonMirrorTree();
        var result = MergeTwoBinaryTrees.AreTwoBinaryTreesMirrors(tree, notMirror);
        Assert.That(result, Is.False);
    }

    [Test]
    public void AreTwoBinaryTreesIdentical_ReturnsTrue()
    {
        var tree = BuildFirstTree();
        var identicalTree = BuildFirstTree();
        var result = MergeTwoBinaryTrees.AreTwoBinaryTreeIdentical(tree, identicalTree);
        Assert.That(result, Is.True);
    }

    [Test]
    public void AreTwoBinaryTreesIdentical_ReturnsFalse_WhenNotIdentical()
    {
        var tree = BuildFirstTree();
        var notIdenticalTree = BuildSecondTree();
        var result = MergeTwoBinaryTrees.AreTwoBinaryTreeIdentical(tree, notIdenticalTree);
        Assert.That(result, Is.False);
    }

    [Test]
    public void IsTreeBinarySearchTree_ReturnsTrue_ForValidBst()
    {
        var bst = BuildBstFromValues(new[] { 6, 2, 8, 1 });
        var result = MergeTwoBinaryTrees.IsTreeBinarySearchTree(bst);
        Assert.That(result, Is.True);
    }

    [Test]
    public void IsTreeBinarySearchTree_ReturnsFalse_ForNonBst()
    {
        var nonBst = BuildFirstTree(); // intentionally not a BST
        var result = MergeTwoBinaryTrees.IsTreeBinarySearchTree(nonBst);
        Assert.That(result, Is.False);
    }

    [Test]
    public void CountBinarySearchTreesInTree_Null_ReturnsZero()
    {
        Assert.That(MergeTwoBinaryTrees.CountBinarySearchTreesInTree(null), Is.EqualTo(0));
    }

    [Test]
    public void CountBinarySearchTreesInTree_Empty_ReturnsZero()
    {
        var empty = new BinaryTree<int>();
        Assert.That(MergeTwoBinaryTrees.CountBinarySearchTreesInTree(empty), Is.EqualTo(0));
    }

    [Test]
    public void CountBinarySearchTreesInTree_SingleNode_ReturnsOne()
    {
        var single = new BinaryTree<int> { Root = N(42) };
        Assert.That(MergeTwoBinaryTrees.CountBinarySearchTreesInTree(single), Is.EqualTo(1));
    }

    [Test]
    public void CountBinarySearchTreesInTree_ValidBst_AllSubtreesCounted()
    {
        // BST built as: Insert 6,2,8,1 -> every subtree rooted at any node is a BST => count == nodes (4)
        var bst = BuildBstFromValues(new[] { 6, 2, 8, 1 });
        Assert.That(MergeTwoBinaryTrees.CountBinarySearchTreesInTree(bst), Is.EqualTo(4));
    }

    [Test]
    public void CountBinarySearchTreesInTree_NonBst_PartialSubtreesCounted()
    {
        // BuildFirstTree is not a BST as a whole, but has BST subtrees at nodes 6 (with 5), 5 and 2 => count 3
        var nonBst = BuildFirstTree();
        Assert.That(MergeTwoBinaryTrees.CountBinarySearchTreesInTree(nonBst), Is.EqualTo(3));
    }

    [Test]
    public void CountBinarySearchTreesInTree_SecondTree_PartialRootInvalid()
    {
        // BuildSecondTree has a non-BST root but all child-rooted subtrees are BST => count 4 (out of 5 nodes)
        var t = BuildSecondTree();
        Assert.That(MergeTwoBinaryTrees.CountBinarySearchTreesInTree(t), Is.EqualTo(4));
    }

    // FlipBinaryTree tests
    [Test]
    public void FlipBinaryTree_Null_ReturnsNull()
    {
        var result = MergeTwoBinaryTrees.FlipBinaryTree(null);
        Assert.That(result, Is.Null);
    }

    [Test]
    public void FlipBinaryTree_Empty_ReturnsSameInstance()
    {
        var empty = new BinaryTree<int>();
        var result = MergeTwoBinaryTrees.FlipBinaryTree(empty);
        Assert.That(result, Is.SameAs(empty));
    }

    [Test]
    public void FlipBinaryTree_BuildFirst_MatchesMirrorTree()
    {
        var tree = BuildFirstTree();
        var flipped = MergeTwoBinaryTrees.FlipBinaryTree(tree);
        var expected = BuildMirrorTree();
        Assert.That(MergeTwoBinaryTrees.AreTwoBinaryTreeIdentical(flipped, expected), Is.True);
    }

    // Helper to create nodes more concisely and make tree construction easier to read.
    private static TreeNode<int> N(int value, TreeNode<int>? left = null, TreeNode<int>? right = null)
    {
        var node = new TreeNode<int>(value)
        {
            LeftNode = left,
            RightNode = right
        };
        return node;
    }

    private static BinaryTree<int> BuildFirstTree()
    {
        // Structure:
        //       1
        //      / \
        //     6   2
        //    /
        //   5
        return new BinaryTree<int> { Root = N(1, N(6, N(5)), N(2)) };
    }

    private static BinaryTree<int> BuildSecondTree()
    {
        // Structure:
        //       2
        //      / \
        //     1   3
        //      \   \
        //       4   7
        return new BinaryTree<int>
        {
            Root = N(2,
                N(1, null, N(4)),
                N(3, null, N(7)))
        };
    }

    private static BinaryTree<int> BuildMirrorTree()
    {
        // Mirror of BuildFirstTree:
        //       1
        //      / \
        //     2   6
        //          \
        //           5
        return new BinaryTree<int> { Root = N(1, N(2), N(6, null, N(5))) };
    }

    private static BinaryTree<int> BuildNonMirrorTree()
    {
        var t = BuildMirrorTree();
        t.Root.LeftNode.Value = 999;
        return t;
    }

    private static List<int> GetExpectedSerialized()
    {
        // Expected merged structure:
        //       3
        //      / \
        //     7   5
        //    / \   \
        //   5   4   7
        var expectedTree = new BinaryTree<int>
        {
            Root = N(3,
                N(7, N(5), N(4)),
                N(5, null, N(7)))
        };

        return expectedTree.SerializeLevelOrder();
    }

    private static BinaryTree<int> BuildBstFromValues(IEnumerable<int> values)
    {
        var bst = new BinaryTree<int>();
        foreach (var v in values) bst.InsertBinarySearchAllowDuplicates(v);

        return bst;
    }
}