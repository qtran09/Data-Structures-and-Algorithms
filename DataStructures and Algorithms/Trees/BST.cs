using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_and_Algorithms.Trees
{
    class BST<T> where T:IComparable
    {
        public Node<T> root;
        public BST()
        {
            root = null;
            Size = 0;
        }
        public int Size { get; set; }

        public Node<T> add(T elem)
        {
            if(isEmpty())
            {
                root = new Node<T>(elem);
            }
            else
            {
                Node<T> curr = root;
                Node<T> appending = new Node<T>(elem);
                while(curr != null)
                {
                    //Go left
                    if(elem.CompareTo(curr.Value) <= 0)
                    {
                        //Append left
                        if(curr.Left == null)
                        {
                            curr.Left = appending;
                            break;
                        }
                        else
                        {
                            curr = curr.Left;
                        }
                    }
                    //Go right
                    else if(elem.CompareTo(curr.Value) > 0)
                    {
                        //Append right
                        if(curr.Right == null)
                        {
                            curr.Right = appending;
                            break;
                        }
                        else
                        {
                            curr = curr.Right;
                        }
                    }
                }
            }
            Size += 1;
            return root;
        }

        public bool remove(T elem)
        {
            if (isEmpty())
                return false;
            return removeHelper(elem, root, null);
        }

        private bool removeHelper(T elem, Node<T> curr, Node<T> previous)
        {
            if (curr == null)
                return false;
            //curr is what we need to get rid of
            if(elem.CompareTo(curr.Value) == 0)
            {
                //Case 1: curr is a leaf
                if(curr.Left == null && curr.Right == null)
                {
                    //Root
                    if (previous == null)
                    {
                        root = null;
                    }
                    else if (previous.Left == curr)
                    {
                        previous.Left = null;
                    }
                    else
                        previous.Right = null;
                }
                //Case 2: curr has one child
                //Right child
                else if(curr.Left == null && curr.Right != null)
                {
                    //Root
                    if (previous == null)
                        root = root.Right;
                    else
                    {
                        if (curr.Right.Value.CompareTo(previous.Value) <= 0)
                            previous.Left = curr.Right;
                        else
                            previous.Right = curr.Right;
                    }

                   
                }
                //Left child
                else if(curr.Left != null && curr.Right == null)
                {
                    //Root
                    if (previous == null)
                        root = root.Left;
                    else
                    {
                        if (curr.Left.Value.CompareTo(previous.Value) <= 0)
                            previous.Left = curr.Left;
                        else
                            previous.Right = curr.Left;
                    }
                }
                //Case 3: curr has two children
                else
                {
                    T minElem = min_elem(curr.Right);
                    removeHelper(minElem, curr.Right, curr);
                    curr.Value = minElem;
                    Size += 1;
                }
                Size -= 1;
                return true;
            }
            //Go left
            else if(elem.CompareTo(curr.Value) < 0)
            {
                return removeHelper(elem, curr.Left, curr);
            }
            //Go right
            else
            {
                return removeHelper(elem, curr.Right, curr);
            }
        }
        private T min_elem(Node<T> root)
        {
            if (root == null)
                throw new NullReferenceException();
            Node<T> curr = root;
            while(curr.Left != null)
            {
                curr = curr.Left;
            }
            return curr.Value;
        }

        public bool exists(T elem)
        {
            if (isEmpty())
                return false;
            Node<T> curr = root;
            while(curr != null)
            {
                int compare = elem.CompareTo(curr.Value);
                if (compare == 0)
                    return true;
                if (compare > 0)
                    curr = curr.Right;
                if (compare < 0)
                    curr = curr.Left;
            }
            return false;
        }
        public bool isEmpty()
        {
            return Size == 0;
        }
        public void inOrder()
        {
            Console.WriteLine("Inorder traversal; Size: " + Size);
            inOrderHelper(root);
            Console.WriteLine();
        }
        public void inOrderHelper(Node<T> root)
        {
            if (root == null)
                return;
            inOrderHelper(root.Left);
            Console.Write(root.Value+ " ");
            inOrderHelper(root.Right);
        }

        public void preOrder()
        {
            Console.WriteLine("Preorder traversal; Size: " + Size);
            preOrderHelper(root);
            Console.WriteLine();
        }
        public void preOrderHelper(Node<T> root)
        {
            if (root == null)
                return;
            Console.Write(root.Value+ " ");
            preOrderHelper(root.Left);
            preOrderHelper(root.Right);
        }

        public void postOrder()
        {
            Console.WriteLine("Postorder traversal; Size: " + Size);
            postOrderHelper(root);
            Console.WriteLine();
        }
        public void postOrderHelper(Node<T> root)
        {
            if (root == null)
                return;
            postOrderHelper(root.Left);
            postOrderHelper(root.Right);
            Console.Write(root.Value+ " ");
        }
    }
}
