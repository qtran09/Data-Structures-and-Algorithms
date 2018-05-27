using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_and_Algorithms
{
    public static class Searching<T> where T:IComparable
    {
        public static int BinarySearch(T[] arr, T elem)
        {
            if (arr.Length == 0)
            {
                return -1;
            }
            return BinarySearchHelper(arr, elem, 0,arr.Length);
        }
        private static int BinarySearchHelper(T[] arr, T elem, int left, int right)
        {
            if(left >= right)
            {
                if (arr[left].CompareTo(elem) == 0)
                    return left;
                return -1;
            }
            int mid = (left + right) / 2;
            int compareElem = arr[mid].CompareTo(elem);
            if (compareElem == 0)
                return mid;
            if (compareElem > 0)
                return BinarySearchHelper(arr, elem, left,mid);
            if (compareElem < 0)
                return BinarySearchHelper(arr, elem, mid, right);
            return -1;
        }

    }
}
