namespace Coding.Challenges.Easy;

/*
 * Difficulty: Easy
 * Problem:
 *  Given an array arr[] of n elements filled with several integers, some of them being zeroes,
 *  move all the zeroes to the end.
 *      The relative order of non-zero integers needs to remain the same as in the original array.
 *      You must do this in-place without making a copy of the array.
 *      Minimize the total number of operations.
 */
public abstract class TestZeroesToEnd
{
    public static int[] MoveZeroesToEnd(int[] arr)
    {
        if (arr == null)
            throw new ArgumentNullException(nameof(arr));

        var nonZeroIdx = 0;

        for (var i = 0; i < arr.Length; i++)
            if (arr[i] != 0)
            {
                (arr[i], arr[nonZeroIdx]) = (arr[nonZeroIdx], arr[i]);
                nonZeroIdx++;
            }

        return arr;
    }
}