using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMasTree
{
    public class Tree<T> : IEnumerable where T : IComparable
    {
        public Node<T> Root;

        public Tree() { }

        public Tree(T value) {
            Root = new Node<T>(value);
        }

        public Tree(IEnumerable<T> values)
        {
            foreach (T i in values)
            {
                if (Root == null)
                {
                    Root = new Node<T>(i);
                }
                else
                {
                    Insert(i);
                }
            }
        }

        public Tree(T[] values)
        {
            foreach (T i in values)
            {
                if (Root == null)
                {
                    Root = new Node<T>(i);
                }
                else
                {
                    Insert(i);
                }
            }
        }

        public void Insert(T value)
        {
            if (Root == null)
            {
                Root = new Node<T>(value);
            }
            else
            {
                InsertIntoSubtree(Root, value);
            }
        }

        public void Insert(IEnumerable<T> values)
        {
            foreach (T value in values)
            {
                Insert(value);
            }
        }

        public void Insert(T[] values)
        {
            foreach (T value in values)
            {
                Insert(value);
            }
        }

        private void InsertIntoSubtree(Node<T> node, T value)
        {
            if (node.Value.CompareTo(value)==0)
            {
                return;
            }
            else if (node.Value.CompareTo(value) < 0)
            {
                if (node.Right == null)
                {
                    node.Right = new Node<T>(value);
                }
                else
                {
                    InsertIntoSubtree(node.Right, value);
                }
            }
            else
            {
                if (node.Left == null)
                {
                    node.Left = new Node<T>(value);
                }
                else
                {
                    InsertIntoSubtree(node.Left, value);
                }
            }
        }

        public bool Search(T value) => Root == null ? false : SearchSubtree(Root, value);

        private bool SearchSubtree(Node<T> node, T value)
        {
            if (node.Value.CompareTo(value) == 0)
            {
                return true;
            }
            else if (node.Value.CompareTo(value) < 0)
            {
                if (node.Right == null)
                {
                    return false;
                }
                return SearchSubtree(node.Right, value);
            }
            else
            {
                if (node.Left == null)
                {
                    return false;
                }
                return SearchSubtree(node.Left, value);
            }
        }

        public T GetMinimum() => Root == null ? default(T) : GetMinimumInSubtree(Root);

        private T GetMinimumInSubtree(Node<T> node) => node.Left == null ? node.Value : GetMinimumInSubtree(node.Left);

        public T GetMaximum() => Root == null ? default(T) : GetMaximumInSubtree(Root);

        private T GetMaximumInSubtree(Node<T> node) => node.Right == null ? node.Value : GetMaximumInSubtree(node.Right);

        public void Delete(T value)
        {
            if (Root != null)
            {
                Root = DeleteFromSubtree(Root, value);
            }
        }

        private Node<T> DeleteFromSubtree(Node<T> node, T value)
        {
            if (node.Value.CompareTo(value) == 0)
            {
                return DeleteNode(node);
            }
            else if (node.Value.CompareTo(value) < 0)
            {
                if (node.Right != null)
                {
                    node.Right = DeleteFromSubtree(node.Right, value);
                }
            }
            else
            {
                if (node.Left != null)
                {
                    node.Left = DeleteFromSubtree(node.Left, value);
                }
            }

            return node;
        }

        private Node<T> DeleteNode(Node<T> node)
        {
            if (node.Left != null && node.Right != null)
            {
                Node<T> rightMinimum = node.Right;
                while (rightMinimum.Left != null)
                {
                    rightMinimum = rightMinimum.Left;
                }

                DeleteFromSubtree(node.Right, rightMinimum.Value);

                rightMinimum.Left = node.Left;
                InsertNodeIntoSubtree(rightMinimum, node.Right);

                return rightMinimum;
            }

            if (node.Left != null)
            {
                return node.Left;
            }

            if (node.Right != null)
            {
                return node.Right;
            }

            return null;
        }

        private void InsertNodeIntoSubtree(Node<T> node, Node<T> insert)
        {
            if (node.Value.CompareTo(insert.Value) == 0)
            {
                return;
            }
            else if (node.Value.CompareTo(insert.Value) < 0)
            {
                if (node.Right == null)
                {
                    node.Right = insert;
                }
                else
                {
                    InsertNodeIntoSubtree(node.Right, insert);
                }
            }
            else
            {
                if (node.Left == null)
                {
                    node.Left = insert;
                }
                else
                {
                    InsertNodeIntoSubtree(node.Left, insert);
                }
            }
        }

        public override string ToString() => Root == null ? "" : Root.ToString();

        public IEnumerator GetEnumerator() => new TreeEnumerator<T>(this);
    }
}
