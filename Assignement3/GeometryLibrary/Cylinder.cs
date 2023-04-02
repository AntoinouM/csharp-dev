using System;

namespace GeometryLibrary
{
    public abstract class BasicCylinderProperties {
        public float Height = 1f;
        public float Radius = 1f;
    }

    public class Cylinder<TCylinder> : SShape where TCylinder : BasicCylinderProperties, new() 
     {

        private TCylinder _property = new TCylinder();

       public TCylinder Property {
            get {return _property;}
            set {_property = value;}
       }

        public override void SurfaceArea() {

        }
    }


}