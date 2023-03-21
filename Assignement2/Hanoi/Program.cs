using System;
using System.Diagnostics;
using Classes;

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
            IterativeHanoi(nDisks, animate);
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
    static void IterativeHanoi(int nDisks, bool animate) {
        System.Console.WriteLine("Iterative" + "; " + nDisks + "; " + animate);
       
       

    }

// Class stack
// Class HanoiParam

    public static bool StringIsInt(string stringToTest) {
        return int.TryParse(stringToTest, out int value);
    }

    static void ShowElapsedTime(System.Diagnostics.Stopwatch watch) {
        double elapsedTime = watch.ElapsedMilliseconds;
        System.Console.WriteLine("Runtime: " + elapsedTime + " ms");
    }
}

