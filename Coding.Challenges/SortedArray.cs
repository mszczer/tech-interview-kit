﻿using System.Runtime.InteropServices.JavaScript;

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
         * Comb sort works as Bubble Sort but uses a gap larger than 1.
         * The inner loop of bubble sort, where swaps happen, is modified such that gap between swapped elements decreases
         * by a shrink factor k for each iteration of outer loop. This shrink factor is usually taken as 1.3.
         */
        public static int[] CombSort(int[] arr)
        {
            var swapFlag = true;

            for (var gap = (int)(arr.Length / 1.3); gap > 0 || swapFlag; gap = (int)(gap / 1.3))
                for (var i = gap; i < arr.Length; i++)
                {
                    swapFlag = false;
                    if (arr[i - gap] > arr[i])
                    {
                        (arr[i - gap], arr[i]) = (arr[i], arr[i - gap]);
                        swapFlag = true;
                    }
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

        /*
         * Shell sort is a generalized version of the insertion sort algorithm. It first sorts elements that are
         * far apart from each other and successively reduces the interval between the elements to be sorted.
         */
        public static int[] ShellSort(int[] arr)
        {
            // Start with half of array, then reduces to its half
            for (var interval = arr.Length / 2; interval > 0; interval /= 2)
                // Interval insertion sort for specific interval size
                for (var i = interval; i < arr.Length; i++)
                    if (arr[i - interval] > arr[i])
                        (arr[i - interval], arr[i]) = (arr[i], arr[i - interval]);

            return arr;
        }

        /*
         * Merge sort is a recursive algorithm that continuously splits the array in half until it cannot be further divided
         * i.e., the array has only one element left (an array with one element is always sorted).
         * Then the sorted subarrays are merged into one sorted array.
         * Credits: https://www.c-sharpcorner.com/blogs/a-simple-merge-sort-implementation-c-sharp 
         */
        public static int[] MergeSort(int[] arr)
        {
            if (arr.Length <= 1)
                return arr;
            
            // Create duplicate copies of sub-arrays to be sorted
            var mid = arr.Length / 2;

            var left = new int[mid];
            var right = new int[arr.Length - mid];

            for (var i = 0; i < mid; i++)
                left[i] = arr[i];
            for (var i = mid; i < arr.Length; i++)
                right[i - mid] = arr[i];

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        private static int[] Merge(IReadOnlyList<int> left, IReadOnlyList<int> right)
        {
            var mergedArr = new int[left.Count + right.Count];

            var idxLeft = 0;
            var idxRight = 0;
            var idxMerged = 0;

            // while there is element to check in any array
            while (idxLeft < left.Count || idxRight < right.Count)
                // until we reach the end of either arrays, larger element is placed at merged array
                if (idxLeft < left.Count && idxRight < right.Count)
                {
                    if (left[idxLeft] <= right[idxRight])
                    {
                        mergedArr[idxMerged] = left[idxLeft];
                        idxLeft++;
                    }
                    else
                    {
                        mergedArr[idxMerged] = right[idxRight];
                        idxRight++;
                    }
                    idxMerged++;
                }
                // if the left array still has elements, add them to the merged array
                else if (idxLeft < left.Count)
                {
                    mergedArr[idxMerged] = left[idxLeft];
                    idxLeft++;
                    idxMerged++;
                }
                // if the right array still has elements, add them to the merged array
                else if (idxRight < right.Count)
                {
                    mergedArr[idxMerged] = right[idxRight];
                    idxRight++;
                    idxMerged++;
                }

            return mergedArr;
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
 *  Merge Sort program in C# (Done)
 *  Quick Sort program in C# (ToDo)
 *
 * Bubble Sorts and Variant:
 *  Bubble Sort program  in C# (Done)
 *  Shell Sort program in C# (Done)
 *  Comb Sort program in C# (Done)
 *
 * Distribution Sorts:
 *  Bucket Sort program in C# (ToDo)
 *  Radix Sort program in C# (ToDo)
 */