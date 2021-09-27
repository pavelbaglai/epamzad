using System;
using System.Collections.Generic;

namespace homework_10.Task7
{
    public class BST<T> where T : IComparable<T>
    {
        private class Node<T>
        {
            public Node<T> Left { get; set; }
            public Node<T> Right { get; set; }
            public T Value { get; set; }

            public Node(T value)
            {
                Value = value;
                Left = null;
                Right = null;
            }
        }

        public int Count { get; private set; }

        private Node<T> Head { get; set; }

        public IComparer<T> Compar { get; private set; }

        public BST()
        {
            Head = null;
            Count = 0;
            Compar = Comparer<T>.Default;
        }

        public BST(IComparer<T> compar)
        {
            Head = null;
            Count = 0;
            Compar = compar;
        }
        
        public bool Remove(T val)
        {
            if (Head == null)
                return false;

            if (RemoveTo(null, Head, val))
            {
                Count--;
                return true;
            }
            else return false;
        }

        private bool RemoveTo(Node<T> parent, Node<T> node, T val)
        {
            if (node == null) return false;

            var compRes = Compar.Compare(val, node.Value);

            if (compRes > 0) return RemoveTo(node, node.Right, val);
            if (compRes < 0) return RemoveTo(node, node.Left, val);
            if (compRes == 0)
            {
                var isLeft = parent.Left == node;

                if (node.Left == null && node.Right == null)
                {
                    if (isLeft) parent.Left = null;
                    else parent.Right = null;
                }

                else if (node.Left == null)
                {
                    if (isLeft)
                    {
                        parent.Left = node.Right;
                    }
                    else parent.Right = node.Right;
                }
                else if (node.Right == null)
                {
                    if (isLeft)
                    {
                        parent.Left = node.Left;
                    }
                    else parent.Right = node.Left;
                }
                else
                {
                    if (node.Right.Left == null)
                    {
                        if (isLeft)
                        {
                            node.Right.Left = node.Left;
                            parent.Left = node.Right;
                        }
                        else parent.Right = node.Right.Right;
                    }
                    else
                    {
                        var mostLeftParent = node.Right;
                        var mostLeft = node.Right.Left;

                        while (mostLeft.Left != null)
                        {
                            mostLeftParent = mostLeft;
                            mostLeft = mostLeft.Left;
                        }
                        node.Value = mostLeft.Value;
                        RemoveTo(mostLeftParent, mostLeft, mostLeft.Value);
                    }
                }
            }
            return true;
        }
        public bool Find(T val)
        {
            if (Head == null) return false;

            var current = Head;

            while (current != null)
            {
                var compRes = Compar.Compare(val, current.Value);

                if (compRes > 0) current = current.Right;
                else if (compRes < 0) current = current.Left;
                else if (compRes == 0) return true;
            }
            return false;
        }

        public void Add(T vL)
        {
            if (Count == 0)
            {
                Head = new Node<T>(vL);
            }
            else
            {
                var current = Head;
                while (true)
                {
                    if (Compar.Compare(vL, current.Value) < 0)
                    {
                        if (current.Left == null)
                        {
                            current.Left = new Node<T>(vL);
                        }
                        else
                        {
                            current = current.Left;
                            continue;
                        }
                    }
                    else
                    {
                        if (current.Right == null)
                        {
                            current.Right = new Node<T>(vL);
                        }
                        else
                        {
                            current = current.Right;
                            continue;
                        }
                    }
                    break;
                }
            }
            Count++;
        }

        public IEnumerable<T> PreOrder()
        {
            if (Head == null) yield break;
            foreach (var ch in PreOrderTo(Head))
                yield return ch;
        }

        private IEnumerable<T> PreOrderTo(Node<T> node)
        {
            if (node != null)
            {
                yield return node.Value;

                if (node.Left != null)
                {
                    foreach (var ch in PreOrderTo(node.Left))
                        yield return ch;
                }

                if (node.Right != null)
                {
                    foreach (var ch in PreOrderTo(node.Right))
                        yield return ch;
                }

            }
        }

        public IEnumerable<T> InOrder()
        {
            if (Head == null) yield break;
            foreach (var ch in InOrderTo(Head))
                yield return ch;
        }

        private IEnumerable<T> InOrderTo(Node<T> node)
        {
            if (node != null)
            {
                if (node.Left != null)
                {
                    foreach (var ch in InOrderTo(node.Left))
                        yield return ch;
                }


                yield return node.Value;

                if (node.Right != null)
                {
                    foreach (var ch in InOrderTo(node.Right))
                        yield return ch;
                }

            }
        }

        public IEnumerable<T> PostOrder()
        {
            if (Head == null) yield break;
            foreach (var ch in PostOrderTo(Head))
                yield return ch;
        }

        private IEnumerable<T> PostOrderTo(Node<T> node)
        {
            if (node != null)
            {
                if (node.Left != null)
                {
                    foreach (var ch in PostOrderTo(node.Left))
                        yield return ch;
                }


                if (node.Right != null)
                {
                    foreach (var ch in PostOrderTo(node.Right))
                        yield return ch;
                }
                yield return node.Value;
            }
        }
    }
}