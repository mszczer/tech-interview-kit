namespace Coding.Challenges.Easy;

/*
 * Difficulty: Easy
 * Problem:
 *  Given the head of a linked list, write a program to swap each pair of adjacent nodes.
 *      Linked List can be of even or odd size.
 *      You shouldn't modify the values of nodes, rather swap the nodes itself.
 *          Note: LinkedLst node properties Next and Previous are ReadOnly.
 */
public static class SwapListNodes
{
    public static LinkedList<int> SwapNodes(LinkedList<int> ll)
    {
        if (ll.First?.Next == null)
            return ll;

        var currentNode = ll.First;
        var nextNode = currentNode.Next;

        while (currentNode != null && nextNode != null)
        {
            (currentNode.Value, nextNode.Value) = (nextNode.Value, currentNode.Value);
            currentNode = nextNode.Next;
            nextNode = nextNode.Next?.Next;
        }

        return ll;
    }
}