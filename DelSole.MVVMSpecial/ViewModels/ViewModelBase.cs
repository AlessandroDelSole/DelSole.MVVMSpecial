using DelSole.MVVMSpecial.Helpers;
using DelSole.MVVMSpecial.Interfaces;
using System;
using System.Threading.Tasks;

namespace DelSole.MVVMSpecial.ViewModels
{
    public abstract class ViewModelBase : NotifyBase, IAsyncInitialization
    {
        protected INotifyTaskCompletion InitializationNotifier { get; set; }
        public Task Initialization => InitializationNotifier.Task;

        private string _title = string.Empty;
        private bool _isBusy;

        protected ViewModelBase()
        {
            // EXAMPLE for other class impl
            // InitializationNotifier = NotifyTaskCompletion.Create(InitializeAsync());
        }

        /// <summary>
        /// Contains asynchronous code that must run at initialization
        /// </summary>
        /// <returns>Task</returns>
        /// <remarks>
        /// Add the following in the ViewModel's constructor:
        /// <code>InitializationNotifier = NotifyTaskCompletion.Create(InitializeAsync());</code>
        /// </remarks>
        public virtual async Task InitializeAsync()
        {
            await Task.Run(() => { Console.WriteLine("ViewModelBase Initialized!"); });
        }

        /// <summary>
        /// It can be bound to any <seealso cref="Xamarin.Forms.View"/> to represent a busy state
        /// </summary>
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        /// <summary>
        /// It can be bound to a Page's Title property
        /// </summary>
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

    }
}
