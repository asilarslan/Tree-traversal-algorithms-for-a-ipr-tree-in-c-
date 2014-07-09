using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPRTree
{
    class Node<Type> where Type : IComparable<Type>
    {
        public Type value;
        public Node<Type> parent;
        public Node<Type> left;
        public Node<Type> right;
        public Node(Type value)
        {
            this.value = value;
            left = null;
            right = null;
            parent = null;
        }
        public override string ToString()
        {
            return Convert.ToString(value.ToString());
        }
    }
}
