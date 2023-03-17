namespace Animals; // need to have the same namespace as classes for references
class Program
{
    static void Main(string[] args)
    {
        // Cat nana = new Cat("Nana", new DateTime(2019, 12, 9));
        // nana.Speak();
        // nana.Move();
        int r = 2;
        int newR = DoubleMyRessource(r);
        System.Console.WriteLine($"{r} has been doubled to {newR}");

        float f = 2.5F;
        int newF = DoubleMyRessource(f);
        System.Console.WriteLine($"{f} has been doubled to {newF}");

        // generic function

    }

    public static int DoubleMyRessource(int ressource)
    {
        return 2*ressource;
    }

        public static float DoubleMyRessource(float ressource) // this is function overload (same name with different type) => use generic param?
    {
        return 2.0F*ressource;
    }

    public static T DoubleMyRessource<T>(T ressource) where T : IConvertible /*the <T> inform that you need to specify the type, and we tell that T is number format*/
    {
        double d = ressource.ToDouble(Thread.CurrentThread.CurrentCulture);
        d *= 2.0;
        return (T) Convert.ChangeType(d, typeof(T));
    }
}
