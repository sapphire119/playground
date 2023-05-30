using System.Runtime.ExceptionServices;
using System.Security.Cryptography;

namespace AsyncAwaitInDetail
{
    public class ExampleCustomTask
    {
        private bool _completed;
        private Exception? _error;
        private Action<ExampleCustomTask> _continuation;
        private ExecutionContext? _ec;

        public void ContinueWith(Action<ExampleCustomTask> action)
        {
            lock (this)
            {
                if (_completed)
                {
                    ThreadPool.QueueUserWorkItem(_ => action(this));
                }
                else if(_continuation is not null)
                {
                    throw new InvalidOperationException("Unlike Task, this implementation only supports a single continuation.");
                }
                else
                { 
                    _continuation = action;
                    _ec = ExecutionContext.Capture();
                }
            }
        }

        public void SetResult() => Complete(null);

        public void SetException(Exception error) => Complete(error);

        private void Complete(Exception? error)
        {
            lock (this)
            {
                if (_completed)
                {
                    throw new InvalidOperationException("Already completed");
                }

                _error = error;
                _completed = true;

                if (_continuation is not null)
                {
                    ThreadPool.QueueUserWorkItem(_ =>
                    {
                        if (_ec is not null)
                        {
                            ExecutionContext.Run(_ec, _ => _continuation(this), null);
                        }
                        else
                        {
                            _continuation(this);
                        }
                    });
                }
            }
        }

        public void Wait()
        {
            ManualResetEventSlim? mres = null;
            lock (this)
            {
                if (!_completed)
                {
                    mres = new ManualResetEventSlim();
                    ContinueWith(_ => mres.Set());
                }
            }

            mres?.Wait();
            if (_error is not null)
            {
                ExceptionDispatchInfo.Throw(_error);
            }
        }

        public static ExampleCustomTask WhenAll(ExampleCustomTask t1, ExampleCustomTask t2)
        {
            var t = new ExampleCustomTask();

            int remaining = 2;
            Exception? e = null;

            Action<ExampleCustomTask> continuation = completed =>
            {
                e ??= completed._error; // just store a single exception for simplicity
                if (Interlocked.Decrement(ref remaining) == 0)
                {
                    if (e is not null) t.SetException(e);
                    else t.SetResult();
                }
            };

            t1.ContinueWith(continuation);
            t2.ContinueWith(continuation);

            return t;
        }

        public static ExampleCustomTask Run(Action action)
        {
            var t = new ExampleCustomTask();

            ThreadPool.QueueUserWorkItem(_ =>
            {
                try
                {
                    action();
                    t.SetResult();
                }
                catch (Exception e)
                {
                    t.SetException(e);
                }
            });

            return t;
        }

        public static ExampleCustomTask Delay(TimeSpan delay)
        {
            var t = new ExampleCustomTask();

            var timer = new Timer(_ => t.SetResult());
            timer.Change(delay, Timeout.InfiniteTimeSpan);

            return t;
        }
    }
}
