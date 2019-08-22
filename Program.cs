using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Mergetest();
            // MergeSortTest();
            // QuickSortTest();
            //BinarySearchTest();
            //HexaDecimalTest();
            // MaxHeapTest();
            Console.WriteLine("Hello world");
            IQuaribleTest();
            Console.ReadKey();
        }
        private static void IQuaribleTest()
        {
            var list = new List<string>
            {
              "Roman",
              "Ivan",
              "Jana",
              "Filip"
            };

            IQueryable<string> result = list.Where(item => item.Length > 4).AsQueryable<string>();
            Console.WriteLine(result.ToString());
        }
        private static void WriteHeapToConsole<T>(MaxHeap<T> heap) where T:IComparable<T>
        {
            Console.WriteLine();
            foreach(var item in heap.GetItems())
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
        private static void MaxHeapTest()
        {
            var intHeap = new MaxHeap<int>();
            intHeap.Add(24);
            intHeap.Add(37);
            intHeap.Add(17);
            intHeap.Add(28);
            intHeap.Add(31);
            intHeap.Add(29);
            intHeap.Add(15);
            intHeap.Add(12);
            intHeap.Add(20);
            intHeap.Add(40);

            WriteHeapToConsole(intHeap);

            while(intHeap.Count>0)
            {
                intHeap.RemoveMaxAndReturnItsValue();
                WriteHeapToConsole(intHeap);
            }          
          
        }
        private static void HexaDecimalTest()
        {
            var i = 1234 & 0x7FFFFFFF;
            var b = -1234 & 0x7FFFFFFF;
            Console.WriteLine(444 & 0x7FFFFFFF);
            Console.WriteLine(-12 & 0x7FFFFFFF);
            Console.WriteLine(i);
            Console.WriteLine(b);
        }

        private static void BinarySearchTest()
        {
            var inputArray = new int[] { 1, 2, 4, 7, 9, 10, 25, 88, 567, 12456 };
            Console.WriteLine(inputArray.CustomBinarySearch(1));
            Console.WriteLine(inputArray.CustomBinarySearch(25));
            Console.WriteLine(inputArray.CustomBinarySearch(288));
            Console.WriteLine(inputArray.CustomBinarySearch(88));
            Console.WriteLine(inputArray.CustomBinarySearch(12456));
        }
        private static void MergeSortTest()
        {
            var array = new int[] { 4, 123, -20, -3, 23, 123, 5, 6, 4567, 2, 32, 43, 612, 5 };
            Console.WriteLine("Start merge sort");
            var sortedArray = SortingAlgorythms.MergeSort(array);
            var result = "";
            foreach (var item in sortedArray)
            {
                result += $"{item}, ";
            }
            result = result.Substring(0, result.Length - 2);
            Console.WriteLine(result);
            Console.WriteLine("Finish merge sort");
        }

        private static void QuickSortTest()
        {
            var array = new int[] { 4, 123, -20, -3, 23, 123, 5, 6, -100, 4512, 34, -12, 33, 567, 2, 32, 43, 612, 5, 15, 25 };
            Console.WriteLine("Start quick sort");
            var sortedArray = SortingAlgorythms.QuickSort(array);
            var result = "";
            foreach (var item in sortedArray)
            {
                result += $"{item}, ";
            }
            result = result.Substring(0, result.Length - 2);
            Console.WriteLine(result);
            Console.WriteLine("Finish quick sort");
        }

        private static void Mergetest()
        {
            var arrayOne = new int[] { -2, -1, 1, 2, 3, 4, 6, 55, 90 };
            var arrayTwo = new int[] { 3, 5, 8, 10 };
            var mergedArray = SortingAlgorythms.Merge(arrayOne, arrayTwo);

            var result = "";

            foreach (var item in mergedArray)
            {
                result += $"{item}, ";
            }
            result = result.Substring(0, result.Length - 2);
            Console.WriteLine(result);
        }
    }
}
