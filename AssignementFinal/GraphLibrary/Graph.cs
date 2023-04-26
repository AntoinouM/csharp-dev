using System.Collections.Generic;

namespace GraphLibrary;

public class Graph <TVertex, TEdges> 
where TVertex: BasicVertexProperty, new()
where TEdges: BasicEdgeProperty, new()
{
    struct helperType<T> where T : IComparable {
        public Vertex<TVertex> vertexValue;
        public T value;

        public helperType(Vertex<TVertex> vertex, T givenValue) {
            vertexValue = vertex;
            value = givenValue;
        }

    }
    // Fields
    // The vertex/edge lists in the graph
    private LinkedList<Vertex<TVertex>> _vertices;
    private LinkedList<Edge<TEdges>> _edges;

    //private Dictionary<int, Vertex<T1>> _vertices; // better access methods, just bind an ID to a vertex! better?

    // The number of vertices and edges
    private int _nVertices;
    private int _nEdges;

    // Constructors
    public Graph() 
    {
        _vertices = new LinkedList<Vertex<TVertex>>();
        _edges = new LinkedList<Edge<TEdges>>();
        _nVertices = 0;
        _nEdges = 0;

    }

    // Methods
        // Vertex
        public int AddVertex(string name) {
            if (HasVertex(name) != null) {
                return 0;
            }

            Vertex<TVertex> v = new Vertex<TVertex>(_nVertices, name);
            _vertices.AddLast(v);
            _nVertices++;
            return _nVertices-1;
        }

        public Vertex<TVertex>? HasVertex(string name) {
            for (int i = 0; i < _vertices.Count; i++) {
                if (_vertices.ElementAt(i).Property.Name == name) {
                    return _vertices.ElementAt(i);
                }
            }
            return null;
        }

        // Function overload same one with different parameter
        public Vertex<TVertex>? HasVertex(int id) {
            for (int i = 0; i < _vertices.Count; i++) {
                if (_vertices.ElementAt(i).Property.Id == id) {
                    return _vertices.ElementAt(i);
                }
            }
            return null;
        }

        public void RemoverVertex(string name) {
            Vertex<TVertex>? v = HasVertex(name);

            if (v == null) {return;}

            // remove adjacent edges
            bool allChecked = false;
            while(!allChecked) {
                 allChecked = true;
                 for (int i = 0; i < _edges.Count; i++) {
                    //check if source Id or Target Id
                    if (_edges.ElementAt(i).Property.SourceId == v.Property.Id || _edges.ElementAt(i).Property.TargetId == v.Property.Id) {
                        _edges.Remove(_edges.ElementAt(i));
                        _nEdges--;
                        allChecked = false;
                    }
                 }

                 // Remove vertex
                 _vertices.Remove(v);
                 _nVertices--;
            }
        }

        // Edge
        public void AddEdge(int sourceId, int targetId, int weight) {
            Edge<TEdges>? e = HasEdge(sourceId, targetId);

            if (e == null) {
                Vertex<TVertex>? sourceV = HasVertex(sourceId);
                Vertex<TVertex>? targetV = HasVertex(targetId);

                if (sourceV == null || targetV == null) {
                    Console.WriteLine("Source or target vertex could not be found.");
                    return;
                }

                Edge<TEdges> newE = new Edge<TEdges>(_nEdges, sourceId, targetId, weight);
                _edges.AddLast(newE);
                _nEdges++;
            }
        }

        public Edge<TEdges>? HasEdge(int sourceId, int targetId) {

            for (int i = 0; i < _edges.Count; i++) {
                if ( (_edges.ElementAt(i).Property.SourceId == sourceId) && (_edges.ElementAt(i).Property.TargetId == targetId)) {
                    return _edges.ElementAt(i);
                }
            }
            return null;
        }

        public void RemoveEdge(int sourceId, int targetId) {
            Edge<TEdges>? e = HasEdge(sourceId, targetId);

            if (e != null) {
                _edges.Remove(e);
                _nEdges--;
            }
        }

        // Graph
    public void PrintGraph()
    {
        Console.WriteLine("The total number of vertices is " + _nVertices);
        Console.WriteLine("The total number of edges is " + _nEdges);
        Console.WriteLine("============================================");

        // Vertex list
        for(int i = 0; i < _vertices.Count; i++) {
            System.Console.WriteLine($"V({_vertices.ElementAt(i).Property.Id}) = {_vertices.ElementAt(i).Property.Name}");
        }
        Console.WriteLine("============================================");

        // Vertex list
        for(int i = 0; i < _edges.Count; i++) {
            System.Console.WriteLine($"E({_edges.ElementAt(i).Property.Id}) = V{_edges.ElementAt(i).Property.SourceId}) -- V({_edges.ElementAt(i).Property.TargetId})");
        }
    }

  
public string[]? Dijkstra(string startName, string endName) {
    string[] displayedText = new string[3];
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
        return null;
    }

    // create and initialize a boolena array 
    helperType<bool>[] boolArr = new helperType<bool>[_nVertices];
    for (int i = 0; i < _nVertices; i++) {
        boolArr[i] = new helperType<bool>(_vertices.ElementAt(i), false);
    }

    // create and initialize a dtstance array
    helperType<int>[] distArr = new helperType<int>[_nVertices];
    for (int i = 0; i < _nVertices; i++) {
        distArr[i] = new helperType<int>(_vertices.ElementAt(i), int.MaxValue);
    }
    
    // set the distance of startVertex to itself to 0
    ChangeArray<int>(distArr, startVertex, 0);

    // Create a Parent array of Vertices that store an ID
    helperType<int>[] parrentArr = new helperType<int>[_nVertices];
    for (int i = 0; i < _nVertices; i++) {
        parrentArr[i] = new helperType<int>(_vertices.ElementAt(i), -1); // all ID are instanciate to -1
    }

    for (int count = 0; count < _nVertices - 1; count++) {
        Vertex<TVertex> vertexWithMinimumDistance = returnVertexWithMinDistance(boolArr, distArr);
        helperType<int>? verMinDistHT = returnedHelperType<int>(distArr, vertexWithMinimumDistance)!;

        ChangeArray<bool>(boolArr, vertexWithMinimumDistance, true);
        if (returnedHelperType<bool>(boolArr, endVertex)!.Value.value) {
            // write headers
            //Console.Write("Vertex \t\t Distance from Source \t\t Path\n");
            displayedText[0] = "Vertex \t\t Distance from Source \t\t Path\n";

            // write selected path and distance
            //Console.Write(startVertex.Property.Name + " -> " + endVertex.Property.Name + " \t\t " + returnedHelperType<int>(distArr, endVertex)!.Value.value  + "\t\t\t\t" + startVertex.Property.Name + " ");
            displayedText[1] = $"{startVertex.Property.Name} -> {endVertex.Property.Name} \t\t {returnedHelperType<int>(distArr, endVertex)!.Value.value} \t\t\t\t {startVertex.Property.Name}";
            // write path
            printPath(parrentArr, endVertex);
            return displayedText;
        }


        for (int vertexCount = 0; vertexCount < _nVertices; vertexCount++) {
            Vertex<TVertex> currentVertex =  _vertices.ElementAt(vertexCount);
            Edge<TEdges>? currentEdge = returnEdge(vertexWithMinimumDistance, currentVertex)!;
            helperType<bool>? tempBool = returnedHelperType<bool>(boolArr,currentVertex)!.Value;
            helperType<int>? tempInt = returnedHelperType<int>(distArr, currentVertex)!.Value;

            if (!tempBool.Value.value &&
                currentEdge != null &&
                verMinDistHT.Value.value != int.MaxValue &&
                verMinDistHT.Value.value + currentEdge.Property.Weight < tempInt.Value.value
                ) {
                    ChangeArray<int>(parrentArr, currentVertex, vertexWithMinimumDistance.Property.Id);
                    ChangeArray<int>(distArr, currentVertex, (verMinDistHT.Value.value + currentEdge.Property.Weight));
            }
        }     
    }
    printSolution(distArr, parrentArr, startVertex);

    
    /*=====================*/
    /*** HELPER FUNCTION ***/
    /*=====================*/


    Vertex<TVertex> returnVertexWithMinDistance(helperType<bool>[] boolArr, helperType<int>[] distarr) {
        int min = int.MaxValue;
        Vertex<TVertex> vertexWithMinDistance = new Vertex<TVertex>(-1, "");

        for (int i = 0; i < _nVertices; i++) {
            helperType<bool>? tempBool = returnedHelperType<bool>(boolArr, _vertices.ElementAt(i))!;
            helperType<int>? tempInt= returnedHelperType<int>(distArr, _vertices.ElementAt(i))!;

            
            if (tempBool.Value.value == false && tempInt.Value.value <= min) {
                min = tempInt.Value.value;
                vertexWithMinDistance = tempInt.Value.vertexValue;
            }
        }

        return vertexWithMinDistance;
    }

    Edge<TEdges>? returnEdge(Vertex<TVertex> v1, Vertex<TVertex> v2) {

        if (HasEdge(v1.Property.Id, v2.Property.Id) != null) {
            return HasEdge(v1.Property.Id, v2.Property.Id);
        } else if (HasEdge(v2.Property.Id, v1.Property.Id) != null) {
            return HasEdge(v2.Property.Id, v1.Property.Id);
        }
        return null;
    }
    
    void ChangeArray<T>(helperType<T>[] arr, Vertex<TVertex> vertex, T value) where T : IComparable {
        for (int i = 0; i < arr.Length; i++) {
            if (arr[i].vertexValue == vertex) {
                arr[i].value = value;
            }
        }
    }

    helperType<T>? returnedHelperType<T>(helperType<T>[] arr, Vertex<TVertex> vertex) where T: IComparable {
        
        for (int i = 0; i < arr.Length; i++) {
            if (arr[i].vertexValue == vertex) {
                return arr[i];
            }
        }
        return null;
    }

    void printSolution(helperType<int>[] distArr, helperType<int>[] parentArr, Vertex<TVertex> startVertex)
    {
        Console.Write("Vertex \t\t Distance from Source \t\t Path\n");
        for (int i = 0; i < distArr.Length; i++) {
            if (distArr[i].vertexValue.Property.Id != startVertex.Property.Id) {
                Console.Write("\n" + startVertex.Property.Name + " -> " + distArr[i].vertexValue.Property.Name + " \t\t " + distArr[i].value  + "\t\t\t" + startVertex.Property.Name + " ");
                printPath(parentArr, distArr[i].vertexValue);
            }
        }
    }

    void printPath(helperType<int>[] parentArr, Vertex<TVertex> currentVertex) {
        helperType<int>? currentHT = returnedHelperType<int>(parrentArr, currentVertex)!;
        if (currentHT.Value.value == -1) { // if comes back to startVertex, return
            return;
        }
        printPath(parrentArr, HasVertex(currentHT.Value.value)!);
        displayedText[1] += $" {currentVertex.Property.Name}";
    }

    
    return displayedText;
}


    // Finaliser
    ~Graph() {}

}