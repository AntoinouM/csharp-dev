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
        Cylinder<CylinderProperty>[] cyloArr = test.AddCylinder(5);
        Cuboid<CuboidProperty>[] cuboArr = test.AddCuboid(5);
        Tetrahedon<TetrahedonProperty>[] tetraArr = test.AddTetrahedron(5);

        if (args.Length == 0) {
            iterativeMethod(cyloArr, cuboArr, tetraArr);
        } else {
            if (args[0] == "-thread") {
            threadMethod(cyloArr, cuboArr, tetraArr);
            } else {
                iterativeMethod(cyloArr, cuboArr, tetraArr);
            }
        }
        // System.Console.WriteLine(
        //     $"btm area: {cylo.BottomArea()} \nheight: {cylo.Height} \nTotal Surface: {cylo.SurfaceArea()} \nVolume: {cylo.Volume()}"
        // );
    }

    public static void iterativeMethod(Cylinder<CylinderProperty>[] cyloArr, Cuboid<CuboidProperty>[] cuboArr, Tetrahedon<TetrahedonProperty>[] tetraArr) {
        Stopwatch timer = Stopwatch.StartNew();

        // Generate a shape array
        SShape[] shapeArr = new SShape[cyloArr.Length + cuboArr.Length + tetraArr.Length];
        cyloArr.CopyTo(shapeArr, 0);
        cuboArr.CopyTo(shapeArr, cyloArr.Length);
        tetraArr.CopyTo(shapeArr, (cuboArr.Length) + (tetraArr.Length));

        for (int i = 0; i < shapeArr.Length; i++) {
            if (shapeArr[i] is Cylinder<CylinderProperty>) {
                System.Console.WriteLine($"Cylinder {i+1} surface: {MathF.Round(shapeArr[i].SurfaceArea(), 3)} cm²");
            } else if (shapeArr[i] is Cuboid<CuboidProperty>) {

                System.Console.WriteLine($"Cuboid {(i-5)+1} surface: {MathF.Round(shapeArr[i].SurfaceArea(), 3)} cm²");
            } else {
                System.Console.WriteLine($"Tetrahedron {(i-10)+1} surface: {MathF.Round(shapeArr[i].SurfaceArea(), 3)} cm²");
            }
        }



        timer.Stop();
        System.Console.WriteLine($"{timer.ElapsedMilliseconds:#,##0}ms elapsed");
    }

    public static void threadMethod(Cylinder<CylinderProperty>[] cyloArr , Cuboid<CuboidProperty>[] cuboArr,Tetrahedon<TetrahedonProperty>[] tetraArr) {
        Stopwatch timer = Stopwatch.StartNew();





        timer.Stop();
        System.Console.WriteLine($"{timer.ElapsedMilliseconds:#,##0}ms elapsed");
    }
}
