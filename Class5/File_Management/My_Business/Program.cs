using System;
using PetLibrary;

namespace My_Business;
class Program
{
    static void Main(string[] args)
    {
        Cat[] Cats =
        {
            new Cat("Nana", new DateTime(2019, 12, 9)),
            new Cat("Coffee", new DateTime(2018, 02, 19)),
            new Cat("Kiwi", new DateTime(2017, 04, 23))
        };

        Array.Sort(Cats);

        // Print the array
        for (int i = 0; i < Cats.Length; i++) {
            System.Console.WriteLine($"{Cats[i].Name}");
        }


        // Making a cat run
        // double speed = nana.SpeedUp(2);
        // System.Console.WriteLine($"{nana.Name} is running at {speed} km/hr.");

        // // Call instance method
        // Cat kitty1 = nana.ProduceKitty(coffee);
        // kitty1.Name = "Naffee";

        // // call static method
        // //Cat kitty2 = Cat.ProduceKitty(kiwi, coffee);
        // /*operator call*/ Cat kitty2 = kiwi * coffee;
        // kitty2.Name = "Kiffee";

        // System.Console.WriteLine($"{nana.Name} has {nana.Children.Count} kitty.");
        // System.Console.WriteLine($"{coffee.Name} has {coffee.Children.Count} kitty.");
        // System.Console.WriteLine($"{kiwi.Name} has {kiwi.Children.Count} kitty.");

        // can't access Dog here because class is internal (only usable in origin folder)

        //OwnPets myPets = new OwnPets();
        //myPets.WriteToconsole();
    }
}
