using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleStateMachine
{
    internal class Original
    {
        public static void Main_Original()
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

        public static Task GoshoAsync(IEnumerable<Task> tasks)
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
            return GoshoAsync(PeshoAsync(source, destination));

            static IEnumerable<Task> PeshoAsync(Stream source, Stream destination)
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
    }
}
