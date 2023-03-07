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
            // Shield: if args.Lenght != 2 || args0 != Bubble && args0 != Merge -> Format hint
            // if args[0] == "-Bubble" ... (check args[1] datatype?) then => Bubble(args[1])
            //  else if args[0] == "-Merge" ... (check args[1] datatype?) then => Merge(args[1])
            if (args.Length != 3 || args[0] != "sort" || args[1] != "-Bubble" && args[1] != "-Merge") {
                Console.WriteLine("Please format your request like this:\n sort [-Bubble or -Merge] [1,2,3,4]");
                return;
            }

            int[] numbers = args[2].Split(',').Select(int.Parse).ToArray<int>();

            if (args[1] == "-Bubble") {
                Bubble(numbers);
            }
            else {
                Merge(numbers);
            }
            
            WriteArrayIntoTerminal(numbers, true);
        }

        // Bubble takes int and sort the array with the Bubble method
        static void Bubble(int[] numbers)
        {       
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
            } while (hasChanged); 
        }

        // Merge takes int and sort the array with the Merge method
        static void Merge(int[] numbers)
        {                  
            if (numbers.Length <= 1) { // break the Merge method when array <= 1
                return;
            }
            
            // divide the array until undivisable. need left index, right index, middle index. 
            int middle = MiddlePoint(numbers.Length);
            int[] left = new int[middle]; // create a new array with [middle.ceiled - left] entries (all = 0)
            int[] right = new int[(numbers.Length + 1) - (middle + 1)];
            Array.Copy(numbers, left, left.Length); // initiate the value of left array with origin array
            Array.Copy(numbers, middle, right, 0, right.Length);

            Merge(left); //iterate for left subarray until left array is one
            Merge(right);

            int leftIndex = 0, rightIndex = 0, numbersIndex = 0; // initiating the index each iteration
            while(leftIndex < left.Length && rightIndex < right.Length) {
                if (left[leftIndex] < right[rightIndex]) {
                    numbers[numbersIndex++] = left[leftIndex++];
                } else {
                    numbers[numbersIndex++] = right[rightIndex++];
                }
            }

            //adding leftover
            while(leftIndex < left.Length) {
                numbers[numbersIndex++] = left[leftIndex++];
            }
            while(rightIndex < right.Length) {
            numbers[numbersIndex++] = right[rightIndex++];
            }

            static int MiddlePoint(int lenght) {
                int result = 0;
                if (lenght % 2 == 0) {
                    result = lenght / 2;
                } else {
                    result = (lenght + 1) / 2;
                }
                return result;
            }
        }

        static void WriteArrayIntoTerminal(int[] array, bool sort) {
            if (sort == true) {
                Console.WriteLine("After sort: " + "{0}", string.Join(" ", array));
            } else {
                Console.WriteLine("{0}", string.Join(" ", array));
            }
        }
    }
}