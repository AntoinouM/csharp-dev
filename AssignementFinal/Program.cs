using System;
using GraphLibrary;
using System.Globalization;
using System.IO;
using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;

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

        //graph.Dijkstra("0", "3");

        // creating files path
        string inputPath = Combine(CurrentDirectory, "input.txt");
        string outputPath = Combine(CurrentDirectory, "output.txt");

        // check if files exists
        if (!File.Exists(outputPath)) {
            File.Delete(outputPath);
        }

        if (!File.Exists(inputPath)) {
            Console.WriteLine("\nPlease create a text file: input:txt");
            return;
        }



        // execute each line

    }
}
