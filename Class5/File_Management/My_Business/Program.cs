using System;
using PetLibrary;

namespace My_Business;
class Program
{
    static void Main(string[] args)
    {
        Cat nana = new Cat("Nana", new DateTime(2019, 12, 9));
        nana.WritetoConsole();

        OwnPets myPets = new OwnPets();
        myPets.WriteToconsole();
    }
}
