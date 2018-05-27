using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_and_Algorithms.Trees
{
    public class Node<T>
    {
        public Node(T elem)
        {
            Value = elem;
            Left = null;
            Right = null;
        }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public T Value { get; set; }
    }
}
