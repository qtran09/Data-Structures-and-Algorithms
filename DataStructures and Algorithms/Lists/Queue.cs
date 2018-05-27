using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_and_Algorithms.Lists
{
    class Queue<T>
    {
        private Node<T> head;
        private Node<T> tail;
        public Queue()
        {
            head = null;
            Size = 0;
        }
        public int Size { get; set; }

        public Node<T> enqueue(T elem)
        {
            if(head == null)
            {
                head = new Node<T>(elem);
                tail = head;
            }
            else
            {
                tail.Next = new Node<T>(elem);
                tail = tail.Next;
            }
            Size += 1;
            return head;
        }
        
        public T dequeue()
        {
            if (isEmpty())
                throw new NullReferenceException();
            else
            {
                T elem = head.Value;
                head = head.Next;
                Size -= 1;
                return elem;
            }
        }

        public T peek()
        {
            if (isEmpty())
                throw new NullReferenceException();
            return head.Value;
        }

        public bool isEmpty()
        {
            return Size == 0;
        }

        public void printAll()
        {
            if (isEmpty())
                return;
            Console.WriteLine("Queue size: " + Size);
            Node<T> curr = head;
            while (curr.Next != null)
            {
                Console.Write(curr.Value + "->");
                curr = curr.Next;
            }
            Console.WriteLine(curr.Value);
        }
    }
}
