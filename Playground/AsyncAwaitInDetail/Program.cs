namespace AsyncAwaitInDetail
{
    using System.Net;
    using System.Net.Sockets;

    public class Program
    {
        public static void Main()
        {
            var random = new Random();
            var sourceBuffer = new byte[0x1000];
            var destBuffer = new byte[0x1000];

            random.NextBytes(sourceBuffer);
            using var source = new MemoryStream(sourceBuffer);
            using var destination = new MemoryStream(destBuffer);

            var task = CopyStreamToStreamAsync(source, destination);
            task.Wait();
        }

        public static Task IterateAsync(IEnumerable<Task> tasks)
        {
            var tcs = new TaskCompletionSource();

            IEnumerator<Task> e = tasks.GetEnumerator();

            void Process()
            {
                try
                {
                    if (e.MoveNext())
                    {
                        e.Current.ContinueWith(t => Process());
                        return;
                    }
                }
                catch (Exception e)
                {
                    tcs.SetException(e);
                    return;
                }
                tcs.SetResult();
            }
            Process();

            return tcs.Task;
        }

        public static Task CopyStreamToStreamAsync(Stream source, Stream destination)
        {
            return IterateAsync(Impl(source, destination));

            static IEnumerable<Task> Impl(Stream source, Stream destination)
            {
                var buffer = new byte[0x1000];
                while (true)
                {
                    Task<int> read = source.ReadAsync(buffer, 0, buffer.Length);
                    yield return read;
                    int numRead = read.Result;
                    if (numRead <= 0) break;

                    Task write = destination.WriteAsync(buffer, 0, numRead);
                    yield return write;
                    write.Wait();
                }
            }
        }

        public void NetFramework1_0()
        {
            //Example of Stack Dive example
            using Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(new IPEndPoint(IPAddress.Loopback, 0));
            listener.Listen();

            using Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.Connect(listener.LocalEndPoint!);

            using Socket server = listener.Accept();
            _ = server.SendAsync(new byte[100_000]);

            var mres = new ManualResetEventSlim();
            byte[] buffer = new byte[1];

            var stream = new NetworkStream(client);

            void ReadAgain()
            {
                stream.BeginRead(buffer, 0, 1, iar =>
                {
                    if (stream.EndRead(iar) != 0)
                    {
                        ReadAgain(); // uh oh!
                    }
                    else
                    {
                        mres.Set();
                    }
                }, null);
            };
            ReadAgain();

            mres.Wait();
        }
    }
}