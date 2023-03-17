﻿using System;

namespace Exercice;
    
    class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedList singleList = new DoubleLinkedList();
            singleList.InsertLast(4);
            singleList.InsertLast(3);
            singleList.InsertLast(6);
            singleList.InsertLast(12);
            singleList.InsertLast(2);
            singleList.PrintList();

            singleList.deleteNodebyKey(12);
            singleList.PrintList();

            singleList.InsertAfter(6, 12);
            singleList.PrintList();
        }
    }

    // list member is {data; adress} so we need a class that contain both data
    public class Node 
    {
        // Fields
        private int _data;
        private Node? _next;
        private Node? _prev;

        // Constructors
        public Node(int d)
        {
            _data = d;
            _next = null;
            _prev = null;
        }

        // Getters and Setters
        public int Data
        {
            get { return _data;} // shortend of having a Getage() function with a return
            set { _data = value;}
        }

        public Node? Next
        {
            get {return _next;}
            set {_next = value;}
        }

        public Node? Prev
        {
            get{return _prev;}
            set{_prev = value;}
        }

        // Methods

        // Finalisers
        ~Node() {
            //to do on destruction
        }
    }

    public class DoubleLinkedList
    {
        // Fields
        private Node? _head;
        private Node? _tail;

        // Constructors
        public DoubleLinkedList() 
        {
            _head = null;
            _tail = null;
        }

        // Getters and setters
        public Node? Head
        {
            get { return _head; }
            set { _head = value; }
        }

        public Node? Tail
        {
            get{ return _tail;}
            set{_tail = value;}
        }

        // Methods
        // InsertFront
        public void InsertFront(int newData) {
            // HEAD (first node - [Pprev, data, next] - TAIL)
            Node newNode = new Node(newData);
            newNode.Next= _head;
            newNode.Prev = null;
            _head = newNode;
            
        }
        // InsertLast
        public void InsertLast(int newData) {
            Node newNode = new Node(newData);
            // first check if list is empty
            if (_head == null) {
                _head = newNode;
            } else {
                Node? lastNode = GetLastNode();
                if (lastNode != null) {
                    newNode.Prev = lastNode;
                    lastNode.Next = newNode;
                }
            }
        }
        // GetLastNode
        public Node? GetLastNode() {
            Node? temp = _head;
            while ((temp != null) && (temp.Next != null)) {
                temp = temp.Next;
            }
            return temp;
        }
        // InsertAfter
        public void InsertAfter(int key, int newData) {
            Node? preNode = FindbyKey(key);
            if (preNode == null) {
                Console.WriteLine("The node cannot be null here!");
            } else {
                Node newNode = new Node(newData);
                newNode.Prev = preNode;
                newNode.Next = preNode.Next;
                if (preNode.Next != null) preNode.Next.Prev = newNode;
                preNode.Next = newNode;
            }
        }
        // FindbyKey
        public Node? FindbyKey(int data) {
            Node? temp = _head;
            while(temp != null) {
                if (temp.Data == data) {
                    return temp;
                }
                temp = temp.Next;
            }
            return null;
        }
        // DeleteNodebyKey
        public void deleteNodebyKey(int key) {
            Node? temp = _head;

            // if key = _head, this means that the searched node is the first one
            if ((temp != null) && (temp.Data == key)) {
                _head = temp.Next;
            }

            while ((temp != null) && (temp.Data != key)) {
                temp = temp.Next;
            }

            // case if you don't find key in the list
            if (temp == null) return;

            if (temp.Prev != null) {
                temp.Prev.Next = temp.Next;
            }
        }
        // PrintList
        public void PrintList() {
            Node? temp = _head;
            Console.WriteLine("The DoubleLinkedList: ");
            while(temp != null) {
                Console.Write(temp.Data + " ");
                temp = temp.Next;
            }
            Console.WriteLine(" ");
        }

        // Finaliser
        ~DoubleLinkedList() 
        {
            // on kill
        }
    }
