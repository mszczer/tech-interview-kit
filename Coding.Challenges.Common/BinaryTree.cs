namespace Coding.Challenges.Common;

// TreeNode class to represent a node in the tree
public class TreeNode<T>
{
    public T Value { get; set; }
    public TreeNode<T>? LeftNode { get; set; }
    public TreeNode<T>? RightNode { get; set; }

    public TreeNode(T value)
    {
        Value = value;
        LeftNode = null;
        RightNode = null;
    }
}

// BinaryTree class to represent the entire binary tree
public class BinaryTree<T>
{
    public TreeNode<T>? Root { get; private set; }
    private int _count;
    public int Count => _count;

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
            _count = 1;
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
                _count++;
                return;
            }
            else 
                queue.Enqueue(currentNode.LeftNode);

            if (currentNode.RightNode == null)
            {
                currentNode.RightNode = new TreeNode<T>(value);
                _count++;
                return;
            }
            else 
                queue.Enqueue(currentNode.RightNode);
        }
    }
}