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
        if (arr == null || arr.Length == 0)
            return -1;

        var maxIdx = FindMaxIdx(arr);

        if (arr[maxIdx] == k)
            return maxIdx;

        var left = BinarySearch(arr, 0, maxIdx - 1, k, ascending: true);
        if (left != -1)
            return left;

        return BinarySearch(arr, maxIdx + 1, arr.Length - 1, k, ascending: false);
    }

    // Binary search for both ascending and descending order
    private static int BinarySearch(int[] arr, int low, int high, int k, bool ascending)
    {
        while (low <= high)
        {
            var mid = low + (high - low) / 2;
            if (arr[mid] == k)
                return mid;

            if (ascending)
            {
                if (arr[mid] < k)
                    low = mid + 1;
                else
                    high = mid - 1;
            }
            else
            {
                if (arr[mid] < k)
                    high = mid - 1;
                else
                    low = mid + 1;
            }
        }
        return -1;
    }

    // Binary search to find the peak (max element) in bitonic array
    private static int FindMaxIdx(int[] arr)
    {
        int low = 0, high = arr.Length - 1;
        while (low < high)
        {
            var mid = low + (high - low) / 2;
            if (arr[mid] < arr[mid + 1])
                low = mid + 1;
            else
                high = mid;
        }
        return low;
    }
}