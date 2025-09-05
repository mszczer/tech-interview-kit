namespace Coding.Challenges.Easy;

/*
 * Difficulty: Easy
 * Problem:
 *  Given the head of a linked list, write a program to swap each pair of adjacent nodes.
 *      Linked List can be of even or odd size.
 *      You shouldn't modify the values of nodes, rather swap the nodes itself.
 * Note:
 *      LinkedLst node properties Next and Previous are ReadOnly in .net.
 */
public static class SwapListNodes
{
    public static LinkedList<int> SwapNodes(LinkedList<int> ll)
    {
        if (ll == null || ll.Count < 2)
            return ll;

        var current = ll.First;
        while (current != null && current.Next != null)
        {
            var first = current;
            var second = current.Next;

            // Remove second node and re-insert before first
            ll.Remove(second);
            ll.AddBefore(first, second);

            // Move to the next pair
            current = first.Next;
        }

        return ll;
    }
}
