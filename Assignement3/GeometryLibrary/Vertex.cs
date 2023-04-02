namespace GeometryLibrary;

public abstract class BasicVertexProperty
{    
    public float x;
    public float y;
    public float z;  
}

public class Vertex<T> where T: BasicVertexProperty, new() // this is a constraint because we want to initiate a new instance later
{
    // Fields
    private T _position;

    // Constructor
    public Vertex(float xPos, float yPos, float zPos)
    {
        _position = new T();
        _position.x = xPos;
        _position.y = yPos;
        _position.z = zPos;
    }

    // Getters and Setters
    public T Position {
        get {return _position;}
        set {_position = value;}
    }

    // Methods

    // Finaliser
    ~Vertex() {}
}
