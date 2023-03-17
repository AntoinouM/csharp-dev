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

}
