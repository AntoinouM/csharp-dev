```csharp
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
            Position farthestVertexBtmFace = returnFarthestVertex(btmFace, origin);

            float xMax = minMaxCoord(btmFace, 'x')[1];
            float yMax = minMaxCoord(arrayToOrganize, 'y')[1];
            float zMax = minMaxCoord(arrayToOrganize, 'z')[1];

            Position point2btm = returnFarthestVertex(btmFace, farthestVertexBtmFace);
            Position point3btm = new Position(float.MaxValue, float.MaxValue, float.MaxValue);

            for (int i = 0; i < btmFace.Length; i++) {
                if (btmFace[i] != farthestVertexBtmFace &&
                    btmFace[i] != point2btm) {
                        point3btm = btmFace[i];
                    }
            }
            Position[] organizedArr = new Position[] {
                farthestVertexBtmFace,
                point2btm,
                point3btm,
                topPoint
            };

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

        public Position[] returnBtmFace(Position[] arr) {
            Position[] btmFace = new Position[3];
            IterativeIncrementation(btmFace, arr, 0);
            return btmFace;
        }

        public void IterativeIncrementation(Position[] destArr, Position[] srcArr, uint index) {
            if (index == destArr.Length) {return;} // if index reach destArr.Length then return
            // look for the minimun
            float minY = minMaxCoord(srcArr, 'y')[0];

            // find the first point with minY and add it to destArr
            Position chosenPoint = new Position(float.MaxValue, float.MaxValue, float.MaxValue);
            for (int i = 0; i < srcArr.Length; i++) {
                Position tempPos = srcArr[i];
                //if (tempPos.x < 0) {
                    if (tempPos.y == minY && (chosenPoint == new Position(float.MaxValue, float.MaxValue, float.MaxValue) || tempPos.y < chosenPoint.y)) {
                        chosenPoint = tempPos;
                    }
                //}

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
```

> Method from sorting (tetrahedron)

```csharp
        // methods
        public void AddVertex(Position vertex) {
            for (int i = 0; i < _vertices.Length; i++) {
                if (!_vertices[i].Declared) {
                    _vertices[i] = vertex;
                    return;
                }
            }
        }
        public void RemoveVertex(Position vertex) {
            Position temp = new Position(float.MinValue, float.MinValue, float.MinValue);
            temp.Declared = false;
            for (int i = 0; i < _vertices.Length; i++) {
                if (_vertices[i] == vertex) {
                        _vertices[i] = temp;
                        break;
                } else {
                    Console.WriteLine($"The vertex (x: {vertex.x}, y: {vertex.y}, z: {vertex.z}) was not found in the shape.");
                }
            }
        }

        public bool HasVertex(Position vertex) {
            for (int i = 0; i < _vertices.Length; i++) {
                if ( (_vertices[i].x == vertex.x) &&
                     (_vertices[i].y == vertex.y) &&
                     (_vertices[i].z == vertex.z) ) {
                        return true;
                    } 
            }
            return false;
        }
```
> Vertex management method