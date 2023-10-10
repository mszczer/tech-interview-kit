namespace Coding.Challenges.Easy;

/*
 * Difficulty: Easy
 * Problem:
 *  Given a sorted array arr[] with possibly duplicate elements, write a program to find indexes of first
 *  and last occurrences of a target element in the given array.
 *      The algorithm's runtime complexity must be in the order of O(log n).
 *      If the target is not found in the array, return [-1, -1].
 */
public static class RangeInSortedArray
{
    public static int[] GetRangeIndexes(int[] arr, int target)
    {
        var firstIdx = -1;
        var lastIdx = -1;

        for (var i = 0; i < arr.Length; i++)
            if (arr[i] == target)
            {
                if (firstIdx == -1)
                    firstIdx = i;
                lastIdx = i;
            }

        return new[] { firstIdx, lastIdx };
    }

    public static int[] GetRangeIndexes_BinarySearch(int[] arr, int target)
    {
        var range = new int[2];
        var minIdx = 0;
        var maxIdx = arr.Length - 1;

        var leftIdx = GetLeftIdx(arr, minIdx, maxIdx, target);
        var rightIdx = GetRightIdx(arr, minIdx, maxIdx, target);

        range[0] = leftIdx;
        range[1] = rightIdx;

        return range;
    }

    private static int GetLeftIdx(IReadOnlyList<int> arr, int minIdx, int maxIdx, int target)
    {
        if (minIdx == maxIdx)
            return arr[minIdx] == target ? minIdx : -1;

        var medIdx = (minIdx + maxIdx) / 2;

        if (arr[medIdx] < target)
            return GetLeftIdx(arr, medIdx + 1, maxIdx, target);
        else
            return GetLeftIdx(arr, minIdx, medIdx, target);
    }

    private static int GetRightIdx(IReadOnlyList<int> arr, int minIdx, int maxIdx, int target)
    {
        if (minIdx == maxIdx)
            return arr[minIdx] == target ? minIdx : -1;

        var medIdx = (minIdx + maxIdx + 1) / 2;

        if (arr[medIdx] > target)
            return GetRightIdx(arr, minIdx, medIdx - 1, target);
        else 
            return GetRightIdx(arr, medIdx, maxIdx, target);
    }
}


/*
 * ToDo:
 *  Find the element that appears once in a sorted array
 *  Find the minimum element in a sorted and rotated array
 *  Find the only repeating element in a sorted array of size n
 *  Find the Kth smallest element in the sorted generated array
 *  Find the missing element in a sorted array of consecutive numbers
 */