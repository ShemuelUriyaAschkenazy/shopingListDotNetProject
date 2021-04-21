using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PL.commands
{
    public class ViewRndListAction:ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public event Action<DateTime> ListButtonClickedEvent;

        public bool CanExecute(object parameter)
        {
            if (parameter != null)
                return true;
            else return false;
        }
        public void Execute(object parameter)
        {
            if (ListButtonClickedEvent != null && parameter is DateTime)
                ListButtonClickedEvent((DateTime)parameter);
        }
    }
}
