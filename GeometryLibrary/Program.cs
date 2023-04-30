using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using GeometryLibrary;


namespace Assignement3;

public class Program
{
    private static object priorityTaskToken = new object();
    public class CylinderProperty : BasicCylinderProperties {
               
    }
    public class CuboidProperty : BasicCuboidProperty {
               
    }
    public class TetrahedonProperty : BasicTetrahedonProperty {

    }
    static void Main(string[] args)
    {
        Stopwatch timer = Stopwatch.StartNew();
        Test test = new Test();
        Cylinder<CylinderProperty>[] cyloArr = test.AddCylinder(5);
        Cuboid<CuboidProperty>[] cuboArr = test.AddCuboid(5);
        Tetrahedon<TetrahedonProperty>[] tetraArr = test.AddTetrahedron(5);

        if (args.Length == 0) {

            GetCuboSurface(cuboArr);
            GetCyloSurface(cyloArr);
            GetTetraSurface(tetraArr);
        } else {
            if (args[0] == "-thread") {
            Task tetraSurfaceT = Task.Run(() =>
            {
                GetTetraSurface(tetraArr);
            });
            tetraSurfaceT.Wait();

            Task cuboSurfaceT = Task.Run(() =>
            {
                GetCuboSurface(cuboArr);
            });

            Task cyloSurfaceT = Task.Run(() =>
            {
                GetCyloSurface(cyloArr);
            });
            if (cyloSurfaceT.IsCompleted && cuboSurfaceT.IsCompleted && tetraSurfaceT.IsCompleted) {
            }

            } else {
            GetCuboSurface(cuboArr);
            GetCyloSurface(cyloArr);
            GetTetraSurface(tetraArr);
            timer.Stop();
            System.Console.WriteLine();
            System.Console.WriteLine($"{timer.ElapsedMilliseconds:#,##0}ms elapsed");
            }
        }
        timer.Stop();
        System.Console.WriteLine();
        System.Console.WriteLine($"{timer.ElapsedMilliseconds:#,##0}ms elapsed");
        Console.ReadKey();

    }

    public static void GetTetraSurface(Tetrahedon<TetrahedonProperty>[] tetraArr) {
        for (int i = 0; i < tetraArr.Length; i++) {
            System.Console.WriteLine($"Tetrahedron {i + 1} surface: {MathF.Round(tetraArr[i].SurfaceArea(), 3)} cm²");
        }
    }
    public static void GetCuboSurface(Cuboid<CuboidProperty>[] cuboArr) {
        for (int i = 0; i < cuboArr.Length; i++) {
            System.Console.WriteLine($"Cuboid {i + 1} surface: {MathF.Round(cuboArr[i].SurfaceArea(), 3)} cm²");
        }
    }
    public static void GetCyloSurface(Cylinder<CylinderProperty>[] cyloArr) {
        for (int i = 0; i < cyloArr.Length; i++) {
            System.Console.WriteLine($"Cylinder {i + 1} surface: {MathF.Round(cyloArr[i].SurfaceArea(), 3)} cm²");
        }
    }
}
