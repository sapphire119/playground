using System.Diagnostics;

Time(async () =>
{
    Console.WriteLine("Enter");
    await Task.Delay(TimeSpan.FromSeconds(10));
    Console.WriteLine("Exit");
});

static void Time(Action action)
{
    var oldCtx = SynchronizationContext.Current;
    try
    {
        var newCtx = new CountdownContext();
        SynchronizationContext.SetSynchronizationContext(newCtx);

        Console.WriteLine("Timing...");
        Stopwatch sw = Stopwatch.StartNew();

        action();
        newCtx.SignalAndWait();

        Console.WriteLine($"...done timing: {sw.Elapsed}");
    }
    finally
    {
        SynchronizationContext.SetSynchronizationContext(oldCtx);
    }
}

sealed class CountdownContext : SynchronizationContext
{
    private readonly ManualResetEventSlim _mres = new ManualResetEventSlim(false);
    private int _remaining = 1;

    public override void OperationStarted() => Interlocked.Increment(ref _remaining);

    public override void OperationCompleted()
    {
        if (Interlocked.Decrement(ref _remaining) == 0)
        {
            _mres.Set();
        }
    }

    public void SignalAndWait()
    {
        OperationCompleted();
        _mres.Wait();
    }
}