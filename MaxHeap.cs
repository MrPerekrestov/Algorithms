using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class MaxHeap<T> where T : IComparable<T>
    {
        private T[] _innerArray;
        public int Count { get; private set; }
        public MaxHeap()
        {
            _innerArray = new T[100];
            Count = 0;
        }
        public void Add(T item)
        {
            _innerArray[Count++] = item;

            ChangePosition(Count - 1, (Count - 2) / 2);

            void ChangePosition(int itemIndex, int parrentIndex)
            {
                if (_innerArray[itemIndex].CompareTo(_innerArray[parrentIndex]) <= 0)
                {
                    return;
                }
                Swap(itemIndex, parrentIndex);

                var newParrentIndex = (parrentIndex - 1) / 2;
                if (newParrentIndex >= 0)
                {
                    ChangePosition(parrentIndex, newParrentIndex);
                }
            }
        }
        public T RemoveMaxAndReturnItsValue()
        {
            if (!(Count > 0)) return default(T);
            var itemToReturn = _innerArray[0];
            Swap(0,--Count);
            Sink(0);
            return itemToReturn;

            void Sink(int sinkIndex)
            {
                var leftChildIndex = 2 * sinkIndex + 1;
                var rightChildIndex = 2 * sinkIndex + 2;

                if (_innerArray[leftChildIndex].CompareTo(_innerArray[sinkIndex]) <= 0
                    && _innerArray[rightChildIndex].CompareTo(_innerArray[sinkIndex]) <= 0)
                    return;

                if (_innerArray[leftChildIndex].CompareTo(_innerArray[rightChildIndex]) >= 0)
                {
                    if(leftChildIndex<Count)
                    {
                        Swap(leftChildIndex, sinkIndex);
                        Sink(leftChildIndex);
                    }                    
                }
                else
                {
                    if (rightChildIndex<Count)
                    {
                        Swap(rightChildIndex, sinkIndex);
                        Sink(rightChildIndex);
                    }                   
                }
                
            }            
        }
        public void Remove(T item)
        {
            var itemIndex = _innerArray.FirstIndexOf(item);

            if (itemIndex == Count - 1)
            {
                Count--;
                return;
            }           

            Swap(itemIndex, --Count);
            var swimIndex = Swim(itemIndex, (itemIndex - 1) / 2);

            Sink(swimIndex);

            int Swim(int currentIndex, int parrentIndex)
            {

                if (_innerArray[currentIndex].CompareTo(_innerArray[parrentIndex]) <= 0)
                {
                    return currentIndex;
                }

                Swap(currentIndex, parrentIndex);

                var newParrentIndex = (parrentIndex - 1) / 2;

                if (newParrentIndex >= 0)
                {
                    return Swim(parrentIndex, newParrentIndex);
                }

                return parrentIndex;
            }

            void Sink(int sinkIndex)
            {
                var leftChildIndex = 2 * sinkIndex + 1;
                var rightChildIndex = 2 * sinkIndex + 2;                

                if (_innerArray[leftChildIndex].CompareTo(_innerArray[sinkIndex]) <= 0
                    && _innerArray[rightChildIndex].CompareTo(_innerArray[sinkIndex]) <= 0)
                    return;

                if (_innerArray[leftChildIndex].CompareTo(_innerArray[rightChildIndex]) >= 0)
                {
                    if (leftChildIndex<Count)
                    {                     
                        Swap(leftChildIndex, sinkIndex);
                        Sink(leftChildIndex);
                    }                   
                }
                else
                {
                    if (rightChildIndex<Count)
                    {                       
                        Swap(rightChildIndex, sinkIndex);
                        Sink(rightChildIndex);
                    }                    
                }
               
            }

        }

        public IEnumerable<T> GetItems()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _innerArray[i];
            }
        }
        private void Swap(int itemOneIndex, int itemTwoIndex)
        {
            var temp = _innerArray[itemOneIndex];
            _innerArray[itemOneIndex] = _innerArray[itemTwoIndex];
            _innerArray[itemTwoIndex] = temp;
        }

    }
    public static class ArrayExtensions
    {
        public static int FirstIndexOf<T>(this T[] array, T item) where T : IComparable<T>
        {
            for (var i = 0; i < array.Length; i++)
            {
                if (array[i].CompareTo(item) == 0) { return i; }
            }
            return -1;
        }
    }
}
