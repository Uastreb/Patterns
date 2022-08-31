﻿using System;
using System.Collections.Generic;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Node<char>('F',
                new Node<char>('B', new Node<char>('A'), new Node<char>('D', new Node<char>('C'), new Node<char>('E'))),
                new Node<char>('G', null, new Node<char>('I', new Node<char>('H'), null)));

            foreach (var item in tree.PreOrder)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class Node<T>
    {
        public T Value;
        public Node<T> Left, Right;
        public Node<T> Parent;

        public Node(T value)
        {
            Value = value;
        }

        public Node(T value, Node<T> left, Node<T> right)
        {
            Value = value;
            Left = left;
            Right = right;

            if (left != null)
            {
                left.Parent = this;
            }

            if (right != null)
            {
                right.Parent = this;
            }
        }

        public IEnumerable<T> PreOrder
        {
            get
            {
                foreach (var node in TraversePreOrder(this))
                {
                    yield return node.Value;
                }
            }
        }

        private static IEnumerable<Node<T>> TraversePreOrder(Node<T> current)
        {
            yield return current;

            if (current.Left != null)
            {
                foreach (var left in TraversePreOrder(current.Left))
                {
                    yield return left;
                }
            }

            if (current.Right != null)
            {
                foreach (var right in TraversePreOrder(current.Right))
                {
                    yield return right;
                }
            }
        }
    }
}
