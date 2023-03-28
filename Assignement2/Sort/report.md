# C# Development: Sorting algorithms
## _Sorting an array using Bubble sort and Merge sort_

### Objectives 
Having a Program that sort an array using either Bubble sort or Merge sort regarding the user input:
• Input: $ sort -Bubble “1,4,2,3” or $ sort -Merge “1,4,2,3” 
• Output: $ After Sort: 1 2 3 4

### Entry point: Main
The Entry Point of the Program transfer the numbers to be sorted to the algorithm that the user selected.

```csharp
            // Input: sort -Method -Type "1,2,4,3"
            if (args.Length != 4 || args[0] != "sort" || args[1] != "-Bubble" && args[1] != "-Merge") {
                Console.WriteLine("Please format your request like this:\n sort [-Bubble or -Merge] [1,2,3,4]");
                return;
            }
```
First we 'shield' the execution of the code bay exiting it if the user input doesn't fit the required format. And we provide the desired one.

```csharp
            // Create a new string to put the string with characters from args
            List<string> listToSort = new List<string>();

            foreach(string element in args[args.Length - 1].Split(",")) {
                listToSort.Add(element.Trim());
            }

            ConvertAndRedirect(args[1], listToSort, args[2]);
```
 We create a list of string to call a Converting the string to the selected data type and redirecting to the sorting method picked by the user

```csharp
        static void ConvertAndRedirect<T>(string sortingMethod, List<T> passedList, string dataType) where T : IConvertible {
        // -Bubble or -Merge, array to sort, -Int or -String...

            switch (dataType) {
```
This is done in a switch case.

### Interface

Both my sorting algorithm use the same function. So I created an interface with this method. Both my sorting method extand this interface.

```csharp
    interface SortAlg<T>
   {
        static void StartSort(List<T> stringArg) {}
        static void WriteArrayToTerminal(List<T> sortedList) {}
   }
```

### Generics

As the logic of my methods / algorithms did not change I will here focus on the new Type<T> generic.
This generic type allow us to create method that takes parameter of undefined data type.

```csharp
        class BubbleSort<T>: SortAlg<T> where T : IComparable<T> {
            public static void StartSort(List<T> listToSort)  {
            List<T> sortedList = Bubble(listToSort);
            WriteArrayToTerminal(sortedList);
            }

            private static List<T> Bubble(List<T> listToSort)
```

Here you have an example of the interface and generics usage.
If the user selected the Bubble sorting algorithm, the Converting and directing function will call this StartSort method of my class BubbleSort.

This class extends my interface are all my sorting algorithms use a strartsort and writeArrayToterminal method.

The bubble method return s sorted list regarding the listToSort parameter it was called with.
This listTosort is of type generics and therefore can be called with different data types:
- List<string> listToSort
- List<int> listToSort
- List<double> listToSort

That is provided by the ConvertAndRedirect method.