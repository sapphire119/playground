namespace ExecutionContextExample
{
    public class Program
    {
        public static void Main()
        {
            //SystemThreadPoolExample();
            CustomThreadPoolExample();
        }

        public static void SystemThreadPoolExample()
        {
            var number = new AsyncLocal<int>();
            var nonExecutionContextNumber = default(int);

            number.Value = 42;
            nonExecutionContextNumber = 42;
            //  A copy of the ExecutionContext is always read
            //  ThreadPool.QueueUserWorkItem(_ => Console.WriteLine($"number.Value -> {number.Value}"));
            //  always has the state of the "number" variable, regardless of which thread, continues the execution

            //  Explained by MSFT -> That will print 42 every time this is run. It doesn’t matter that the moment after we queue the delegate we reset the value of the AsyncLocal<int> back to 0, because the ExecutionContext was captured as part of the "QueueUserWorkItem" call, and that capture included the state of the AsyncLocal<int> at that exact moment.
            ThreadPool.QueueUserWorkItem(_ => Console.WriteLine($"number.Value -> {number.Value}"));
            //
            //
            //
            ThreadPool.QueueUserWorkItem(_ => Console.WriteLine($"nonExecutionContextNumber -> {nonExecutionContextNumber}"));

            nonExecutionContextNumber = 0;
            number.Value = 0;

            Console.ReadKey();
        }

        public static void CustomThreadPoolExample()
        {
            var number = new AsyncLocal<int>();
            number.Value = 42;
            MyThreadPool.QueueWorkItem(() => Console.WriteLine($"number.Value -> {number.Value}"));
            number.Value = 0;

            Console.ReadKey();
        }
    }
}