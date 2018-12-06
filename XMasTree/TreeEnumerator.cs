using System;
using System.Collections;
using System.Collections.Generic;

namespace XMasTree
{
    internal class PrintableNode<T> where T : IComparable
    {
        public Node<T> Node;
        public bool Printed = false;

        public PrintableNode(Node<T> node)
        {
            Node = node;
        }
    }

    public class TreeEnumerator<T> : IEnumerator where T : IComparable
    {
        private Stack<PrintableNode<T>> _stack = new Stack<PrintableNode<T>>();
        private Tree<T> _tree;

        public TreeEnumerator(Tree<T> tree)
        {
            _tree = tree;
            if (tree.Root != null)
            {
                _stack.Push(new PrintableNode<T>(tree.Root));
            }
        }

        public object Current
        {
            get
            {
                return _stack.Count > 0 ?_stack.Peek().Node.Value : default(T);
            }
            
        }

        public bool MoveNext()
        {
            if (_stack.Count == 0)
            {
                return false;
            }

            if (!_stack.Peek().Printed)
            {
                SlideLeft();
                _stack.Peek().Printed = true;
                return true;
            }

            if (_stack.Peek().Node.Right!=null)
            {
                _stack.Push(new PrintableNode<T>(_stack.Peek().Node.Right));
                SlideLeft();
            }
            else
            {
                while ((_stack.Count > 0) && _stack.Peek().Printed) {
                    _stack.Pop();
                }
            }

            if (_stack.Count > 0)
            {
                _stack.Peek().Printed = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SlideLeft()
        {
            while (_stack.Peek().Node.Left != null)
            {
                _stack.Push(new PrintableNode<T>(_stack.Peek().Node.Left));
            }
        }

        public void Reset()
        {
            _stack.Clear();
            if (_tree.Root != null)
            {
                _stack.Push(new PrintableNode<T>(_tree.Root));
            }
        }
    }
}