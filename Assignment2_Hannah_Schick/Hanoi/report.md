### Solution to the "Drill" of Hanoi Puzzle
### Hannah Schick, cc211012 BCC

    using System;
    using System.Collections.Generic;

These two lines are using directives, which allow the code to access types and methods defined in other namespaces. In this case, the code uses the System namespace, which provides a wide range of types and methods for working with the .NET Framework, and the System.Collections.Generic namespace, which provides generic collections like Stack<T>.

    private const int ROD_WIDTH = 10;
    private const int MAX_DISKS = 8;

These two lines define two private constants that will be used later in the code. ROD_WIDTH defines the width of the rods that the disks will be placed on, and MAX_DISKS defines the maximum number of disks that can be used in the puzzle.

    public void SolveRecursive(int n, char from_rod, char to_rod, char aux_rod)


This line defines a public method called SolveRecursive. This method takes four arguments: n, which specifies the number of disks in the puzzle; from_rod, which specifies the starting rod; to_rod, which specifies the destination rod; and aux_rod, which specifies the auxiliary rod. This method uses a recursive algorithm to solve the Tower of Hanoi puzzle.


    if (n == 1)
    {
        Console.WriteLine($"Move disk 1 from rod {from_rod} to rod {to_rod}");
        PrintRods(new Stack<int>[] { new Stack<int>(), new Stack<int>(), new Stack<int>() });
        return;
    }

This if statement checks whether there is only one disk left to move. If there is, it prints a message to the console that indicates which disk is being moved and from which rod to which rod. It then calls the PrintRods method to display the state of the rods after the move is made, and returns from the method.


    SolveRecursive(n - 1, from_rod, aux_rod, to_rod);
    Console.WriteLine($"Move disk {n} from rod {from_rod} to rod {to_rod}");
    PrintRods(new Stack<int>[] { new Stack<int>(), new Stack<int>(), new Stack<int>() });
    SolveRecursive(n - 1, aux_rod, to_rod, from_rod);

If there is more than one disk left to move, this code uses recursion to solve the puzzle. It first calls SolveRecursive with n - 1 disks, moving the top n - 1 disks from the starting rod to the auxiliary rod, using the destination rod as an auxiliary. It then prints a message to the console indicating which disk is being moved and from which rod to which rod. It calls PrintRods to display the state of the rods, and then calls SolveRecursive again with n - 1 disks, moving the n - 1 disks from the auxiliary rod to the destination rod, using the starting rod as an auxiliary.

    public void SolveIterative(int n, char source, char destination, char auxiliary)

    // Create three stacks to represent the rods
    var sourceStack = new Stack<int>();
    var destinationStack = new Stack<int>();
    var auxiliaryStack = new Stack<int>();

    // Push all disks onto the source stack
    for (int i = n; i > 0; i--)
    {
        sourceStack.Push(i);
    }

Defining a method called SolveIterative that takes in four arguments - n, source, destination, and auxiliary. n represents the number of disks in the Tower of Hanoi game, while source, destination, and auxiliary are the names of the three rods in the game.

Inside the method, the code creates three stacks - sourceStack, destinationStack, and auxiliaryStack - to represent the three rods in the game. It then pushes all the disks (represented by integers from 1 to n) onto the sourceStack in descending order.


    // Calculate the total number of moves
    int totalMoves = (int)Math.Pow(2, n) - 1;

    // If the number of disks is odd, swap the destination and auxiliary stacks
    if (n % 2 != 0)
    {
        char temp = destination;
        destination = auxiliary;
        auxiliary = temp;
    }

Next, the code calculates the total number of moves required to solve the game using the formula 2^n - 1. It also checks if the number of disks is odd and if so, swaps the destination and auxiliary stacks. This is an optimization that ensures that the smallest disk is always moved to the opposite rod (either destination or auxiliary) on the first move.

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


Loop that iterates from 1 to the total number of moves needed to solve the puzzle. Inside the loop, it checks the current move number using the modulo operator (%) to determine which stack to move the top disk from and where to move it.

