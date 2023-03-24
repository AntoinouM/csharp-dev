using System;
using GraphLibrary;

namespace SocialNet;
class Program
{
    static void Main(string[] args)
    {
        //dotnet new classlib --name GraphLibrary
        Graph graph = new Graph();

        uint v1 = graph.AddVertex("Helen");
        uint v2 = graph.AddVertex("Jon");
        uint v3 = graph.AddVertex("Sue");
        uint v4 = graph.AddVertex("Yun");

        graph.AddEdge(v1,v2);
        graph.AddEdge(v1,v3);
        graph.AddEdge(v2,v3);

        graph.PrintGraph();
        graph.RemoverVertex("helen");
        graph.PrintGraph();
    }
}
