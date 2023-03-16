# Code Review Report
Course: C# Development SS 2023 (4 ECTS, 3 SWS)

Student ID: cc211036

BCC Group: 2

Name: Antoine Muneret

#

### General Questions

- The name of the student you are reviewing: Patrick Piterle

- I could run the code by myself with no difficulty.

- The code output a sorted array.

- The requirements are fulfilled.

- The logic is quite clear and the variables are well named.

### A Short Summary about the codes you reviewed: 
This code is a program to sort arrays with the Bubble and Merge algorithms. The user input the algorithm he wants to use and the array he wants to sort in the entry point (Main). 
The Bubble sort is iterative and is composed of two 'For' loops and one conditional operation. It takes every entry, compare it to the next one and swap them if needed.
The Merge sort is first recursive. There is a first part: MergeSort that split the array in two and call itself on both halves. When the array can't be split (in the code it is done by exiting the function if the the first index is not smaller than the right one: if array length = 1). When the array is length 1, then it call Merge to compare both array and merge them in a sorted way. Then it repeats until all broke-down array had been sorted.

### Comments to Your Colleague
#### Strength:
(List down and explain the good parts of the codes. Please explain in detail.)
1. I like that the bubble sort is using two for loop. That allow to skip one step considering that the last item of the array is always the highest number after the first iteration.
2. The Merge sort is well organised by separating the array spliting and the array sorting.

#### Major Weakness:
(List down and explain major issues. Do you have a better solution? Please explain in detail.)
1. No major weakness found.

#### Minor Weakness:
(List down and explain minor issues. Please explain in detail.)
1. In the entry points,  is there is a wrong input or an error no information is passed to the user. A 'shielding codition' that return an information to the user of how to use the program with the correct input format and arguments lenght would be a nice help.


### Reflections on Your Own Codes:
(List down and explain what you have learned from your colleague’s codes and what you should pay attention to when writing codes next time.)
1. Even if it is a small improvement my Bubble alogirthm could be optimized by not using a variable to exit the loop but by using two for loops and saving one step.
2. For a small code like this, I still prefer to have all my code in one main function so I don't have to scroll to understand my logic.