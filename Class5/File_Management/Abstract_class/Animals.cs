namespace Animals 
{
    public abstract class Animals
    {
        public abstract void Speak();
        public virtual void Move() // can leave like this or implement body (as below)
        {
            System.Console.WriteLine("Move like an animal!");
        }
    }

    public class Cat : Animals
    {
        public string Name;
        public DateTime DateOfBirth;

        public Cat(string name, DateTime dateOfBirth)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
        }

        public override void Speak() // use override keyword to nitify that you override the method from abstraxt class
        {
            System.Console.WriteLine("Meow!");
        }

        public sealed override void Move()
        {
            System.Console.WriteLine("Move like a Cat.");
        }

        public virtual void WriteToConsole()
        {
            System.Console.WriteLine($"{Name} was born on a {DateOfBirth:dddd}");
        }

    }

    public class WildCat : Cat 
  {
        public WildCat(string name, DateTime dateOfBirth) : base (name, dateOfBirth)
        {
            // Name = name;
            // DateOfBirth = dateOfBirth;
        }

        public override void WriteToConsole() // can't do this because method is in parent Class. T override, make it virtual in parent class
        {
            System.Console.WriteLine($"{Name} was born on a {DateOfBirth:dddd}");
        }
  }  

}