using System;

namespace GeometryLibrary
{
    public abstract class BasicCuboidProperty {

    }

    public class Cuboid<TCuboid> : SShape where TCuboid : BasicCuboidProperty, new() 
    {
        // Fields
        private TCuboid _property = new TCuboid(); // instantiate a new instance of generic property

        public Cuboid() : base(8) {

        }

        // Getters Setters
        public TCuboid Propriety {
            get {return _property;}
            set {_property = value;}
       }

        // Methods
            // Surface Area
        sealed public override float SurfaceArea() {
            Thread.Sleep(1000); //mandatory sleeping time requirement
            return 0;
        }
        
           // Volume
        sealed public override float Volume() {
            base.Volume();
            return base.Volume();
        }

        // Methods non-inheritated

    }
}
