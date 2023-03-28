using System;
using System.Collections.Generic;

public class TowerOfHanoi
{
    private const int ROD_WIDTH = 10;
    private const int MAX_DISKS = 8;

    public void SolveRecursive(int n, char from_rod, char to_rod, char aux_rod)
    {
        if (n == 1)
        {
            Console.WriteLine($"Move disk 1 from rod {from_rod} to rod {to_rod}");
            PrintRods(new Stack<int>[] { new Stack<int>(), new Stack<int>(), new Stack<int>() });
            return;
        }
        SolveRecursive(n - 1, from_rod, aux_rod, to_rod);
        Console.WriteLine($"Move disk {n} from rod {from_rod} to rod {to_rod}");
        PrintRods(new Stack<int>[] { new Stack<int>(), new Stack<int>(), new Stack<int>() });
        SolveRecursive(n - 1, aux_rod, to_rod, from_rod);
    }

    public void SolveIterative(int n, char source, char destination, char auxiliary)
    {
        // Create three stacks to represent the rods
        var sourceStack = new Stack<int>();
        var destinationStack = new Stack<int>();
        var auxiliaryStack = new Stack<int>();

        // Push all disks onto the source stack
        for (int i = n; i > 0; i--)
        {
            sourceStack.Push(i);
        }

        // Calculate the total number of moves
        int totalMoves = (int)Math.Pow(2, n) - 1;

        // If the number of disks is odd, swap the destination and auxiliary stacks
        if (n % 2 != 0)
        {
            char temp = destination;
            destination = auxiliary;
            auxiliary = temp;
        }

        // Perform the iterative algorithm
        for (int i = 1; i <= totalMoves; i++)
        {
            if (i % 3 == 1)
            {
                // Move the top disk from the source stack to the destination stack
                MoveDisk(sourceStack, destinationStack, source, destination);
            }
            else if (i % 3 == 2)
            {
                // Move the top disk from the source stack to the auxiliary stack
                MoveDisk(sourceStack, auxiliaryStack, source, auxiliary);
            }
            else if (i % 3 == 0)
            {
                // Move the top disk from the auxiliary stack to the destination stack
                MoveDisk(auxiliaryStack, destinationStack, auxiliary, destination);
            }

            // Display the current state of the rods
            Console.Clear();
            Console.WriteLine("Tower of Hanoi\n");

                  Console.Write("\t");
            Console.Write(new string('=', n));
            Console.Write("\t");
            Console.Write(new string('=', n));
            Console.Write("\t");
            Console.Write(new string('=', n));
            Console.Write("\n");

            Console.Write("\t");
            Console.Write(source);
            Console.Write("\t");
            Console.Write(auxiliary);
            Console.Write("\t");
            Console.Write(destination);
            Console.Write("\n");

            for (int j = n - 1; j >= 0; j--)
            {
                Console.Write("\t");
                Console.Write(sourceStack.Count > j ? new string('-', sourceStack.ToArray()[j]) : new string(' ', n));
                Console.Write("\t");
                Console.Write(auxiliaryStack.Count > j ? new string('-', auxiliaryStack.ToArray()[j]) : new string(' ', n));
                Console.Write("\t");
                Console.Write(destinationStack.Count > j ? new string('-', destinationStack.ToArray()[j]) : new string(' ', n));
                Console.Write("\n");
            }

      

            System.Threading.Thread.Sleep(500);
        }
    }

    // Helper method to move the top disk from one stack to another
    // Helper method to move the top disk from one stack to another
    private void MoveDisk(Stack<int> sourceStack, Stack<int> destinationStack, char source, char destination)
    {
        int disk = 0;
        if (sourceStack.Count == 0)
        {
            disk = destinationStack.Pop();
            sourceStack.Push(disk);
            Console.WriteLine($"Move disk {disk} from rod {destination} to rod {source}");
        }
        else if (destinationStack.Count == 0)
        {
            disk = sourceStack.Pop();
            destinationStack.Push(disk);
            Console.WriteLine($"Move disk {disk} from rod {source} to rod {destination}");
        }
        else if (sourceStack.Peek() < destinationStack.Peek())
        {
            disk = sourceStack.Pop();
            destinationStack.Push(disk);
            Console.WriteLine($"Move disk {disk} from rod {source} to rod {destination}");
        }
        else
        {
            disk = destinationStack.Pop();
            sourceStack.Push(disk);
            Console.WriteLine($"Move disk {disk} from rod {destination} to rod {source}");
        }
    }


    // Helper method to create the rods with the disks
    // Helper method to create the rods with the disks
private string[] CreateRods(Stack<int> stack, int rodWidth, string[] disks)
{
    string[] rods = new string[rodWidth];

    int i = 0;
    foreach (int disk in stack)
    {
        rods[rodWidth - i - 1] = disks[disk - 1];
        i++;
    }

    for (; i < rodWidth; i++)
    {
        rods[rodWidth - i - 1] = new string(' ', disks[0].Length);
    }

    return rods;
}


    private void PrintRods(Stack<int>[] rods)
    {
        // Define the disks
        string[] disks = new string[MAX_DISKS];
        for (int i = 0; i < MAX_DISKS; i++)
        {
            disks[i] = new string('X', i + 1).PadLeft(ROD_WIDTH);
        }

        // Create the rods with the disks
        string[][] rodsWithDisks = new string[3][];
        for (int i = 0; i < 3; i++)
        {
            rodsWithDisks[i] = CreateRods(rods[i], MAX_DISKS, disks);
        }

        // Print the rods
        for (int i = 0; i < MAX_DISKS; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(rodsWithDisks[j][i]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }


    public static void Main()
    {
        Console.Write("Enter the algorithm to use (Recursive or Iterative): ");
        string algorithm = Console.ReadLine() ?? string.Empty;

        Console.Write("Enter the number of disks: ");
        int numDisks = int.Parse(Console.ReadLine() ?? string.Empty);

        TowerOfHanoi tower = new TowerOfHanoi();

        if (algorithm == "Recursive")
        {
            tower.SolveRecursive(numDisks, 'A', 'C', 'B');
        }
        else if (algorithm == "Iterative")
        {
            Console.Clear(); // clear the console
            Console.WriteLine($"Solving Tower of Hanoi iteratively with {numDisks} disks\n");
            tower.SolveIterative(numDisks, 'A', 'C', 'B');
        }
        else
        {
            Console.WriteLine("Invalid algorithm selected.");
        }
    }



}