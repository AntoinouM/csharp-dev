using System;

namespace class_implementation
{
    
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
        // InsertLast
        // GetLastNode
        // InsertAfter
        // FindbyKey
        // DeleteNodebyKey
        // PrintList


        // Finaliser
        ~SingleLinkedList() 
        {
            // on kill
        }
    }
}

