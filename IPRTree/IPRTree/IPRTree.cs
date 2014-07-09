using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPRTree
{
    class IPRTree<Type> where Type : IComparable<Type>
    {
        public Node<Type> root;

        public IPRTree()
        {
            this.root = null;
        }
        public int IPR(Node<Type> x)        
        {
            if (x == null)
                return 0;


            int left, right;
            left = IPR(x.left);
            right = IPR(x.right);
            return Convert.ToInt32(left + right + 1);
        }
        public void ınsert(Node<Type> x, Node<Type> temp_Root)
        {
            if (temp_Root == null)
            {
                root = x;
                return;
            }
            if (x.value.CompareTo(temp_Root.value) < 0)
            {
                if (temp_Root.left == null)
                {
                    temp_Root.left = x;
                    x.parent = temp_Root;
                    reBalance(temp_Root.parent);
                    return;
                }
                else
                {
                    ınsert(x, temp_Root.left);
                    return;
                }
            }
            else if (x.value.CompareTo(temp_Root.value) > 0)
            {
                if (temp_Root.right == null)
                {
                    temp_Root.right = x;
                    x.parent = temp_Root;
                    reBalance(temp_Root.parent);
                    return;
                }
                else
                {
                    ınsert(x, temp_Root.right);
                    return;
                }
            }
        }

        public void reBalance(Node<Type> x)
        {
            if (x == null)
                return;
            int left, right;
            left = IPR(x.left);
            right = IPR(x.right);

            if (left > right)
            {
                if (IPR(x.left.left) > right)
                {
                    single_right_rotate(x.left);
                    reBalance(x.parent.parent);
                    return;
                }
                else if (IPR(x.left.right) > right)
                {
                    single_left_rotate(x.left.right);
                    single_right_rotate(x.left);
                    reBalance(x.parent);
                    return;
                }
            }
            else if (right > left)
            {
                if (IPR(x.right.right) > left)
                {
                    single_left_rotate(x.right);
                    reBalance(x.parent);
                    return;
                }
                else if (IPR(x.right.left) > left)
                {
                    single_right_rotate(x.right.left);
                    single_left_rotate(x.right);
                    reBalance(x.parent.parent);
                    return;
                }
            }

            if (x.parent != null)
            {
                reBalance(x.parent);
            }
        }
        public void single_right_rotate(Node<Type> x)
        {
            if (x == null)
                return;

            Node<Type> temp_root = new Node<Type>(default(Type));
            bool del = false;
            if (x.parent.parent == null)
            {
                del = true;

                x.parent.parent = temp_root;
                temp_root.right = x.parent;
            }

            if (x.parent.parent.right == x.parent)
            {
                x.parent.parent.right = x;
                x.parent.left = x.right;
                if (x.right != null)
                    x.right.parent = x.parent;
                x.right = x.parent;
                x.parent = x.parent.parent;
                x.right.parent = x;
            }
            else if (x.parent.parent.left == x.parent)
            {
                x.parent.parent.left = x;
                x.parent.left = x.right;
                if (x.right != null)
                    x.right.parent = x.parent;
                x.right = x.parent;
                x.parent = x.parent.parent;
                x.right.parent = x;

            }
            if (del)
            {
                root = temp_root.right;
                temp_root.right = null;
                x.parent = null;

            }
            temp_root = null;


        }
        public void single_left_rotate(Node<Type> x)
        {
            if (x == null)
                return;

            Node<Type> temp_root = new Node<Type>(default(Type));
            bool del = false;

            if (x.parent.parent == null)
            {
                del = true;

                x.parent.parent = temp_root;
                temp_root.left = x.parent;
            }

            if (x.parent.parent.left == x.parent)
            {
                x.parent.parent.left = x;
                x.parent.right = x.left;
                if (x.left != null)
                    x.left.parent = x.parent;
                x.left = x.parent;
                x.parent = x.parent.parent;
                x.left.parent = x;
            }
            else if (x.parent.parent.right == x.parent)
            {
                x.parent.parent.right = x;
                x.parent.right = x.left;
                if (x.left != null)
                    x.left.parent = x.parent;
                x.left = x.parent;
                x.parent = x.parent.parent;
                x.left.parent = x;


            }
            if (del)
            {
                root = temp_root.left;
                temp_root.left = null;
                x.parent = null;

            }
            temp_root = null;

        }
        public StringBuilder str = new StringBuilder();
        public string preOrderTraversal(Node<Type> node)
        {
            if (node != null)
            {
                Console.Write(node + ",");
                preOrderTraversal(node.left);
                preOrderTraversal(node.right);
            }
            return str.ToString();
        }
        public string inOrderTraversal(Node<Type> node)
        {
            if (node != null)
            {

                inOrderTraversal(node.left);
                Console.Write(node + ",");
                inOrderTraversal(node.right);
            }
            return str.ToString();
        }
        public string postOrderTraversal(Node<Type> node)
        {
            if (node != null)
            {
                postOrderTraversal(node.left);
                postOrderTraversal(node.right);
                Console.Write(node + ",");
            }
            return str.ToString();
        }
    }
}
