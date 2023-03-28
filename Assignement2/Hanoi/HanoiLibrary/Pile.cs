namespace HanoiLibrary
{
    public class Pile
    {
            //Fields
        private int _capacity;
        private int _top;
        private int[] _disks;
        private char _name;
        private int _xPos;

        //Constructor
        public Pile(int cap, int top, int[] disks, char name, int xPos)
            {
                _capacity = cap;
                _top = top;
                _disks = disks;
                _name = name;
                _xPos = xPos;
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
        public char Name{
            get{return _name;}
            set{_name = value;}
        }

        public int xPos{
        get{return _xPos;}
        set{_xPos = value;}
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

        public int pop() { // remove a disk from stack
            if (isEmpty()) {return int.MinValue;}
            int temp = _disks[_top];
            _disks[_top--] = 0;
            return temp;
        }

        //Finaliser
        ~Pile() {}   
    }

}