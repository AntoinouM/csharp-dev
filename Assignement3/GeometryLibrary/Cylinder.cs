using System;

namespace GeometryLibrary
{
    public abstract class BasicCylinderProperties {
        public float Height = 1f;
        public float Radius = 1f;
    }

    public class Cylinder<TVertex, TCylinder> : SShape<TVertex>
     where TVertex : BasicVertexProperty, new()
     where TCylinder : BasicCylinderProperties, new() 
     {

        private TCylinder _property = new TCylinder();

       public TCylinder Property {
            get {return _property;}
            set {_property = value;}
       }

        public override void GetCentroid() {

        }
    }


}