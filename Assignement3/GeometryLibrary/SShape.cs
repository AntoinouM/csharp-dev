using System;

namespace GeometryLibrary
{
    public struct Position {
        private float _x;
        private float _y;
        private float _z;

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
    }

    public abstract class SShape {
        
        // Field
        private LinkedList<Position> _vertices;
        private uint _nVertices;

        // Constructor
        public SShape() {
            _vertices = new LinkedList<Position>();
            _nVertices = 0;
        }

        public LinkedList<Position> Vertices {
            get {return _vertices;}
        }

        public uint NumberOfVertices {
            get {return _nVertices;}
            set {_nVertices = value;}
        }

        // methods
        public virtual void AddVertices(Position vertex) {
            _vertices.AddLast(vertex);
            _nVertices++;
        }
        //GetCentroid
        public abstract void GetCentroid();
        //SurfaceArea
        //Volume

        // Finaliser
        ~SShape() {}

    }


}