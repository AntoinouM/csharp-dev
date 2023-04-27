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
I used the graph library we created during class, has the edge

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
1. Item
2. Item, and so forth