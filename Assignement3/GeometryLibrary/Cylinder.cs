using System;

namespace GeometryLibrary
{
    public abstract class BasicCylinderProperties {
        public float Radius {get; set;}
    }

    public class Cylinder<TCylinder> : SShape where TCylinder : BasicCylinderProperties, new() 
     {

        private TCylinder _property = new TCylinder();
        private float _height;
        private float _PI = MathF.PI;

        public Cylinder(Position p1, Position p2, float radius) : base(2) {
            _vertices = new Position[] { p1, p2 };
            _property.Radius = radius;
            _height = MathF.Sqrt(Pow2(p2.y - p1.y));
            _height = MathF.Sqrt(Pow2(p2.y - p1.y));
        }

       public TCylinder Property {
            get {return _property;}
            set {_property = value;}
       }
        // Methods
            // height
        public float Height {
            get {return _height;}
        }
            // Surface area
        sealed public override float SurfaceArea() {
            Thread.Sleep(1000); //mandatory sleeping time requirement
            // Formula : 2πrh + 2 * πr2 (side surface + 2 * surface area)
            float sideArea = 2 * _PI * _height * _property.Radius;
            float surface = BottomArea();
            return sideArea + (2 * surface);
        }
            // Volume
        sealed public override float Volume() {
            // Formula : π r² h
            return _PI * Pow2(_property.Radius) * _height;
        }
            // BottomArea
        public float BottomArea() {
            // Formula : π r²
            return _PI * Pow2(_property.Radius);
        }
    }


}