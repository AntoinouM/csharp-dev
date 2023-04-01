using System;
using System.Diagnostics;
using GeometryLibrary;


namespace Assignement3;
class Program
{
    public class VertexPorperty : BasicVertexProperty {

    }
    public class CylinderProperty : BasicCylinderProperties {
               
    }
    public class CuboidProperty : BasicCuboidProperty {
               
    }
    public class TetrahedonProperty : BasicTetrahedonProperty {
               
    }
    static void Main(string[] args)
    {
        Tetrahedon<VertexPorperty, TetrahedonProperty> tetrahedon = new Tetrahedon<VertexPorperty, TetrahedonProperty>();
        Vertex<VertexPorperty> newPoint = new Vertex<VertexPorperty>(1, 2, 1);

        Cylinder<VertexPorperty, CylinderProperty> cylo = new Cylinder<VertexPorperty, CylinderProperty>();
        cylo.Property.Height = 2f;
        
        tetrahedon.AddVertices(newPoint);
        System.Console.WriteLine(cylo.Property.Radius);
        
        for (int i = 0; i < tetrahedon.Vertices.Count; i++) {
            System.Console.WriteLine(tetrahedon.Vertices.ElementAt(i).Position.x);
        }
        
        
        
    }
}
