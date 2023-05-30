namespace Delegates
{
    public class Program
    {
        public static void Main()
        {
            Operation sum = Sum;
            Operation multiply = Multiply;
            Operation subtract = Subtract;
            
            var test = sum + multiply + subtract;

            Operation test1 = multiply;
            test1 += sum;
            test1 += subtract;

            test(5, 2);
            Console.WriteLine();
            Console.WriteLine(new string('=', 50));
            Console.WriteLine();
            test1(7, 3);
        }

        public delegate void Operation(int a, int b);

        public static void Multiply(int a, int b)
        {
            Print((a * b).ToString());
        }

        public static void Subtract(int a, int b)
        {
            Print((a - b).ToString());
        }

        public static void Sum(int a, int b)
        {
            Print((a + b).ToString());
        }

        public static void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}