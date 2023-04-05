using System;

namespace GeometryLibrary
{
    public abstract class BasicCuboidProperty {

    }

    /* All input should be in the order convention:
         8_________________________ 7
         /|                       /| 
       5/_|____________________6_/ | 
        | |                     |  | 
        | |_4___________________|__| 3
        | /                     | /  
        |/______________________|/
        1                       2
*/

    public class Cuboid<TCuboid> : SShape where TCuboid : BasicCuboidProperty, new() 
    {
        // Fields
        private TCuboid _property = new TCuboid(); // instantiate a new instance of generic property

        private Position[] _btmFace = new Position[4];
        private Position[] _rightFace = new Position[4];
        private Position[] _topFace = new Position[4];
        private Position[] _leftFace = new Position[4];
        private Position[] _frontFace = new Position[4];
        private Position[] _backFace = new Position[4];
        private TriFace[] _triFaces = new TriFace[12];

        public Cuboid(Position p1, Position p2, Position p3, Position p4, Position p5, Position p6, Position p7, Position p8) : base(8) {
            btmFace = new Position[] { p1, p2, p3, p4};
            topFace = new Position[] { p5, p6, p7, p8};
            rightFace = new Position[] { p2, p3, p7, p6};
            leftFace = new Position[] { p1, p4, p8, p5};
            frontFace = new Position[] { p1, p4, p8, p5};
            backFace = new Position[] { p1, p4, p8, p5};

            _vertices = new Position[] { p1, p2, p3, p4, p5, p6, p7, p8 };

            // setting up some trigo faces for easier calculations
            _triFaces = new TriFace[] {
                // 2 triangles btm face
                new TriFace(p1, p2, p4),
                new TriFace(p2, p3, p4),
                // 2 triangles right face            8_________________________ 7
                new TriFace(p2, p3, p7),  //         /|                       /| 
                new TriFace(p2, p7, p6),  //       5/_|____________________6_/ | 
                // 2 triangles top face             | |                     |  |         
                new TriFace(p5, p6, p8),  //        | |_4___________________|__| 3
                new TriFace(p8, p6, p7),  //        | /                     | /  
                // 2 triangles left face            |/______________________|/
                new TriFace(p1, p5, p4),  //        1                       2
                new TriFace(p4, p5, p8),
                // 2 triangles front face
                new TriFace(p1, p2, p6),
                new TriFace(p1, p5, p6),
                // 2 triangles back face
                new TriFace(p4, p3, p7),
                new TriFace(p4, p7, p8)
            };
        }



        // Getters Setters
        public TCuboid Propriety {
            get {return _property;}
            set {_property = value;}
       }

        public Position[] btmFace {get;}
        public Position[] topFace {get;}
        public Position[] rightFace {get;}
        public Position[] leftFace {get;}
        public Position[] frontFace {get;}
        public Position[] backFace {get;}


        // Methods
            // Surface Area
        sealed public override float SurfaceArea() {
            Thread.Sleep(1000); //mandatory sleeping time requirement
            float totalSurface = _triFaces.Aggregate(0, (float total, TriFace next) => total + next.Surface);
            return totalSurface;
        }

           // Volume
        sealed public override float Volume() {
            Position centroid = base.Centroid(_vertices);
            // I have 12 triangular face -- in a _triFaces array
            // I want to create 12 tetrahedrons -- a tetrahedron is an array of 4 vertices
            // Create an array to hold my tetrahedrons:
            Position[][] tetraArr = new Position[_triFaces.Length][];

            // Increment if with the 4 points (all point to the centroid)
            for (int i = 0; i < tetraArr.Length; i++) {
               tetraArr[i] = extractAndConcatenate(_triFaces[i], centroid);
            }
            // create an array that hold the volume of all tetra
            // formula : https://keisan.casio.com/exec/system/1223609147 create in SShape in case to use in another class
            float[] volTetraArr = new float[tetraArr.Length];
            for (int i = 0; i < volTetraArr.Length; i++) {
               volTetraArr[i] = VolumeTetrahedron(tetraArr[i]);
            }
            
            // sum all element of volume array
            float volume = volTetraArr.Aggregate(0, (float total, float next) => total + next);

            Position[] extractAndConcatenate(TriFace tf, Position p) {
                Position[] tempArr = new Position[tf.Vertices.Count() + 1];
                for (int i = 0; i < tf.Vertices.Count(); i++) {
                    tempArr[i] = tf.Vertices[i];
                }
                tempArr[tempArr.Length - 1] = p;
                return tempArr;
            }

            return volume;
        }

        // Methods non-inheritated

    }
}
