namespace CustomTask
{
    public class Program
    {
        public static void Main()
        {

        }

        public async MyTask SomeTest(string val)
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            Console.WriteLine(val);
        }

    }
}