using System.Collections.Concurrent;

namespace ExecutionContextExample
{
    public class MyThreadPool
    {
        private static readonly BlockingCollection<(Action, ExecutionContext?)> s_workItems = new();

        public static void QueueWorkItem(Action workItem)
        {
            s_workItems.Add((workItem, ExecutionContext.Capture()));
        }

        static MyThreadPool()
        {
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                new Thread(() =>
                {
                    while (true)
                    {
                        (Action action, ExecutionContext? ec) = s_workItems.Take();
                        if (ec is null)
                        {
                            action();
                        }
                        else
                        {
                            ExecutionContext.Run(ec, s => ((Action)s!)(), action);
                        }

                    }
                })
                { IsBackground = true }.UnsafeStart();
            }
        }
    }
}