If the move number is divisible by 3, it moves the top disk from the auxiliary stack to the destination stack. If the move number has a remainder of 2 when divided by 3, it moves the top disk from the source stack to the auxiliary stack. If the move number has a remainder of 1 when divided by 3, it moves the top disk from the source stack to the destination stack.

After each move, the current state of the rods is displayed on the console. The console output shows the current state of each stack using hyphens to represent the disks and spaces to represent empty slots. The number of hyphens used to represent each disk is equal to its size. The stacks are displayed vertically, with the source, auxiliary, and destination rods shown side by side.

Finally, the code pauses for half a second using the Thread.Sleep() method before proceeding to the next move. This pause allows the user to see the current state of the puzzle before the next move is made.


### MoveDisk

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

The method takes four arguments: two Stack<int> objects representing the source stack and the destination stack, and two characters representing the source and destination rods. The Stack<int> objects hold the disks in the puzzle, and the characters are used to identify the rods when printing out the move to the console.

The method first declares an integer variable 'disk' to hold the value of the disk being moved. It then checks the conditions for each of the four possible moves that can be made in the puzzle.

If the source stack is empty, the method pops the top disk from the destination stack, assigns it to 'disk', pushes it onto the source stack, and prints out the move to the console.

If the destination stack is empty, the method pops the top disk from the source stack, assigns it to 'disk', pushes it onto the destination stack, and prints out the move to the console.

If the top disk on the source stack is smaller than the top disk on the destination stack, the method pops the top disk from the source stack, assigns it to 'disk', pushes it onto the destination stack, and prints out the move to the console.

If none of the above conditions are met, the top disk on the destination stack is smaller than the top disk on the source stack. In this case, the method pops the top disk from the destination stack, assigns it to 'disk', pushes it onto the source stack, and prints out the move to the console.

After the disk has been moved, the method prints out the details of the move to the console.


### CreateRods

Creates a new string array rods with a length of rodWidth. This will be the array that represents the current state of a rod.


    string[] rods = new string[rodWidth];

Initializes a counter variable i to 0. This variable will be used to keep track of how many disks have been added to the rods array.


    int i = 0;

Loops through each disk in the stack parameter. For each disk, the corresponding string from the disks array is added to the rods array. The position of the string in the rods array is determined by subtracting the current value of i from rodWidth and then subtracting 1 (since arrays are zero-indexed).


    foreach (int disk in stack)
    {
        rods[rodWidth - i - 1] = disks[disk - 1];
        i++;
    }

For example, if rodWidth is 5, and i is 0, then the first disk will be added to rods[4]. If i is 1, then the second disk will be added to rods[3], and so on.

After all the disks have been added to the rods array, the remaining elements are filled with spaces. The for loop continues from the last value of i and fills the rest of the rods array with spaces. This ensures that all elements of the rods array have a value, even if there are fewer disks than rodWidth.



    for (; i < rodWidth; i++)
    {
        rods[rodWidth - i - 1] = new string(' ', disks[0].Length);
    }

Finally, the rods array is returned.


    return rods;

Method takes a stack of integers representing the current state of a rod, and returns a string array representing that state in a more readable format. The disks array contains strings that represent the disks, and rodWidth specifies the width of the rod. The method ensures that the rods array is always rodWidth elements long, and that all elements have a value (either a disk string or spaces).

### PRINTRODS

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


The PrintRods() method is used to print out the state of the rods at each step of the puzzle. It first defines an array disks that contains strings of X's of increasing lengths, which will be used to represent the disks. Then, it creates a 2D array rodsWithDisks that represents the state of the rods with their corresponding disks. The CreateRods() method is called for each rod to create an array of strings representing that rod and its disks. Finally, the rodsWithDisks array is printed out by iterating over each row of the 2D array and printing out the corresponding strings for each rod.

### MAIN

The Main() method is the entry point of the program. It prompts the user for input and calls the appropriate method on the tower object based on the user's choice.