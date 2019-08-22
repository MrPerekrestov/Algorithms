using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{
    public static class SearchingAlgorithms
    {
       /// <summary>
       /// Simple implementation of binary search
       /// </summary>
       /// <param name="array">Input array</param>
       /// <param name="searchingNumber"></param>
       /// <returns></returns>
        public static bool CustomBinarySearch(this int[] array, int searchingNumber)
        {
            if (array.Length == 0) throw new ArgumentException("Array should contain one or more elements");
            return Search(0, array.Length - 1);

            bool Search(int lower, int upper)
            {
                if (upper-lower == 1)
                {
                    if (array[lower] == searchingNumber 
                        || array[upper] == searchingNumber) { return true; }

                    return false;
                }

                var middle = (lower + upper) / 2;

                if (array[middle] == searchingNumber) { return true; }                
                if (array[middle]> searchingNumber) { return Search(lower, middle - 1); }
                return Search(middle+1, upper);
            }
        }
    }
}
