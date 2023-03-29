using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ThreadConsept;

public class Cat
{
    public string Name = "ACat";
    public virtual void Speak() {
        Console.WriteLine("Meow!");
    }
}

public class WildCat: Cat 
{
    public override void Speak()
    {
        Console.WriteLine("WildMeow!");
    }
}
class Program
{
    static string _message = ""; // a shared resource
    private static object conch = new object();
    static void Main(string[] args)
    {
        Cat nana = new Cat();
        WildCat leopard = new WildCat();

        Cat petCat = leopard;
        //WildCat wildo = petCat; // can'T convert in that direction because WildCat inherit from Cat --->
        WildCat wildo = (WildCat) petCat;

        petCat.Speak();

        Stopwatch timer = Stopwatch.StartNew();
        // System.Console.WriteLine("Running method synchornously on one thread.");
        // MethodA();
        // MethodB();
        // MethodC();

        /* This would allow the operating system to generate an order of execution
        Task taskA = new Task(MethodA);
        taskA.Start();

        Task taskB = Task.Factory.StartNew(MethodB);
        Task taskC = Task.Run(new Action(MethodC));
        */

        // System.Console.WriteLine("Running method asynchornously on one thread.");
        // Task taskA = new Task(MethodA);
        // taskA.Start();

        // Task taskB = Task.Factory.StartNew(MethodB);
        // Task taskC = Task.Run(new Action(MethodC));

        // Task[] tasks = {taskA, taskB, taskC};
        // Task.WaitAll(tasks); // tell the program to wait for all the tasks completion

        Task taskA = Task.Factory.StartNew(MethodA);
        Task taskB = Task.Factory.StartNew(MethodB);

        Task[] tasks = { taskA, taskB };
        Task.WaitAll(tasks); // the operating system still generate a specific processing order that change

        System.Console.WriteLine(_message);

        timer.Stop();
        System.Console.WriteLine($"{timer.ElapsedMilliseconds:#,##0}ms elapsed");
    }

    static void MethodA() {
        lock(conch) {
            for (int i = 0; i < 5; i++) {
                Thread.Sleep(500);
                _message += "A";
            }
        }
    }

    static void MethodB() {
        lock(conch) {
            for (int i = 0; i < 5; i++) {
                Thread.Sleep(500);
                _message += "B";
            }
        }
    }

    // static void MethodA() {
    //     Console.WriteLine("Starting Method A...");
    //     Thread.Sleep(3000);
    //     Console.WriteLine("Finished Method A...");
    // }

    // static void MethodB() {
    //     Console.WriteLine("Starting Method B...");
    //     Thread.Sleep(2000);
    //     Console.WriteLine("Finished Method B...");       
    // }

    // static void MethodC() {
    //     Console.WriteLine("Starting Method C...");
    //     Thread.Sleep(1000);
    //     Console.WriteLine("Finished Method C...");      
    // }
}
