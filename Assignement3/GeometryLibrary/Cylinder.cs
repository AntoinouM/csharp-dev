using System;

namespace GeometryLibrary
{
    public abstract class BasicCylinderProperties {
        public float Radius {get; set;}
    }

    public class Cylinder<TCylinder> : SShape where TCylinder : BasicCylinderProperties, new() 
     {

        private TCylinder _property = new TCylinder();

        public Cylinder() : base(2) {}

       public TCylinder Property {
            get {return _property;}
            set {_property = value;}
       }
        // Methods
            // Surface area
        sealed public override float SurfaceArea() {
            Thread.Sleep(1000); //mandatory sleeping time requirement
            return 0;
        }
            // Volume
        sealed public override float Volume() {
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