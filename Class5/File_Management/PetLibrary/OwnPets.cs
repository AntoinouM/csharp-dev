namespace PetLibrary;
public class OwnPets
{
 Cat houseCat;
 Dog houseDog;

 public OwnPets()
 {
    houseCat = new Cat();
    houseDog = new Dog();
 }

 public void WriteToconsole()
 {
    System.Console.WriteLine($"{houseCat}'s name is: {houseCat.Name};"); 
    System.Console.WriteLine($"{houseDog}'s name is: {houseDog.Name};"); 
 }
}