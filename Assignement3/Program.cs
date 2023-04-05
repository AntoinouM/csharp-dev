using System;
using System.Diagnostics;
using GeometryLibrary;


namespace Assignement3;

/* All input should be in the order convention:
        8 _________________________ 7
         /|                       /| 
        /_|______________________/ | 
      5 | |                    6|  | 
        | |_____________________|__| 3
        | /4                    | /  
        |/______________________|/
        1                       2
*/

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
        System.Console.WriteLine();

    }

}
