using System.Collections.Generic;
using System.Collections;

namespace GraphLibrary;

public class Graph <TVertex, TEdges> 
where TVertex: BasicVertexProperty, new()
where TEdges: BasicEdgeProperty, new()
{
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
        public void AddEdge(int sourceId, int targetId, uint weight) {
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

    
    /*=====================*/
    /*** HELPER FUNCTION ***/
    /*=====================*/

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

    Edge<TEdges>? returnEdge(Vertex<TVertex> v1, Vertex<TVertex> v2) {

        if (HasEdge(v1.Property.Id, v2.Property.Id) != null) {
            return HasEdge(v1.Property.Id, v2.Property.Id);
        } else if (HasEdge(v2.Property.Id, v1.Property.Id) != null) {
            return HasEdge(v2.Property.Id, v1.Property.Id);
        }
        return null;
    }

    void printSolution( Dictionary<Vertex<TVertex>, uint> distDic, 
                        Dictionary<Vertex<TVertex>, Vertex<TVertex>?> parentDic, 
                        Vertex<TVertex> startVertex)
    {
        for (int i = 0; i < distDic.Count; i++) {
            if (distDic.ElementAt(i).Key.Property.Id != startVertex.Property.Id) {
                pathStr = "";
                printPath(parentDic, distDic.ElementAt(i).Key);
                DijkstraDic[$"line{i+1}"] = ("\n" + startVertex.Property.Name + " -> " + distDic.ElementAt(i).Key.Property.Name + " \t\t " + distDic.ElementAt(i).Value  + "\t\t\t " + startVertex.Property.Name) + pathStr;
            }
        }
    }

    void printPath(Dictionary<Vertex<TVertex>, Vertex<TVertex>?> parentDic , Vertex<TVertex>? currentVertex) {
        Vertex<TVertex>? currentParent = parentDic[currentVertex!];
        if (currentParent == null) { // if comes back to startVertex, return
            return;
        }
        printPath(parentDic, currentParent!);
        pathStr += $"-{currentVertex!.Property.Name}";
    }

    return DijkstraDic;
}

    // Finaliser
    ~Graph() {}

}