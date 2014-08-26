using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace NewExample.WindowsPhone7Unleashed
{
    public class DelegateCommand<T> : IEventCommand
    {
        string eventName = "Click";

        public string EventName
        {
            get
            {
                return eventName;
            }
            set
            {
                eventName = value;
            }
        }

        readonly Action<T> executeAction;
        readonly Func<T, bool> canExecuteFunc;
        bool previousCanExecute;

        public DelegateCommand(Action<T> executeAction, Func<T, bool> canExecuteFunc)
        {
            this.executeAction = ArgumentValidator.AssertNotNull(executeAction, "executeAction");
            this.canExecuteFunc = canExecuteFunc;
        }

        public DelegateCommand(Action<T> executeAction)
        {
            this.executeAction = ArgumentValidator.AssertNotNull(executeAction, "executeAction");
        }

        #region ICommand Members

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            object coercedParameter = CoerceParameterToType(parameter);
            return CanExecute((T)coercedParameter);
        }

        public void Execute(object parameter)
        {
            object coercedParameter = CoerceParameterToType(parameter);
            Execute((T)coercedParameter);
        }

        object CoerceParameterToType(object parameter)
        {
            object coercedParameter = parameter;
            Type typeOfT = typeof(T);
            if (parameter != null && !typeOfT.IsAssignableFrom(parameter.GetType()))
            {
                coercedParameter = ImplicitTypeConverter.ConvertToType(parameter, typeOfT);
            }
            return coercedParameter;
        }

        #endregion

        public bool CanExecute(T parameter)
        {
            if (canExecuteFunc == null)
            {
                return true;
            }

            bool temp = canExecuteFunc(parameter);

            if (previousCanExecute != temp)
            {
                previousCanExecute = temp;
                OnCanExecuteChanged(EventArgs.Empty);
            }

            return previousCanExecute;
        }

        public void Execute(T parameter)
        {
            executeAction(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            OnCanExecuteChanged(EventArgs.Empty);
        }

        protected virtual void OnCanExecuteChanged(EventArgs e)
        {
            var tempEvent = CanExecuteChanged;
            if (tempEvent != null)
            {
                tempEvent(this, e);
            }
        }
    }

    public class DelegateCommand : DelegateCommand<object>
    {
        public DelegateCommand(
            Action<object> executeAction, Func<object, bool> canExecute)
            : base(executeAction, canExecute)
        {
            /* Intentionally left blank. */
        }

        public DelegateCommand(Action<object> executeAction)
            : base(executeAction)
        {
            /* Intentionally left blank. */
        }
    }
}
