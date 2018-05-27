using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_and_Algorithms.Trees
{
    public class MinHeap<T> where T:IComparable
    {
        int MAX_SIZE = 10;
        public T[] arr;
        public MinHeap()
        {
            Size = 0;
            arr = new T[MAX_SIZE];
        }
        public int Size { get; set; }
        public void insert(T elem)
        {
            if (Size == MAX_SIZE)
                arr = doubled_size();
            arr[Size] = elem;
            Size++;
            heapify();
        }
        public T extract()
        {
            if (isEmpty())
                throw new NullReferenceException();
            T elem = arr[0];
            arr[0] = arr[Size - 1];
            Size--;
            heapify();
            return elem;
        }


        //Must check if out of bound or null
        public T Left(int parent)
        {
            return arr[(parent * 2) + 1];
        }
        public T Right(int parent)
        {
            return arr[(parent * 2) + 2];
        }
        public bool isEmpty()
        {
            return Size == 0;
        }
        public T peek()
        {
            if (isEmpty())
                throw new NullReferenceException();
            return arr[0];
        }

        public void swap(int x, int y)
        {
            T elemX = arr[x];
            T elemY = arr[y];
            arr[x] = elemY;
            arr[y] = elemX;
        }

        public void heapify()
        {
            for (int i = Size - 1; i >= 0; i--)
            {
                int left = i * 2 + 1;
                int right = i * 2 + 2;
                if (left >= Size)
                {
                    continue;
                }
                int compareLeft = arr[left].CompareTo(arr[i]);
                if (right < Size)
                {
                    int compareRight = arr[right].CompareTo(arr[i]);
                    if (compareLeft < 0 && compareRight < 0)
                    {
                        if (arr[right].CompareTo(arr[left]) >= 0)
                            swap(i, left);
                        else
                            swap(i, right);
                    }
                    else if (compareRight < 0)
                        swap(i, right);
                    else if (compareLeft < 0)
                        swap(i, left);
                }
                else if (arr[left].CompareTo(arr[i]) < 0)
                    swap(i, left);
            }
        }
        public void Print()
        {
            T[] copy = new T[Size];
            for (int i = 0; i < Size; i++)
            {
                copy[i] = arr[i];
            }
            int size = copy.Length - 1;
            Console.WriteLine("Min-heap size: " + Size);
            while (size >= 0)
            {
                T elem = extract();
                Console.Write(elem + " ");
                size--;
            }
            Console.WriteLine();
        }
        public T[] doubled_size()
        {
            MAX_SIZE *= 2;
            T[] doubled_copy = new T[MAX_SIZE];
            for (int i = 0; i < Size; i++)
            {
                doubled_copy[i] = arr[i];
            }
            return doubled_copy;
        }
    }
}
