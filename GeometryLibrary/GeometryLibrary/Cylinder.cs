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
        private float _length;
        private float _PI = MathF.PI;

        public Cylinder(Position p1, Position p2, float radius) : base(2) {
            _vertices = new Position[] { p1, p2 };
            _property.Radius = radius;
            _height = MathF.Sqrt(Pow2(p2.y - p1.y));
            _length = euclidDist(p1, p2);
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

        public float Length {
            get {return _length;}
        }
            // Surface area
        sealed public override float SurfaceArea() {
            Thread.Sleep(1000); //mandatory sleeping time requirement
            // shanted side area: 2πrl
            // Formula : 2πrl + 2 * πr2 (side surface for shanted/straight + 2 * surface area)
            float sideArea = 2 * _PI * _property.Radius * _length;
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