using System;
using Animals;

namespace Class // Note: actual namespace depends on the project name.
{

    internal class Program
    {
        static void Main(string[] args)
        {
          
        }
    }
}

namespace Animals {
    internal class Cat
    {
        //Class fields
        private string _name = "Unknown"; //Cat Name 
        //was public but switch to private to protect the data (for concevntion when private use _... notation)
        public DateTime DateOfBirth;
        //public int Age { get; set; } not a lot of flexibility (see prefer methods below)

    public string getName() {
        return _name;
    }
    private int _age;

    //Read wrtihe property
    public int Age {
        get => _age; //lambda expression
        //get {return _age; }
        set {_age = value; }
    }
    // public void setName(string name) {   // old way to do
    //     _name = name;
    // }

    ~Cat() {
        // code when Object is destructed
    }
    }
}