namespace ExampleStateMachine
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Threading.Tasks;

    public class ExampleIteratorStateMachine
    {
        private sealed class CopyStreamToStreamAsync_g_PeshoAsync : IEnumerable<Task>, IEnumerable, IEnumerator<Task>, IEnumerator, IDisposable
        {
            private int __state__;

            private Task __current;

            private int __initialThreadId;

            private Stream source;

            public Stream __source;

            private Stream destination;

            public Stream __destination;

            private byte[] buffer5__1;

            private Task<int> read5__2;

            private int numRead5__3;

            private Task write5__4;

            Task IEnumerator<Task>.Current
            {
                get
                {
                    return __current;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return __current;
                }
            }

            public CopyStreamToStreamAsync_g_PeshoAsync(int __state__)
            {
                this.__state__ = __state__;
                __initialThreadId = Environment.CurrentManagedThreadId;
            }

            void IDisposable.Dispose()
            {
            }

            private bool MoveNext()
            {
                switch (__state__)
                {
                    default:
                        return false;
                    case 0:
                        __state__ = -1;
                        buffer5__1 = new byte[4096];
                        goto IL_00f8;
                    case 1:
                        __state__ = -1;
                        numRead5__3 = read5__2.Result;
                        if (numRead5__3 > 0)
                        {
                            write5__4 = destination.WriteAsync(buffer5__1, 0, numRead5__3);
                            __current = write5__4;
                            __state__ = 2;
                            return true;
                        }
                        return false;
                    case 2:
                        {
                            __state__ = -1;
                            write5__4.Wait();
                            read5__2 = null;
                            write5__4 = null;
                            goto IL_00f8;
                        }
                    IL_00f8:
                        read5__2 = source.ReadAsync(buffer5__1, 0, buffer5__1.Length);
                        __current = read5__2;
                        __state__ = 1;
                        return true;
                }
            }

            bool IEnumerator.MoveNext()
            {
                return this.MoveNext();
            }

            void IEnumerator.Reset()
            {
                throw new NotSupportedException();
            }

            IEnumerator<Task> IEnumerable<Task>.GetEnumerator()
            {
                CopyStreamToStreamAsync_g_PeshoAsync CopyStreamToStreamAsync_g_Pesho;
                if (__state__ == -2 && __initialThreadId == Environment.CurrentManagedThreadId)
                {
                    __state__ = 0;
                    CopyStreamToStreamAsync_g_Pesho = this;
                }
                else
                {
                    CopyStreamToStreamAsync_g_Pesho = new CopyStreamToStreamAsync_g_PeshoAsync(0);
                }
                CopyStreamToStreamAsync_g_Pesho.source = __source;
                CopyStreamToStreamAsync_g_Pesho.destination = __destination;
                return CopyStreamToStreamAsync_g_Pesho;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable<Task>)this).GetEnumerator();
            }
        }


        private sealed class __DisplayClass1_0
        {
            public IEnumerator<Task> e;

            public TaskCompletionSource tcs;

            internal void g__Process()
            {
                try
                {
                    if (e.MoveNext())
                    {
                        //  Gets the current Task from e.Current, which is set inside the state machine
                        //  and ContinueWith()s it with the same GoshoAsync__b__1 > g__Process() method
                        //  This Process runs until "   numRead5__3 > 0    " which is __state__ == 1
                        e.Current.ContinueWith(new Action<Task>(GoshoAsync__b__1));
                        return;
                    }
                }
                catch (Exception exception)
                {
                    tcs.SetException(exception);
                    return;
                }
                tcs.SetResult();
            }

            internal void GoshoAsync__b__1(Task t)
            {
                g__Process();
            }
        }

        public static void Main()
        {
            Random random = new Random();
            byte[] buffer = new byte[4096];
            byte[] buffer2 = new byte[4096];
            random.NextBytes(buffer);
            MemoryStream memoryStream = new MemoryStream(buffer);
            try
            {
                MemoryStream memoryStream2 = new MemoryStream(buffer2);
                try
                {
                    Task task = CopyStreamToStreamAsync(memoryStream, memoryStream2);
                    task.Wait();
                }
                finally
                {
                    if (memoryStream2 != null)
                    {
                        ((IDisposable)memoryStream2).Dispose();
                    }
                }
            }
            finally
            {
                if (memoryStream != null)
                {
                    ((IDisposable)memoryStream).Dispose();
                }
            }
        }

        public static Task GoshoAsync(IEnumerable<Task> tasks)
        {
            __DisplayClass1_0 c__DisplayClass1_ = new __DisplayClass1_0();
            c__DisplayClass1_.tcs = new TaskCompletionSource();
            c__DisplayClass1_.e = tasks.GetEnumerator();
            c__DisplayClass1_.g__Process();
            return c__DisplayClass1_.tcs.Task;
        }

        public static Task CopyStreamToStreamAsync(Stream source, Stream destination)
        {
            return GoshoAsync(CopyStreamToStreamAsync_g__Pesho(source, destination));
        }

        internal static IEnumerable<Task> CopyStreamToStreamAsync_g__Pesho(Stream source, Stream destination)
        {
            CopyStreamToStreamAsync_g_PeshoAsync CopyStreamToStreamAsync_g_Pesho = new CopyStreamToStreamAsync_g_PeshoAsync(-2);
            CopyStreamToStreamAsync_g_Pesho.__source = source;
            CopyStreamToStreamAsync_g_Pesho.__destination = destination;
            return CopyStreamToStreamAsync_g_Pesho;
        }
    }

}