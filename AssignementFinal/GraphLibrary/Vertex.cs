namespace GraphLibrary;

public abstract class BasicVertexProperty
{
    // Fields
    public int Id;
    public string Name = "Unknown Name";
}

public class Vertex<T> where T: BasicVertexProperty, new() // this is a constraint because we want to initiate a new instance later
{
    // Fields
    private T _property;

    // Constructor
    public Vertex( int id, string name)
    {
        _property = new T();
        _property.Id = id;
        _property.Name = name;
    }

    // Getters and Setters
    public T Property {
        get {return _property;}
        set {_property = value;}
    }

    // Methods

    // Finaliser
    ~Vertex() {}
}