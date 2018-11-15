using System;
using System.Collections;
using System.Collections.Generic;

namespace XMasTree
{
    internal class PrintableNode
    {
        public Node Node;
        public bool Printed = false;

        public PrintableNode(Node node)
        {
            Node = node;
        }
    }
    class TreeEnumerator : IEnumerator
    {
        private Stack<PrintableNode> _stack = new Stack<PrintableNode>();
        private Tree _tree;

        public TreeEnumerator(Tree tree)
        {
            _tree = tree;
            if (tree.Root != null)
            {
                _stack.Push(new PrintableNode(tree.Root));
            }
        }

        public object Current
        {
            get
            {
                return _stack.Peek().Node.Value;
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
                _stack.Push(new PrintableNode(_stack.Peek().Node.Right));
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
                _stack.Push(new PrintableNode(_stack.Peek().Node.Left));
            }
        }

        public void Reset()
        {
            throw new System.NotImplementedException();
        }
    }
}