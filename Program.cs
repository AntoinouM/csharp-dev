using System;
using System.Runtime.CompilerServices;

namespace CSHARP // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int p = 2;
            int countFor = 0;
            int countWhile = 0;
            for (int q = 2; q < 32; q = q *2) {
                while(p<q) {
                    p = p * 2;
                    countWhile = countWhile + 1;
                    Console.WriteLine("p: " + p);
                }
                countFor = countFor + 1;
                q = p - q;
                Console.WriteLine("q: " + q);
            }
            System.Console.WriteLine("countWhile: " + countWhile + " ;countFor: " + countFor);
        }
    }
}