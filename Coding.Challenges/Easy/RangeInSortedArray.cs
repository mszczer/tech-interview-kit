﻿namespace Coding.Challenges.Easy;

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

    public static int[] GetElementsAppearingOnce(IEnumerable<int> arr)
    {
        var countElements = new Dictionary<int, int>();

        foreach (var element in arr)
            if (countElements.ContainsKey(element))
                countElements[element]++;
            else
                countElements.Add(element, 1);

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
            if (countElements.ContainsKey(element))
                return element;
            else
                countElements.Add(element, 1);

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