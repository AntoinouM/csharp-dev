using System.Collections.Generic;

namespace GraphLibrary;


public class Graph 
{
    // Fields
    // The vertex/edge lists in the graph
    private LinkedList<Vertex> _vertices;
    private LinkedList<Edge> _edges;

    // The number of vertices and edges
    private uint _nVertices;
    private uint _nEdges;

    // Constructors
    public Graph() 
    {
        _vertices = new LinkedList<Vertex>();
        _edges = new LinkedList<Edge>();
        _nVertices = 0;
        _nEdges = 0;

    }

    // Methods
        // Vertex
        public uint AddVertex(string name) {
            Vertex v = new Vertex(_nVertices, name);
            _vertices.AddLast(v);
            _nVertices++;
            return _nVertices-1;
        }

        public Vertex? HasVertex(string name) {
            for (int i = 0; i < _vertices.Count; i++) {
                if (_vertices.ElementAt(i).Property.Name == name) {
                    return _vertices.ElementAt(i);
                }
            }
            return null;
        }

        // Function overload same one with different parameter
        public Vertex? HasVertex(uint id) {
            for (int i = 0; i < _vertices.Count; i++) {
                if (_vertices.ElementAt(i).Property.Id == id) {
                    return _vertices.ElementAt(i);
                }
            }
            return null;
        }

        public void RemoverVertex(string name) {
            Vertex? v = HasVertex(name);

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
        public void AddEdge(uint sourceId, uint targetId) {
            Edge? e = HasEdge(sourceId, targetId);

            if (e == null) {
                Vertex? sourceV = HasVertex(sourceId);
                Vertex? targetV = HasVertex(targetId);

                if (sourceV == null || targetV == null) {
                    Console.WriteLine("Source or target vertex could not be found.");
                    return;
                }

                Edge newE = new Edge(_nEdges, sourceId, targetId);
                _edges.AddLast(newE);
                _nEdges++;
            }
        }

        public Edge? HasEdge(uint sourceId, uint targetId) {

            for (int i = 0; i < _edges.Count; i++) {
                if ( (_edges.ElementAt(i).Property.SourceId == sourceId) && (_edges.ElementAt(i).Property.TargetId == targetId)) {
                    return _edges.ElementAt(i);
                }
            }
            return null;
        }

        public void RemoveEdge(uint sourceId, uint targetId) {
            Edge? e = HasEdge(sourceId, targetId);

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

    // Finaliser
    ~Graph() {}

}