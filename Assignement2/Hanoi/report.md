# C# Development: Sorting algorithms
## _Sorting an array using Bubble sort and Merge sort_

### Objectives 
Having a Program that solve the Tower of Hanoi puzzle, iteratievly or recursively of n disks regarding the user input:
• Input: $ hanoi -Recursive 4 or $ hanoi -Iterative 4 (4 means the user specified number of disks.)
• Output: - Text : Disk 1 moved from (L) to (R)
          - ASCII art

### Entry point: Main
The Entry Point of the Program transfer the call the solving method selected by the user.

```csharp
    static bool CheckArgs(string[] args, ConsoleAnimation animObj) {
        // input hanoi [-Recursive || -Iterative] nDisks {optional param: -animation} lenght 3 or 4
        if (args.Length != 3 && args.Length != 4) {
            // not enough arguments
            ...
```
If the user's input doesn't match the required input, we provide the user a detailed error message and exit the program.

If the condition is met, we use the DirectToChosenMethod that select the user method to solve the Tower of Hanoi.
```csharp
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
```

The important things to note are the presence of two custom classes here. There are in fact 3 custom classes:

• Pile: A class that behave like the data type Stack.
• HanoiBoardParam: This class hold the parameters of the game (eg: name of the rods, max disks...) and different method to inititate an object that hold the informations (like a physical board).
• ConsoleAnimation: A class to manage my animation or the text display of the console. 

### Recursive solution

```csharp
dotnet run hanoi -Recursive 4
```

The recursive method is in my opinion the best way to solve the Tower of Hanoi. The method use mainly 4 parameters: int nDisks, char startRod, char endRod, char tempRod as the 5 other are mainly used for anmation purpose.

The method first call itself on the same start and end peg. It always remove one disks and when there is only no disk to move we switch the pegs.

```csharp
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
```

#### Implementation
The algorithm follow this steps:

1. We have a shield to return if the number of disks to move is equal to 0.
2. The method call itself with the number of disks minus one.
3. When we reach the shield condition, we break from the first recursive call.
4. We print the movement in the console (or update the stacks to animate)
5. We call the method by switching the pegs.


### Iterative solution
```csharp
dotnet run -Iterative 4
```
This solution is not as performant as the recursive solution. Already using 7 disks you can see some performance difference.

The iterative solution iterate through all the steps with conditional Rod switching.

Important part of the codes:

```csharp
        if (board.MaxDisks % 2 == 0) {
            Pile temp = board.Piles[1];
            board.Piles[1] = board.Piles[2];
            board.Piles[2] = temp;
        }
```
switch the temp and end peg to have the complete tower on the last peg after solving.

```csharp
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
```
iterating throught all the steps and adding specifics every 3 steps.

```csharp
static void MoveDiskBetweenRod(Pile src, Pile dest, int nDisks, Pile[] stacks, HanoiBoardParam board, ConsoleAnimation animObj) {
```
conditional pop and push of the disks regarding disks comparison between dest and src.

#### Implementation

1. Calculate the total number of moves required to solve the Tower of Hanoi problem.
2. Check if the maximum number of disks on any rod is even or odd and switch the second and third rods if it is even.
3. Push all the disks onto the first rod in descending order of size, with the largest disk at the bottom and the smallest disk at the top.
4. Enter a for loop that iterates totalMoves number of times and call the MoveDiskBetweenRod method to move the disks between rods.
5. MoveDiskBetweenRod method pops the top disk from each rod and moves it to the destination rod based on the size of the disk.
6. If a disk cannot be moved to a rod because it is smaller than the top disk on the rod, it is pushed back onto the source rod.
7. If the top disk on the destination rod is smaller than the top disk on the source rod, the top disk on the destination rod is pushed onto the source rod before the top disk on the source rod is pushed onto the destination rod.
8. Call the animObj.DisplayConsole method to update the console display with the new positions of the disks after a disk is moved.
