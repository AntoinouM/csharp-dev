using System;
using System.Collections;

namespace GeometryLibrary
{
    public struct Position {
        private float _x;
        private float _y;
        private float _z;
        private bool _declared = false;

        public Position(float xPos, float yPos, float zPos) {
            this._x = xPos;
            this._y = yPos;
            this._z = zPos;
            this._declared = true;
        }

        public float x {
            get {return _x;}
            set {_x = value;}
        }
        public float y {
            get {return _y;}
            set {_y = value;}
        }
        public float z {
            get {return _z;}
            set {_z = value;}
        }
        public bool Declared {
            get {return _declared;}
            set {_declared = value;}
        }
        public static bool operator ==(Position a, Position b)
        {
            return a.x == b.x && a.y == b.y && a.z == b.z;
        }

        public static bool operator !=(Position a, Position b)
        {
            return !(a == b);
        }
        public override bool Equals(object? obj)
        {
            if (!(obj is Position))
            {
                return false;
            }
            Position other = (Position)obj;
            return x == other.x && y == other.y && z == other.z;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = _x.GetHashCode();
                hashCode = (hashCode * 397) ^ _y.GetHashCode();
                hashCode = (hashCode * 397) ^ _z.GetHashCode();
                return hashCode;
            }
        }

    }

    public abstract class SShape {
        
        // Field
        protected Position[] _vertices;


        // Constructor
        protected SShape(uint nVertices) {
            _vertices = new Position[nVertices];
        }

        public Position[] Vertices {
            get {return _vertices;}
            set {_vertices = value;}
        }

        // methods
        public void AddVertex(Position vertex) {
            for (int i = 0; i < _vertices.Length; i++) {
                if (!_vertices[i].Declared) {
                    _vertices[i] = vertex;
                    return;
                }
            }
        }
        public void RemoveVertex(Position vertex) {
            Position temp = new Position(0f, 0f, 0f);
            temp.Declared = false;
            for (int i = 0; i < _vertices.Length; i++) {
                if ( (_vertices[i].x == vertex.x) &&
                     (_vertices[i].y == vertex.y) &&
                     (_vertices[i].z == vertex.z) ) {
                        _vertices[i] = temp;
                        break;
                } else {
                    Console.WriteLine($"The vertex (x: {vertex.x}, y: {vertex.y}, z: {vertex.z}) was not found in the shape.");
                }
            }
        }

        public bool HasVertex(Position vertex) {
            for (int i = 0; i < _vertices.Length; i++) {
                if ( (_vertices[i].x == vertex.x) &&
                     (_vertices[i].y == vertex.y) &&
                     (_vertices[i].z == vertex.z) ) {
                        return true;
                    } 
            }
            return false;
        }
        //GetCentroid
        public virtual Position Centroid() {
            return new Position();
        }
        //SurfaceArea
        public abstract void SurfaceArea();
        //Volume
        public virtual float Volume() {
            return 0;
        }

        // Finaliser
        ~SShape() {}

    }


}