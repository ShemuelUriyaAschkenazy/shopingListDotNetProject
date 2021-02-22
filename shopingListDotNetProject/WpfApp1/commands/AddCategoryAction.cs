using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PL.commands
{
    public class AddCategoryAction : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public event Action<Category> AddCategoryClicked;

        public bool CanExecute(object parameter)
        {
            if (parameter != null)
                return true;
            else return false;
        }

        public void Execute(object parameter)
        {
            if (AddCategoryClicked != null && parameter is Category)
                AddCategoryClicked(parameter as Category);
        }
    }
}
