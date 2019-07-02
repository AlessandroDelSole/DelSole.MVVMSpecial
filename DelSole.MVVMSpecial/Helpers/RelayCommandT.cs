using System;
using System.Windows.Input;

namespace DelSole.MVVMSpecial.Helpers
{
    /// <summary>
    /// Generic RelayCommand class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RelayCommand<T> : ICommand
    {
        /// <summary>
        /// The execute
        /// </summary>
        private readonly Action<T> _execute;

        /// <summary>
        /// The can execute
        /// </summary>
        private readonly Predicate<T> _canExecute; 

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand{T}" /> class.
        /// </summary>
        /// <param name="execute">The execute action.</param>
        /// <exception cref="System.ArgumentNullException">execute</exception>
        public RelayCommand(Action<T> execute) : this(execute, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand{T}" /> class.
        /// </summary>
        /// <param name="execute">The execute.</param>
        /// <param name="canExecute">The can execute predicate.</param>
        /// <exception cref="System.ArgumentNullException">execute</exception>
        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));

            if (canExecute != null)
            {
                _canExecute = canExecute;
            }
        }

        /// <summary>
        /// Occurs when changes occur that affect whether the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Raise <see cref="RelayCommand{T}.CanExecuteChanged" /> event.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            handler?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Determines whether this instance can execute the specified parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns><c>true</c> if this instance can execute the specified parameter; otherwise, <c>false</c>.</returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute.Invoke((T)parameter);
        }

        /// <summary>
        /// Executes the specified parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        public virtual void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                _execute((T)parameter);
            }
        }
    }
}