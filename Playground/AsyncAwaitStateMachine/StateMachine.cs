using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitStateMachine
{

    ////////////////////////////////////////////////////////////////////////////////////////
    //                                                                                    //
    //                                                                                    //
    //          NOTE THIS STATE MACHINE WAS GENERATED IN DEBUG MODE                       //
    //          FOR RELEASE BUILDS THE                                                    //
    //          _CopyStreamToStreamAsync_d__1 && _Main_d__0                               //
    //          ARE GENERATED NOT AS CLASSES BUT AS STRUCTS                               //
    //                                                                                    //
    //                                                                                    //
    ////////////////////////////////////////////////////////////////////////////////////////
    public class GeneratedStateMachine
    {
        private sealed class _CopyStreamToStreamAsync_d__1 : IAsyncStateMachine
        {
            public int _1__state;

            public AsyncTaskMethodBuilder _t__builder;

            public Stream source;

            public Stream destination;

            private byte[] _buffer_5__1;

            private int _numRead_5__2;

            private int _s__3;

            private TaskAwaiter _u__1;

            private TaskAwaiter<int> _u__2;

            private async void MoveNext()
            {
                int num = _1__state;
                try
                {
                    //  This exception is propagated to the top
                    //      throw new ArgumentException("Test");
                    //  thanks to _t__builder.SetException(exception);

                    TaskAwaiter<int> awaiter;
                    if (num != 0)
                    {
                        if (num != 1)
                        {
                            _buffer_5__1 = new byte[4096];
                            goto IL_00a0;
                        }
                        awaiter = _u__2;
                        _u__2 = default(TaskAwaiter<int>);
                        num = (_1__state = -1);
                        goto IL_010f;
                    }
                    TaskAwaiter awaiter2 = _u__1;
                    _u__1 = default(TaskAwaiter);
                    num = (_1__state = -1);
                    goto IL_0097;
                IL_0097:
                    awaiter2.GetResult();
                    goto IL_00a0;
                IL_00a0:
                    awaiter = source.ReadAsync(_buffer_5__1, 0, _buffer_5__1.Length).GetAwaiter();
                    if (!awaiter.IsCompleted)
                    {
                        num = (_1__state = 1);
                        _u__2 = awaiter;
                        _CopyStreamToStreamAsync_d__1 stateMachine = this;
                        _t__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
                        return;
                    }
                    goto IL_010f;
                IL_010f:
                    _s__3 = awaiter.GetResult();
                    if ((_numRead_5__2 = _s__3) != 0)
                    {
                        awaiter2 = destination.WriteAsync(_buffer_5__1, 0, _numRead_5__2).GetAwaiter();
                        if (!awaiter2.IsCompleted)
                        {
                            num = (_1__state = 0);
                            _u__1 = awaiter2;
                            _CopyStreamToStreamAsync_d__1 stateMachine = this;
                            _t__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
                            return;
                        }
                        goto IL_0097;
                    }
                }
                catch (Exception exception)
                {
                    _1__state = -2;
                    _buffer_5__1 = null;
                    _t__builder.SetException(exception);
                    return;
                }
                _1__state = -2;
                _buffer_5__1 = null;
                _t__builder.SetResult();
            }

            void IAsyncStateMachine.MoveNext()
            {
                //ILSpy generated this explicit interface implementation from .override directive in MoveNext
                this.MoveNext();
            }

            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }

            void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
            {
                //ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
                this.SetStateMachine(stateMachine);
            }
        }


        private sealed class _Main_d__0 : IAsyncStateMachine
        {
            public int _1__state;

            public AsyncTaskMethodBuilder _t__builder;

            private Random _random_5__1;

            private byte[] _sourceBuffer_5__2;

            private byte[] _destBuffer_5__3;

            private MemoryStream _source_5__4;

            private MemoryStream _destination_5__5;

            private TaskAwaiter _u__1;

            private void MoveNext()
            {
                int num = _1__state;
                try
                {
                    if (num != 0)
                    {
                        _random_5__1 = new Random();
                        _sourceBuffer_5__2 = new byte[4096];
                        _destBuffer_5__3 = new byte[4096];
                        _random_5__1.NextBytes(_sourceBuffer_5__2);
                        _source_5__4 = new MemoryStream(_sourceBuffer_5__2);
                    }
                    try
                    {
                        if (num != 0)
                        {
                            _destination_5__5 = new MemoryStream(_destBuffer_5__3);
                        }
                        try
                        {
                            TaskAwaiter awaiter;
                            if (num != 0)
                            {
                                awaiter = CopyStreamToStreamAsync(_source_5__4, _destination_5__5).GetAwaiter();
                                if (!awaiter.IsCompleted)
                                {
                                    num = (_1__state = 0);
                                    _u__1 = awaiter;
                                    _Main_d__0 stateMachine = this;
                                    _t__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
                                    return;
                                }
                            }
                            else
                            {
                                awaiter = _u__1;
                                _u__1 = default(TaskAwaiter);
                                num = (_1__state = -1);
                            }
                            awaiter.GetResult();
                        }
                        finally
                        {
                            if (num < 0 && _destination_5__5 != null)
                            {
                                ((IDisposable)_destination_5__5).Dispose();
                            }
                        }
                    }
                    finally
                    {
                        if (num < 0 && _source_5__4 != null)
                        {
                            ((IDisposable)_source_5__4).Dispose();
                        }
                    }
                }
                catch (Exception exception)
                {
                    _1__state = -2;
                    _random_5__1 = null;
                    _sourceBuffer_5__2 = null;
                    _destBuffer_5__3 = null;
                    _source_5__4 = null;
                    _destination_5__5 = null;
                    _t__builder.SetException(exception);
                    return;
                }
                _1__state = -2;
                _random_5__1 = null;
                _sourceBuffer_5__2 = null;
                _destBuffer_5__3 = null;
                _source_5__4 = null;
                _destination_5__5 = null;
                _t__builder.SetResult();
            }

            void IAsyncStateMachine.MoveNext()
            {
                //ILSpy generated this explicit interface implementation from .override directive in MoveNext
                this.MoveNext();
            }

            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }

            void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
            {
                //ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
                this.SetStateMachine(stateMachine);
            }
        }

        //[AsyncStateMachine(typeof(_Main_d__0))]
        public static Task Main()
        {
            _Main_d__0 stateMachine = new _Main_d__0();
            stateMachine._t__builder = AsyncTaskMethodBuilder.Create();
            stateMachine._1__state = -1;
            stateMachine._t__builder.Start(ref stateMachine);
            return stateMachine._t__builder.Task;
        }

        //[AsyncStateMachine(typeof(_CopyStreamToStreamAsync_d__1))]
        public static Task CopyStreamToStreamAsync(Stream source, Stream destination)
        {
            _CopyStreamToStreamAsync_d__1 stateMachine = new _CopyStreamToStreamAsync_d__1();
            stateMachine._t__builder = AsyncTaskMethodBuilder.Create();
            stateMachine.source = source;
            stateMachine.destination = destination;
            stateMachine._1__state = -1;
            stateMachine._t__builder.Start(ref stateMachine);
            return stateMachine._t__builder.Task;
        }
    }
}