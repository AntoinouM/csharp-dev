using System;
using System.Collections;

namespace GeometryLibrary
{
    public struct TriFace {
        private Position[] _vertices;
        private Edge[] _edges;
        private float _semiPerim;
        private float _surface;
        public TriFace(Position vertex1, Position vertex2, Position vertex3) {

            this._vertices = new Position[] {
                vertex1,
                vertex2,
                vertex3
            };
            this._edges = new Edge[_vertices.Length];
            for (int i = 0; i < _vertices.Length; i++) {
              int j = i + 1;
              j = j >= _vertices.Length ? 0 : i + 1;
              _edges[i] = new Edge(_vertices[i], _vertices[j]);
            }
            // Heron's formula
            this._semiPerim = (_edges[0].Length + _edges[1].Length + _edges[2].Length) / 2;

            this._surface = MathF.Sqrt(
                    _semiPerim *
                    (_semiPerim - _edges[0].Length) *
                    (_semiPerim - _edges[1].Length) *
                    (_semiPerim - _edges[2].Length)
            );
        }
        public Position[] Vertices {
            get {return _vertices;}
            set {_vertices = value;}
        }
        public Edge[] Edges {
            get {return _edges;}
            set {_edges = value;}
        }

        public float Surface {
            get {return _surface;}
        }

    }
    public struct Edge {
        private Position _vertex1;
        private Position _vertex2;
        private float _length;

        public Edge(Position vertex1, Position vertex2) {
            this._vertex1 = vertex1;
            this._vertex2 = vertex2;
            this._length = MathF.Sqrt(
                MathF.Pow(vertex2.x - vertex1.x, 2) +
                MathF.Pow(vertex2.y - vertex1.y, 2) +
                MathF.Pow(vertex2.z - vertex1.z, 2)
            );
        }
        public float Length {
            get {return _length;}
        }


    }
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
            Position temp = new Position(float.MinValue, float.MinValue, float.MinValue);
            temp.Declared = false;
            for (int i = 0; i < _vertices.Length; i++) {
                if (_vertices[i] == vertex) {
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
        public virtual Position Centroid(Position[] arr)
        {

            float xSum = arr.Aggregate(0, (float total, Position next) => total + next.x);
            float ySum = arr.Aggregate(0, (float total, Position next) => total + next.y);
            float zSum = arr.Aggregate(0, (float total, Position next) => total + next.z);

            Position Centroid = new Position(
                xSum / arr.Length,
                ySum / arr.Length,
                zSum / arr.Length
            );
            return Centroid;
        }
        //SurfaceArea
        public abstract float SurfaceArea();
        //Volume
        public virtual float VolumeTetrahedron(Position[] pointArr) {
            Position v1 = pointArr[0];
            Position v2 = pointArr[1];
            Position v3 = pointArr[2];
            Position v4 = pointArr[3];
            
            // formula : https://keisan.casio.com/exec/system/1223609147
            float volume = (v4.x - v1.x) * ((v2.y - v1.y) * (v3.z - v1.z) - (v2.z - v1.z) * (v3.y - v1.y)) +
                    (v4.y - v1.y) * ((v2.z - v1.z) * (v3.x - v1.x) - (v2.x - v1.x) * (v3.z - v1.z)) +
                    (v4.z - v1.z) * ((v2.x - v1.x) * (v3.y - v1.y) - (v2.y - v1.y) * (v3.x - v1.x));

            return Math.Abs((1.0f / 6.0f) * volume);
        }
        public virtual float Volume() {
            return 0;
        }
        public static void WritePositionToConsole(Position[] arr) {
            for (int i = 0; i < arr.Length; i++) {
                System.Console.WriteLine($"Point {i}:    x: {arr[i].x}, y: {arr[i].y}, z: {arr[i].z}");
            }                       
        }
        public static void WritePositionToConsole(Position pos) {
            System.Console.WriteLine($"x: {pos.x}, y: {pos.y}, z: {pos.z}");                     
        }

        public static float Pow2(float num) {
            return MathF.Pow(num, 2);
        }
        public static float euclidDist (Position p1, Position p2) {
            //d = Sqr( (x2 - x1)pow2 + (y2 - y1)pow2 + (z2 - z1)pow2)
            float squaredDist = Pow2(p2.x - p1.x) + Pow2(p2.y - p1.y) + Pow2(p2.z - p1.z);
            return MathF.Sqrt(squaredDist);
        }
        // Finaliser
        ~SShape() {}

    }


}