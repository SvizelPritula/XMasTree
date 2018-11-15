using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMasTree
{
    class Tree<T> : IEnumerable where T : IComparable
    {
        public Node Root { get; private set; }

        public Tree() { }

        public Tree(T value) {
            Root = new Node(value);
        }

        public Tree(IEnumerable<T> values)
        {
            Root = new Node(values);
        }

        public Tree(T[] values)
        {
            Root = new Node(values);
        }

        public void Insert(T value)
        {
            if (Root == null)
            {
                Root = new Node(value);
            }
            else
            {
                Root.Insert(value);
            }
        }

        public void Insert(IEnumerable<T> values)
        {
            foreach (T value in values)
            {
                Insert(value);
            }
        }

        public void Insert(T[] values) => Insert(values.AsEnumerable());

        public T Search(T value)
        {
            if (Root == null)
            {
                return null;
            }
            return Root.Search(value);
        }

        public T GetMinimum() => Root == null ? null : Root.GetMinimum();

        public T GetMaximum() => Root == null ? null : Root.GetMaximum();

        public bool Delete(T value)
        {
            if (Root.CompareTo(value) == 0)
            {
                Root = Root.Delete();
                return true;
            }
            else
            {
                return Root.DeleteFromChildren(value);
            }
        }

        public override string ToString() => Root == null ? "" : Root.ToString();

        public IEnumerator GetEnumerator()
        {
            return new TreeEnumerator(this);
        }
    }
}
