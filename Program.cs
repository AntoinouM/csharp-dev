using System;
using System.Runtime.CompilerServices;

namespace CSHARP // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The length of the arguments:" + args.Length);
                    for(int i=0; i < args.Length; i++) {
            Console.WriteLine(args[i]);
            }
        }
    }
}