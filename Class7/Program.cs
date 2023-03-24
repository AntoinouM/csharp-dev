namespace Class7;
class Program
{
    static void Main(string[] args)
    {
        // Local function
        bool CompareMethod(int a, int b) {return a == b;}

        System.Console.WriteLine(CompareMethod(1,3));

        // Lambda Expression
        bool CompareLambda(int a, int b) => (a == b);

        // Print a fibonacci sequence
        for (int i = 0; i < 10; i++) {
            System.Console.WriteLine("The {0} tern of the Fibonnacci sequence is {1:N0}", arg0: i+1, arg1:FibMethod(term: i)); //:N0 means convert a number into string
        }
    }
    static int FibMethod(int term) {
        switch (term) {
            case 0:
                return 0;
            case 1:
                return 1;
            default:
                return FibMethod(term - 1) + FibMethod(term - 2);
        }
    }
    // Fibo sequence
    // Statement Lambda
    static int FibLambda(int term) => term switch
   {
    0 => 0,
    1 => 1,
    _ => FibLambda(term -1) + FibLambda(term-2)
   } ;
}
