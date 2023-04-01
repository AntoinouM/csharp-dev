using System;

namespace GeometryLibrary
{
    public abstract class BasicCuboidProperty {

    }

    public class Cuboid<TVertex, TCuboid> : SShape<TVertex> 
    where TVertex : BasicVertexProperty, new() 
    where TCuboid : BasicCuboidProperty, new() 
    {
        private TCuboid _property = new TCuboid();

        public TCuboid Propriety {
            get {return _property;}
            set {_property = value;}
       }

        public override void GetCentroid() {

        }
        
    }


}