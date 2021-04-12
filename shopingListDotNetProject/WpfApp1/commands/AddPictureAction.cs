using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PL.commands
{
    class AddPictureAction : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public event Action<Product> AddPictureClicked;

        public bool CanExecute(object parameter)
        {
            if (parameter != null)
                return true;
            else return false;
        }

        public void Execute(object parameter)
        {
            if (AddPictureClicked != null && parameter is Product)
                AddPictureClicked(parameter as Product);
        }
    }
}
