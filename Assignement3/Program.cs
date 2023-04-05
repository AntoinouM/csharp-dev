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
        Cylinder<CylinderProperty> cylo = test.AddCylinder();
        Cuboid<CuboidProperty> cubo = test.AddCuboid();
        Tetrahedon<TetrahedonProperty> tetra = test.AddTetrahedron();
        Cuboid<Assignement3.Program.CuboidProperty> cubo2 = new Cuboid<Assignement3.Program.CuboidProperty>(
            new Position(0.563215f,-0.870595f,-0.919927f),
            new Position(1.46298f,-0.870595f,0.866248f),
            new Position(0.563215f,0.858149f,-0.919927f),
            new Position(1.01123f,0.858149f,-0.030544f),
            new Position(-1.24306f,-0.870595f,-0.919927f),
            new Position(-0.795039f,0.858149f,-0.030544f),
            new Position(-1.24306f,0.858149f,-0.919927f),
            new Position(-0.34329f,-0.870595f,0.866248f)
        );


        System.Console.WriteLine(cubo == cubo2);


        // System.Console.WriteLine(
        //     $"btm area: {cylo.BottomArea()} \nheight: {cylo.Height} \nTotal Surface: {cylo.SurfaceArea()} \nVolume: {cylo.Volume()}"
        // );

    }

}
