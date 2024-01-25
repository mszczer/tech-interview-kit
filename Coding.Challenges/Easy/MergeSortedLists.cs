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
    public static LinkedList<int>? MergeSortedListsAndSort(LinkedList<int>? list1, LinkedList<int>? list2)
    {
        if (list1 == null) return list2;
        if (list2 == null) return list1;

        foreach (var item in list2)
            list1.AddLast(item);

        var mergedList = new LinkedList<int>(list1.OrderBy(x => x));

        return mergedList;
    }

    public static LinkedList<int>? MergeSortedListsUsingTwoPointers(LinkedList<int>? list1, LinkedList<int>? list2)
    {
        if (list1 == null) return list2;
        if (list2 == null) return list1;

        var list1Node = list1.First;
        var list2Node = list2.First;

        while (list1Node != null && list2Node != null)
            if (list1Node.Value <= list2Node.Value)
            {
                list1Node = list1Node.Next;
            }
            else
            {
                var nextNode = list2Node.Next;
                list1.AddBefore(list1Node, list2Node.Value);
                list2Node = nextNode;
            }

        while (list2Node != null)
        {
            list1.AddLast(list2Node.Value);
            list2Node = list2Node.Next;
        }

        return list1;
    }

    public static LinkedList<int> MergeSortedListUsingRecursion(LinkedList<int> list1, LinkedList<int> list2)
    {
        if (list1 == null) return list2;
        if (list2 == null) return list1;

        var mergedList = new LinkedList<int>();

        MergeRecursive(list1.First, list2.First, mergedList);

        return mergedList;
    }

    private static void MergeRecursive(LinkedListNode<int>? list1Node, LinkedListNode<int>? list2Node,
        LinkedList<int> mergedList)
    {
        if (list1Node == null)
        {
            while (list2Node != null)
            {
                mergedList.AddLast(list2Node.Value);
                list2Node = list2Node.Next;
            }

            return;
        }

        if (list2Node == null)
        {
            while (list1Node != null)
            {
                mergedList.AddLast(list1Node.Value);
                list1Node = list1Node.Next;
            }

            return;
        }

        if (list1Node.Value <= list2Node.Value)
        {
            mergedList.AddLast(list1Node.Value);
            MergeRecursive(list1Node.Next, list2Node, mergedList);
        }
        else
        {
            mergedList.AddLast(list2Node.Value);
            MergeRecursive(list1Node, list2Node.Next, mergedList);
        }
    }
}