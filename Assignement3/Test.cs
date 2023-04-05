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
            new Position(-0.34329f,-0.870595f,0.866248f),
            new Position(1.46298f,-0.870595f,0.866248f),
            new Position(1.01123f,0.858149f,-0.030544f),
            new Position(-0.795039f,0.858149f,-0.030544f),
            new Position(-1.24306f,-0.870595f,-0.919927f),
            new Position(0.563215f,-0.870595f,-0.919927f),
            new Position(0.563215f,0.858149f,-0.919927f),
            new Position(-1.24306f,0.858149f,-0.919927f)
            );
        return cubo;   
    }

    public Cylinder<Assignement3.Program.CylinderProperty> AddCylinder() {

        Cylinder<Assignement3.Program.CylinderProperty> cylo = new Cylinder<Assignement3.Program.CylinderProperty>(
            new Position(1f, 0f, 1f),
            new Position(1f, 2f, 1f),
            2f
        );
        
        return cylo;
    }
}

// TO OVERIDE == for the shapes, just check if all the vertices are matching the other one
// array.Contains(xx)