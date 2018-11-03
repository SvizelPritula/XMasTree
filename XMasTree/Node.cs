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

        public void InsertNode(Node node)
        {
            int relativeValue = node.Value.CompareTo(Value);

            if (relativeValue < 0)
            {
                if (Left == null)
                {
                    Left = node;
                }
                else
                {
                    Left.InsertNode(node);
                }
            }

            if (relativeValue > 0)
            {
                if (Right == null)
                {
                    Right = node;
                }
                else
                {
                    Right.InsertNode(node);
                }
            }
        }

        public void Insert(IComparable value) => InsertNode(new Node(value));

        public void Insert(IEnumerable<IComparable> values)
        {
            foreach (IComparable value in values)
            {
                Insert(value);
            }
        }

        public void Insert(IComparable[] values) => Insert(values.AsEnumerable());

        public Node SearchNode(IComparable value)
        {
            int relativeValue = value.CompareTo(Value);

            if (relativeValue < 0)
            {
                if (Left == null)
                {
                    return null;
                }
                return Left.SearchNode(value);
            }
            else if (relativeValue > 0)
            {
                if (Right == null)
                {
                    return null;
                }
                return Right.SearchNode(value);
            }
            else
            {
                return this;

            }
        }

        public IComparable Search(IComparable value)
        {
            Node node = SearchNode(value);
            if (node == null)
            {
                return null;
            }
            return node;
        }

        public bool DeleteFromChildren(IComparable value) {
            int relativeValue = value.CompareTo(Value);

            if (relativeValue < 0)
            {
                if (Left != null)
                {
                    if (Left.CompareTo(value) == 0)
                    {
                        Left = Left.Delete();
                        return true;
                    }
                    else
                    {
                        return Left.DeleteFromChildren(value);
                    }
                }
            }
            else if (relativeValue > 0)
            {
                if (Right != null)
                {
                    if (Right.CompareTo(value) == 0)
                    {
                        Right = Right.Delete();
                        return true;
                    }
                    else
                    {
                        return Right.DeleteFromChildren(value);
                    }
                }
            }

            return false;

        }

        public Node Delete()
        {
            if (Left != null && Right != null)
            {
                Node rightMinimum=Right.GetMinimumNode();
                Right.DeleteFromChildren(rightMinimum.Value);
                rightMinimum.Left = Left;
                rightMinimum.InsertNode(Right);
                return rightMinimum;
            }

            if (Left != null)
            {
                return Left;
            }

            if (Right != null)
            {
                return Right;
            }

            return null;
        }

        public Node GetMinimumNode()
        {
            if (Left == null)
            {
                return this;
            }
            return Left.GetMinimumNode();
        }

        public Node GetMaximumNode()
        {
            if (Right == null)
            {
                return this;
            }
            return Right.GetMaximumNode();
        }

        public IComparable GetMinimum() => GetMinimumNode().Value;

        public IComparable GetMaximum() => GetMaximumNode().Value;

        public int CompareTo(object obj) => obj is Node ? Value.CompareTo(((Node) obj).Value) : Value.CompareTo(obj);

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
