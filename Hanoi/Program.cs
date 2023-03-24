using System;
using System.Diagnostics;
using System.Threading;
using HanoiLibrary;

namespace Hanoi;
class Program
{

    static void Main(string[] args)
    {
        // Call function to check args
        // create a new board (Class Hanoi) by giving the arg disks
        HanoiBoardParam board = new HanoiBoardParam();
        
    }

    // creating Hanoi board
    static void InitiateHanoiBoardParam(int nDisks, HanoiBoardParam board) {
        
        board.MaxDisks = nDisks;
        Stacks startStack = board.createStack(nDisks, board.StartRod, (0 + ((Console.WindowWidth / 3) / 2)));
        Stacks tempStack = board.createStack(nDisks, board.TempRod, (board.FirstLimit + ((Console.WindowWidth / 3) / 2)));
        Stacks endStack = board.createStack(nDisks, board.EndRod, (board.SecLimit + ((Console.WindowWidth / 3) / 2)));

        board.AddtoArray(0, startStack);
        board.AddtoArray(1, tempStack);
        board.AddtoArray(2, endStack);


    }
    

    //function to check args
}
