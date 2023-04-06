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

    public Tetrahedon<Assignement3.Program.TetrahedonProperty>[] AddTetrahedron(uint num) {

        Tetrahedon<Assignement3.Program.TetrahedonProperty>[] tetraArr = new Tetrahedon<Assignement3.Program.TetrahedonProperty>[num];

        Tetrahedon<Assignement3.Program.TetrahedonProperty> tetra1 = new Tetrahedon<Assignement3.Program.TetrahedonProperty>(
        new Position(0f, 1f, 0f),
        new Position(0.707f, 0f, 0f),
        new Position(-1.708f, 0f, 0f),
        new Position(0f, 0f, 1f)
        );

        Tetrahedon<Assignement3.Program.TetrahedonProperty> tetra2 = new Tetrahedon<Assignement3.Program.TetrahedonProperty>(
        new Position(0.32145f, 1.6532f, -0.535f),
        new Position(1.707f, -1.2328f, -0.894f),
        new Position(-1.708f, 0f, 0.3987f),
        new Position(-0.567f, 0f, 1f)
        );

        Tetrahedon<Assignement3.Program.TetrahedonProperty> tetra3 = new Tetrahedon<Assignement3.Program.TetrahedonProperty>(
        new Position(-6.26819f, 7.01244f, 0f),
        new Position(-1.18902f, -0.86597f, 0f),
        new Position(-1.18902f, -0.86597f, 0f),
        new Position(-3.44132f, 4.79788f, 3.13311f)
        );

        Tetrahedon<Assignement3.Program.TetrahedonProperty> tetra4 = new Tetrahedon<Assignement3.Program.TetrahedonProperty>(
        new Position(-3.74407f, 2.81046f, -0.41865f),
        new Position(0.33992f, -5.53084f, 0.90708f),
        new Position(2.53484f, 0.45881f, 0.65123f),
        new Position(-4.94778f, 6.46897f, 0f)
        );

        Tetrahedon<Assignement3.Program.TetrahedonProperty> tetra5 = new Tetrahedon<Assignement3.Program.TetrahedonProperty>(
        new Position(-3f, 3f, 0f),
        new Position(-2.78743f, -1.73836f, -0.59322f),
        new Position(0f, -2.564f, 0f),
        new Position(-4.85907f, 1.50916f, 0f)
        );

        Tetrahedon<Assignement3.Program.TetrahedonProperty>[] tempArr = new Tetrahedon<Assignement3.Program.TetrahedonProperty>[] {
            tetra1, tetra2, tetra3, tetra4, tetra5
        };

        for (int i = 0; i < num; i++) {
            if (i > 5) {break;}
            tetraArr[i] = tempArr[i];
        }

        return tetraArr;
    }

    public Cuboid<Assignement3.Program.CuboidProperty>[] AddCuboid(uint num) {

        Cuboid<Assignement3.Program.CuboidProperty>[] cuboArr = new Cuboid<Assignement3.Program.CuboidProperty>[num];
       
        Cuboid<Assignement3.Program.CuboidProperty> cubo1 = new Cuboid<Assignement3.Program.CuboidProperty>(
            new Position(-0.34329f,-0.870595f,0.866248f),
            new Position(1.46298f,-0.870595f,0.866248f),
            new Position(1.01123f,0.858149f,-0.030544f),
            new Position(-0.795039f,0.858149f,-0.030544f),
            new Position(-1.24306f,-0.870595f,-0.919927f),
            new Position(0.563215f,-0.870595f,-0.919927f),
            new Position(0.563215f,0.858149f,-0.919927f),
            new Position(-1.24306f,0.858149f,-0.919927f)
        );
        Cuboid<Assignement3.Program.CuboidProperty> cubo2 = new Cuboid<Assignement3.Program.CuboidProperty>(
            new Position(1f, -1f, -1f),
            new Position(1f, 1f, -1f),
            new Position(-1f, 1f, -1f),
            new Position(-1f, -1f, -1f),
            new Position(1.6093f,-1.6093f,1f),
            new Position(1.6093f,1.6093f,1f),
            new Position(-1.6093f,1.6093f,1f),
            new Position(-1.6093f,-1.6093f,1f)
        );
        Cuboid<Assignement3.Program.CuboidProperty> cubo3 = new Cuboid<Assignement3.Program.CuboidProperty>(
            new Position(0.73636f, -1.0803f, -0.73636f),
            new Position(1f, 1f, 0.14578f),
            new Position(-1f, 1f, 0.14578f),
            new Position(-0.73636f, -1.0803f, -0.73636f),
            new Position(1.3155f, -1.3668f, 0.87238f),
            new Position(1.6093f, 1.6093f, 2.1458f),
            new Position(-1.6093f, 1.6093f, 2.1458f),
            new Position(-1.0545f, -1.3668f, 0.87238f)
        );
        Cuboid<Assignement3.Program.CuboidProperty> cubo4 = new Cuboid<Assignement3.Program.CuboidProperty>(
            new Position(0.73636f, -1.0803f, -0.73636f),
            new Position(0.487f, 1f, 1.1636f),
            new Position(-0.487f, 1f, 1.1636f),
            new Position(0.73636f, -1.0803f, -0.73636f),
            new Position(1.3155f, -1.3668f, -0.87238f),
            new Position(0.81829f, 1.6093f, 2.1458f),
            new Position(-0.81829f, 1.6093f, 2.1458f),
            new Position(-1.0545f, -1.3668f, 0.87238f)
        );
        Cuboid<Assignement3.Program.CuboidProperty> cubo5 = new Cuboid<Assignement3.Program.CuboidProperty>(

        );

        Cuboid<Assignement3.Program.CuboidProperty>[] tempArr = new Cuboid<Assignement3.Program.CuboidProperty>[] {
            cubo1, cubo2, cubo3, cubo4, cubo5
        };

        for (int i = 0; i < num; i++) {
            if (i > 5) {break;}
            cuboArr[i] = tempArr[i];
        }

        return cuboArr;   
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
