using System;
using System.Diagnostics;
using GeometryLibrary;


namespace Assignement3;
public class Program
{
    public class CylinderProperty : BasicCylinderProperties {
               
    }
    public class CuboidProperty : BasicCuboidProperty {
               
    }
    public class TetrahedonProperty : BasicTetrahedonProperty {

    }
    static void Main(string[] args)
    {
        Test test = new Test();
        Cylinder<CylinderProperty> cylo = test.AddCylinder(0f);
        Cuboid<CuboidProperty> cubo = test.AddCuboid(0f);

        // for (int i = 0; i < cubo.Vertices.Length; i++) {
        //     System.Console.WriteLine($"Point {i}:   x: {cubo.Vertices[i].x}, y: {cubo.Vertices[i].y}, z: {cubo.Vertices[i].z}");
        // }

        Position[] btmFace = cubo.returnBtmFace(cubo.Vertices);
        Position[] topFace = cubo.returnTopFace(cubo.Vertices);
        cubo.Vertices = cubo.OrganisePoints(cubo.Vertices);
        for (int i = 0; i < cubo.Vertices.Length; i++) {
            System.Console.WriteLine($"Point {i}:   x: {cubo.Vertices[i].x}, y: {cubo.Vertices[i].y}, z: {cubo.Vertices[i].z}");
        }
  
    }

}
