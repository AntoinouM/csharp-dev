namespace class8;    

class Program
{
    // Declare the delegate
    // public delegate int ChangeValueDelegate(int x);
    // public delegate T ChangeValueDel<T>(T x);
    static void Main(string[] args) 
    {
        // int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9};

        // Instantiate 3 delegate object that will handle the operation addone, multiplebytwo, and square
        // ChangeValueDelegate delegateAddOne = new ChangeValueDelegate(AddOneShort);
        // ChangeValueDelegate delegateMultipleTwo = new ChangeValueDelegate(MultipleTwoShort);
        // ChangeValueDelegate delegateSquare = new ChangeValueDelegate(SquareShort);

        // Console.WriteLine(string.Join(",", AddOne(array)));
        // Console.WriteLine(string.Join(",", MultipleTwo(array)));
        // Console.WriteLine(string.Join(",", Square(array)));

        // System.Console.WriteLine(string.Join(",", Change(array, delegateAddOne)));
        // System.Console.WriteLine(string.Join(",", Change(array, delegateMultipleTwo)));
        // System.Console.WriteLine(string.Join(",", Change(array, delegateSquare)));


        Action<int, int> Addition = new Action<int, int> (PrintAddNumbers);
        Addition(10, 20);

        Func<int, int, int> AddNumbers = new Func<int, int, int> (AddNumbersOpe); // the last int of the Fun is the return type
        Console.WriteLine(AddNumbers(10, 20));

        Predicate<string> ChecikIfApple = new Predicate<string>(IsApple);
        bool result = ChecikIfApple("IphoneX");
        if (result) {
            
        }
    }

    private static void PrintAddNumbers(int num1, int num2) {
        int result = num1 + num2;
        Console.WriteLine($"Addition result: {result}");
    }

    private static int AddNumbersOpe(int num1, int num2) {
        return num1 + num2;
    }


    // public static int AddOneShort(int number) {
    //     return number + 1;
    // }
    // public static int MultipleTwoShort(int number) {
    //     return number * 2;
    // }
    // public static int SquareShort(int number) {
    //     return number * number;
    // }

    // public static int[] Change(int[] _array, ChangeValueDelegate changeValue) {
    //     int[] array = new int[_array.Length];
    //     for (int i = 0; i < _array.Length; i++) {
    //         array[i] = changeValue(_array[i]);
    //     }
    //     return array;
    // }

    // public static int[] AddOne(int[] _array) {
    //     int[] array = new int[_array.Length];
    //     for(int i = 0; i < _array.Length; i++) {
    //         array[i] = _array[i] + 1;
    //     }
    //     return array;
    // }

    // public static int[] MultipleTwo(int[] _array) {
    //     int[] array = new int[_array.Length];
    //     for(int i = 0; i < _array.Length; i++) {
    //         array[i] = _array[i] * 2;
    //     }
    //     return array;
    // }

    // public static int[] Square(int[] _array) {
    //     int[] array = new int[_array.Length];
    //     for(int i = 0; i < _array.Length; i++) {
    //         array[i] = _array[i] * _array[i];
    //     }
    //     return array;

    // }

}


