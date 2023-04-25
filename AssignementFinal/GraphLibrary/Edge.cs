namespace GraphLibrary;

public abstract class BasicEdgeProperty 
{
    // Fields
    public int Id;
    public int SourceId;
    public int TargetId;
    public int Weight;
}

public class Edge<T> where T: BasicEdgeProperty, new() 
{
    // Fields
    private T _property;

    // Constructors
    public Edge(int id, int source, int target, int weight) 
    {
        _property = new T();
        _property.Id = id;
        _property.SourceId = source;
        _property.TargetId = target;
        _property.Weight = weight;
    }

    // Getters and setters
    public T Property
    {
        get{return _property;}
        set{_property = value;}
    }

    // Methods

    // Finaliser
    ~Edge() {}
}