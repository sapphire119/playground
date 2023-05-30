using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TestProfilingValueTasks
{
    internal class DefaultStateMachine
    {
        [StructLayout(LayoutKind.Auto)]
        [CompilerGenerated]
        private struct <Main>d__0 : IAsyncStateMachine
        {
            public int <>1__state;

            public AsyncTaskMethodBuilder<> t__builder;

        private int <i>5__2;

            private ValueTaskAwaiter<> u__1;

        private void MoveNext()
        {
            int num = <> 1__state;
            try
            {
                if (num != 0)
                {
                    new AsyncLocal<int>().Value = 42;
                        < i > 5__2 = 0;
                    goto IL_008b;
                }
                ValueTaskAwaiter awaiter = <> u__1;
                    <> u__1 = default(ValueTaskAwaiter);
                num = (<> 1__state = -1);
                goto IL_0074;
            IL_0074:
                awaiter.GetResult();
                    < i > 5__2++;
                goto IL_008b;
            IL_008b:
                if (< i > 5__2 < 1000)
                {
                    awaiter = SomeMethodAsync().GetAwaiter();
                    if (!awaiter.IsCompleted)
                    {
                        num = (<> 1__state = 0);
                            <> u__1 = awaiter;
                            <> t__builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
                        return;
                    }
                    goto IL_0074;
                }
            }
            catch (Exception exception)
            {
                    <> 1__state = -2;
                    <> t__builder.SetException(exception);
                return;
            }
                <> 1__state = -2;
                <> t__builder.SetResult();
        }

        void IAsyncStateMachine.MoveNext()
        {
            //ILSpy generated this explicit interface implementation from .override directive in MoveNext
            this.MoveNext();
        }

        [DebuggerHidden]
        private void SetStateMachine([System.Runtime.CompilerServices.Nullable(1)] IAsyncStateMachine stateMachine)
        {
                <> t__builder.SetStateMachine(stateMachine);
        }

        void IAsyncStateMachine.SetStateMachine([System.Runtime.CompilerServices.Nullable(1)] IAsyncStateMachine stateMachine)
        {
            //ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
            this.SetStateMachine(stateMachine);
        }
    }


    [StructLayout(LayoutKind.Auto)]
    [CompilerGenerated]
    private struct <SomeMethodAsync>d__1 : IAsyncStateMachine
        {
            public int <>1__state;

            public AsyncValueTaskMethodBuilder<> t__builder;

    private int <i>5__2;

            private YieldAwaitable.YieldAwaiter<> u__1;

    private void MoveNext()
    {
        int num = <> 1__state;
        try
        {
            if (num != 0)
            {
                        < i > 5__2 = 0;
                goto IL_007d;
            }
            YieldAwaitable.YieldAwaiter awaiter = <> u__1;
                    <> u__1 = default(YieldAwaitable.YieldAwaiter);
            num = (<> 1__state = -1);
            goto IL_0066;
        IL_0066:
            awaiter.GetResult();
                    < i > 5__2++;
            goto IL_007d;
        IL_007d:
            if (< i > 5__2 < 1000)
            {
                awaiter = Task.Yield().GetAwaiter();
                if (!awaiter.IsCompleted)
                {
                    num = (<> 1__state = 0);
                            <> u__1 = awaiter;
                            <> t__builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
                    return;
                }
                goto IL_0066;
            }
        }
        catch (Exception exception)
        {
                    <> 1__state = -2;
                    <> t__builder.SetException(exception);
            return;
        }
                <> 1__state = -2;
                <> t__builder.SetResult();
    }

    void IAsyncStateMachine.MoveNext()
    {
        //ILSpy generated this explicit interface implementation from .override directive in MoveNext
        this.MoveNext();
    }

    [DebuggerHidden]
    private void SetStateMachine([System.Runtime.CompilerServices.Nullable(1)] IAsyncStateMachine stateMachine)
    {
                <> t__builder.SetStateMachine(stateMachine);
    }

    void IAsyncStateMachine.SetStateMachine([System.Runtime.CompilerServices.Nullable(1)] IAsyncStateMachine stateMachine)
    {
        //ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
        this.SetStateMachine(stateMachine);
    }
}

        [System.Runtime.CompilerServices.NullableContext(1)]
        [AsyncStateMachine(typeof(< Main > d__0))]
        private static Task Main()
        {
            < Main > d__0 stateMachine = default(< Main > d__0);
            stateMachine.<> t__builder = AsyncTaskMethodBuilder.Create();
            stateMachine.<> 1__state = -1;
            stateMachine.<> t__builder.Start(ref stateMachine);
            return stateMachine.<> t__builder.Task;
        }

        [AsyncStateMachine(typeof(< SomeMethodAsync > d__1))]
        private static ValueTask SomeMethodAsync()
        {
            < SomeMethodAsync > d__1 stateMachine = default(< SomeMethodAsync > d__1);
            stateMachine.<> t__builder = AsyncValueTaskMethodBuilder.Create();
            stateMachine.<> 1__state = -1;
            stateMachine.<> t__builder.Start(ref stateMachine);
            return stateMachine.<> t__builder.Task;
        }
    }
}
