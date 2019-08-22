using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{
    public class SortingAlgorythms
    {
        private static void Swap(ref int firstValue, ref int secondValue)
        {
            var temp = firstValue;
            firstValue = secondValue;
            secondValue = temp;
        }
        public static int[] BubbleSort(int[] inputArray)
        {
            var tempArray = new int[inputArray.Length];
            tempArray = inputArray.Select(item => item).ToArray();
            for (int i = tempArray.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (tempArray[j] > tempArray[j + 1])
                    {
                        Swap(ref tempArray[j], ref tempArray[j + 1]);
                    }
                }
            }
            return tempArray;
        }
        public static int[] SelectionSort(int[] inputArray)
        {
            var tempArray = new int[inputArray.Length];
            tempArray = inputArray.Select(item => item).ToArray();
            for (int i = tempArray.Length - 1; i > 0; i--)
            {
                int maxIndex = 0;
                for (int j = 0; j <= i; j++)
                {
                    if (tempArray[j] > tempArray[maxIndex]) maxIndex = j;
                }
                Swap(ref tempArray[maxIndex], ref tempArray[i]);
            }
            return tempArray;
        }
        public static int[] InsertionSort(int[] inputArray)
        {
            var tempArray = new int[inputArray.Length];
            tempArray = inputArray.Select(item => item).ToArray();
            for (int i = 1; i < tempArray.Length; i++)
            {
                var selectedValue = tempArray[i];
                if (selectedValue > tempArray[i - 1])
                {
                    continue;
                }

                for (int j = i - 1; j >= 0; j--)
                {
                    if (selectedValue >= tempArray[j])
                    {
                        tempArray[j + 1] = selectedValue;
                        break;
                    }

                    if (j == 0)
                    {
                        tempArray[j] = selectedValue;
                    }

                    tempArray[j + 1] = tempArray[j];
                }
            }
            return tempArray;
        }
        public static int[] ShellSort(int[] inputArray)
        {
            var tempArray = new int[inputArray.Length];
            tempArray = inputArray.Select(item => item).ToArray();

            var gap = 1;
            while (gap < tempArray.Length / 3)
            {
                gap = 3 * gap + 1;
            }

            while (gap >= 1)
            {
                for (int i = gap; i < tempArray.Length; i++)
                {
                    for (int j = i; j >= gap && tempArray[j] < tempArray[j - gap]; j--)
                    {
                        Swap(ref tempArray[j], ref tempArray[j - gap]);
                    }
                }
                gap /= 3;
            }

            return tempArray;
        }
        public static int[] Merge(int[] arrayOne, int[] arrayTwo)
        {
            var tempArray = new int[arrayOne.Length + arrayTwo.Length];

            var tempArrayIndex = 0;
            var arrayOneIndex = 0;
            var arrayTwoIndex = 0;

            while (arrayOneIndex < arrayOne.Length && arrayTwoIndex < arrayTwo.Length)
            {
                if (arrayOne[arrayOneIndex] <= arrayTwo[arrayTwoIndex])
                {
                    tempArray[tempArrayIndex] = arrayOne[arrayOneIndex];
                    tempArrayIndex++;
                    arrayOneIndex++;
                    continue;
                }

                tempArray[tempArrayIndex] = arrayTwo[arrayTwoIndex];
                tempArrayIndex++;
                arrayTwoIndex++;
            }

            if (arrayOneIndex <= arrayOne.Length - 1)
            {
                for (var i = arrayOneIndex; i < arrayOne.Length; i++)
                {
                    tempArray[tempArrayIndex] = arrayOne[i];
                    tempArrayIndex++;
                }
                return tempArray;
            }

            for (var i = arrayTwoIndex; i < arrayTwo.Length; i++)
            {
                tempArray[tempArrayIndex] = arrayTwo[i];
                tempArrayIndex++;
            }

            return tempArray;
        }
        public static int[] MergeSort(int[] inputArray)
        {
            var tempArray = new int[inputArray.Length];
            tempArray = inputArray.Select(item => item).ToArray();

            if (inputArray.Length <= 1)
            {
                return inputArray;
            }
            var devisionIndex = inputArray.Length / 2;

            var partOne = MergeSort(tempArray, 0, devisionIndex - 1);
            var partTwo = MergeSort(tempArray, devisionIndex, tempArray.Length - 1);
            var result = Merge(partOne, partTwo);

            return result;

            int[] MergeSort(int[] array, int lowIndex, int highIndex)
            {
                if (lowIndex == highIndex)
                {
                    return new int[1] { array[lowIndex] };
                }

                var devisionIndexInner = (highIndex - lowIndex) / 2 + lowIndex;

                var partOneInner = MergeSort(array, lowIndex, devisionIndexInner);
                var partTwoInner = MergeSort(array, devisionIndexInner + 1, highIndex);

                var resultInner = Merge(partOneInner, partTwoInner);

                return resultInner;
            }
        }
        public static int[] QuickSort(int[] inputArray)
        {            

            var tempArray = new int[inputArray.Length];
            tempArray = inputArray.Select(item => item).ToArray();

            QuickSort(0, tempArray.Length-1);

            return tempArray;
            void QuickSort(int lowerIndex, int higherIndex)
            {
                if (lowerIndex > higherIndex) return;

                var pivot = tempArray[lowerIndex];
                var i = lowerIndex;
                var j = lowerIndex + 1;

                while (j<=higherIndex)
                {
                    if (tempArray[j]<pivot)
                    {
                        i++;
                        Swap(ref tempArray[i], ref tempArray[j]);
                    }
                    j++;
                }             

                Swap(ref tempArray[lowerIndex], ref tempArray[i]);               
             
                if (higherIndex - lowerIndex == 1) return;

                QuickSort(lowerIndex, i-1);
                QuickSort(i + 1, higherIndex);
            }
        }
        public static int[] HeapSort(int[] inputArray)
        {
            var tempArray = new int[inputArray.Length];
            tempArray = inputArray.Select(item => item).ToArray();

            var heap = new MaxHeap<int>();

            foreach(var item in tempArray)
            {
                heap.Add(item);
            }

            for (var i = tempArray.Length-1; i>=0; i--)
            {
                tempArray[i] = heap.RemoveMaxAndReturnItsValue();
            }

            return tempArray;
        }
    }
}
