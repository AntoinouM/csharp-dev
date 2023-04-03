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

            float xSum = _vertices.Aggregate(0, (float total, Position next) => total + next.x);
            float ySum = _vertices.Aggregate(0, (float total, Position next) => total + next.y);
            float zSum = _vertices.Aggregate(0, (float total, Position next) => total + next.z);

            Position Centroid = new Position(
                xSum / 4,
                ySum / 4,
                zSum / 4
            );

            return Centroid;
        }

        // Methods non-inheritated
        public Position[] OrganisePoints(Position[] arrayToOrganize) {
            Position[] btmFace = returnBtmFace(arrayToOrganize);
            Position topPoint = arrayToOrganize[1];
            for (int i = 0; i < arrayToOrganize.Length; i++) {
                if (arrayToOrganize[i] != btmFace[0] &&
                    arrayToOrganize[i] != btmFace[1] &&
                    arrayToOrganize[i] != btmFace[2]) {
                        topPoint = arrayToOrganize[i];
                    }
            }

            Position origin = new Position(0f, 0f, 0f);
            Position closestVertexBtmFace = returnClosestVertex(btmFace, origin);

            float xMax = minMaxCoord(btmFace, 'x')[1];
            float yMax = minMaxCoord(arrayToOrganize, 'y')[1];
            float zMax = minMaxCoord(arrayToOrganize, 'z')[1];

            Position point2btm = returnClosestVertex(btmFace, new Position(xMax, (closestVertexBtmFace.y + yMax)/2, (closestVertexBtmFace.z)/2));
            Position point3btm = point2btm;

            for (int i = 0; i < btmFace.Length; i++) {
                if (btmFace[i] != closestVertexBtmFace &&
                    btmFace[i] != point2btm) {
                        point3btm = btmFace[i];
                    }
            }
            Position[] organizedArr = new Position[] {
                closestVertexBtmFace,
                point2btm,
                point3btm,
                topPoint
            };

            return organizedArr;
        }

        public Position returnClosestVertex(Position[] arr, Position origin) {
            Position closestVertex = arr[0];
            float minDistance = cartesianDistance(arr[0], origin);

            for (int i = 0; i < arr.Length; i++) {
                float distance = cartesianDistance(arr[i], origin);
                if (distance < minDistance) {
                    minDistance = distance;
                    closestVertex = arr[i];
                }
            }
            return closestVertex;
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
                        coordArray[i] = arr[i].x;
                    }
                        break;
                case 'z':
                    for (int i = 0; i < arr.Length; i++) {
                        coordArray[i] = arr[i].x;
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

        public Position[] returnBtmFace(Position[] arr) {
            Position[] btmFace = new Position[3];
            IterativeIncrementation(btmFace, arr, 0);
            return btmFace;
        }

        public void IterativeIncrementation(Position[] destArr, Position[] srcArr, uint index) {
            if (index == destArr.Length) {return;}
            // look for the minimun
            float minY = minMaxCoord(srcArr, 'y')[0];
            // find the first point with minY and add it to destArr
            Position chosenPoint = new Position(float.MinValue, float.MinValue, float.MinValue);
            for (int i = 0; i < srcArr.Length; i++) {
                if (srcArr[i].y <= minY && (chosenPoint == new Position(float.MinValue, float.MinValue, float.MinValue) || srcArr[i].y < chosenPoint.y)) {
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