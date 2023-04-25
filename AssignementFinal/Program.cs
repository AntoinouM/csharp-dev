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

        Graph<VertexProperty, EdgeProperty>  graph = new Graph<VertexProperty, EdgeProperty>  ();
        /*
            { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
            { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
            { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
            { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
            { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
            { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
            { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
            { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
            { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };
        */
        int v0 = graph.AddVertex("0");
        int v1 = graph.AddVertex("1");
        int v2 = graph.AddVertex("2");
        int v3 = graph.AddVertex("3");
        int v4 = graph.AddVertex("4");
        int v5 = graph.AddVertex("5");
        int v6 = graph.AddVertex("6");
        int v7 = graph.AddVertex("7");
        int v8 = graph.AddVertex("8");


        graph.AddEdge(v0,v1, 4);
        graph.AddEdge(v0,v7, 8);
        graph.AddEdge(v1,v2, 8);
        graph.AddEdge(v1,v7, 11);
        graph.AddEdge(v2,v3, 7);
        graph.AddEdge(v2,v5, 4);
        graph.AddEdge(v2,v8, 2);
        graph.AddEdge(v3,v4, 9);
        graph.AddEdge(v3,v5, 14);
        graph.AddEdge(v4,v5, 10);
        graph.AddEdge(v5,v6, 2);
        graph.AddEdge(v6,v7, 1);
        graph.AddEdge(v6,v8, 6);
        graph.AddEdge(v7,v8, 7);

        graph.Dijkstra("0", "7");

    }
}
