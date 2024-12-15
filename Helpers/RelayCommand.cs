﻿using System;
using System.Windows.Input;

namespace UwpExample.Helpers
{
    public class RelayCommand<T> : ICommand
    {
        private readonly Func<T, bool> _targetCanExecuteMethod;
        private readonly Action<T> _targetExecuteMethod;

        public RelayCommand(Action<T> executeMethod)
        {
            _targetExecuteMethod = executeMethod;
        }

        public RelayCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
        {
            _targetExecuteMethod = executeMethod;
            _targetCanExecuteMethod = canExecuteMethod;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        #region ICommand Members

        bool ICommand.CanExecute(object parameter)
        {
            if (_targetCanExecuteMethod != null)
            {
                var tparm = (T)parameter;
                return _targetCanExecuteMethod(tparm);
            }

            if (_targetExecuteMethod != null)
            {
                return true;
            }

            return false;
        }

        // Beware - should use weak references if command instance lifetime is longer than lifetime of
        // UI objects that get hooked up to command
        // Prism commands solve this in their implementation
        public event EventHandler CanExecuteChanged = delegate { };

        void ICommand.Execute(object parameter)
        {
            _targetExecuteMethod?.Invoke((T)parameter);
        }

        #endregion ICommand Members
    }
}