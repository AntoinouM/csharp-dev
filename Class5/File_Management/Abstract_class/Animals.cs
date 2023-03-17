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

        public void WriteToConsole()
        {
            System.Console.WriteLine($"{Name} was born on a {DateOfBirth:dddd}");
        }

    }
}