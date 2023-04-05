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

        sealed public override float SurfaceArea() {
            Thread.Sleep(1000); //mandatory sleeping time requirement

            TriFace[] faces = new TriFace[] {
                new TriFace(_vertices[0], _vertices[1], _vertices[2]), 
                new TriFace(_vertices[0], _vertices[1], _vertices[3]), 
                new TriFace(_vertices[0], _vertices[2], _vertices[3]), 
                new TriFace(_vertices[1], _vertices[2], _vertices[3]) 
            };

            float totalSurface = faces.Aggregate(0, (float total, TriFace next) => total + next.Surface);
            return totalSurface;
        }
    }
}