namespace Coding.Challenges.Common;

// TreeNode class to represent a node in the tree
public class TreeNode<T>(T value)
{
    public T Value { get; set; } = value;
    public TreeNode<T>? LeftNode { get; set; }
    public TreeNode<T>? RightNode { get; set; }
}

// BinaryTree class to represent the entire binary tree
public class BinaryTree<T>
{
    public TreeNode<T>? Root { get; set; }
    public int Count { get; private set; }

    public BinaryTree()
    {
        Root = null;
    }

    // Method using standard level-order traversal to find the first vacant child position to insert the new value
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

    // Serializes the tree (or an arbitrary node) to a level-order list with default placeholders.
    public static List<T?> SerializeLevelOrder(TreeNode<T>? root)
    {
        var result = new List<T?>();
        if (root == null) return result;

        var queue = new Queue<TreeNode<T>?>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            if (node == null)
            {
                result.Add(default);
                continue;
            }

            // Add the node value as nullable (T?)
            result.Add((T?)node.Value);

            // Enqueue children (even if null) so structure is preserved
            queue.Enqueue(node.LeftNode);
            queue.Enqueue(node.RightNode);
        }

        // Trim trailing nulls for a canonical representation
        var defaultValue = default(T?);
        for (var i = result.Count - 1; i >= 0 && EqualityComparer<T?>.Default.Equals(result[i], defaultValue); i--)
            result.RemoveAt(i);

        return result;
    }

    // Convenience instance wrapper for serializing the current tree.
    public List<T?> SerializeLevelOrder()
    {
        return SerializeLevelOrder(Root);
    }
}