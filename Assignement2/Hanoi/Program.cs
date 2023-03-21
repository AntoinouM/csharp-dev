using System;
using System.Diagnostics;
using System.Threading;

namespace Hanoi;

// solve Hanoi tower with n disks, iterative or recursive
// Input: $ hanoi -Recursive 4 or $ hanoi -Iterative 4 (4 means the user specified number of disks.)
// output printed steps and ASCII animations
// As all method will use the same Puzzle framework, privateclass to use pegs name...?
class Program
{

    static System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();

    // entry point to sort inputs and direct to proper algorithm
    static void Main(string[] args)
    {
        
        // input hanoi [-Recursive || -Iterative] nDisks {optional param: -animation} lenght 3 or 4
        if (args.Length != 3 && args.Length != 4) {
            // not enough arguments
            System.Console.WriteLine("Input should be this format:");
            System.Console.WriteLine("hanoi [-Recursive || -Iterative] nDisks {optional param: -animation} ");
            return;
        }

        // check if input 3 (ndisks) can be converted to Int
        if ( (args.Length >= 3) && (!StringIsInt(args[2])) ) {
            System.Console.WriteLine("Input should be this format:");
            System.Console.WriteLine("hanoi [-Recursive || -Iterative] nDisks {optional param: -animation} ");
            System.Console.WriteLine("The third argument nDisks should be an Integer (1, 2, 3, ...)");
            return;
        }

        // check if input 2 is -Iterative or -Recursive
        if ( (args[1] != "-Recursive") && (args[1] != "-Iterative") ) {
            System.Console.WriteLine("Input should be this format:");
            System.Console.WriteLine("hanoi [-Recursive || -Iterative] nDisks {optional param: -animation} ");
            return;
        }

        // if input correct then do
        int nDisks = int.Parse(args[2]);

        HanoiParam board = new HanoiParam();
        char startRod = board.Pegs[0];
        char tempRod = board.Pegs[1];
        char endRod = board.Pegs[2];

        bool animate = false;
        if ( (args[3] != null) && (args[3] == "-animation") ) {
            animate = true;
        }



        if (args[1] == "-Recursive") {
            watch.Start();
            RecursiveHanoi(nDisks, startRod, endRod, tempRod, animate);
            watch.Stop();
            ShowElapsedTime(watch);
        }
        else {
            watch.Start();
            IterativeHanoi(nDisks, startRod, tempRod, endRod, animate);
            if (nDisks >= 6) {System.Console.WriteLine("To many disks to animate. Try with 6 disks or less.");}
            watch.Stop();
            ShowElapsedTime(watch);
        }

    }

    // recursive method
    static void RecursiveHanoi(int nDisks, char startRod, char endRod, char tempRod, bool animate) {
        // exit if no more disk to move
         if (nDisks == 0) {
            return;
        }

        // call again -- move all disks to tempRod but the base
        RecursiveHanoi(nDisks - 1, startRod, tempRod, endRod, animate);
        
        Console.WriteLine("Move disk " + nDisks + " from rod " + startRod + " to rod " + endRod);

        // call again -- move all from tempRod to endRod
        RecursiveHanoi(nDisks - 1, tempRod, endRod, startRod, animate);
    }

    //iterative method
    static void IterativeHanoi(int nDisks, char startRod, char tempRod, char endRod, bool animate) {

        Stack startStack = createStack(nDisks);
        Stack tempStack = createStack(nDisks);
        Stack endStack = createStack(nDisks);

        int i;
        int totalMoves = (int) (Math.Pow(2, nDisks) - 1); // calculate total number of moves and convert to int

        string animState = "start";

        // Put all disks from larger to smaller on first rod
        for (i = nDisks; i >= 1; i--) {
            startStack.PushDisk(i);
        }       

        AnimateConsole(animState);

        for (i = 1; i <= totalMoves; i++)
        {
            animState = "ongoing";
            if (i == totalMoves) {
                animState = "end";
            }
            if (i % 3 == 1) { // move 1 - 4 - 7 - ....
                MoveDiskBetweenRod(startStack, endStack, startRod, endRod, animate, nDisks, animState);
            }
            else if (i % 3 == 2) { //2 move 2 - 5 - 8 ...
                MoveDiskBetweenRod(startStack, tempStack, startRod, tempRod, animate, nDisks, animState);
            }
            else if (i % 3 == 0) { // move 3 - 6 - 9 - ...
                MoveDiskBetweenRod(tempStack, endStack, tempRod, endRod, animate, nDisks, animState);
            }
        }
    }

    // function to move disk between two pegs
    static void MoveDiskBetweenRod(Stack src, Stack dest, char srcRod, char destRod, bool animate, int nDisks, string animState) {

        int rod1TopDisk = src.pop(); // return top disk of rod 1 or int.MinValue if rod empty
        int rod2TopDisk = dest.pop();
        bool animation = animate;

        if (nDisks >= 6) { animation = false;}

        // When rod 1 is empty
        if (rod1TopDisk == int.MinValue)
        {
            src.PushDisk(rod2TopDisk);
            ConsoleMove(destRod, srcRod, rod2TopDisk, animation, animState);
        }
         
        // When rod 2 pole is empty
        else if (rod2TopDisk == int.MinValue)
        {
            dest.PushDisk(rod1TopDisk);
            ConsoleMove(destRod, srcRod, rod1TopDisk, animation, animState);
        }
         
        // When top disk of rod 1 is larger than top disk of rod 2
        else if (rod1TopDisk > rod2TopDisk)
        {
            src.PushDisk(rod1TopDisk);
            src.PushDisk(rod2TopDisk);
            ConsoleMove(destRod, srcRod, rod2TopDisk, animation, animState);
        }
         
        // When top disk of rod 1 is smaller top disk of rod 2
        else
        {
            dest.PushDisk(rod2TopDisk);
            dest.PushDisk(rod1TopDisk);
            ConsoleMove(destRod, srcRod, rod1TopDisk, animation, animState);
        }

    }

    // function to write in console the move
    static void ConsoleMove(char fromPeg, char toPeg, int disk, bool animation, string animState)
    {
        if (animation == false) {
            Console.WriteLine("Move the disk " + disk + " from " + fromPeg + " to " + toPeg);
        } else {
            AnimateConsole(animState);
        }
    }

    static void AnimateConsole(string animState) {
        Thread.Sleep(500);
        //Console.Clear();

        System.Console.WriteLine(animState);

    }

    // function to create a stack of given capacity.
    static Stack createStack(int capacity)
    {
        Stack stack = new Stack(capacity, -1, new int[capacity]);
        return stack;
    }

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

        public int pop() { // remove a disk from stack
            if (isEmpty()) {return int.MinValue;}
            return _disks[_top--];
        }

        //Finaliser
        ~Stack() {}   
    }

    public class HanoiParam 
    {
        // Fields
        private char[] _pegs = {'A', 'B', 'C'};

        // Getters
        public char[] Pegs 
        {
            get { return _pegs;} // shortend of having a Getage() function with a return
        }

        // Methods

        // Finalisers
        ~HanoiParam() {}
    }

    public static bool StringIsInt(string stringToTest) {
        return int.TryParse(stringToTest, out int value);
    }

    static void ShowElapsedTime(System.Diagnostics.Stopwatch watch) {
        double elapsedTime = watch.ElapsedMilliseconds;
        System.Console.WriteLine("Runtime: " + elapsedTime + " ms");
    }
}

