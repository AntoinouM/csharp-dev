using System;

namespace Hanoi;

// solve Hanoi tower with n disks, iterative or recursive
// Input: $ hanoi -Recursive 4 or $ hanoi -Iterative 4 (4 means the user specified number of disks.)
// output printed steps and ASCII animations
// As all method will use the same Puzzle framework, privateclass to use pegs name...?
class Program
{
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
        bool animate = false;
        if ( (args[3] != null) && (args[3] == "-animation") ) {
            animate = true;
        }



        if (args[1] == "-Recursive") {
            RecursiveHanoi(nDisks, animate);
        }
        else {
            IterativeHanoi(nDisks, animate);
        }

    }

    // recursive method
    static void RecursiveHanoi(int nDisks, bool animate) {
        System.Console.WriteLine("Recursive" + " ;" + nDisks + " ;" + animate);
    }

    //iterative method
    static void IterativeHanoi(int nDisks, bool animate) {
        System.Console.WriteLine("Iterative" + " ;" + nDisks + " ;" + animate);

    }

    public class HanoiParam 
    {
        // Fields
        private char[] _pegs = {'A', 'B', 'C'};

        // Getters and Setters
        public char[] Pegs 
        {
            get { return _pegs;} // shortend of having a Getage() function with a return
            set { _pegs = value;}
        }

        // Methods

        // Finalisers
        ~HanoiParam() {}
    }

    public static bool StringIsInt(string stringToTest) {
        return int.TryParse(stringToTest, out int value);
    }

}
