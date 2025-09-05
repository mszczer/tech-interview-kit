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
        var first = FindFirst(arr, target);
        var last = FindLast(arr, target);
        return [first, last];
    }

    private static int FindFirst(int[] arr, int target)
    {
        int left = 0, right = arr.Length - 1, result = -1;
        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            if (arr[mid] == target)
            {
                result = mid;
                right = mid - 1; // search left part for earlier occurrence
            }
            else if (arr[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return result;
    }

    private static int FindLast(int[] arr, int target)
    {
        int left = 0, right = arr.Length - 1, result = -1;
        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            if (arr[mid] == target)
            {
                result = mid;
                left = mid + 1; // search right part for later occurrence
            }
            else if (arr[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return result;
    }

    public static int[] GetElementsAppearingOnce(IEnumerable<int> arr)
    {
        var countElements = new Dictionary<int, int>();

        foreach (var element in arr)
            if (!countElements.TryAdd(element, 1))
                countElements[element]++;

        return (from element in countElements where element.Value == 1 select element.Key).ToArray();
    }

    public static int FindIdxOfTheMinimumInSortedArray(int[] arr)
    {
        var maxIdx = arr.Length - 1;

        if (maxIdx < 0)     
            return maxIdx;
        else if (maxIdx == 0 || arr[maxIdx] >= arr[0])
            return arr[0];
        else
            return arr[maxIdx];
    }

    public static int FindOnlyRepeatingElementInSortedArray(IEnumerable<int> arr)
    {
        var countElements = new Dictionary<int, int>();

        foreach (var element in arr)
            if (!countElements.TryAdd(element, 1))
                return element;

        return int.MinValue;
    }

    public static int FindFirstMissingElementInSortedArray(int[] arr)
    {
        var maxIdx = arr.Length - 1;
        if (maxIdx <= 0)
            return int.MinValue;

        for (var i = 1; i <= maxIdx; i++)
            if (Math.Abs(arr[i] - arr[i - 1]) > 1)
                return arr[i - 1] < arr[i] ? arr[i - 1] + 1 : arr[i] + 1;

        return int.MinValue;
    }

}