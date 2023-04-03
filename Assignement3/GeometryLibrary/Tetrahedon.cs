using System;

namespace GeometryLibrary
{
    public abstract class BasicTetrahedonProperty {
        
    }

    public class Tetrahedon<TTetrahedon> : SShape where TTetrahedon : BasicTetrahedonProperty, new ()
    {
        private TTetrahedon _property = new TTetrahedon();

        public TTetrahedon Propriety {
            get {return _property;}
            set {_property = value;}
       }

       public Tetrahedon() : base(4) {
            
       }
        
        sealed public override void SurfaceArea() {
            Thread.Sleep(1000); //mandatory sleeping time requirement
        }

        sealed public override Position Centroid()
        {
            return base.Centroid();
        }
    }


}