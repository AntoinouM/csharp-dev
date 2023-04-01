using System;

namespace GeometryLibrary
{
    public abstract class BasicTetrahedonProperty {

    }

    public class Tetrahedon<TVertex, TTetrahedon> : SShape<TVertex> 
    where TVertex : BasicVertexProperty, new() 
    where TTetrahedon : BasicTetrahedonProperty, new ()
    {
        private TTetrahedon _property = new TTetrahedon();

        public TTetrahedon Propriety {
            get {return _property;}
            set {_property = value;}
       }
        
        public override void GetCentroid() {

        }
    }


}