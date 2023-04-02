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
        // Methods
            // Surface area
        public override void SurfaceArea() {
            Thread.Sleep(1000); //mandatory sleeping time requirement
        }
            // Volume
        public override float Volume() {
            return base.Volume();
        }
            // Height
        public float Height() {
            return 0;
        }
            // BottomArea
        public float BottomArea() {
            return 0;
        }
    }


}