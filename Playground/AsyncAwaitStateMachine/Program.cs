namespace AsyncAwaitStateMachineOriginal
{
    //https://sharplab.io/#v2:D4OwhgtgpgzgDmAxlABAQRgTxItB3MASwBcBlYsYqAWSQAtCQoB5AJ0IHNGwAbAWABQAb0EoxKAAIAmAIyjxEgAySZAOgCSzANzyxSlQFYdA8Sl2SAzJKkqA7OZEnTCqxJkA2SQA5Jn2owB9Nk5uHgAKAEpzU0dnOJQANzBWFFYwEAATAHsIFABeFCY8FAAldOyISON45ySUmCyAV1ZkACFGgDMOqBSCopQAI0wqAG1FAA8ZRWmAXWqa8TqUDNhidq6e/MKoYqHRianZ42j4tMyc1QA5KHG14dgwhua2zu7WCPmFyWUlp5bUPo7FDUKAQLKsTDkVhQSCPJr/dZvD4nOL6JYrGDEbhYrIgLb9EFgiFQmGVDFrV49ZECFHOCQAThQAGEsnBIcRoZAACpZEmQDDYRBw55QAA0y1W2MIuOpNQAvoJaRJXB5vL5maz2ZyIDy+RABTgwnqUH9kOLjeSpTLabEvolkoNKb1trt7mNJtNFHNaaZGMRCo0ICUYRlPgs8AweKgwmEQIHg2AMlsGSb4chVAmMgahQMneLFOLcxtWKoADJQEAcYh0CIRFAAQgKiiiTi+trtCkZlvAOJAqgA6uwqNmwkW3vnxXGgyHZXaFa3nPPTPO5UA
    public class Program
    {
        public static async Task Main_Original()
        {
            var random = new Random();
            var sourceBuffer = new byte[0x1000];
            var destBuffer = new byte[0x1000];

            random.NextBytes(sourceBuffer);
            using var source = new MemoryStream(sourceBuffer);
            using var destination = new MemoryStream(destBuffer);

            await CopyStreamToStreamAsync(source, destination);
        }

        public static async Task CopyStreamToStreamAsync(Stream source, Stream destination)
        {
            var buffer = new byte[0x1000];
            int numRead;
            while ((numRead = await source.ReadAsync(buffer, 0, buffer.Length)) != 0)
            {
                await destination.WriteAsync(buffer, 0, numRead);
            }
        }
    }
}