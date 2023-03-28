using System;
using System.Threading;
using System.Diagnostics;

namespace ThreadConsept;
class Program
{
    static void Main(string[] args)
    {
        Stopwatch timer = Stopwatch.StartNew();
        System.Console.WriteLine("Running method synchornously on one thread.");
        MethodA();
        MethodB();
        MethodC();
        timer.Stop();
        System.Console.WriteLine($"{timer.ElapsedMilliseconds:#,##0}ms elapsed");
    }

    static void MethodA() {
        Console.WriteLine("Starting Method A...");
        Thread.Sleep(3000);
        Console.WriteLine("Finished Method A...");
    }

    static void MethodB() {
        Console.WriteLine("Starting Method B...");
        Thread.Sleep(2000);
        Console.WriteLine("Finished Method B...");       
    }

    static void MethodC() {
        Console.WriteLine("Starting Method C...");
        Thread.Sleep(1000);
        Console.WriteLine("Finished Method C...");      
    }
}
