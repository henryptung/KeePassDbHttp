using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace KeePassDbHttp
{
    class HttpUtil
    {
        public delegate Task Handler(HttpListenerContext ctx, CancellationToken token);

        public static async Task Listen(uint port, Handler callback, CancellationToken token)
        {
            using (var listener = new HttpListener())
            {
                listener.Prefixes.Add(String.Format("http://localhost:{0}/", port));
                listener.Start();
                
                var stopped = new TaskCompletionSource<object>();
                token.Register(() =>
                {
                    listener.Stop();
                    stopped.SetResult(null);
                });

                while (!token.IsCancellationRequested)
                {
                    try
                    {
                        var ctx = await WrapAsCancellable(listener.GetContextAsync(), token);
                        await callback.Invoke(ctx, token);
                    }
                    catch (Exception)
                    {
                        // swallow
                    }
                }

                await stopped.Task;
                token.ThrowIfCancellationRequested();
            }
        }

        private static async Task<T> WrapAsCancellable<T>(Task<T> originalTask, CancellationToken token)
        {
            var taskSource = new TaskCompletionSource<T>();
            token.Register(() => taskSource.TrySetCanceled(token));
            var wrappedTask = Task.WhenAny(originalTask, taskSource.Task);
            var task = await wrappedTask;
            return await task;
        }
    }
}
