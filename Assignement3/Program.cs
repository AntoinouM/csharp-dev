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
        Cylinder<CylinderProperty> cylo = test.AddCylinder(3f);
        Cuboid<CuboidProperty> cubo = test.AddCuboid();
        Tetrahedon<TetrahedonProperty> tetra = test.AddTetrahedron();



    }

}
