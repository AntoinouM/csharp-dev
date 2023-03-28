 
 ### Refactoring of Sorting Algorithms with Interface and Generics


The program takes an input array from the user, sorts it using the selected sorting algorithm, and outputs the sorted array.

The ```SorterInterface<T>```interface defines a Sort method that takes an array of generic type T and sorts it. 

This interface is implemented by two classes ```BubbleSorter<T> and MergeSorter<T>```. Both these classes use the generic type T, which is constrained to implement the ```IComparable<T>``` interface, meaning that the type T can be compared to another object of type T.


#### BubbleSorter

    class BubbleSorter<T> : SorterInterface<T> where T : IComparable<T>
    {
        public void Sort(T[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j].CompareTo(arr[j + 1]) > 0)
                    {
                        T temporaryVariable = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temporaryVariable;
                    }
                }
            }
        }
    }

The ```BubbleSorter<T>``` class implements the ```SorterInterface<T>``` interface and provides an implementation for the Sort method using the bubble sort algorithm. The bubble sort algorithm works by repeatedly swapping adjacent elements in the array if they are in the wrong order until the entire array is sorted.


#### MergeSorter

    class MergeSorter<T> : SorterInterface<T> where T : IComparable<T>
    {
        public void Sort(T[] arr)
        {
            if (arr.Length <= 1)
            {
                return;
            }

            T[][] subarrays = SplitArray(arr);
            T[] left = subarrays?[0] ?? Array.Empty<T>();
            T[] right = subarrays?[1] ?? Array.Empty<T>();

            Sort(left);
            Sort(right);

            T[] result = Merge(left, right);
            Array.Copy(result, arr, arr.Length);
        }

        private T[][] SplitArray(T[] arr)
        {
            int middleOfArray = arr.Length / 2;
            T[][] subarrays = new T[2][];
            subarrays[0] = new T[middleOfArray];
            subarrays[1] = new T[arr.Length - middleOfArray];
            Array.Copy(arr, 0, subarrays[0], 0, middleOfArray);
            Array.Copy(arr, middleOfArray, subarrays[1], 0, arr.Length - middleOfArray);
            return subarrays;
        }

        private T[] Merge(T[] arr1, T[] arr2)
        {
            T[] result = new T[arr1.Length + arr2.Length];
            int i = 0, j = 0, k = 0;

            while (i < arr1.Length && j < arr2.Length)
            {
                if (arr1[i].CompareTo(arr2[j]) < 0)
                {
                    result[k++] = arr1[i++];
                }
                else
                {
                    result[k++] = arr2[j++];
                }
            }

            while (i < arr1.Length)
            {
                result[k++] = arr1[i++];
            }

            while (j < arr2.Length)
            {
                result[k++] = arr2[j++];
            }

            return result;
        }
    }



The ```MergeSorter<T>``` class also implements the ```SorterInterface<T>``` interface and provides an implementation for the Sort method using the merge sort algorithm. The merge sort algorithm works by dividing the input array into two halves, recursively sorting each half, and then merging the sorted halves into a single sorted array.


#### Main Method

    static void Main()
    {
        Console.WriteLine("Enter the data type of the array (int, string, double, etc.):");
        string inputType = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("Enter -sort bubble or -sort merge:");
        string inputSort = Console.ReadLine() ?? string.Empty;

        switch (inputSort)
        {
            case "-sort bubble":
                Console.WriteLine($"You are Bubble sorting {inputType}s. Please enter {inputType}s to sort, separated by commas:");
                string bubbleInput = Console.ReadLine() ?? string.Empty;

                if (inputType.Equals("int", StringComparison.OrdinalIgnoreCase))
                {
                    int[] bubbleArray = Array.ConvertAll(bubbleInput.Split(','), int.Parse);
                    SorterInterface<int> bubbleSorter = new BubbleSorter<int>();
                    bubbleSorter.Sort(bubbleArray);
                    Console.WriteLine("Sorted array:");
                    PrintArray(bubbleArray);
                }
                else if (inputType.Equals("string", StringComparison.OrdinalIgnoreCase))
                {
                    string[] bubbleArray = bubbleInput.Split(',');
                    SorterInterface<string> bubbleSorter = new BubbleSorter<string>();
                    bubbleSorter.Sort(bubbleArray);
                    Console.WriteLine("Sorted array:");
                    PrintArray(bubbleArray);
                }
                else if (inputType.Equals("double", StringComparison.OrdinalIgnoreCase))
                {
                    double[] bubbleArray = Array.ConvertAll(bubbleInput.Split(','), double.Parse);
                    SorterInterface<double> bubbleSorter = new BubbleSorter<double>();
                    bubbleSorter.Sort(bubbleArray);
                    Console.WriteLine("Sorted array:");
                    PrintArray(bubbleArray);
                }
                else
                {
                    Console.WriteLine($"Invalid data type: {inputType}. Please try again.");
                }

                break;

            
        case "-sort merge":
            Console.WriteLine($"You are Merge sorting {inputType}s. Please enter {inputType}s to sort, separated by commas:");
            string mergeInput = Console.ReadLine() ?? string.Empty;

            if (inputType.Equals("int", StringComparison.OrdinalIgnoreCase))
            {
                int[] mergeArray = Array.ConvertAll(mergeInput.Split(','), int.Parse);
                SorterInterface<int> mergeSorter = new MergeSorter<int>();
                mergeSorter.Sort(mergeArray);
                Console.WriteLine("After Sort:");
                PrintArray(mergeArray);
            }
            else if (inputType.Equals("string", StringComparison.OrdinalIgnoreCase))
            {
                string[] mergeArray = mergeInput.Split(',');
                SorterInterface<string> mergeSorter = new MergeSorter<string>();
                mergeSorter.Sort(mergeArray);
                Console.WriteLine("After Sort:");
                PrintArray(mergeArray);
            }
            else if (inputType.Equals("double", StringComparison.OrdinalIgnoreCase))
            {
                double[] mergeArray = Array.ConvertAll(mergeInput.Split(','), double.Parse);
                SorterInterface<double> mergeSorter = new MergeSorter<double>();
                mergeSorter.Sort(mergeArray);
                Console.WriteLine("After Sort:");
                PrintArray(mergeArray);
            }
            else
            {
                Console.WriteLine($"Invalid data type: {inputType}. Please try again.");
            }

            break;

        default:
            Console.WriteLine($"Invalid input: {inputSort}. Please try again.");
            break;
        }
    }

The ```Main method``` starts by asking the user to input the data type and sorting algorithm to use. 
Depending on the user input, the program reads the input array and converts it to the appropriate data type. 

Then, the program creates an instance of the appropriate sorting algorithm and calls the Sort method to sort the input array. 

Finally, the program outputs the sorted array.
