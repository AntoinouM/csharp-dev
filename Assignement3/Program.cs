using System;
using System.Diagnostics;
using GeometryLibrary;


namespace Assignement3;
class Program
{
    public class CylinderProperty : BasicCylinderProperties {
               
    }
    public class CuboidProperty : BasicCuboidProperty {
               
    }
    public class TetrahedonProperty : BasicTetrahedonProperty {
               
    }
    static void Main(string[] args)
    {
        Tetrahedon<TetrahedonProperty> tetrahedon = new Tetrahedon<TetrahedonProperty>();
        Position newPoint = new Position();
        newPoint.x = 5f;

        Cylinder<CylinderProperty> cylo = new Cylinder<CylinderProperty>();
        cylo.Property.Height = 2f;
        
        tetrahedon.AddVertices(newPoint);
        System.Console.WriteLine(cylo.Property.Radius);
        
        for (int i = 0; i < tetrahedon.Vertices.Count; i++) {
            System.Console.WriteLine(tetrahedon.Vertices.ElementAt(i).x);
        }
        
        
        
    }
}
