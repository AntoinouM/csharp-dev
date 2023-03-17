namespace Animals;
class Program
{
    static void Main(string[] args)
    {
        Cat nana = new Cat("Nana", new DateTime(2019, 12, 9));
        nana.Speak();
        nana.Move();



    }
}
