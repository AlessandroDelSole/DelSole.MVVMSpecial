using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace DelSole.MVVMSpecial.Helpers
{
    public class NotifyBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Set a property value by ref and raise a change notification
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="backingStore">the backing field</param>
        /// <param name="value">the new property value</param>
        /// <param name="propertyName">the property name</param>
        /// <param name="onChanged">custom action to be invoked when the value changes</param>
        /// <returns></returns>
        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName]string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;

            changed?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}