namespace GraphLibrary;

public struct EdgeProperty 
{
    // Fields
    public uint Id;
    public uint SourceId;
    public uint TargetId;
}

public class Edge 
{
    // Fields
    private EdgeProperty _property;

    // Constructors
    public Edge(uint id, uint source, uint target) 
    {
        _property = new EdgeProperty();
        _property.Id = id;
        _property.SourceId = source;
        _property.TargetId = target;
    }

    // Getters and setters
    public EdgeProperty Property
    {
        get{return _property;}
        set{_property = value;}
    }

    // Methods

    // Finaliser
    ~Edge() {}
}