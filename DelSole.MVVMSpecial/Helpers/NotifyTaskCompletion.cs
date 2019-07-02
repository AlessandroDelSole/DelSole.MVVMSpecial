using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using DelSole.MVVMSpecial.Interfaces;


namespace DelSole.MVVMSpecial.Helpers
{
    /// <summary>
    /// Factory for task completion notifiers.
    /// </summary>
    public static class NotifyTaskCompletion
    {
        /// <summary>
        /// Creates a new task notifier watching the specified task.
        /// </summary>
        /// <param name="task">The task to watch.</param>
        /// <returns>A new task notifier watching the specified task.</returns>
        public static INotifyTaskCompletion Create(Task task)
        {
            return new NotifyTaskCompletionImplementation(task);
        }

        /// <summary>
        /// Creates a new task notifier watching the specified task.
        /// </summary>
        /// <typeparam name="TResult">The type of the task result.</typeparam>
        /// <param name="task">The task to watch.</param>
        /// <returns>A new task notifier watching the specified task.</returns>
        public static INotifyTaskCompletion<TResult> Create<TResult>(Task<TResult> task)
        {
            return new NotifyTaskCompletionImplementation<TResult>(task);
        }

        /// <summary>
        /// Executes the specified asynchronous code and creates a new task notifier watching the returned task.
        /// </summary>
        /// <param name="asyncAction">The asynchronous code to execute.</param>
        /// <returns>A new task notifier watching the returned task.</returns>
        public static INotifyTaskCompletion Create(Func<Task> asyncAction)
        {
            return Create(asyncAction());
        }

        /// <summary>
        /// Executes the specified asynchronous code and creates a new task notifier watching the returned task.
        /// </summary>
        /// <param name="asyncAction">The asynchronous code to execute.</param>
        /// <returns>A new task notifier watching the returned task.</returns>
        public static INotifyTaskCompletion<TResult> Create<TResult>(Func<Task<TResult>> asyncAction)
        {
            return Create(asyncAction());
        }

        /// <summary>
        /// Watches a task and raises property-changed notifications when the task completes.
        /// </summary>
        private sealed class NotifyTaskCompletionImplementation : INotifyTaskCompletion
        {
            /// <summary>
            /// Initializes a task notifier watching the specified task.
            /// </summary>
            /// <param name="task">The task to watch.</param>
            public NotifyTaskCompletionImplementation(Task task)
            {
                Task = task;
                if (!task.IsCompleted)
                {
                    var scheduler = SynchronizationContext.Current == null ? TaskScheduler.Current : TaskScheduler.FromCurrentSynchronizationContext();
                    TaskCompleted = task.ContinueWith(t =>
                        {
                            var propertyChanged = PropertyChanged;
                            if (propertyChanged != null)
                            {
                                propertyChanged(this, new PropertyChangedEventArgs("Status"));
                                propertyChanged(this, new PropertyChangedEventArgs("IsCompleted"));
                                propertyChanged(this, new PropertyChangedEventArgs("IsNotCompleted"));
                                if (t.IsCanceled)
                                {
                                    propertyChanged(this, new PropertyChangedEventArgs("IsCanceled"));
                                }
                                else if (t.IsFaulted)
                                {
                                    propertyChanged(this, new PropertyChangedEventArgs("IsFaulted"));
                                    propertyChanged(this, new PropertyChangedEventArgs("Exception"));
                                    propertyChanged(this, new PropertyChangedEventArgs("InnerException"));
                                    propertyChanged(this, new PropertyChangedEventArgs("ErrorMessage"));
                                }
                                else
                                {
                                    propertyChanged(this, new PropertyChangedEventArgs("IsSuccessfullyCompleted"));
                                }
                            }
                        },
                        CancellationToken.None,
                        TaskContinuationOptions.ExecuteSynchronously,
                        scheduler);
                }
            }

            public Task Task { get; }
            public Task TaskCompleted { get; }
            public TaskStatus Status => Task.Status;
            public bool IsCompleted => Task.IsCompleted;
            public bool IsNotCompleted => !Task.IsCompleted;
            public bool IsSuccessfullyCompleted => Task.Status == TaskStatus.RanToCompletion;
            public bool IsCanceled => Task.IsCanceled;
            public bool IsFaulted => Task.IsFaulted;
            public AggregateException Exception => Task.Exception;
            public Exception InnerException => Exception?.InnerException;
            public string ErrorMessage => InnerException?.Message;

            public event PropertyChangedEventHandler PropertyChanged;
        }

        /// <summary>
        /// Watches a task and raises property-changed notifications when the task completes.
        /// </summary>
        /// <typeparam name="TResult">The type of the task result.</typeparam>
        private sealed class NotifyTaskCompletionImplementation<TResult> : INotifyTaskCompletion<TResult>
        {
            /// <summary>
            /// Initializes a task notifier watching the specified task.
            /// </summary>
            /// <param name="task">The task to watch.</param>
            public NotifyTaskCompletionImplementation(Task<TResult> task)
            {
                Task = task;
                if (!task.IsCompleted)
                {
                    var scheduler = SynchronizationContext.Current == null ? TaskScheduler.Current : TaskScheduler.FromCurrentSynchronizationContext();
                    TaskCompleted = task.ContinueWith(t =>
                        {
                            var propertyChanged = PropertyChanged;
                            if (propertyChanged != null)
                            {
                                propertyChanged(this, new PropertyChangedEventArgs("Status"));
                                propertyChanged(this, new PropertyChangedEventArgs("IsCompleted"));
                                propertyChanged(this, new PropertyChangedEventArgs("IsNotCompleted"));
                                if (t.IsCanceled)
                                {
                                    propertyChanged(this, new PropertyChangedEventArgs("IsCanceled"));
                                }
                                else if (t.IsFaulted)
                                {
                                    propertyChanged(this, new PropertyChangedEventArgs("IsFaulted"));
                                    propertyChanged(this, new PropertyChangedEventArgs("Exception"));
                                    propertyChanged(this, new PropertyChangedEventArgs("InnerException"));
                                    propertyChanged(this, new PropertyChangedEventArgs("ErrorMessage"));
                                }
                                else
                                {
                                    propertyChanged(this, new PropertyChangedEventArgs("IsSuccessfullyCompleted"));
                                    propertyChanged(this, new PropertyChangedEventArgs("Result"));
                                }
                            }
                        },
                        CancellationToken.None,
                        TaskContinuationOptions.ExecuteSynchronously,
                        scheduler);
                }
            }

            public Task<TResult> Task { get; }
            Task INotifyTaskCompletion.Task => Task;
            public Task TaskCompleted { get; }
            public TResult Result => Task.Status == TaskStatus.RanToCompletion ? Task.Result : default;
            public TaskStatus Status => Task.Status;
            public bool IsCompleted => Task.IsCompleted;
            public bool IsNotCompleted => !Task.IsCompleted;
            public bool IsSuccessfullyCompleted => Task.Status == TaskStatus.RanToCompletion;
            public bool IsCanceled => Task.IsCanceled;
            public bool IsFaulted => Task.IsFaulted;
            public AggregateException Exception => Task.Exception;
            public Exception InnerException => Exception?.InnerException;
            public string ErrorMessage => InnerException?.Message;

            public event PropertyChangedEventHandler PropertyChanged;
        }
    }
}