using System;
using System.Diagnostics;
using GeometryLibrary;


namespace Assignement3;

public class QuadriFace {
    private Position _p1;
    private Position _p2;
    private Position _p3;
    private Position _p4;

    public QuadriFace () {
        this._p1 = new Position(-1f, -2.7278f, 1.0642f);
        this._p2 = new Position(-2.0361f, -1.6229f, 3.4696f);
        this._p3 = new Position(1.2955f, -0.17434f, 0.37153f);
        this._p4 = new Position(1.7406f, 1.0695f, 0.9312f);
    }

    public Position p1 {get {return _p1;}}
    public Position p2 {get {return _p2;}}
    public Position p3 {get {return _p3;}}
    public Position p4 {get {return _p4;}}
}

 public class Test {
    public Tetrahedon<Assignement3.Program.TetrahedonProperty> AddTetrahedon(float offset) {
        Position point1 = new Position(0f + offset, 1f + offset, 0f + offset);
        Position point2 = new Position(0.707f + offset, 0f + offset, 0f + offset);
        Position point3 = new Position(-1.708f + offset, 0f + offset, 0f + offset);
        Position point4 = new Position(0f + offset, 0f + offset, 1f + offset);

        Tetrahedon<Assignement3.Program.TetrahedonProperty> tetra = new Tetrahedon<Assignement3.Program.TetrahedonProperty>();
        tetra.AddVertex(point1);
        tetra.AddVertex(point2);
        tetra.AddVertex(point3);
        tetra.AddVertex(point4);

        return tetra;
    }

    public Cuboid<Assignement3.Program.CuboidProperty> AddCuboid(float offset) {
        Position[] pointArray = new Position[] {
            new Position(-0.68192f , -1f, -1f), 
            new Position(0.68192f , -1f, -1f), 
            new Position(1f, 1f, -1f), 
            new Position(-1f, 1f, -1f), 
            new Position(-1.6131f, -1.6131f, 1f), 
            new Position(1.6131f, -1.6131f, 1f),
            new Position(0.59856f, 1.6131f, 1f),
            new Position(-0.59856f, 1.6131f, 1f)
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