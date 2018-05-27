using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataStructures_and_Algorithms.Lists
{
    class LinkedList<T>
    {
        private Node<T> head;
        public LinkedList()
        {
            Size = 0;
            head = null;
        }
        public int Size { get; set; }

        public Node<T> add(T elem)
        {
            if(isEmpty())
            {
                head = new Node<T>(elem);
            }
            else
            {
                Node<T> curr = head;
                Node<T> appending = new Node<T>(elem);
                while (curr.Next != null)
                    curr = curr.Next;
                curr.Next = appending;
            }
            Size += 1;
            return head;
        }

        public bool remove(T elem)
        {
            if (isEmpty())
                return false;
            if (head.Value.Equals(elem))
            {
                head = head.Next;
                Size -= 1;
                return true;
            }
            else
            {
                Node<T> curr = head;
                while (curr.Next != null)
                {
                    if (curr.Next.Value.Equals(elem))
                    {
                        curr.Next = curr.Next.Next;
                        Size -= 1;
                        return true;
                    }
                    curr = curr.Next;
                }
            }
            return false;
        }

        public bool isEmpty()
        {
            return Size == 0;
        }
        public bool exists(T elem)
        {
            Node<T> curr = head;
            while(curr != null)
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
            Console.WriteLine("Linked-list size: " + Size);
            Node<T> curr = head;
            while(curr.Next != null)
            {
                Console.Write(curr.Value + "->");
                curr = curr.Next;
            }
            Console.WriteLine(curr.Value);
        }

        public T get(int index)
        {
            if (index >= Size)
                throw new NullReferenceException();
            Node<T> curr = head;
            while(index >= 0)
            {
                curr = curr.Next;
                index -= 1;
            }
            return curr.Value;
        }
    }
}
