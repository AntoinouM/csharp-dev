namespace _2nd_abstract;
class Program
{
    static void Main(string[] args)
    {
        Cat cat1 = new Cat();
        cat1.food = 5;
        System.Console.WriteLine($"Cat food with an integer {cat1.checkedFood(5)}");

        Cat cat2 = new Cat();
        cat2.food = "fish";
        System.Console.WriteLine($"Cat food with an integer {cat2.checkedFood("fish")}");

        // generics
        GenericCat<int> gCat = new GenericCat<int>();
        gCat.food = 5;
        System.Console.WriteLine($"Cat food with an integer {gCat.checkFood(5)}");

        // generic method
        string food1 = "4";
        System.Console.WriteLine("Double cat food",
            arg0: food1,
            arg1: GenericMethodCat.DoubleMyFood<string>(food1)
        );

    }
}
