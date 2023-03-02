namespace QQChannelSharp.Backoffs
{
    public static class DecorrelatedJitterBackoffV2
    {
        public static TimeSpan[] GetRetryIntervals(int maxRetries, TimeSpan baseInterval)
        {
            var intervals = new TimeSpan[maxRetries];
            var random = new Random();

            for (int i = 0; i < maxRetries; i++)
            {
                double interval = baseInterval.TotalMilliseconds;
                interval *= Math.Pow(2, i);
                interval += random.NextDouble() * baseInterval.TotalMilliseconds;
                intervals[i] = TimeSpan.FromMilliseconds(interval);
            }

            return intervals;
        }
    }
}