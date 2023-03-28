namespace GeometryLibrary;

public struct Position {
        public float x;
        public float y;
        public float z;
}

public abstract class BasicVertexProperty
{    
    public Position position;
}

public class Vertex<T> where T: BasicVertexProperty, new() // this is a constraint because we want to initiate a new instance later
{
    // Fields
    private T _property;

    // Constructor
    public Vertex(float xPos, float yPos, float zPos)
    {
        _property = new T();
        _property.position.x = xPos;
        _property.position.y = yPos;
        _property.position.z = zPos;
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
