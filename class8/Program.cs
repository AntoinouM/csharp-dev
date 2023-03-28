namespace class8;    

class Program
{
    static void Main(string[] args) 
    {
        int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9};
        Console.WriteLine(string.Join(",", AddOne(array)));
        Console.WriteLine(string.Join(",", MultipleTwo(array)));
        Console.WriteLine(string.Join(",", Square(array)));


    }

    public static int[] AddOne(int[] _array) {
        int[] array = new int[_array.Length];
        for(int i = 0; i < _array.Length; i++) {
            array[i] = _array[i] + 1;
        }
        return array;
    }

    public static int[] MultipleTwo(int[] _array) {
        int[] array = new int[_array.Length];
        for(int i = 0; i < _array.Length; i++) {
            array[i] = _array[i] * 2;
        }
        return array;
    }

    public static int[] Square(int[] _array) {
        int[] array = new int[_array.Length];
        for(int i = 0; i < _array.Length; i++) {
            array[i] = _array[i] * _array[i];
        }
        return array;
    }
}
