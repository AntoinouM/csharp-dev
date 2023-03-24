using System;
using System.Diagnostics;
using System.Threading;
using HanoiLibrary;

namespace Hanoi;
class Program
{
    static System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();

    static void Main(string[] args)
    {
        // create an animation Instance
        ConsoleAnimation AnimObj = new ConsoleAnimation(4, 700);

        // Call function to check args
        if (!CheckArgs(args, AnimObj)) {
            return;
        }

        // if input correct then do
        int nDisks = int.Parse(args[2]);

        // create a new board (Class Hanoi) by giving the arg disks
        HanoiBoardParam board = new HanoiBoardParam();
        board.InitiateBoard(nDisks);


        // Direct to the correct method:
        DirectToChosenMethod(args[1], board, AnimObj);
        
    }

    static void RecursiveHanoi(int nDisks, char startRod, char endRod, char tempRod, Pile startStack, Pile endStack, Pile tempStack, HanoiBoardParam board, ConsoleAnimation animObj) {
        // exit if no more disk to move
         if (nDisks == 0) {
            return;
        }

        RecursiveHanoi(nDisks - 1, startRod, tempRod, endRod, startStack, tempStack, endStack, board, animObj);
        
        endStack.PushDisk(startStack.pop());
        animObj.DisplayConsole(board.Piles, nDisks, board.MaxDisks, startRod, endRod, board.DiskChara);

        // call again -- move all from tempRod to endRod
        RecursiveHanoi(nDisks - 1, tempRod, endRod, startRod, tempStack, endStack, startStack, board, animObj);
    }

        //iterative method
    static void IterativeHanoi(int nDisks, char startRod, char tempRod, char endRod, HanoiBoardParam board, ConsoleAnimation animObj) {


        int i;
        int totalMoves = (int) (Math.Pow(2, nDisks) - 1); // calculate total number of moves and convert to int

        if (board.MaxDisks % 2 == 0) {
            Pile temp = board.Piles[1];
            board.Piles[1] = board.Piles[2];
            board.Piles[2] = temp;
        }

        // Put all disks from larger to smaller on first rod
        for (i = nDisks; i >= 1; i--) {
            board.Piles[0].PushDisk(i);
        }       

        for (i = 1; i <= totalMoves; i++)
        {

            if (i % 3 == 1) { // move 1 - 4 - 7 - ....
                MoveDiskBetweenRod(board.Piles[0], board.Piles[2], nDisks, board.Piles, board, animObj);
            }
            else if (i % 3 == 2) { //2 move 2 - 5 - 8 ...
                MoveDiskBetweenRod(board.Piles[0], board.Piles[1], nDisks, board.Piles, board, animObj);
            }
            else if (i % 3 == 0) { // move 3 - 6 - 9 - ...
                MoveDiskBetweenRod(board.Piles[1], board.Piles[2], nDisks, board.Piles, board, animObj);
            }
        }
    }

    // function to move disk between two pegs
    static void MoveDiskBetweenRod(Pile src, Pile dest, int nDisks, Pile[] stacks, HanoiBoardParam board, ConsoleAnimation animObj) {

        int rod1TopDisk = src.pop(); // return top disk of rod 1 or int.MinValue if rod empty
        int rod2TopDisk = dest.pop();

        // When rod 1 is empty
        if (rod1TopDisk == int.MinValue)
        {   
            src.PushDisk(rod2TopDisk);
            
        }
         
        // When rod 2  is empty
        else if (rod2TopDisk == int.MinValue)
        {
            dest.PushDisk(rod1TopDisk);
            animObj.DisplayConsole(stacks, rod1TopDisk, board.MaxDisks, src.Name, dest.Name, board.DiskChara);
        }
         
        // When top disk of rod 1 is larger than top disk of rod 2
        else if (rod1TopDisk > rod2TopDisk)
        {
            src.PushDisk(rod1TopDisk);
            src.PushDisk(rod2TopDisk);
            animObj.DisplayConsole(stacks, rod2TopDisk, board.MaxDisks, src.Name, dest.Name, board.DiskChara);
        }
         
        // When top disk of rod 1 is smaller top disk of rod 2
        else
        {
            dest.PushDisk(rod2TopDisk);
            dest.PushDisk(rod1TopDisk);
            animObj.DisplayConsole(stacks, rod1TopDisk, board.MaxDisks, src.Name, dest.Name, board.DiskChara);
        }

    }
    
    //function to check args
    static bool CheckArgs(string[] args, ConsoleAnimation animObj) {
        // input hanoi [-Recursive || -Iterative] nDisks {optional param: -animation} lenght 3 or 4
        if (args.Length != 3 && args.Length != 4) {
            // not enough arguments
            ErrorMessage("length");
            GetRandomInputExample();
            return false;
        }
        // check if input 3 (ndisks) can be converted to Int
        if ( (args.Length >= 3) && (!StringIsInt(args[2])) ) {
            ErrorMessage("type");
            GetRandomInputExample();
            return false;
        }
        // check if input 2 is -Iterative or -Recursive
        if ( (args[1] != "-Recursive") && (args[1] != "-Iterative") ) {
            ErrorMessage("mismatch");
            GetRandomInputExample();
            return false;
        }

        bool animate = false;
        if ( (args.Length > 3) && (args[3] != null) && (args[3] == "-animation") ) {
            if (int.Parse(args[2]) <= 6) {
                animate = true;
            } else {
                System.Console.WriteLine("To many disks to animate. Try with 6 disks or less.");
            }
        }
        animObj.Animation = animate;
        

        return true;
    }
    static bool StringIsInt(string stringToTest) {
        return int.TryParse(stringToTest, out int value);
    }
    static void ErrorMessage(string error) {

        switch (error) {
            case "length":
            System.Console.WriteLine("Input should have 3 or 4 arguments:");
                break;
            case "type":
            System.Console.WriteLine("The third argument (number of disks) should be an Integer: 1, 2, 3, ...");
                break;
            case "mismatch":
            System.Console.WriteLine("The second argument (Method) should be -Recursive or -Iterative");
                break;
            default:
            System.Console.WriteLine("Your Input should be:");
                break;
        }
    }
    static void GetRandomInputExample() {

        string[] exampleStrings = new String[2] {"example input: dotnet run hanoi -Recursive 3 -animation", "example input: dotnet run hanoi -Iterative 4"};
        int rnd = new Random().Next(0, 2);
        System.Console.WriteLine(exampleStrings[rnd]);
    }

    //function to direct sorting method
    static void DirectToChosenMethod(string args1, HanoiBoardParam board, ConsoleAnimation animObj) {
        if (args1 == "-Recursive") {
            RecursiveHanoi(board.MaxDisks, board.StartRod, board.EndRod, board.TempRod, board.Piles[0], board.Piles[2], board.Piles[1], board, animObj);
            Console.SetCursorPosition(0, Console.WindowHeight);
        }
        else {
            IterativeHanoi(board.MaxDisks, board.StartRod, board.TempRod, board.EndRod, board, animObj);
            Console.SetCursorPosition(0, Console.WindowHeight);
        }
    }
}
