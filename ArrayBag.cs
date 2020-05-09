using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AirlineNetworks
{
    public class ArrayBag<T> : IBag<T>
    {
        private T[] bagArray = new T[1];
        private int nextAvailableIndex;
        
        public void Add(T item)
        {
            if (bagArray.Length * 0.75 <= nextAvailableIndex)
            {
                var tempArray = new T[bagArray.Length * 2];
                for (var i = 0; i < nextAvailableIndex; i++)
                {
                    tempArray[i] = bagArray[i];
                }
        
                bagArray = tempArray;
            }
            bagArray[nextAvailableIndex] = item;
            nextAvailableIndex++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return bagArray.Cast<T>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        
        public bool IsEmpty()
        {
            return nextAvailableIndex == 0;
        }
    
        public int GetSize()
        {
            return nextAvailableIndex;
        }
    }

}