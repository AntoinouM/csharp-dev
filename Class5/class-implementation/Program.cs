﻿using System;

namespace Class5;
    
    class Program
    {
        static void Main(string[] args)
        {
        
        }
    }

    // list member is {data; adress} so we need a class that contain both data
    public class Node 
    {
        // Fields
        private int _data;
        private Node? _next;

        // Constructors
        public Node(int d)
        {
            _data = d;
            _next = null;
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

        // Methods

        // Finalisers
        ~Node() {
            //to do on destruction
        }
    }

    public class SingleLinkedList
    {
        // Fields
        private Node? _head;

        // Constructors
        public SingleLinkedList() 
        {
            _head = null;
        }

        // Getters and setters
        public Node? Head
        {
            get { return _head; }
            set { _head = value; }
        }

        // Methods
        // InsertFront
        public void InsertFront(int newData) {
            Node newNode = new Node(newData);
            newNode.Next= _head;
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
        public void InsertAfter(Node? preNode, int newData) {
            if (preNode == null) {
                Console.WriteLine("The node cannot be null here!");
            } else {
                Node newNode = new Node(newData);
                newNode.Next = preNode.Next;
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
            Node? prev = null;

            // if key = _head, this means that the searched node is the first one
            if ((temp != null) && (temp.Data == key)) {
                _head = temp.Next;
            }

            while ((temp != null) && (temp.Data != key)) {
                prev = temp;
                temp = temp.Next;
            }
        }
        // PrintList


        // Finaliser
        ~SingleLinkedList() 
        {
            // on kill
        }
    }
