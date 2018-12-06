using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMasTree
{
    public class Node<T> where T : IComparable
    {
        public T Value;
        public Node<T> Left;
        public Node<T> Right;

        public Node(T value) => Value = value;

        public override string ToString() {
            string representation = "";

            if (Left != null)
            {
                representation += '(';
                representation += Left.ToString();
                representation += ')';
                representation += ' ';
            }

            representation += Value.ToString();

            if (Right != null)
            {
                representation += ' ';
                representation += '(';
                representation += Right.ToString();
                representation += ')';
            }

            return representation;
        }
    }
}
