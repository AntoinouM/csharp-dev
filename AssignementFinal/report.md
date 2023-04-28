# Code Review Report
Course: C# Development SS 2023 (4 ECTS, 3 SWS)

Student ID: cc211036

BCC Group: B

Name: Antoine Muneret

Your Project Topic: Dijkstra’s Algorithm

#

### A Short Summary about the Algorithm (What is the Background and the Motivation of having such an algorithm?): 
The motivation behind the algorithm is to find the most efficient route between two points in a graph, such as finding the shortest route between two cities on a map. The algorithm works by maintaining a set of visited nodes and distances from the starting node to all other nodes in the graph, continually updating the distances as it explores the graph.

Dijkstra's algorithm is widely used in network routing protocols, transportation planning, and many other applications that involve finding the shortest path in a graph.

### Implementation Detail
I used the graph library we created during class, as the edge are weighted positiviely I added **uint weight** to the proprieties.
```csharp
    public uint Weight;
```

Concerning my implementation of Dirjkstra, I chose to create a method (non-static) that must be called on an instance of graph and that return a Dictionary<TKey, TValue> to have for each graph a 'dist', 'path', 'source' and 'target' -if provided-.

```csharp
public Dictionary<string, string>? Dijkstra(string startName, string endName) {

    Dictionary<string, string> DijkstraDic = new Dictionary<string, string>();
    string pathStr = "";

    // Find the starting vertex
    Vertex<TVertex>? startVertex = HasVertex(startName);
    if (startVertex == null) {
        Console.WriteLine("Starting vertex not found.");
        return null;
    }

    // Find the ending vertex
    Vertex<TVertex>? endVertex = HasVertex(endName);
    if (endVertex == null) {
        Console.WriteLine("Ending vertex not found.");
    }
    DijkstraDic.Add("source", startVertex.Property.Name); //create an entry source in the dictionary to be returned

    if (endVertex != null) {
        DijkstraDic.Add("target", endVertex.Property.Name); // create a target entry if target declared
    }

    // create dictionary to store Vertex-bool
    Dictionary<Vertex<TVertex>, bool> boolDic = new Dictionary<Vertex<TVertex>, bool>();
    for (int i = 0; i < _nVertices; i++) {
        boolDic.Add(_vertices.ElementAt(i), false);
    }
    
    // create dictionary to store Vertex-int (dist)
    Dictionary<Vertex<TVertex>, uint> distDic = new Dictionary<Vertex<TVertex>, uint>();
    for (int i = 0; i < _nVertices; i++) {
        distDic.Add(_vertices.ElementAt(i), int.MaxValue);
    }
    
    // set the distance of startVertex to itself to 0
    distDic[startVertex] = 0;
 
    // Create a Parent array of Vertices that store an ID
    Dictionary<Vertex<TVertex>, Vertex<TVertex>?> parentDic = new Dictionary<Vertex<TVertex>, Vertex<TVertex>?>();
    for (int i = 0; i < _nVertices; i++) {
        parentDic.Add(_vertices.ElementAt(i), null);
    }
```
The method return a Dictionary. This is a personal choice that I made in order to facilitate the generation of an output.txt.

At first I decided to create my own struct to generate an array of it to store my visitedList and my distanceList. But after trying and researching I decided to use dictionary, to improve performances.

There are 3 Dictionary entries:
```csharp
Dictionary<Vertex<TVertex>, bool> boolDic
Dictionary<Vertex<TVertex>, uint> distDic
Dictionary<Vertex<TVertex>, Vertex<TVertex>?> parentDic
```
These allow me to store and update values for my vertices.

The important part of the code is the following:
```csharp
    // Iterate through all the vertices in the graph
    for (int count = 0; count < _nVertices; count++) {
        Vertex<TVertex> vertexWithMinimumDistance = returnVertexWithMinDistance(boolDic, distDic)!;
        uint minDistance = distDic[vertexWithMinimumDistance];

        boolDic[vertexWithMinimumDistance] = true;

        if (endVertex != null) {
            System.Console.WriteLine(boolDic[endVertex]);
            if (boolDic[endVertex]) {
                // add distance
                DijkstraDic.Add("dist", distDic[endVertex].ToString());

                // add path
                printPath(parentDic, endVertex);
                DijkstraDic.Add("path", pathStr);
                return DijkstraDic;
            }
        }

    // loop for all vertices that are neighbors
        for (int vertexCount = 0; vertexCount < _nVertices; vertexCount++) {
            Vertex<TVertex> currentVertex =  _vertices.ElementAt(vertexCount);
            Edge<TEdges>? currentEdge = returnEdge(vertexWithMinimumDistance, currentVertex);
            bool tempBool = boolDic[currentVertex];
            uint tempDistance = distDic[currentVertex];

            if (!tempBool && // if vertices has not been 'approved' before
                currentEdge != null && // if nodes are connected
                minDistance != int.MaxValue && // if the distance has already been updated
                minDistance + currentEdge.Property.Weight < tempDistance // if distance from previous + edge < distance marked for current
                ) { // update
                    parentDic[currentVertex] = vertexWithMinimumDistance;
                    distDic[currentVertex] = minDistance + currentEdge.Property.Weight;
            }
        }     
    }
    printSolution(distDic, parentDic, startVertex);
```

