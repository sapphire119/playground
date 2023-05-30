namespace ConsoleApp1
{
    public class Program
    {
        static ManualResetEventSlim _event = new ManualResetEventSlim(false);

        public static void Main()
        {
            // Start two threads that will wait for the event to be signaled
            Thread t1 = new Thread(WaitForEvent);
            Thread t2 = new Thread(WaitForEvent);
            t1.Start();
            t2.Start();

            // Wait for a second and then signal the event
            Thread.Sleep(3_000);
            Console.WriteLine("Signaling the event");
            _event.Set();

            // Wait for the threads to complete
            t1.Join();
            t2.Join();

            Console.WriteLine("Done");
        }

        static void WaitForEvent()
        {
            Console.WriteLine("Thread {0} waiting for event", Thread.CurrentThread.ManagedThreadId);

            // Wait for the event to be signaled
            _event.Wait();

            Console.WriteLine("Thread {0} continuing", Thread.CurrentThread.ManagedThreadId);
        }
    }
}