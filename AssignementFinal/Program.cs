using System;
using GraphLibrary;

namespace SocialNet;
class Program
{
    public class VertexProperty: BasicVertexProperty{

    }
    public class EdgeProperty: BasicEdgeProperty{

    }

    static void Main(string[] args)
    {
        System.Console.WriteLine("New line from main");
        Graph<VertexProperty, EdgeProperty>  graph = new Graph<VertexProperty, EdgeProperty>  ();

        uint v1 = graph.AddVertex("Helen");
        uint v2 = graph.AddVertex("Jon");
        uint v3 = graph.AddVertex("Sue");
        uint v4 = graph.AddVertex("Yun");

        graph.AddEdge(v1,v2, 6);
        graph.AddEdge(v1,v3, 1);
        graph.AddEdge(v2,v3, 1);
        graph.PrintGraph();
        graph.RemoverVertex("helen");
        graph.PrintGraph();
    }
}
