using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_and_Algorithms.Lists
{
    public class Node<T>
    {
        public Node(T elem) {
            Value = elem;
            Next = null;
        }
        public T Value { get; set; }
        public Node<T> Next { get; set; }
    }
}
