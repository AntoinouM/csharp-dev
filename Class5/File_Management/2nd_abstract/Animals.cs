namespace _2nd_abstract 
{
    public class Cat
    {
        public object? food = default(object);

        public string checkedFood(object input)
        {
            if(food == null)
            {
                return "Expected food is empty.";
            }
            else if (food == input)
            {
                return "Expected food and input are the same";
            } else 
            {
                return "Expected food and input are NOT the same";
            }
        }

    }

    public class GenericCat<T> where T : IComparable
    {
        public T? food = default(T?);
        
        public string checkFood(T input) {
            if(food == null) {
                return "expected food is empty";
            }
            else if(food.CompareTo(input) == 0) {
                return "Expected food and input are the same";
            }
            else {
                return "Expected food and input are NOT the same";
            }
        }
    }

    public class GenericMethodCat {
        public static double DoubleMyFood<T>(T input) where T : IConvertible {
            double d = input.ToDouble(Thread.CurrentThread.CurrentCulture);

            return 2.0 * d;
        }
    }
}