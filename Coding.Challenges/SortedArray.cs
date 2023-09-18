using System.Runtime.InteropServices.JavaScript;

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

        /*
         * Selection sort start from the first element and checks through other elements to find the minimum value.
         * After the end of the first iteration, the minimum value is swapped with the current element.
         * The iteration then continues from the 2nd element and so on.
         */
        public static int[] SelectionSort(int[] arr)
        {
            for (var i = 0; i < arr.Length - 1; i++)
            {
                var minIdx = i;

                for (var j = i + 1; j < arr.Length; j++)
                    if (arr[j] < arr[minIdx])
                        minIdx = j;

                if (minIdx != i)
                    (arr[i], arr[minIdx]) = (arr[minIdx], arr[i]);
            }

            return arr;
        }

        /*
         * We assume that the first card is already sorted then, we select an unsorted card.
         * If the unsorted card is greater than the card in hand, it is placed on the right otherwise, to the left.
         * In the same way, other unsorted cards are taken and put in their right place.
         * A similar approach is used by insertion sort:
         * To sort an array of size N in ascending order iterate over the array and compare the current element (key) to its predecessor,
         * if the key element is smaller than its predecessor, compare it to the elements before.
         * Move the greater elements one position up to make space for the swapped element.
         */
        public static int[] InsertionSort(int[] arr)
        {
            for (var i = 1; i < arr.Length; i++)
            {
                var key = arr[i];

                for (var j = i - 1; j >= 0 && arr[j] > key; j--)
                    if (arr[j] > key)
                    {
                        arr[j + 1] = arr[j];
                        arr[j] = key;
                    }
            }

            return arr;
        }
    }
}

/*
 * Simple Sorts:
 *  Selection Sort program in C# (Done)
 *  Insertion Sort program in C# (Done)
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