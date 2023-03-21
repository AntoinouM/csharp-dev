namespace Classes;

    public class Stack {
        //Fields
        private int _capacity;
        private int _top;
        private int[] _disks;

        //Constructor
        public Stack(int cap, int top, int[] disks)
            {
                _capacity = cap;
                _top = top;
                _disks = disks;
            }

        // Getters and setters
        public int Capacity{
            get{return _capacity;}
            set{_capacity = value;}
        }
        public int Top{
            get{return _top;}
            set{_top = value;}
        }
        public int[] Disks{
            get{return _disks;}
            set{_disks = value;}
        }

        //Methods
        public bool isFull() {
            return (_top == _capacity -1);
        }

        public bool isEmpty() {
            return (_top == -1);
        }

        public void PushDisk(int disk) {
            if (isFull()) {return;} // check is peg is full
            _disks[++_top] = disk; // increment top and add disk to stack
        }

        public int pop() {
            if (isEmpty()) {return int.MinValue;}
            return _disks[_top--];
        }

        //Finaliser
        ~Stack() {}   
    }