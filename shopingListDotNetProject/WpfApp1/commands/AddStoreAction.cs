using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BE;


namespace PL.commands
{
    class AddStoreAction : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public event Action<Store> AddStoreClicked;

        public bool CanExecute(object parameter)
        {
            if (parameter != null)
                return true;
            else return false;
        }

        public void Execute(object parameter)
        {
            if (AddStoreClicked != null && parameter is Store)
                AddStoreClicked(parameter as Store);
        }
    }

}
