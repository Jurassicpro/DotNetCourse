using System;
using System.Runtime.Serialization;
using System.Text;

namespace DotNetTestTask 
{
    internal class ListException : Exception 
    {
        public ListException() { }
        public ListException(string message) : base(message) { }
        public ListException(string message, Exception innerException) : base(message, innerException) { }
        protected ListException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
    
    public class List 
    {
        private uint _len = 0;
        private ListNode _head = null;

        public List() {
        }

        public void insert_at_last(int value) {
            if (_len == 0)
            {
                _head = new ListNode(value);
            }
            else
            {
                _head.InsertNode(_len -1, new ListNode(value));
            }

            _len++;
        }

        public void insert_in_place(uint place, int value) 
        {
            if (place > _len - 1)
            {
                throw new ListException(
                    $"Cant insert node. Number of node to insert is too big. Current size of list = {_len}");
            }
            _head.InsertNode(place, new ListNode(value));
            _len++;
        }

        public void print_info() 
        {
            Console.Write(_head.Information + " ");
            var node = _head.Next();
            while (node != null)
            {
                Console.Write(node.Information + " ");
                node = node.Next();
            }
            Console.WriteLine();
        }

        public void DeleteLast() {
            _head.DeleteNode(_len - 1);
            _len--;
        }

        public void delete_in_place(uint place) {
            if (place > _len - 1)
            {
                throw new ListException(
                    $"Cant insert node. Number of node to delete is too big. Current size of list = {_len}");
            }
            if (place == 0)
                _head = _head.DeleteNode();
            else
            {
                _head.DeleteNode(place);
            }

            _len--;
        }

        public void ReverseList() {
            _head = _head.Reverse();
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            var node = _head;
            while (node != null)
            {
                sb.Append(node.Information);
                node = node.Next();
            }
            return sb.ToString();
        }
    }

    internal class ListNode 
    {
        private ListNode _nextNodeList;
        private ListNode _prevNodeList;
        public int Information { get; }

        public ListNode(int information) 
        {
            Information = information;
            _nextNodeList = null;
            _prevNodeList = null;
        }

        private void AddNode(ListNode nextListNode) 
        {
            _nextNodeList = nextListNode;
            nextListNode._prevNodeList = this;
        }

        public ListNode Next() {
            return _nextNodeList;
        }

        public void InsertNode(uint numberOfNode, ListNode ListNodeToInsert) 
        {
            var i = 0;
            var node = this;
            while (node != null && i < numberOfNode)
            {
                node = node.Next();
                i++;
            }
            var nextToInsertedNode = node._nextNodeList;
            node.AddNode(ListNodeToInsert);
            if (nextToInsertedNode != null)
                ListNodeToInsert.AddNode(nextToInsertedNode);
        }


        public void DeleteNode(uint numberOfNode) 
        {
            if (numberOfNode < 1)
            {
                throw new ListException("Number of node should be > 0");
            }

            var i = 1;
            var node = Next();
            while (node != null && i < numberOfNode)
            {
                node = node.Next();
                i++;
            }

            if (node == null)
            {
                throw new ListException(
                    $"Cant insert node. Number of node to insert is too big. Current size of list = {i}");
            }

            var nextToDeletedNode = node._nextNodeList;
            var prevToDeletedNode = node._prevNodeList;
            if (nextToDeletedNode != null)
            {
                prevToDeletedNode.AddNode(nextToDeletedNode);
            }
            else
            {
                prevToDeletedNode._nextNodeList = null;
            }

            node._nextNodeList = null;
            node._prevNodeList = null;
        }

        public ListNode DeleteNode() {
            var toReturn = Next();
            _nextNodeList = null;
            _prevNodeList = null;
            return toReturn;
        }

        public ListNode Reverse() {
            ListNode current = this, prev = null;
            while (current != null) {
                var next = current._nextNodeList;
                prev = current._prevNodeList;
                current._nextNodeList = prev;
                current._prevNodeList = next;
                current = next;
            }
            return prev._prevNodeList;
        }
    }
}