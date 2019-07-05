#pragma warning disable CS1591

using DelSole.MVVMSpecial.Helpers;
using DelSole.MVVMSpecial.Interfaces;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DelSole.MVVMSpecial.ViewModels
{
    /// <summary>
    /// A base ViewModel with asynchronous initialization and change notification 
    /// </summary>
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
            this.ClosePageCommand = new Command(ExecuteCloseCommand, CanExecuteCloseCommand);

            await Task.Run(() => { Console.WriteLine("ViewModelBase Initialized!"); });
        }

        private void ExecuteCloseCommand(object obj)
        {
            MessagingCenter.Send(this, "ClosePageCommand");
        }

        private bool CanExecuteCloseCommand(object arg)
        {
            return !IsBusy;
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

        private Command _closePageCommand;
        /// <summary>
        /// A bindable <seealso cref="Command"/> that allows for closing a page
        /// </summary>
        public Command ClosePageCommand
        {
            get => _closePageCommand;
            set => SetProperty(ref _closePageCommand, value);
        }
    }
}
