<!-- ABOUT THE PROJECT -->
## About The Project
Third assignement of the C# development class. Implementation of Dijkstra's algorithm.
Find the shortest path between two vertices in a weighted graph that does not contain negative edge.


### Built With

* [![Visual Studio Code]][[https://code.visualstudio.com/]
* [!.NET][https://dotnet.microsoft.com/en-us/]


<!-- GETTING STARTED -->
### Prerequisites

* Having an IDE
* Having .NET 6.0 SDK installed <!-- link in Built with above -->
    * if .NET is installed, use the command 'dotnet --list-sdks' to check your version.

### Installation

1. Download the source file (.zip file)
2. Extract the code
3. Open the folder that contain the extracted code in your IDE
<!-- The next step are for VS code, if you use another IDE please refer to the documentation -->
4. Open a new terminal for the project Terminal > New Terminal.


<!-- USAGE EXAMPLES -->
## Usage

This Program is a built as a simple library to represents shapes (cylinders, cuboids and tetrahedrons) in a 3D space with attached methods to calculate related propreties.

Your input would be 'dotnet run' and the program will display all the result of the search in the terminal and save it in the file: output.txt

Prior to running the program you need to have/modify the input.txt like so:
Put all your edges in this format: "vertexName1, vertexName2, weight" (space doesn't matter)
and specify  source: "from: exampleName" and a target: "to: xx".

If you chose to leave the target blank: "to:  ", then every path from the source will be returned.

Example of input.txt:
```
v0,v7,8
v1,v2,8
v1,v7,11
v2,v3,7
v2,v5,4
v2,v8,2
v3,v4,9
v3,v5,14
v4,v5,10
v5,v6,2
v6,v7,1
v6,v8,6
v7,v8,7

from: v0
to: 
```

<!-- ROADMAP -->
## Roadmap

- [ ] A library for graph.
    - [ ] A Vertex class with generic proprieties
    - [ ] An Edge class with generic proprieties
    - [ ] A Graph class with methods related to creation
    - [ ] Dijkstra's algorithm

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

* [GeeksForGeeks](https://www.geeksforgeeks.org/dijkstras-shortest-path-algorithm-greedy-algo-7/)
* [StackOverflow](https://stackoverflow.com/)
    * [User:][shingo](hhttps://stackoverflow.com/users/6196568/shingo)
    * [User:][JonasH](https://stackoverflow.com/users/12342238/jonash)
