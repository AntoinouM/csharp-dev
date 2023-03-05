using System;

namespace Assignement1 // Note: actual namespace depends on the project name.
{

/*
Having a program that output "After Sort: 1 2 3 4" with input " $ sort -Bubble “1,4,2,3” or $ sort -Merge “1,4,2,3”.
Need a main program with args.Length == 2; args[0] == -Bubble || -Merge; args[1] == array or list to sort
Main = check args and output right method or format hint. Check types of data of args. !!!!!!!
static void Bubble method is called regarding args[0] || static void Merge is called
This two methods take int? as parameters.
 */

    internal class Program
    {
        static System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
        // Main function to sort the args
        static void Main(string[] args)
        {
            /*
            foreach (var arg in args)
            {
                Console.WriteLine(arg + " Type: " + arg.GetType());
            }
            */
            // Shield: if args.Lenght != 2 || args0 != Bubble && args0 != Merge -> Format hint
            // if args[0] == "-Bubble" ... (check args[1] datatype?) then => Bubble(args[1])
            //  else if args[0] == "-Merge" ... (check args[1] datatype?) then => Merge(args[1])
            if (args.Length != 2 || args[0] != "-Bubble" && args[0] != "-Merge") {
                Console.WriteLine("Please format your request like this:\n[-Bubble or -Merge] [1,2,3,4]");
                return;
            }

            int[] numbers = args[1].Split(',').Select(int.Parse).ToArray<int>();
            /*
            foreach (int number in numbers) {
                Console.WriteLine(number);
            }
            */
            if (args[0] == "-Bubble") {
                Bubble(numbers);
            }
            else {
                Merge(numbers);
            }

        }

        // Bubble takes int and sort the array with the Bubble method
        static void Bubble(int[] numbers)
        {       
            watch.Start();
            
            // code to execute
            // compare each vallue to the direct neigbhor. Repeat until each value in order.
            // create a boolean that change when no swap needed == sorting finished
            bool hasChanged = true;
            int temp = 0;
            do {
                hasChanged = false;
                for (int i = 1; i < numbers.Length; i++) {
                    if (numbers[i-1] > numbers[i]) {
                        temp = numbers[i];
                        numbers[i] = numbers [i-1];
                        numbers[i-1] = temp;
                        hasChanged = true;
                    } 
                }
            } while (hasChanged == true); 
            Console.WriteLine("After sort: " + "[{0}]", string.Join(", ", numbers));

            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        // Merge takes int and sort the array with the Merge method
        static void Merge(int[] numbers)
        {      
            watch.Start();
            
            // code to execute
            Console.WriteLine("Merge");

            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        }
    }
}