public class Person
{
    public string Name {get; set;}
    public decimal Salary {get; set;}

    public Person()
    {
        Name = "unknown";
    }
    public Person(string name, decimal salary)
    {
        Name = name;
        Salary = salary;
    }
}