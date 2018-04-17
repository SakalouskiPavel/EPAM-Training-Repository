using System;
using System.Collections;
using System.Collections.Generic;

namespace NET.W._2018.Соколовский._13.Models
{
    public class BinarySearchTree<T> : IEnumerable<T>
    {
        private IComparer<T> _comparer;

        private TreeNode<T> _root;

        public BinarySearchTree() : this(Comparer<T>.Default)
        {
        }

        public BinarySearchTree(IComparer<T> comparer)
        {
            if (ReferenceEquals(comparer, null))
            {
                this._comparer = Comparer<T>.Default;
            }
            else
            {
                this._comparer = comparer;
            }
        }

        public IEnumerable<T> InOrder
        {
            get { return InOrderSequence(this._root); }
        }

        public IEnumerable<T> PreOrder
        {
            get { return PreOrderSequence(this._root); }
        }

        public IEnumerable<T> PostOrder
        {
            get { return PostOrderSequence(this._root); }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return PreOrder.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T data)
        {
            if (ReferenceEquals(data, null))
            {
                throw new ArgumentNullException(nameof(data));
            }

            AddNode(data, this._root);
        }

        public TreeNode<T> Find(T data)
        {
            if (ReferenceEquals(this._root, null))
            {
                return null;
            }

            if (this._comparer.Compare(data, this._root.Data) == 0)
            {
                return this._root;
            }

            if (this._comparer.Compare(data, this._root.Data) > 0)
            {
                return FindNode(data, this._root.Right);
            }

            return FindNode(data, this._root.Left);
        }

        private TreeNode<T> AddNode(T data, TreeNode<T> node)
        {
            if (ReferenceEquals(node, null))
            {
                return new TreeNode<T>(data);
            }

            if (this._comparer.Compare(data, node.Data) > 0)
            {
                node.Left = AddNode(data, node.Left);
            }
            else
            {
                node.Right = AddNode(data, node.Right);
            }

            return node;
        }

        private TreeNode<T> FindNode(T data, TreeNode<T> node)
        {
            if (ReferenceEquals(node, null))
            {
                return null;
            }

            if (this._comparer.Compare(data, node.Data) == 0)
            {
                return node;
            }

            if (this._comparer.Compare(data, node.Data) > 0)
            {
                return FindNode(data, node.Right);
            }

            return FindNode(data, node.Left);
        }

        private IEnumerable<T> PreOrderSequence(TreeNode<T> node)
        {
            yield return node.Data;

            if (node.Left != null)
            {
                foreach (var n in PreOrderSequence(node.Left))
                {
                    yield return n;
                }
            }

            if (node.Right != null)
            {
                foreach (var n in PreOrderSequence(node.Right))
                {
                    yield return n;
                }
            }
        }

        private IEnumerable<T> PostOrderSequence(TreeNode<T> node)
        {
            if (node.Left != null)
            {
                foreach (var n in PostOrderSequence(node.Left))
                {
                    yield return n;
                }
            }

            if (node.Right != null)
            {
                foreach (var n in PostOrderSequence(node.Right))
                {
                    yield return n;
                }
            }

            yield return node.Data;
        }

        private IEnumerable<T> InOrderSequence(TreeNode<T> node)
        {
            if (node.Left != null)
            {
                foreach (var n in InOrderSequence(node.Left))
                {
                    yield return n;
                }
            }

            yield return node.Data;

            if (node.Right != null)
            {
                foreach (var n in InOrderSequence(node.Right))
                {
                    yield return n;
                }
            }
        }
    }
}