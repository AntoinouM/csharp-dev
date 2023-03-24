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
        board.InitiateBoard(5);

        for (int i = 0; i < board.Stacks.Length; i++) {
            System.Console.WriteLine(board.Stacks[i].Name);
        }
        
    }
    
    //function to check args
}
