namespace Coding.Challenges.Easy;

/*
 * Difficulty: Easy
 * Problem:
 *  Given a bitonic sequence arr[] of n distinct elements, search a given element k in the bitonic sequence.
 *      A Bitonic Sequence is a sequence of numbers that is first strictly increasing then after a point strictly decreasing.
 *      It is guaranteed that there are no duplicates in the input array arr[].
 *      If the element is found then return the index otherwise return -1 .
 */
public static class BitonicArray
{
    public static int GetIdxInBitonicArray(int[] arr, int k)
    {
        for (var i = 0; i < arr.Length; i++)
            if (arr[i] == k)
                return i;

        return -1;
    }

    public static int GetIdxInBitonicArray_Optimized(int[] arr, int k)
    {
        // find the idx of max element of the bitonic array
        var maxIdx = FindMaxIdx(arr);

        // if the element is equal to the max element then return its index
        if (k == arr[maxIdx])
            return maxIdx;
        // if the element is greater than the element at max point then the element does not exist in the array
        if (k > arr[maxIdx])
            return -1;

        // if the element is less than the max element search in both halves of the array using binary search
        // search in ascending part of array
        var result = SearchInAscendingPartOfBitonicArray(arr, k, maxIdx);
        // search in descending part of array
        if (result == -1)
            result = SearchInDescendingPartOfBitonicArray(arr, k, maxIdx);

        return result;
    }

    private static int SearchInDescendingPartOfBitonicArray(IReadOnlyList<int> arr, int k, int maxIdx)
    {
        for (var i = maxIdx + 1; i < arr.Count; i++)
            if (arr[i] < k)
                return -1;
            else if (arr[i] == k)
                return i;

        return -1;
    }

    private static int SearchInAscendingPartOfBitonicArray(IReadOnlyList<int> arr, int k, int maxIdx)
    {
        for (var i = 0; i < maxIdx; i++)
            if (arr[i] > k)
                return -1;
            else if (arr[i] == k)
                return i;

        return -1;
    }

    private static int FindMaxIdx(IReadOnlyList<int> arr)
    {
        var max = 0;

        for (var i = 1; i < arr.Count; i++)
            if (arr[i] > arr[i - 1])
                max = i;
            else
                break;

        return max;
    }
}