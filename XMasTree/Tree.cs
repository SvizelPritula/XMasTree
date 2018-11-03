using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMasTree
{
    class Tree
    {
        public Node Root { get; private set; }

        public Tree() { }

        public Tree(IComparable value) {
            Root = new Node(value);
        }

        public Tree(IEnumerable<IComparable> values)
        {
            Root = new Node(values);
        }

        public Tree(IComparable[] values)
        {
            Root = new Node(values);
        }

        public void Insert(IComparable value)
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

        public void Insert(IEnumerable<IComparable> values)
        {
            foreach (IComparable value in values)
            {
                Insert(value);
            }
        }

        public void Insert(IComparable[] values) => Insert(values.AsEnumerable());

        public IComparable Search(IComparable value)
        {
            if (Root == null)
            {
                return null;
            }
            return Root.Search(value);
        }

        public IComparable GetMinimum() => Root == null ? null : Root.GetMinimum();

        public IComparable GetMaximum() => Root == null ? null : Root.GetMaximum();

        public bool Delete(IComparable value)
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
    }
}
