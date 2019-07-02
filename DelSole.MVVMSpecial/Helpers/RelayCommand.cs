using System;
using System.Windows.Input;

namespace DelSole.MVVMSpecial.Helpers
{
    /// <summary>
    /// Class RelayCommand.
    /// </summary>
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// The _execute
        /// </summary>
        private readonly Action _execute;

        /// <summary>
        /// The _can execute
        /// </summary>
        private readonly Func<bool> _canExecute;

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class.
        /// </summary>
        /// <param name="execute">The execute.</param>
        /// <param name="canExecute">The can execute.</param>
        /// <exception cref="System.ArgumentNullException">execute</exception>
        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));

            if (canExecute != null)
            {
                _canExecute = canExecute;
            }
        }

        /// <summary>
        /// Initializes a new instance of the RelayCommand class that
        /// can always execute.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <exception cref="ArgumentNullException">If the execute argument is null.</exception>
        public RelayCommand(Action execute) : this(execute, null)
        {
        }

        /// <summary>
        /// Occurs when changes occur that affect whether the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged;


        /// <summary>
        /// Raises the can execute changed.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            handler?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>true if this command can be executed; otherwise, false.</returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute.Invoke();
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public virtual void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                _execute.Invoke();
            }
        }
    }
}
