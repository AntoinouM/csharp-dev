using System;
using System.Diagnostics;
using GeometryLibrary;


namespace Assignement3;

 public class Test {
    public Tetrahedon<Assignement3.Program.TetrahedonProperty> AddTetrahedon(float offset) {
        Position point1 = new Position(0f + offset, 0f + offset, 0f + offset);
        Position point2 = new Position(1f + offset, 0f + offset, 1f + offset);
        Position point3 = new Position(0f + offset, 0f + offset, 1f + offset);
        Position point4 = new Position(1f + offset, 1f + offset, 0f + offset);

        Tetrahedon<Assignement3.Program.TetrahedonProperty> tetra = new Tetrahedon<Assignement3.Program.TetrahedonProperty>();
        tetra.AddVertex(point1);
        tetra.AddVertex(point2);
        tetra.AddVertex(point3);
        tetra.AddVertex(point4);

        return tetra;
    }

    public Cuboid<Assignement3.Program.CuboidProperty> AddCuboid(float offset) {
        Position[] pointArray = new Position[] {
            new Position(1f + offset, 1f + offset, 1f + offset), 
            new Position(1f + offset, 4f + offset, 1f + offset), 
            new Position(4f + offset, 4f + offset, 1f + offset), 
            new Position(4f + offset, 1f + offset, 1f + offset), 
            new Position(1f + offset, 1f + offset, 4f + offset), 
            new Position(1f + offset, 4f + offset, 4f + offset), 
            new Position(4f + offset, 4f + offset, 4f + offset), 
            new Position(4f + offset, 1f + offset, 4f + offset)
            };
        Cuboid<Assignement3.Program.CuboidProperty> cubo = new Cuboid<Assignement3.Program.CuboidProperty>();
        for (int i = 0; i < pointArray.Length; i++) {
            cubo.Vertices[i] = pointArray[i];
        }
        return cubo;   
    }

    public Cylinder<Assignement3.Program.CylinderProperty> AddCylinder(float offset) {
        Position point1 = new Position(1f + offset, 0f + offset, 1f + offset);
        Position point2 = new Position(1f + offset, 2f + offset, 1f + offset);

        Cylinder<Assignement3.Program.CylinderProperty> cylo = new Cylinder<Assignement3.Program.CylinderProperty>();
        cylo.AddVertex(point1);
        cylo.AddVertex(point2);

        return cylo;
    }
}