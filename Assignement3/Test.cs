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

    public Tetrahedon<Assignement3.Program.TetrahedonProperty> AddTetrahedron() {
        Tetrahedon<Assignement3.Program.TetrahedonProperty> tetra = new Tetrahedon<Assignement3.Program.TetrahedonProperty>(
        new Position(0f, 1f, 0f),
        new Position(0.707f, 0f, 0f),
        new Position(-1.708f, 0f, 0f),
        new Position(0f, 0f, 1f)
        );
        return tetra;
    }

    public Cuboid<Assignement3.Program.CuboidProperty> AddCuboid() {
       
        Cuboid<Assignement3.Program.CuboidProperty> cubo = new Cuboid<Assignement3.Program.CuboidProperty>(
            new Position(-0.68192f , -1f, -1f), 
            new Position(0.68192f , -1f, -1f), 
            new Position(1f, 1f, -1f), 
            new Position(-1f, 1f, -1f), 
            new Position(-1.6131f, -1.6131f, 1f), 
            new Position(1.6131f, -1.6131f, 1f),
            new Position(0.59856f, 1.6131f, 1f),
            new Position(-0.59856f, 1.6131f, 1f)
            );
        return cubo;   
    }

    public Cylinder<Assignement3.Program.CylinderProperty> AddCylinder(float radius) {
        Position point1 = new Position(1f, 0f, 1f);
        Position point2 = new Position(1f, 2f, 1f);

        Cylinder<Assignement3.Program.CylinderProperty> cylo = new Cylinder<Assignement3.Program.CylinderProperty>();
        cylo.AddVertex(point1);
        cylo.AddVertex(point2);
        cylo.Property.Radius = radius;

        return cylo;
    }
}