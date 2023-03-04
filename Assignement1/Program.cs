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
        // Main function to sort the args
        static void Main(string[] args)
        {
            foreach (var arg in args)
            {
                Console.WriteLine(arg + " Type: " + arg.GetType());
            }
            // Shield: if args.Lenght != 2 || args0 != Bubble && args0 != Merge -> Format hint
            // if args[0] == "-Bubble" ... (check args[1] datatype?) then => Bubble(args[1])
            //  else if args[0] == "-Merge" ... (check args[1] datatype?) then => Merge(args[1])
            if (args.Length != 2 || args[0] != "-Bubble" && args[0] != "-Merge") {
                Console.WriteLine("Please format your request like this: \nI [-Bubble or -Merge] [1,2,3,4]");
                return;
            }

            int[] numbers = args[1].Split(',').Select(int.Parse).ToArray<int>();
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

        }

        // Merge takes int and sort the array with the Merge method
        static void Merge(int[] numbers)
        {
            
        }
    }
}