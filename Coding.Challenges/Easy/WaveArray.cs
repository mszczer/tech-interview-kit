namespace Coding.Challenges;

/*
 * Difficulty: Easy
 * Problem:
 *  Given an unsorted array of integers( arr ) of length n , write a program to sort it in wave form.
 *      The array elements in the resultant array must be such that arr[0] >= arr[1] <= arr[2] >= arr[3] <= arr[4]
 *      If there are multiple sorted orders in wave form, return the one which is lexicographically smallest.
 *      The array may contain duplicates.
 */

public abstract class WaveArray
{
    public static int[] GetWaveArray(int[] arr)
    {
        if (arr == null)
            throw new ArgumentNullException(nameof(arr));

        if (arr.Length == 0)
            return [];

        var result = (int[])arr.Clone();
        Array.Sort(result);

        for (var i = 1; i < result.Length; i++)
            if ((i + 1) % 2 == 0)
                (result[i], result[i - 1]) = (result[i - 1], result[i]);

        return result;
    }

    public static int[] GetWaveArrayComparingNeighbors(int[] arr)
    {
        if (arr == null)
            throw new ArgumentNullException(nameof(arr));

        if (arr.Length == 0)
            return [];

        var result = (int[])arr.Clone();

        for (var i = 0; i < result.Length; i += 2)                      // traverse all even positioned elements of the input array
        {
            if (i > 0 && result[i - 1] > result[i])                     // If current even index element is smaller than previous 
                (result[i], result[i - 1]) = (result[i - 1], result[i]);
            if (i < result.Length - 1 && result[i] < result[i + 1])     // If current even index element is smaller than next 
                (result[i], result[i + 1]) = (result[i + 1], result[i]);
        }

        return result;
    }
}