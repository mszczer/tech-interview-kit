namespace Coding.Challenges
{
    public abstract class SortedArray
    {
        /*
         * Bubble sort changes the position of numbers or changing an unordered sequence into an ordered sequence:
         * Traverse from left and compare adjacent elements and the higher one is placed at right side.
         * The largest element is moved to the rightmost end at first.
         * The process is then continued to find the second largest and place it and so on until the data is sorted.
         * Bubble sort has worst-case and average complexity both О(n2), where n is the number of items being sorted.
         */
        public static int[] BubbleSort(int[] arr)
        {
            for (var i = 0; i < arr.Length - 1; i++)
                for (var j = 0; j < arr.Length - 1; j++)
                    if (arr[j] > arr[j + 1])
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);

            return arr;
        }

        public static int[] OptimizedBubbleSort(int[] arr)
        {
            for (var i = 0; i < arr.Length - 1; i++)
            {
                var swapFlag = false;
                for (var j = 0; j < arr.Length - 1; j++)
                    if (arr[j] > arr[j + 1])
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                        swapFlag = true;
                    }

                if (swapFlag == false)
                    break; // If no two elements were swapped by inner loop there is no need to check remaining elements
            }

            return arr;
        }
    }
}
/*
 * Simple Sorts:
 *  Selection Sort program in C# (ToDo)
 *  Insertion Sort program in C# (ToDo)
 *
 * Efficient Sorts:
 *  Heap Sort program in C# (ToDo)
 *  Merge Sort program in C# (ToDo)
 *  Quick Sort program in C# (ToDo)
 *
 * Bubble Sorts and Variant:
 *  Bubble Sort program  in C# (Done)
 *  Shell Sort program in C# (ToDo)
 *  Comb Sort program in C# (ToDo)
 *
 * Distribution Sorts:
 *  Bucket Sort program in C# (ToDo)
 *  Radix Sort program in C# (ToDo)
 */




