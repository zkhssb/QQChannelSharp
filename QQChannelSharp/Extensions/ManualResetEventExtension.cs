using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQChannelSharp.Extensions
{
    public static class ManualResetEventExtension
    {
        public static Task WaitAsync(this ManualResetEvent manualResetEvent)
        {
            var tcs = new TaskCompletionSource<object>();
            var registration = default(CancellationTokenRegistration);

            registration = default(CancellationToken).Register(() =>
            {
                tcs.TrySetCanceled();
                registration.Dispose();
            });

            manualResetEvent.SetOnCompleted(() =>
            {
                tcs.TrySetResult(0);
                registration.Dispose();
            });

            return tcs.Task;
        }

        private static void SetOnCompleted(this ManualResetEvent manualResetEvent, Action continuation)
        {
            ThreadPool.QueueUserWorkItem(state =>
            {
                manualResetEvent.WaitOne();
                continuation();
            });
        }
    }
}
