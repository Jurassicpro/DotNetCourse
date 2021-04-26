using System;
using System.Runtime.Serialization;

namespace DotNetTestTask 
{
    public class BinaryTree 
    {
        private BinaryNode _root;

        public void add(int value) 
        {
            if (_root != null)
            {
                _root.AddNode(new BinaryNode(value));
            }
            else
            {
                _root = new BinaryNode(value);
            }
        }
        public void Delete(int value) 
        {
            var node = _root.Search(value);
            node.delete_node();
        }
        public void print_tree_info() 
        {
            Console.WriteLine("|----|");
            _root.print_info();
            Console.WriteLine("|----|");
        }
        
        private BinaryNode Search(int value) 
        {
            try
            {
                var res = _root.Search(value);
                return res;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("You need add at least 1 node");
                throw;
            }
        }

        
    }

    internal class BinaryTreeException : Exception 
    {
        public BinaryTreeException() { }

        public BinaryTreeException(string message) : base(message) { }

        public BinaryTreeException(string message, Exception innerException) : base(message, innerException) { }

        protected BinaryTreeException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    internal class BinaryNode 
    {
        private BinaryNode _leftNode;
        private BinaryNode _rightNode;
        private BinaryNode _parent;
        public int Info { get; set; }

        public BinaryNode(int value) 
        {
            Info = value;
        }

        public void AddNode(BinaryNode node) 
        {
            if (node.Info < Info)
            {
                CheckInternalNode(ref _leftNode, node);
            }
            else if (node.Info > Info)
            {
                CheckInternalNode(ref _rightNode, node);
            }
        }

        public BinaryNode Search(int value) 
        {
            if (Info == value)
                return this;
            var node = value > Info ? _rightNode.Search(value) : _leftNode.Search(value);
            if (node == null)
                throw new BinaryTreeException("There is no node with that value");
            return node;
        }

        private void CheckInternalNode(ref BinaryNode internalNode, BinaryNode nodeToAdd) 
        {
            if (internalNode == null)
            {
                nodeToAdd._parent = this;
                internalNode = nodeToAdd;
            }
            else
            {
                internalNode.AddNode(nodeToAdd);
            }
        }
        public void print_info() 
        {
            Console.WriteLine(ToString());
            _leftNode?.print_info();
            _rightNode?.print_info();
        }
        public void delete_node() 
        {
            if (_leftNode == null && _rightNode == null)
            {
                ReplaceParentNode(null);
            }
            else if (_leftNode != null ^ _rightNode != null)
            {
                ReplaceParentNode(_leftNode ?? _rightNode);
            }
            else
            {
                var node = _rightNode.find_min();
                Info = node.Info;
                node.delete_node();
            }
        }
        private BinaryNode find_min() 
        {
            var node = this;
            while (node._leftNode != null)
            {
                node = node._leftNode;
            }

            return node;
        }
        private void ReplaceParentNode(in BinaryNode newNode) 
        {
            if (newNode != null)
                newNode._parent = _parent;
            if (_parent == null) return;
            if (_parent._leftNode == this)
                _parent._leftNode = newNode;
            else
                _parent._rightNode = newNode;
        }
        
        public override string ToString() 
        {
            return $"I:{Info}|P:{_parent?.Info}|LC:{_leftNode?.Info}|RC:{_rightNode?.Info}|";
        }

        
    }
}