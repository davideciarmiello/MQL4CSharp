using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MQL4CSharp.Base.REST
{
    /// <summary>
    /// 
    /// https://www.anthonysteele.co.uk/AsyncResync.html
    /// https://medium.com/rubrikkgroup/understanding-async-avoiding-deadlocks-e41f8f2c6f5d
    /// </summary>
    internal class AsyncHelper
    {
        #region RunSyncWithNewThread
        private static readonly TaskFactory _myTaskFactory = new
            TaskFactory(CancellationToken.None,
                TaskCreationOptions.None,
                TaskContinuationOptions.None,
                TaskScheduler.Default);

        public static TResult RunSyncWithNewThread<TResult>(Func<Task<TResult>> func)
        {
            var newFunc = func;
            return _myTaskFactory
                .StartNew<Task<TResult>>(newFunc)
                .Unwrap<TResult>()
                .GetAwaiter()
                .GetResult();
        }

        public static void RunSyncWithNewThread(Func<Task> func)
        {
            RunSyncWithNewThread(async () =>
            {
                await func();
                return 0;
            });
        }
        #endregion

        /// <summary>
        /// Execute's an async Task<T> method which has a void return value synchronously
        /// Evita i deadlock, ma mantiene lo stesso thread di origine, mantenendo cosi le informazioni del context
        /// </summary>
        /// <param name="task">Task<T> method to execute</param>
        public static void RunSync(Func<Task> task)
        {
            var synch = new ExclusiveSynchronizationContext();
            using (SynchronizationContextScope(synch))
            {
                async void SendOrPostCallback(object state)
                {
                    try
                    {
                        await task();
                    }
                    catch (Exception e)
                    {
                        synch.InnerException = e;
                        throw;
                    }
                    finally
                    {
                        synch.EndMessageLoop();
                    }
                }
                synch.Post(SendOrPostCallback, null);
                synch.BeginMessageLoop();
            }
        }

        /// <summary>
        /// Execute's an async Task method which has a TResult return type synchronously
        /// </summary>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="task">Task method to execute</param>
        /// <returns></returns>
        public static TResult RunSync<TResult>(Func<Task<TResult>> task)
        {
            var ret = default(TResult);
            RunSync(async () =>
            {
                ret = await task();
            });
            return ret;
        }

        internal class ExclusiveSynchronizationContext : SynchronizationContext
        {
            private bool done;
            public Exception InnerException { get; set; }
            readonly AutoResetEvent workItemsWaiting = new AutoResetEvent(false);
            readonly Queue<Tuple<SendOrPostCallback, object>> items =
                new Queue<Tuple<SendOrPostCallback, object>>();

            public override void Send(SendOrPostCallback d, object state)
            {
                throw new NotSupportedException("We cannot send to our same thread");
            }

            public override void Post(SendOrPostCallback d, object state)
            {
                lock (items)
                {
                    items.Enqueue(Tuple.Create(d, state));
                }
                workItemsWaiting.Set();
            }

            public void EndMessageLoop()
            {
                Post(_ => done = true, null);
            }

            public void BeginMessageLoop()
            {
                while (!done)
                {
                    Tuple<SendOrPostCallback, object> task = null;
                    lock (items)
                    {
                        if (items.Count > 0)
                        {
                            task = items.Dequeue();
                        }
                    }
                    if (task != null)
                    {
                        task.Item1(task.Item2);
                        if (InnerException != null) // the method threw an exeption
                        {
                            throw InnerException;
                            //throw new AggregateException("AsyncHelpers.Run method threw an exception.", InnerException);
                        }
                    }
                    else
                    {
                        workItemsWaiting.WaitOne();
                    }
                }
            }

            public override SynchronizationContext CreateCopy()
            {
                return this;
            }
        }

        #region NoSynchronizationContextScope
        /// <summary>
        /// https://jike.in/?qa=571906/c%23-use-task-run-in-synchronous-method-to-avoid-deadlock-waiting-on-async-method&show=571907
        /// </summary>
        /// <returns></returns>
        public static IDisposable NoSynchronizationContextScope()
        {
            return SynchronizationContextScope(null);
        }
        public static IDisposable SynchronizationContextScope(SynchronizationContext newContext)
        {
            var context = SynchronizationContext.Current;
            SynchronizationContext.SetSynchronizationContext(newContext);
            return new ActionOnDispose(() =>
            {
                //if (SynchronizationContext.Current == newContext)
                SynchronizationContext.SetSynchronizationContext(context);
            });
        }
        public class ActionOnDispose : IDisposable
        {
            public Action Action { get; private set; }

            public ActionOnDispose(Action action)
            {
                Action = action;
            }
            public void Dispose()
            {
                if (Action == null)
                    return;
                Action();
                Action = null;
            }
        }
        #endregion
    }
}
