# Code Review Report
Course: C# Development SS 2023 (4 ECTS, 3 SWS)

Student ID: cc211036

BCC Group: B

Name: Antoine Muneret

#

### General Questions

- The name of the student you are reviewing: Hannah Schick - cc211012

- Did you run the code successfully? Did you run the code without problems by yourself, or did you get help from your colleague?
  Yes the code worked on first attempt. I just add to delete the obj and bin folders as it was provided in the zip.

- Is the output of the code correct?
  The output part is correct but the animation is upside down

- Did the codes you are reviewing fulfill all requirements specified in the assignment?
  The code fulfill al the requirement. Output the steps (by printing in the console) or by animating the movement in ASCII art in the console.

- Do you understand the code logic and variables used?
  Most of the variables are clear and the name is well chosen. The constant MAX_DISKS is used for the rodWtih paramter in createRod method while a ROD_WIDTH constant exsits. Could be confusing.

### A Short Summary about the codes you reviewed: 
The code is a straightforward algorithm that offer two different methods to solve the Tower of Hanoi puzzle. Both method are very smilirar to my approach.
I think the use of classes and splitting functions into smaller one could make the code more readable.
The use of classes could also make the code reusable and create a logic between an object and its methods.

### Comments to Your Colleague
#### Strength:
(List down and explain the good parts of the codes. Please explain in detail.)
1. Straight-forward and concise solution
2. Some of the method are split into smaller one. Which make it easier to read.

#### Major Weakness:
(List down and explain major issues. Do you have a better solution? Please explain in detail.)
1. Commenting: It would be easier to understand with more precise comment as it is hard to understand it without prior knowledge in this puzzle
2. Some methods could be split for more readability. For example the printRod method could seperate with a part generating the disks and another for printing the rods. This would help with maintaining the code.

#### Minor Weakness:
(List down and explain minor issues. Please explain in detail.)
No minor weakness found.


### Reflections on Your Own Codes:
(List down and explain what you have learned from your colleague’s codes and what you should pay attention to when writing codes next time.)
1. I could also comment my code better.
2. I think my code is longer but would be easier to maintain due to use of classes.