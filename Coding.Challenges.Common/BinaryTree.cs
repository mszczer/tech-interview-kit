namespace Coding.Challenges.Common;

// TreeNode class to represent a node in the tree
/// <summary>
///     Represents a node in a binary tree holding a value of type <typeparamref name="T" />.
/// </summary>
/// <typeparam name="T">The type of the value stored in the node.</typeparam>
public class TreeNode<T>(T value)
{
    /// <summary>
    ///     The value stored in this node.
    /// </summary>
    public T Value { get; set; } = value;

    /// <summary>
    ///     Reference to the left child node, or <c>null</c> when none exists.
    /// </summary>
    public TreeNode<T>? LeftNode { get; set; }

    /// <summary>
    ///     Reference to the right child node, or <c>null</c> when none exists.
    /// </summary>
    public TreeNode<T>? RightNode { get; set; }
}

// BinaryTree class to represent the entire binary tree
/// <summary>
///     Represents a binary tree structure with convenience insertion and serialization helpers.
/// </summary>
/// <typeparam name="T">The type of values stored in the tree.</typeparam>
public class BinaryTree<T>
{
    /// <summary>
    ///     The root node of the tree, or <c>null</c> when the tree is empty.
    /// </summary>
    public TreeNode<T>? Root { get; set; }

    /// <summary>
    ///     The number of nodes currently contained in the tree.
    /// </summary>
    public int Count { get; private set; }

    /// <summary>
    ///     Initializes a new instance of the <see cref="BinaryTree{T}" /> class.
    /// </summary>
    public BinaryTree()
    {
        Root = null;
    }

    /// <summary>
    ///     Inserts a value into the tree using a standard level-order traversal.
    ///     The value is placed in the first vacant child position encountered (fills tree left-to-right by level).
    /// </summary>
    /// <param name="value">The value to insert.</param>
    public void Insert(T value)
    {
        if (Root == null)
        {
            Root = new TreeNode<T>(value);
            Count = 1;
            return;
        }

        var queue = new Queue<TreeNode<T>>();
        queue.Enqueue(Root);

        while (queue.Count > 0)
        {
            var currentNode = queue.Dequeue();

            if (currentNode.LeftNode == null)
            {
                currentNode.LeftNode = new TreeNode<T>(value);
                Count++;
                return;
            }

            queue.Enqueue(currentNode.LeftNode);

            if (currentNode.RightNode == null)
            {
                currentNode.RightNode = new TreeNode<T>(value);
                Count++;
                return;
            }

            queue.Enqueue(currentNode.RightNode);
        }
    }

    /// <summary>
    ///     Attempts to insert a child node with the specified <paramref name="childValue" /> for the first node
    ///     whose value equals <paramref name="parentValue" /> using level-order traversal to search for the parent.
    /// </summary>
    /// <param name="parentValue">The value identifying the parent node to attach the child to.</param>
    /// <param name="childValue">The value to insert as the child.</param>
    /// <param name="insertRight">
    ///     When <c>true</c>, attempt to insert as the right child; when <c>false</c>, attempt to insert as the left child.
    /// </param>
    /// <returns>
    ///     <c>true</c> if the child was inserted; <c>false</c> if the parent was not found or the requested child position was
    ///     already occupied.
    /// </returns>
    public bool InsertChild(T parentValue, T childValue, bool insertRight)
    {
        if (Root == null)
            return false;

        var queue = new Queue<TreeNode<T>>();
        queue.Enqueue(Root);

        while (queue.Count > 0)
        {
            var currentNode = queue.Dequeue();
            if (EqualityComparer<T>.Default.Equals(currentNode.Value, parentValue))
            {
                if (insertRight)
                {
                    if (currentNode.RightNode == null)
                    {
                        currentNode.RightNode = new TreeNode<T>(childValue);
                        Count++;
                        return true;
                    }
                }
                else
                {
                    if (currentNode.LeftNode == null)
                    {
                        currentNode.LeftNode = new TreeNode<T>(childValue);
                        Count++;
                        return true;
                    }
                }

                // Child already exists
                return false;
            }

            if (currentNode.LeftNode != null)
                queue.Enqueue(currentNode.LeftNode);
            if (currentNode.RightNode != null)
                queue.Enqueue(currentNode.RightNode);
        }

        // Parent not found
        return false;
    }

