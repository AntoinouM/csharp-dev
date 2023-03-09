# Data Structure

1. Ways to roganize data

- Different data structures lead to differtent ways to solve a given problem (algorithm)
- Different algorithms ,ay give different efficiency (space and time)

## Algorithms and Application
- Every computer...

## Different datastructure type

### Array / List / Linked List

#### Array
An array has fixed size, usually quicker to research through
A List is better to get item from

- Storing data in a sequential memory location
- Access eahc eleet using integer index
- Very basic, popular and simple
```csharp
Int[] myArray = new int[] {a,b,c,d};
```
- Store the elements in a continous way

##### Array problems
- New insertion and deletion: difficult
- Need to shift to make space for insertion
- Need to fill empty positions after deletion

Two extensions exist: Dynamic Array(=List in C#) and Linked List.

1. Dynamic List (List in C#):
   Takes a long time to add and delete based on the memory allocation

2. Linked List
   - A singely linked list is a concrete datastructure consisting of a sequence of nodes
   - Each nodes stores:
     - element
     - link to the next node from head to tail
     - Each node is a design like this: {data; addresse of next},...
Gives a logical usability of a List but offer more flexibility
Linked list is not implemented in C#. it is doubled linked list that is the same but like this:
head - {address of previous; data; address of next} - {} - {} - ... - trailer

### Stack and Queue

## Stack
A stack is a list of elements under the LIFO law to remove element (pile of dished: add on top, remove from top)
Push to add, pop to remove.

#### Queue
List of elements with FIFO