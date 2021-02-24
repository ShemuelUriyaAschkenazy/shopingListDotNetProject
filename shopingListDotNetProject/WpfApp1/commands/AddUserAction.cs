using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BE;


namespace PL.commands
{
    class AddUserAction : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public event Action<User> AddUserClicked;

        public bool CanExecute(object parameter)
        {
            if (parameter != null)
                return true;
            else return false;
        }

        public void Execute(object parameter)
        {
            if (AddUserClicked != null && parameter is User)
                AddUserClicked(parameter as User);
        }
    }

}