    /// <summary>
    ///     Inserts a value into the tree using binary-search-tree ordering.
    ///     Duplicates are placed in the left subtree.
    /// </summary>
    /// <param name="value">The value to insert.</param>
    /// <param name="comparer">
    ///     Optional comparer used to order values. When <c>null</c>, <see cref="Comparer{T}.Default" /> is used.
    /// </param>
    /// <returns><c>true</c> when the value was inserted; otherwise <c>false</c>.</returns>
    public bool InsertBinarySearchAllowDuplicates(T value, IComparer<T>? comparer = null)
    {
        comparer ??= Comparer<T>.Default;

        if (Root == null)
        {
            Root = new TreeNode<T>(value);
            Count = 1;
            return true;
        }

        var current = Root;
        while (true)
        {
            var cmp = comparer.Compare(value, current.Value);

            if (cmp <= 0)
            {
                // For cmp == 0 (duplicate) and cmp < 0, place in left subtree
                if (current.LeftNode == null)
                {
                    current.LeftNode = new TreeNode<T>(value);
                    Count++;
                    return true;
                }

                current = current.LeftNode;
            }
            else
            {
                if (current.RightNode == null)
                {
                    current.RightNode = new TreeNode<T>(value);
                    Count++;
                    return true;
                }

                current = current.RightNode;
            }
        }
    }

    /// <summary>
    ///     Serializes the tree using an in-order traversal.
    ///     Missing children are represented by <c>default(T?)</c> to preserve structure during serialization.
    /// </summary>
    /// <returns>
    ///     A list of nullable values representing the tree in an in-order sequence with placeholders for missing nodes.
    ///     When the tree root is <c>null</c> an empty list is returned.
    /// </returns>
    public List<T?> SerializeInOrderTraversal()
    {
        return SerializeInOrderTraversal(Root);
    }

    /// <summary>
    ///     Serializes the subtree rooted at <paramref name="node" /> using an in-order traversal (Left subtree &gt; Root &gt;
    ///     Right subtree).
    ///     This static overload returns node values only (no placeholders). For a null node an empty list is returned.
    /// </summary>
    /// <param name="node">The subtree root to serialize.</param>
    /// <returns>
    ///     A list of nullable values for the subtree where only existing node values are included.
    /// </returns>
    public static List<T?> SerializeInOrderTraversal(TreeNode<T>? node)
    {
        var serializedTree = new List<T?>();
        if (node == null) return serializedTree;

        serializedTree.AddRange(SerializeInOrderTraversal(node.LeftNode));
        serializedTree.Add((T?)node.Value);
        serializedTree.AddRange(SerializeInOrderTraversal(node.RightNode));

        return serializedTree;
    }

    /// <summary>
    ///     Serializes the current tree instance using a pre-order traversal.
    ///     The sequence follows Root &gt; Left subtree &gt; Right subtree.
    /// </summary>
    /// <returns>
    ///     A list of nullable values representing this tree in pre-order. If the tree is empty, an empty list is returned.
    /// </returns>
    public List<T?> SerializePreOrderTraversal()
    {
        return SerializePreOrderTraversal(Root);
    }

    /// <summary>
    ///     Serializes the subtree rooted at <paramref name="node" /> using a pre-order traversal (Root &gt; Left &gt; Right).
    ///     This static overload returns node values only (no placeholders). For a null node an empty list is returned.
    /// </summary>
    /// <param name="node">The subtree root to serialize.</param>
    /// <returns>
    ///     A list of nullable values for the subtree where only existing node values are included.
    /// </returns>
    private static List<T?> SerializePreOrderTraversal(TreeNode<T>? node)
    {
        var serializedTree = new List<T?>();
        if (node == null) return serializedTree;

        serializedTree.Add((T?)node.Value);
        serializedTree.AddRange(SerializePreOrderTraversal(node.LeftNode));
        serializedTree.AddRange(SerializePreOrderTraversal(node.RightNode));

        return serializedTree;
    }

    /// <summary>
    ///     Serializes the current tree instance using a post-order traversal.
    ///     The sequence follows Left subtree &gt; Right subtree &gt; Root.
    /// </summary>
    /// <returns>
    ///     A list of nullable values representing this tree in post-order. If the tree is empty, an empty list is returned.
    /// </returns>
    public List<T?> SerializePostOrderTraversal()
    {
        return SerializePostOrderTraversal(Root);
    }

