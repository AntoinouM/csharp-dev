using System;
using GraphLibrary;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
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

        Graph<VertexProperty, EdgeProperty>  graph = new Graph<VertexProperty, EdgeProperty>();

        // variables
        string source = "";
        string target = "";
        LinkedList<string> verticesName = new LinkedList<string>();

        // creating files path
        string inputPath = Combine(CurrentDirectory, "input.txt");
        string outputPath = Combine(CurrentDirectory, "output.txt");

        // check if files exists
        if (File.Exists(outputPath)) {
            File.Delete(outputPath);
        }

        if (!File.Exists(inputPath)) {
            Console.WriteLine("\nPlease create a text file: input:txt");
            return;
        }

        // generate vertices
        string[] linesForVName = File.ReadAllLines(inputPath);
        foreach (string line in linesForVName) {
            string[] argsForNames = line.Split(',');
            foreach (string name in argsForNames) {
                name.Trim();
                if (!name.All(char.IsDigit) && !line.Contains("from") && !line.Contains("to")) {
                    if (!verticesName.Contains(name)) {
                        verticesName.AddLast(name);
                    }
                }
            }
        }
        for (int i = 0; i < verticesName.Count; i++) {
            graph.AddVertex(verticesName.ElementAt(i));
        }

        // read text file
        string[] linesFromInput = File.ReadAllLines(inputPath);
        foreach (string line in linesFromInput) {
            if (!line.Contains("from") && !line.Contains("to") && line.Length != 0) {
                //Console.WriteLine(line);
                string[] parameters = line.Split(',');
                if (parameters.Length == 3) {
                     graph.AddEdge(graph.HasVertex(parameters[0].Trim())!.Property.Id, graph.HasVertex(parameters[1].Trim())!.Property.Id, uint.Parse(parameters[2]));
                }
            }
            else if (line.Contains("from")) {
                string[] parametersSrc = line.Split(':');
                source = parametersSrc[parametersSrc.Length-1].Trim();
            }
            else if (line.Contains("to")) {
                string[] parametersTrg = line.Split(':');
                target = parametersTrg[parametersTrg.Length-1].Trim();
            }
        }

        Dictionary<string, string>? dijkstraDictionary = graph.Dijkstra(source, target)!;

        // create output
        // create a text file and return a writer helper
        StreamWriter output = File.CreateText(outputPath);
        
        if (target.Length != 0) { 
            output.WriteLine($"{dijkstraDictionary["source"]} --> {dijkstraDictionary["target"]}"); // text is a helper writer that helps generating/managing text file
            output.WriteLine($"Minimum distance: {dijkstraDictionary["dist"]}");
            output.WriteLine($"Path: {dijkstraDictionary["source"]}{dijkstraDictionary["path"]}");
        } else {
            output.WriteLine("No destination specified");
            output.Write("Vertex \t\t Distance from Source \t\t Path");
            for (int i = 1; i < dijkstraDictionary.Count; i++) {
                output.Write(dijkstraDictionary.ElementAt(i).Value);
            }
        }
        output.Close(); // release the ressources

        Console.WriteLine();
        Console.WriteLine(File.ReadAllText(outputPath));
        Console.WriteLine("Result saved into output.txt");
    }


}
