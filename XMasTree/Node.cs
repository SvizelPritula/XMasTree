using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMasTree
{
    class Node : IComparable
    {
        public IComparable Value { get; private set; }
        public Node Left { get; private set; }
        public Node Right { get; private set; }

        public Node(IComparable value) => Value = value;

        public Node(IEnumerable<IComparable> values)
        {
            foreach (IComparable value in values)
            {
                if (Value == null)
                {
                    Value = value;
                }
                else
                {
                    Insert(value);
                }
            }
        }

        public Node(IComparable[] values) : this(values.AsEnumerable()) { }

        public void Insert(IComparable value)
        {
            int relativeValue = value.CompareTo(Value);

            if (relativeValue < 0)
            {
                if (Left == null)
                {
                    Left = new Node(value);
                }
                else
                {
                    Left.Insert(value);
                }
            }

            if (relativeValue > 0)
            {
                if (Right == null)
                {
                    Right = new Node(value);
                }
                else
                {
                    Right.Insert(value);
                }
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
            int relativeValue = value.CompareTo(Value);

            if (relativeValue < 0)
            {
                if (Left == null)
                {
                    return null;
                }
                return Left.Search(value);
            }
            else if (relativeValue > 0)
            {
                if (Right == null)
                {
                    return null;
                }
                return Right.Search(value);
            }
            else
            {
                return Value;
            }
        }

        public int CompareTo(object obj) => Value.CompareTo(obj);

        public override string ToString() {
            string representation = "";

            if (Left != null)
            {
                representation += Left.ToString();
                representation += ' ';
            }

            representation += Value.ToString();

            if (Right != null)
            {
                representation += ' ';
                representation += Right.ToString();
            }

            return representation;
        }
    }
}