    /// <summary>
    ///     Serializes the subtree rooted at <paramref name="node" /> using a post-order traversal (Left &gt; Right &gt; Root).
    ///     This static overload returns node values only (no placeholders). For a null node an empty list is returned.
    /// </summary>
    /// <param name="node">The subtree root to serialize.</param>
    /// <returns>
    ///     A list of nullable values for the subtree where only existing node values are included.
    /// </returns>
    private static List<T?> SerializePostOrderTraversal(TreeNode<T>? node)
    {
        var serializedTree = new List<T?>();
        if (node == null) return serializedTree;

        serializedTree.AddRange(SerializePostOrderTraversal(node.LeftNode));
        serializedTree.AddRange(SerializePostOrderTraversal(node.RightNode));
        serializedTree.Add((T?)node.Value);

        return serializedTree;
    }

    /// <summary>
    ///     Serializes the current tree instance using a level-order traversal (breadth-first).
    /// </summary>
    /// <returns>
    ///     A list of nullable values representing this tree in level-order. If the tree is empty, an empty list is returned.
    /// </returns>
    /// <remarks>
    ///     Missing children are represented by <c>default(T?)</c> placeholders to preserve tree structure during traversal.
    ///     Trailing placeholder values are trimmed to produce a canonical representation.
    /// </remarks>
    public List<T?> SerializeLevelOrderTraversal()
    {
        return SerializeLevelOrderTraversal(Root);
    }

    /// <summary>
    ///     Serializes the subtree rooted at <paramref name="node" /> using a level-order traversal (breadth-first).
    ///     Missing children are represented by <c>default(T?)</c> placeholders in the returned list.
    /// </summary>
    /// <param name="node">The subtree root to serialize, or <c>null</c> to indicate an empty subtree.</param>
    /// <returns>
    ///     A list of nullable values for the subtree where missing children are represented by <c>default(T?)</c>
    ///     placeholders.
    ///     Trailing placeholder values are removed from the returned list.
    /// </returns>
    /// <remarks>
    ///     The method enqueues <c>null</c> placeholders while traversing to preserve the exact tree shape, then trims trailing
    ///     <c>default(T?)</c> values for a canonical output suitable for comparisons and tests.
    /// </remarks>
    private static List<T?> SerializeLevelOrderTraversal(TreeNode<T>? node)
    {
        var serializedTree = new List<T?>();
        if (node == null) return serializedTree;

        var queue = new Queue<TreeNode<T>?>();

        queue.Enqueue(node);

        while (queue.Count > 0)
        {
            var currentNode = queue.Dequeue();
            if (currentNode == null)
            {
                serializedTree.Add(default);
                continue;
            }

            serializedTree.Add((T?)currentNode.Value);
            queue.Enqueue(currentNode.LeftNode);
            queue.Enqueue(currentNode.RightNode);
        }

        // Trim trailing nulls for a canonical representation
        var defaultValue = default(T?);
        for (var i = serializedTree.Count - 1;
             i >= 0 && EqualityComparer<T?>.Default.Equals(serializedTree[i], defaultValue);
             i--)
            serializedTree.RemoveAt(i);

        return serializedTree;
    }

    /// <summary>
    ///     Returns the depth of the tree measured in edges (distance from root to the deepest leaf).
    ///     For an empty tree this returns 0. A single-node tree returns 0.
    /// </summary>
    /// <returns>Depth measured in edges.</returns>
    public int GetDepth()
    {
        return Root == null ? 0 : GetDepthInternal(Root);
    }

    private static int GetDepthInternal(TreeNode<T>? node)
    {
        if (node == null) return -1;
        return Math.Max(GetDepthInternal(node.LeftNode), GetDepthInternal(node.RightNode)) + 1;
    }

    /// <summary>
    ///     Determines whether the current tree is height-balanced.
    ///     Uses a simple recursive implementation: at each node compare subtree heights and recurse.
    ///     An empty tree is considered balanced.
    /// </summary>
    /// <returns><c>true</c> when the tree is height-balanced; otherwise <c>false</c>.</returns>
    public bool IsTreeHeightBalanced()
    {
        return CheckBalanced(Root);
    }

    private static bool CheckBalanced(TreeNode<T>? node)
    {
        if (node == null) return true;

        var leftHeight = GetDepthInternal(node.LeftNode);
        var rightHeight = GetDepthInternal(node.RightNode);

        if (Math.Abs(leftHeight - rightHeight) > 1) return false;

        return CheckBalanced(node.LeftNode) && CheckBalanced(node.RightNode);
    }
}

