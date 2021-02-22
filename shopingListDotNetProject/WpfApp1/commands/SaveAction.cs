using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PL.commands
{
    public class SaveAction : ICommand
    {
        public event EventHandler CanExecuteChanged { 
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
        }

        public event Action SaveButtonClicked;
        public bool CanExecute(object parameter)
        {
            if (parameter != null)
                return parameter.Equals(true);
            else return false;
        }

        public void Execute(object parameter)
        {
            if (SaveButtonClicked != null)
                SaveButtonClicked();
        }
    }
}
