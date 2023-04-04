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

        QuadriFace face = new QuadriFace();
        Position[] faceVertices = new Position[] {
            face.p1, face.p2, face.p3, face.p4
        };
        SShape.WritePositionToConsole(faceVertices);


        // for (int i = 0; i < tetra.Vertices.Length; i++) {
        //     System.Console.WriteLine($"Point {i}:       x: {tetra.Vertices[i].x}, y: {tetra.Vertices[i].y}, z: {tetra.Vertices[i].z}");
        // }
        // Position tetraCentroid1 = tetra.Centroid();
        // float tetraSurface1 = tetra.SurfaceArea();
        // System.Console.WriteLine(tetraSurface1);
        // System.Console.WriteLine($"{tetraCentroid1.x}, {tetraCentroid1.y}, {tetraCentroid1.z}");
  
        // System.Console.WriteLine();
        // tetra.Vertices = tetra.OrganisePoints(tetra.Vertices);
        // for (int i = 0; i < tetra.Vertices.Length; i++) {
        //     System.Console.WriteLine($"Point {i}:       x: {tetra.Vertices[i].x}, y: {tetra.Vertices[i].y}, z: {tetra.Vertices[i].z}");
        // }
        // Position tetraCentroid = tetra.Centroid();
        // float tetraSurface = tetra.SurfaceArea();
        // System.Console.WriteLine(tetraSurface);
        // System.Console.WriteLine($"{tetraCentroid.x}, {tetraCentroid.y}, {tetraCentroid.z}");
  
    }

}
