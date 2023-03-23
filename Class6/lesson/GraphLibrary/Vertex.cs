namespace GraphLibrary;

public struct VertexProperty
{
    // Fields
    public uint Id;
    public string Name;
}

public class Vertex 
{
    // Fields
    private VertexProperty _property;

    // Constructor
    public Vertex( uint id, string name)
    {
        _property = new VertexProperty();
        _property.Id = id;
        _property.Name = name;
    }

    // Getters and Setters
    public VertexProperty Property {
        get {return _property;}
        set {_property = value;}
    }

    // Methods

    // Finaliser
    ~Vertex() {}
}