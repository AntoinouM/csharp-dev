using System;

namespace GeometryLibrary
{
    public abstract class BasicCuboidProperty {

    }

    public class Cuboid<TCuboid> : SShape where TCuboid : BasicCuboidProperty, new() 
    {
        private TCuboid _property = new TCuboid();

        public TCuboid Propriety {
            get {return _property;}
            set {_property = value;}
       }

        public override void SurfaceArea() {

        }
        
    }


}