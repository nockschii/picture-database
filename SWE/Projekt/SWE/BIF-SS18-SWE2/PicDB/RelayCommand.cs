using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PicDB
{
    public class RelayCommand : ICommand
    {
        private Action _action;
        private bool _canExecute;

        public RelayCommand(Action action, bool canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        /// <summary>
        /// bool if action can be executed 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>bool</returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        /// <summary>
        /// EventHandler CanExecuteChanged
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Executes action
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _action();
        }
    }
}
