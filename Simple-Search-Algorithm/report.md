# C# Development: Sorting algorithms
## _Sorting an array using Bubble sort and Merge sort_

### Objectives 
Having a Program that sort an array using either Bubble sort or Merge sort regarding the user input:
• Input: $ sort -Bubble “1,4,2,3” or $ sort -Merge “1,4,2,3” 
• Output: $ After Sort: 1 2 3 4

### Entry point: Main
The Entry Point of the Program transfer the numbers to be sorted to the algorithm that the user selected.

```csharp
if (args.Length != 3 || args[0] != "sort" || args[1] != "-Bubble" && args[1] != "-Merge") 
{
   Console.WriteLine("Please format your request like this:\n sort [-Bubble or -Merge] [1,2,3,4]");
   return;
}
```
First we 'shield' the execution of the code bay exiting it if the user input doesn't fit the required format. And we provide the desired one.

```csharp
int[] numbers = args[2].Split(',').Select(int.Parse).ToArray<int>();

if (args[1] == "-Bubble") {
    Bubble(numbers);
} else {
    Merge(numbers);
}
```
Then, after converting the string parameter given by the user, we pass this array to the algorithm define as parameter 2 (args[1]).

```csharp
WriteArrayIntoTerminal(numbers, true);

static void WriteArrayIntoTerminal(int[] array, bool sort) {
    if (sort == true) {
        Console.WriteLine("After sort: " + "{0}", string.Join(" ", array));
    } else {
        Console.WriteLine("{0}", string.Join(" ", array));
    }
}
```

We then print the sorted in the terminal using the method WriteArrayIntoTerminal. We can ignore the second parameter as it was use for testing.
Output:
>After sort: 1 2 3 4

### Bubble sort

```csharp
dotnet run sort -Bubble 1,2,3,4
```

Bubble Sort is the simplest sorting algorithm that works by repeatedly swapping the adjacent elements if they are in the wrong order.

Bubble sort is an iterative way of sorting an array. It compares the first two values, swap then if necessary, the compares the second and third value. This operation are repeated until the array is sorted.

For the implementation I needed two variable:
• hasChanged: a boolean that will serve as exit condition of my while loop.
• temp: an integer value that will store temporarly the value of an item of the array to allow the swapping.

```csharp
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
```

#### Implementation
The algorithm follow this steps:

1. We first attribute the value false to the hasChanged boolean at the start of each iteration.
2. We call a For loop that will repeat for n times regarding the array to sort has n entries. Note that we start with an index 1, so we will start at the second entry of the array.
3. We check if the values need to be swapped.
4. If we need to sawp, we swap them using the temp variable and we change the boolean hasChanged to true. If we don't need to swap we go to the next values.
5. We repeat this until no item need to be swap. Then the hasChanged boolean doesn't change to true.
6. The exit condition is reached and we then exit the loop.


### Merge sort
```csharp
dotnet run sort -Bubble 1,2,3,4
```
Merge sort is a sorting algorithm that works by dividing an array into smaller subarrays, sorting each subarray, and then merging the sorted subarrays back together to form the final sorted array. One of the main advantages of merge sort is that it has a time complexity of O(n log n), which means it can sort large arrays relatively quickly. 

This algorithm is recursive. It first divide the array into two arrays after calculating the middle point. It then call this method on each side until the arrays' lenght is 1.

```csharp
static int MiddlePoint(int lenght) {
    int result = 0;
        if (lenght % 2 == 0) {
            result = lenght / 2;
         } else {
            result = (lenght + 1) / 2;
            }
    return result;
}
```

```csharp
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
```

#### Implementation

1. We check if the array is divisable by checking if the lenght is 1. If yes, we break from the code. If not, continue to step 2.
2. We calculate the middle point of the array using the MiddlePoint method.
3. We create a left array and a right array with thr right dimensions.
4. We use Array.Copy to intiate the value of each array.
5. We call the method on left array and right array. Each time, left array will be divided and create a temporary right array. When the left array reach the length of 1. We exit the recursive call on left and switch to the last temp value of the right array. This will create a new left array.
6. When both array (left and right) have a length of 1. Values are compared and merged in the right order.
7. The first while loop compare the value and increment the original array the smallest one.
8. The two following while add the leftovers to the array.

The output is a sorted list of numbers in this format:
```
This is your sorted array: 
“1 2 3 4”
```