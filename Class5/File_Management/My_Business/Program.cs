using System;
using PetLibrary;

namespace My_Business;
class Program
{
    static void Main(string[] args)
    {
        Cat nana = new Cat("Nana", new DateTime(2019, 12, 9));
        nana.WritetoConsole();
        Cat coffee = new Cat("Coffee", new DateTime(2018, 02, 19));
        coffee.WritetoConsole();
        Cat kiwi = new Cat("Kiwi", new DateTime(2017, 04, 23));
        kiwi.WritetoConsole();

        // Making a cat run
        double speed = nana.SpeedUp(2);
        System.Console.WriteLine($"{nana.Name} is running at {speed} km/hr.");

        // Call instance method
        Cat kitty1 = nana.ProduceKitty(coffee);
        kitty1.Name = "Naffee";

        // call static method
        //Cat kitty2 = Cat.ProduceKitty(kiwi, coffee);
        /*operator call*/ Cat kitty2 = kiwi * coffee;
        kitty2.Name = "Kiffee";

        System.Console.WriteLine($"{nana.Name} has {nana.Children.Count} kitty.");
        System.Console.WriteLine($"{coffee.Name} has {coffee.Children.Count} kitty.");
        System.Console.WriteLine($"{kiwi.Name} has {kiwi.Children.Count} kitty.");

        // can't access Dog here because class is internal (only usable in origin folder)

        //OwnPets myPets = new OwnPets();
        //myPets.WriteToconsole();
    }
}
