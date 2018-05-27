using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_and_Algorithms.Lists
{
    class Stack<T>
    {

        private Node<T> head;
        public Stack()
        {
            Size = 0;
            head = null;
        }

        public int Size { get; set; }
        
        public Node<T> push(T elem)
        {
            if (isEmpty())
                head = new Node<T>(elem);
            else
            {
                Node<T> appending = new Node<T>(elem);
                appending.Next = head;
                head = appending;
            }
            Size += 1;
            return head;
        }

        public T pop()
        {
            if (isEmpty())
                throw new NullReferenceException();
            T elem = head.Value;
            head = head.Next;
            Size -= 1;
            return elem;
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

        public bool exists(T elem)
        {
            Node<T> curr = head;
            while (curr != null)
            {
                if (curr.Value.Equals(elem))
                    return true;
                curr = curr.Next;
            }
            return false;
        }

        public void printAll()
        {
            if (isEmpty())
                return;
            Console.WriteLine("Stack size: " + Size);
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
