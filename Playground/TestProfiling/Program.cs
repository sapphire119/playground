namespace TestProfiling
{
    internal class Program
    {
        static async Task Main()
        {
            var al = new AsyncLocal<int>() { Value = 42 };
            for (int i = 0; i < 1000; i++)
            {
                await SomeMethodAsync();
            }
        }

        static async Task SomeMethodAsync()
        {
            for (int i = 0; i < 1000; i++)
            {
                await Task.Yield();
            }
        }
    }
}