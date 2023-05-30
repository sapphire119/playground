using System.Runtime.CompilerServices;

namespace CustomTask
{
    [AsyncMethodBuilder(typeof(MyTaskMethodBuilder))]
    public class MyTask 
    {
        private bool _completed = false;
        
        public MyTaskAwaiter GetAwaiter() => new MyTaskAwaiter { _task = this };

        private void ContinueWith(Action<object> continuation) => continuation(new object());

        private void Wait()
        {
            
        }

        //  ICriticalNotifyCompletion 
        //  or INotifyCompletion 
        public struct MyTaskAwaiter : ICriticalNotifyCompletion
        {
            internal MyTask _task;

            public bool IsCompleted 
                => _task._completed;

            public void OnCompleted(Action continuation)
                => _task.ContinueWith(_ => continuation());

            public void UnsafeOnCompleted(Action continuation) 
                => _task.ContinueWith(_ => continuation());

            public void GetResult() => _task.Wait();
        }
    }
}