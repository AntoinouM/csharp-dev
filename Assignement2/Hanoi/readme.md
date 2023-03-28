<!-- ABOUT THE PROJECT -->
## About The Project
First assignement of the C# development class. Introduction to algorithms and classes through solving the Tower of Hanoi puzzle recursively or Iteratively.


### Built With

* [![Visual Studio Code]][[https://code.visualstudio.com/]
* [!.NET][https://dotnet.microsoft.com/en-us/]


<!-- GETTING STARTED -->
### Prerequisites

* Having an IDE
* Having .NET 6.0 SDK installed <!-- link in Built with above -->
    * if .NET is installed, use the command 'dotnet --list-sdks' to check your version.
* Not mixing Durian with Blue cheese on a pizza (or anywhere).
* Liking ASCII almost art.

### Installation

1. Download the source file (.zip file)
2. Extract the code
3. Open the folder that contain the extracted code in your IDE
<!-- The next step are for VS code, if you use another IDE please refer to the documentation -->
4. Open a new terminal for the project Terminal > New Terminal.


<!-- USAGE EXAMPLES -->
## Usage

This Program is used to solve and print the solving steps of the puzzle Tower of Hanoi with 'n' disks.

You input your number and the method you prefer like this:

dotnet run hanoi -Recursive 4 {and -animation if you want to display animations}
or
dotnet run hanoi -Iterative 4 {and -animation if you want to display animations}

You will see in the console:
- if you pass the parameter -animation and the number of disks is lower than 6.
  - An ASCII animation of disks mouvement.

- if you do not pass the -animation parameter
  - A print of the steps 


<!-- ROADMAP -->
## Roadmap

- [ ] A Program to sort numbers in ascending order
    - [ ] Bubble sort algorithm
    - [ ] Merge sort algorithm

See the [github repo](https://github.com/AntoinouM/csharp-dev) for a full overview of the code.


<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please open an issue with the tag "enhancement".

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request


<!-- LICENSE -->
## License

Distributed under the MIT License.


<!-- CONTACT -->
## Contact

Antoine Muneret - antoine.muneret@hotmail.fr
Project Link: [https://github.com/AntoinouM/csharp-dev](https://github.com/AntoinouM/csharp-dev)

<!-- ACKNOWLEDGMENTS -->
## Acknowledgments

* [wikipedia](https://en.wikipedia.org/wiki/Tower_of_Hanoi)
* [GeeksforGeeks](https://www.geeksforgeeks.org/c-program-for-tower-of-hanoi/)
* [StackOverflow](https://stackoverflow.com/)
    * [User:][Mong Zhu](https://stackoverflow.com/users/5174469/mong-zhu)
