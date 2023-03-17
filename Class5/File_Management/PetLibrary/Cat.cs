using System;

namespace PetLibrary;
public class Cat
{
    // Fields
    public string Name;
    public DateTime DateOfBirth;
    public List<Cat> Children = new List<Cat>();

    // Constructors
    public Cat() {
        Name = "Unknowm cat";
        DateOfBirth = DateTime.Today;
    }

    public Cat(string name, DateTime dateOfBirth) {
        this.Name = name;
        this.DateOfBirth = dateOfBirth;
    }

    // Getters and setters

    // Finalizer
    ~Cat() {

    }
    // Methods
    public void WritetoConsole() {
        System.Console.WriteLine($"{Name} was born on a {DateOfBirth:dddd}");
    }

    /////// Produce kitty function
    /* static method "multiply" */
    public static Cat ProduceKitty(Cat cat1, Cat cat2) 
    {
        Cat kitty = new Cat 
        {
            Name = $"Baby of {cat1.Name} and {cat2.Name}"
        };

        cat1.Children.Add(kitty);
        cat2.Children.Add(kitty);

        return kitty;
    }

    // same thing but use an operator call (see Program)
    public static Cat operator * (Cat cat1, Cat cat2)
    {
        return Cat.ProduceKitty(cat1, cat2);
    }

    /* Instance method multiply */
    public Cat ProduceKitty(Cat partner) // can be called by a Cat instance.
    {
        return Cat.ProduceKitty(this, partner);
     }
 }
