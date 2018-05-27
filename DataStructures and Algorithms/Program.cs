using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures_and_Algorithms.Lists;
using DataStructures_and_Algorithms.Trees;
namespace DataStructures_and_Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Lists.LinkedList<int> linked_list = new Lists.LinkedList<int>();
            for (int i = 0; i < 10; i++)
                linked_list.add(i);
            linked_list.printAll();

            Lists.Stack<int> stack = new Lists.Stack<int>();
            for (int i = 0; i < 10; i++)
                stack.push(i);
            stack.printAll();

            Lists.Queue<int> queue = new Lists.Queue<int>();
            for (int i = 0; i < 10; i++)
                queue.enqueue(i);
            queue.printAll();


            Trees.BST<int> bst = new Trees.BST<int>();
            bst.add(10);
            bst.add(13);
            bst.add(19);
            bst.add(5);
            bst.add(7);
            bst.add(11);
            bst.remove(13);
            bst.inOrder();
            bst.preOrder();
            bst.postOrder();

            Trees.MinHeap<int> heap = new Trees.MinHeap<int>();
            for (int i = 10; i < 40; i++)
                heap.insert(i);
            heap.Print();
            Trees.MaxHeap<int> heap2 = new Trees.MaxHeap<int>();
            for (int i = 10; i < 40; i++)
                heap2.insert(i);
            heap2.Print();
            int[] s = {};
            int d = Searching<int>.BinarySearch(s, 3);
            Console.WriteLine(d);
        }
    }
}
