using System;

namespace GeometryLibrary
{
    public abstract class BasicCuboidProperty {

    }

    public class Cuboid<TCuboid> : SShape where TCuboid : BasicCuboidProperty, new() 
    {
        // Fields
        private TCuboid _property = new TCuboid(); // instantiate a new instance of generic property

        // Getters Setters
        public TCuboid Propriety {
            get {return _property;}
            set {_property = value;}
       }

        // Methods
            // Surface Area
        public override void SurfaceArea() {
            Thread.Sleep(1000); //mandatory sleeping time requirement
        }
            // Centroid
        public override Position Centroid() {
            return base.Centroid();
        }
            // Volume
        public override float Volume() {
            return base.Volume();
        }

        
    }


}