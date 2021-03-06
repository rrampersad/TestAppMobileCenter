﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows.Input;

namespace TestAppMobilecenter.Commands
{
    //https://github.com/xamarin/Xamarin.Forms/blob/master/Xamarin.Forms.Core/Command.cs 
    public class Command : ICommand
    {
        readonly Func<object, bool> _canExecute;
        readonly Action<object> _execute;

        public Command(Action<object> execute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }
            _execute = execute;
        }

        public Command(Action execute) : this(o => execute())
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
        }

        public Command(Action<object> execute, Func<object, bool> canExecute) : this(execute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(canExecute));
            }

            _canExecute = canExecute;
        }

        public Command(Action execute, Func<bool> canExecute) : this(o => execute(), o => canExecute())
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
            if (canExecute == null)
                throw new ArgumentNullException(nameof(canExecute));
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute != null)
                return _canExecute(parameter);

            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public void ChangeCanExecute()
        {
            EventHandler changed = CanExecuteChanged;
            changed?.Invoke(this, EventArgs.Empty);
        }
    }
}
