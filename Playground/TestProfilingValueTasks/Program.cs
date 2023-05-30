namespace TestProfilingValueTasks
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

        static async ValueTask SomeMethodAsync()
        {
            for (int i = 0; i < 1000; i++)
            {
                await Task.Yield();
            }
        }
    }
}