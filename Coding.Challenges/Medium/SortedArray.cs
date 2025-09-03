namespace Coding.Challenges.Medium
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
                for (var j = 0; j < arr.Length - 1 - i; j++)
                    if (arr[j] > arr[j + 1])
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);

            return arr;
        }

        public static int[] OptimizedBubbleSort(int[] arr)
        {
            for (var i = 0; i < arr.Length - 1; i++)
            {
                var swapFlag = false;
                for (var j = 0; j < arr.Length - 1 - i; j++)
                    if (arr[j] > arr[j + 1])
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                        swapFlag = true;
                    }

                if (!swapFlag)
                    break;
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
            for (var gap = arr.Length / 2; gap > 0; gap /= 2)
            {
                for (var i = gap; i < arr.Length; i++)
                {
                    var temp = arr[i];
                    int j;
                    for (j = i; j >= gap && arr[j - gap] > temp; j -= gap)
                    {
                        arr[j] = arr[j - gap];
                    }
                    arr[j] = temp;
                }
            }
            return arr;
        }

        /*
         * Merge sort is a recursive algorithm that continuously splits the array in half until it cannot be further divided
         * idx.e., the array has only one element left (an array with one element is always sorted).
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

        /*
         * Quicksort is a sorting algorithm based on the divide and conquer approach where:
         * 1. An array is divided into subarrays by selecting a pivot element (element selected from the array).
         *    The pivot element should be positioned in such a way that elements less than pivot are kept on the left
         *    side and elements greater than pivot are on the right side of the pivot.
         * 2. The left and right subarrays are also divided using the same approach. This process continues until
         *    each sub array contains a single element.
         * 3. Elements are combined to form a sorted array.
         * Credits: https://www.programiz.com/dsa/quick-sort
         */
        public static int[] QuickSort(int[] arr, int start, int end)
        {
            if (start < end)
            {
                var pIdx = Partition(arr, start, end);
                QuickSort(arr, start, pIdx - 1);
                QuickSort(arr, pIdx + 1, end);
            }

            return arr;
        }

        private static int Partition(IList<int> arr, int start, int end)
        {
            var pivot = arr[end];   // select pivot element

            var idx = start - 1;    // index of greater element

            for (var i = start; i <= end - 1; i++)
                // swap elements if current element is smaller than the pivot element
                if (arr[i] < pivot)
                {
                    idx++;
                    (arr[i], arr[idx]) = (arr[idx], arr[i]);
                }

            (arr[idx + 1], arr[end]) = (arr[end], arr[idx + 1]);

            return idx + 1;
        }

        /*
         * Heap sort divides its input into a sorted and an unsorted region, and it iteratively shrinks
         * the unsorted region by extracting the largest element and moving that to the sorted region:
         * 1. Build Max-Heap: Since the tree satisfies Max-Heap property, then the largest item is
         * stored at the root node.
         * 2. Swap elements: Remove the root element and put at the end of the array (last position). Put the last
         * item of the tree (heap) at the vacant place.
         * 3. Remove the last element: Reduce the size of the heap by 1.
         * 4. Heapify: Heapify the root element again so that we have the highest element at root.
         * 5. The process is repeated until all the items of the list are sorted.
         * Credits: https://www.programiz.com/dsa/heap-sort
         */
        public static int[] HeapSort(int[] arr)
        {
            var size = arr.Length;

            // build max heap 
            for (var i = size / 2 - 1; i >= 0; i--) // the first index of a non-leaf node: size/2 - 1
                Heapify(arr, size, i);

            // heap sort
            for (var i = size - 1; i >= 0; i--)
            {
                (arr[0], arr[i]) = (arr[i], arr[0]);

                // heapify the root
                Heapify(arr, i, 0);
            }

            return arr;
        }

        private static void Heapify(IList<int> arr, int size, int idx)
        {
            // find the largest from root and it's direct children
            var largestIdx = idx;
            var leftChild = 2 * idx + 1;    // the element at the index 2i+1 is the left child
            var rightChild = 2 * idx + 2;   // the element at the index 2i+2 is the right child

            if (leftChild < size && arr[leftChild] > arr[largestIdx])
                largestIdx = leftChild;

            if (rightChild < size && arr[rightChild] > arr[largestIdx])
                largestIdx = rightChild;

            // swap and continue heapifying if root is not largest
            if (largestIdx != idx)
            {
                (arr[idx], arr[largestIdx]) = (arr[largestIdx], arr[idx]);
                Heapify(arr, size, largestIdx);
            }
        }

        /*
         * Bucket Sort divides the unsorted array elements into several groups called buckets.
         * Each bucket is then sorted by using any of the suitable sorting algorithms or recursively
         * applying the same bucket algorithm. Finally, the sorted buckets are combined to form
         * a final sorted array:
         * 1. create n empty buckets
         * 2. add array elements in different buckets
         * 3. sort individual buckets
         * 4. merge all buckets into final array
         */
        public static double[] BucketSort(double[] arr)
        {
            var size = arr.Length;

            // create empty buckets
            var buckets = new List<double>[size];
            for (var i = 0; i < size; i++)
                buckets[i] = new List<double>();

            // add elements to the different buckets
            for (var i = 0; i < size; i++)
            {
                    var bucketIdx = arr[i] * size;
                buckets[(int)bucketIdx].Add(arr[i]);
            }

            // sort elements in each buckets
            for (var i = 0; i < size; i++)
                buckets[i].Sort();

            // merge all buckets into arr[]
            var idx = 0;
            for (var i = 0; i < size; i++)                  // for each bucket
                for (var j = 0; j < buckets[i].Count; j++)  // check every number in bucket
                    arr[idx++] = buckets[i][j];

            return arr;
        }

        /*
         * Counting sort algorithm:
         * 1. Declare an auxiliary array count array of size max(input array+1 and initialize it with 0.
         * 2. Count each element of inputArray[] as an index of count array
         * 3. Calculate the prefix sum at every index of input array
         * 4. Create an array outputArray[] of size N.
         * 5. Traverse array inputArray[] from end and update outputArray[ countArray[ inputArray[i] ] – 1] = inputArray[i].
         *  Also, update countArray[ inputArray[i] ] = countArray[ inputArray[i] ]–-.
         * Credits: https://www.geeksforgeeks.org/counting-sort/
         */
        public static int[] CountingSort(int[] arr)
        {
            var size = arr.Length;

            // find the largest element in arr
            var max = arr[0];
            for (var i = 0; i < size; i++)
                if (arr[i] > max)
                    max = arr[i];

            // initialize count array with all zeros
            var countArr = new int[max + 1];
            for (var i = 0; i < countArr.Length; i++)
                countArr[i] = 0;

            // count of each element in input array and store in count array
            for (var i = 0; i < size; i++)
                countArr[arr[i]]++;

            // Store the cumulative count of each element
            for (var i = 1; i <= max; i++)
                countArr[i] += countArr[i - 1];

            // create output array and place elements there
            var outputArr = new int[size];
            for (var i = size - 1; i >= 0; i--)
            {
                outputArr[countArr[arr[i]] - 1] = arr[i];
                countArr[arr[i]]--;
            }

            return outputArr;
        }

        // ToDo: Implementation of Radix Sort
        public static int[] RadixSort(int[] arr)
        {
            throw new NotImplementedException();
        }

    }
}




/*
 * Simple Sorts:
 *  Selection Sort program in C# (Done)
 *  Insertion Sort program in C# (Done)
 *
 * Efficient Sorts:
 *  Heap Sort program in C# (Done)
 *  Merge Sort program in C# (Done)
 *  Quick Sort program in C# (Done)
 *
 * Bubble Sorts and Variant:
 *  Bubble Sort program  in C# (Done)
 *  Shell Sort program in C# (Done)
 *  Comb Sort program in C# (Done)
 *
 * Distribution Sorts:
 *  Bucket Sort program in C# (Done)
 *  Radix Sort program in C# (ToDo)
 *
 * ***************************************
 * Search algorithms
 *  Binary search (ToDo)
 *
 */