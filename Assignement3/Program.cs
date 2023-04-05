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

        System.Console.WriteLine(
            $"btm area: {cylo.BottomArea()} \nheight: {cylo.Height} \nTotal Surface: {cylo.SurfaceArea()} \nVolume: {cylo.Volume()}"
        );

    }

}
