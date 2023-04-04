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
        Tetrahedon<TetrahedonProperty> tetra = test.AddTetrahedon(0f);

        // for (int i = 0; i < cubo.Vertices.Length; i++) {
        //     System.Console.WriteLine($"Point {i}:   x: {cubo.Vertices[i].x}, y: {cubo.Vertices[i].y}, z: {cubo.Vertices[i].z}");
        // }

        Position[] btmFace = tetra.returnBtmFace(tetra.Vertices);
        tetra.Vertices = tetra.OrganisePoints(tetra.Vertices);
        Position tetraCentroid = tetra.Centroid();
        float tetraSurface = tetra.SurfaceArea();
        System.Console.WriteLine(tetraSurface);
  
    }

}
