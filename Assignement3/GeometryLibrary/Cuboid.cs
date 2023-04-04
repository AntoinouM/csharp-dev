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
            // Centroid
        sealed public override Position Centroid() {
            return base.Centroid();
        }
            // Volume
        // sealed public override float Volume() {
        //     base.Volume();
        //     return base.Volume();
        // }

        // Methods non-inheritated
        public Position[] OrganisePoints(Position[] arrayToOrganize) {
            Position[] btmFace = returnBtmFace(arrayToOrganize);
            Position[] topFace = returnTopFace(arrayToOrganize);

            Position origin = new Position(0f, 0f, 0f);
            Position farthestVertexBtmFace = returnFarthestVertex(btmFace, origin);
            Position closestVertexBtmFace = returnFarthestVertex(btmFace, farthestVertexBtmFace);
            Position farthestVertexTopFace = returnFarthestVertex(topFace, origin);
            Position closestVertexTopFace = returnFarthestVertex(topFace, farthestVertexTopFace);

            float xMax = minMaxCoord(btmFace, 'x')[1];
            Position point4btm = returnFarthestVertex(btmFace, new Position(xMax, closestVertexBtmFace.y, closestVertexBtmFace.z));
            Position point2btm = returnFarthestVertex(btmFace, point4btm);
            Position point4top = returnFarthestVertex(topFace, new Position(xMax, closestVertexTopFace.y, closestVertexTopFace.z));
            Position point2top = returnFarthestVertex(topFace, point4top);
            
            Position[] btmFaceOrganized = new Position[] {
                closestVertexBtmFace,
                point2btm,
                farthestVertexBtmFace,
                point4btm
            };
            Position[] topFaceOrganized = new Position[] {
                closestVertexTopFace,
                point2top,
                farthestVertexTopFace,
                point4top
            };

            Position[] organizedArr = new Position[arrayToOrganize.Length];
            btmFaceOrganized.CopyTo(organizedArr, 0);
            topFaceOrganized.CopyTo(organizedArr, btmFaceOrganized.Length);

            return organizedArr;
        }

        public Position returnFarthestVertex(Position[] arr, Position origin) {
            Position farthestVertex = arr[0];
            float maxDistance = 0;

            for (int i = 0; i < arr.Length; i++) {
                float distance = cartesianDistance(arr[i], origin);
                if (distance > maxDistance) {
                    maxDistance = distance;
                    farthestVertex = arr[i];
                }
            }
            return farthestVertex;
        }

        public float cartesianDistance(Position point, Position origin) {
            float distance = Math.Abs(point.x - origin.x) +
                            Math.Abs(point.y - origin.y) +
                            Math.Abs(point.z - origin.z);
            return distance;
        }

        public float[] minMaxCoord(Position[] arr, char coord) {
            float[] coordArray = new float[arr.Length];

            switch (coord) {
                case 'y':
                    for (int i = 0; i < arr.Length; i++) {
                        coordArray[i] = arr[i].y;
                    }
                        break;
                case 'z':
                    for (int i = 0; i < arr.Length; i++) {
                        coordArray[i] = arr[i].z;
                    }
                    break;
                default:
                    for (int i = 0; i < arr.Length; i++) {
                        coordArray[i] = arr[i].x;
                    }
                    break;
            }
            float[] minMaxArr = new float[2];
            float min = coordArray[0];
            for (int i = 1; i < coordArray.Length; i++) {
                if (coordArray[i] < min) {
                    min = coordArray[i];
                }
            }
            float max = coordArray[0];
            for (int i = 1; i < coordArray.Length; i++) {
                if (coordArray[i] > max) {
                    max = coordArray[i];
                }
            }
            minMaxArr[0] = min;
            minMaxArr[1] = max;


            return minMaxArr;
        }

        public Position[] returnTopFace(Position[] arr) {
            Position[] btmFace = returnBtmFace(arr);
            Position[] topFace = new Position[4];

            int pos = 0;
            for (int i = 0; i < arr.Length; i++) {
                if (pos == topFace.Length) {break;}
                if (arr[i] != btmFace[0] &&
                    arr[i] != btmFace[1] &&
                    arr[i] != btmFace[2] &&
                    arr[i] != btmFace[3]) {
                        topFace[pos] = arr[i];
                        pos++;
                    }
            }
            return topFace;
        }

        public Position[] returnBtmFace(Position[] arr) {
            Position[] btmFace = new Position[4];
            IterativeIncrementation(btmFace, arr, 0);
            return btmFace;
        }

        public void IterativeIncrementation(Position[] destArr, Position[] srcArr, uint index) {
            if (index == destArr.Length) {return;}
            // look for the minimun
            float minY = MathF.Abs(minMaxCoord(srcArr, 'y')[0]);

            // find the first point with minY and add it to destArr
            Position chosenPoint = new Position(float.MaxValue, float.MaxValue, float.MaxValue);
            for (int i = 0; i < srcArr.Length; i++) {
                if (srcArr[i].y <= minY && (chosenPoint == new Position(float.MaxValue, float.MaxValue, float.MaxValue) || srcArr[i].y < chosenPoint.y)) {
                    chosenPoint = srcArr[i];
                }
            }
            destArr[index] = chosenPoint;
            // create a new array without the chosen point
            Position[] generatedArr = new Position[srcArr.Length - 1];
            int j = 0;
            for (int i = 0; i < srcArr.Length; i++) {
                if (srcArr[i] != chosenPoint) {
                    generatedArr[j] = srcArr[i];
                    j++;
                }
            }
            // call IterativeIncrementation recursively with the updated arrays
            IterativeIncrementation(destArr, generatedArr, index + 1);
        }
    }
}