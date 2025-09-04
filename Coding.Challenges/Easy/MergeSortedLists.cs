namespace Coding.Challenges.Easy;

/*
 * Difficulty: Easy
 * Problem:
 *  Given two sorted lists having head as head1 and head2 merge them into one big sorted list
 *      The two linked lists can be of different sizes
 *      It is possible that one of the lists is empty
 *      The new list must be created by splicing together the nodes of the first two lists.
 * Note:
 *      LinkedLst node properties Next and Previous are ReadOnly in .net.
 */
public static class MergeSortedLists
{
    // Efficient O(n) merge, always returns a new list
    public static LinkedList<int>? MergeSortedListsAndSort(LinkedList<int>? list1, LinkedList<int>? list2)
    {
        if (list1 == null) return list2 == null ? null : new LinkedList<int>(list2);
        if (list2 == null) return new LinkedList<int>(list1);

        var merged = new LinkedList<int>();
        var node1 = list1.First;
        var node2 = list2.First;

        while (node1 != null && node2 != null)
        {
            if (node1.Value <= node2.Value)
            {
                merged.AddLast(node1.Value);
                node1 = node1.Next;
            }
            else
            {
                merged.AddLast(node2.Value);
                node2 = node2.Next;
            }
        }

        while (node1 != null)
        {
            merged.AddLast(node1.Value);
            node1 = node1.Next;
        }

        while (node2 != null)
        {
            merged.AddLast(node2.Value);
            node2 = node2.Next;
        }

        return merged;
    }

    // Two-pointer approach, returns a new list
    public static LinkedList<int>? MergeSortedListsUsingTwoPointers(LinkedList<int>? list1, LinkedList<int>? list2)
    {
        return MergeSortedListsAndSort(list1, list2);
    }

    // Recursive approach, returns a new list
    public static LinkedList<int>? MergeSortedListUsingRecursion(LinkedList<int>? list1, LinkedList<int>? list2)
    {
        var merged = new LinkedList<int>();
        MergeRecursive(list1?.First, list2?.First, merged);
        return merged;
    }

    private static void MergeRecursive(LinkedListNode<int>? node1, LinkedListNode<int>? node2, LinkedList<int> merged)
    {
        if (node1 == null)
        {
            while (node2 != null)
            {
                merged.AddLast(node2.Value);
                node2 = node2.Next;
            }
            return;
        }

        if (node2 == null)
        {
            while (node1 != null)
            {
                merged.AddLast(node1.Value);
                node1 = node1.Next;
            }
            return;
        }

        if (node1.Value <= node2.Value)
        {
            merged.AddLast(node1.Value);
            MergeRecursive(node1.Next, node2, merged);
        }
        else
        {
            merged.AddLast(node2.Value);
            MergeRecursive(node1, node2.Next, merged);
        }
    }
}