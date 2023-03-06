using System;

namespace Class3 // Note: actual namespace depends on the project name.
{

    internal class Program
    {
    //     static void Main(string[] args)
    //     {
    //         int number = Convert.ToInt32(args[0]);

    //         if (_isEven(number)) {
    //             DivideByTwo(number);
    //         } else {
    //             TripleAddOne(number);
    //         }

    //         int[] numbers = Enumerable.Repeat(1, Convert.ToString(number)).ToArray();

    //         while (number > 1) {
    //             Console.WriteLine("Current number: " + number);
    //             Main(numbers);
    //         }
    //     }
        

    //     static int DivideByTwo(int num) {
    //         num = num / 2;

    //         return num;
    //     }

    //     static int TripleAddOne(int num) {
    //         num = (num * 3) + 1;

    //         return num;
    //     }
    //     static bool _isEven(int num) {
    //         bool isEven = true;
    //         if(num % 2 == 0) {
    //             isEven = true;
    //         } else {
    //             isEven = false;
    //         }
    //         return isEven;
    //     }

    static System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
     static void Main(string[] args)
        {
            Console.WriteLine(args[0]);
            if(args.Length != 2 || args[0] != "Recursive" && args[0] != "Iterative") {
                Console.WriteLine("please use: dotnet run [Recursive || Iterative] [number of steps]");
                return;
            }

            int steps = Convert.ToInt32(args[1]);

            if (args[0] == "Recursive") {
                FiboRecursive(0, 1, steps);
            } else {
                FiboIterative(steps);
            }

        }

    static void FiboRecursive(int num1, int num2, int steps) {
        watch.Start();

    if (steps == 0) {
        Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        return;
    }
        int newNum = num1 + num2;
        Console.WriteLine("new num: " + newNum);
        FiboRecursive(num2, newNum, --steps);
        watch.Stop();
    }

    static void FiboIterative(int num) {
        watch.Start();

        int newNum1 = 0;
        int newNum2 = 1;
        for (int i = 1; i <= num; i++) {
            int newNum = newNum1 + newNum2;
            Console.WriteLine(newNum);
            newNum1 = newNum2;
            newNum2 = newNum;
        }

        watch.Stop();
        Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
    }

    }
}