In this bloc of code, I Iterate through all my vertices, each time, I returned the vertex with the minimum distance from my source that has not been 'approved' yet, using the helper function returnVertexWithMinDistance. This function will be detailed later.
I then 'aprove' that vertex in order to not return it at the next iteration.

I then have a conditional statement, that return a different result if a target vertex has been provided and found. This allow me to only print the path and distance between the source Vertex and Target Vertex.

I then iterate through all the neigbor vertices (that share an edge) and update their distance regarding the value of it and the 'approve' status.

```csharp
    // This helper function is used to find the vertex with the minimum distance from the start vertex that has not been marked as visited
    Vertex<TVertex>? returnVertexWithMinDistance(Dictionary<Vertex<TVertex>, bool> boolDic, Dictionary<Vertex<TVertex>, uint> distDic) {
        
        uint min = uint.MaxValue; // initialize to max value
        Vertex<TVertex>? vertexWithMinDistance = null; // initialize as null

        // Loop through all vertices
        for (int i = 0; i < _nVertices; i++) {
            bool tempBoolean = boolDic[_vertices.ElementAt(i)];
            uint tempDist = distDic[_vertices.ElementAt(i)];
            
            if (tempBoolean == false && tempDist <= min) { //if vertex has not been 'approved' and distance inferior than min dist
                min = tempDist; // update min dist
                vertexWithMinDistance = _vertices.ElementAt(i); // update vertex
            }
        }
        return vertexWithMinDistance;
    }
```

This function has the only aim to return a Vertex that has not been approved yet with the shortest distance in the set.

When all the vertices has been 'approved', all the distances has been updated to the minimum possible to reach that target.

I then call some helper functions to print/generate my result:
```csharp
    void printSolution( Dictionary<Vertex<TVertex>, uint> distDic, 
                        Dictionary<Vertex<TVertex>, Vertex<TVertex>?> parentDic, 
                        Vertex<TVertex> startVertex)
                        {...}

    void printPath(Dictionary<Vertex<TVertex>, Vertex<TVertex>?> parentDic , 
                Vertex<TVertex>? currentVertex) 
                {... }
```
These two helpers methods just update my Dictionary dijsktra that is return by the method. They are not rocket science but they work well, and there is a nice use of recursive for the printPath.




#### Implementation Logic Explanation:
Dijkstra pseudo code:
```
  function Dijkstra(Graph, source, target):
      
    create an array to hold distance // initialize to INFINITY for later comparison
    create an array to hold if Node has been pproved // initialize all to FALSE
    all array are dimension of *number of vertices*

    update distance[source] = 0 // distance to itself

    For all vertices:
        pick the vertex 'minDistVertex' with minimum distance that has not been aproved
        approve it    

        
        for each neighbor vertex of minDistVertex still not approved:
            distance ← dist[minDistVertex] + Edge(minDistVertex, neighborVertex)
            if distance < dist[neighbor vertex]:
                dist[neighbor vertex] ← distance
    return distance[]
```

#### Achievements:
(List down and explain what achievements you are proud of (e.g., features, techniques, etc.) in the project. Please explain in detail.)
1. I am proud that I could reused the code from the class and adapt it to implement Dijsktra
2. Generate output from input

### Learned Knowledge from the Project
I deepthen my knowledge in data structure (MinHeap), Generic collection (Dictionary) and collection (Hastable).

#### Major Challenges and Solutions:
(List down and explain the major challenges. Did you solve it? How? Please explain in detail.)
1. No major challenge has been encountered

#### Minor Challenges and Solutions:
(List down and explain the minor challenges. Did you solve it? How? Please explain in detail.)
1. Generate code from an input.txt. 
2. Chose the right structure and formating for ma data to improve performance
3. Understand the pattern of Dijsktra

### Reflections on the Own Project:
(List down and explain what you could improve and add if you have more time.)
1. I think a better way to implement this algorithm would be to implement a minHeap.
2. I wonder how I could return Dijsktra's algorithm findings to optimise its use

### Reflections on the Projects learned during the Presentation:
(List down and explain what you have learned from your colleague’s codes and what you should pay attention to when writing codes next time.)
1. Adjency list is a better approach that adjency matrix in term of results
2. Data structure such as queue are more useful than I thought. I did discover a use case for this and it change my approach of my own code.


We discussed in class that having an infinity edge could create an infinity loop.
I do believe that in my implementation that would not happen has each vertex is visited/approved in each iteration (first for loop). So in my code it would only return the wrong path.
In any case you can not provide a negative value for a Weight as it require a uint type.