using System;

namespace GeometryLibrary
{

    public abstract class SShape<TVertex> where TVertex : BasicVertexProperty, new() {
        
        // Field
        private LinkedList<Vertex<TVertex>>? _vertices;
        private uint _nVertices;

        // Constructor
        public SShape() {
            _vertices = new LinkedList<Vertex<TVertex>>();
            _nVertices = 0;
        }

        public LinkedList<Vertex<TVertex>> Vertices {
            get {return _vertices!;}
        }

        public uint NumberOfVertices {
            get {return _nVertices;}
            set {_nVertices = value;}
        }

        // methods
        public virtual void AddVertices(Vertex<TVertex> vertex) {
            _vertices!.AddLast(vertex);
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