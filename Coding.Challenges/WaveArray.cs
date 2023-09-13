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
        Array.Sort(arr);

        for (var i = 1; i < arr.Length; i++)
            if ((i + 1) % 2 == 0)
                (arr[i], arr[i - 1]) = (arr[i - 1], arr[i]);

        return arr;
    }

    public static int[] GetWaveArrayComparingNeighbors(int[] arr)
    {
        for (var i = 0; i < arr.Length; i += 2)             // traverse all even positioned elements of the input array
        {
            if (i > 0 && arr[i - 1] > arr[i])               // If current even index element is smaller than previous 
                (arr[i], arr[i - 1]) = (arr[i - 1], arr[i]);
            if (i < arr.Length - 1 && arr[i] < arr[i + 1])  // If current even index element is smaller than next 
                (arr[i], arr[i + 1]) = (arr[i + 1], arr[i]);
        }

        return arr;
    }
}