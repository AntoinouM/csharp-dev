using System;

namespace GeometryLibrary
{
    public abstract class BasicTetrahedonProperty {

    }

    public class Tetrahedon<TTetrahedon> : SShape where TTetrahedon : BasicTetrahedonProperty, new ()
    {
        private TTetrahedon _property = new TTetrahedon();
        private TriFace[] _triFaces = new TriFace[4];

        public TTetrahedon Propriety {
            get {return _property;}
            set {_property = value;}
       }

       public Tetrahedon(Position p1, Position p2, Position p3, Position p4) : base(4) {  
            _triFaces = new TriFace[] {
                new TriFace(p1, p2, p3), 
                new TriFace(p1, p2, p4), 
                new TriFace(p1, p3, p4), 
                new TriFace(p2, p3, p4) 
            };
       }

        sealed public override float SurfaceArea() {
            Thread.Sleep(1000); //mandatory sleeping time requirement
            float totalSurface = _triFaces.Aggregate(0, (float total, TriFace next) => total + next.Surface);
            return totalSurface;
        }
    }
}