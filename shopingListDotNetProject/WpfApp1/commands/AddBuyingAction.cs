using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using BE;


    namespace PL.commands
    {
        class AddBuyingAction : ICommand
        {
            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }

            public event Action<Buying> AddBuyingClicked;

            public bool CanExecute(object parameter)
            {
                if (parameter != null)
                    return true;
                else return false;
            }
            public void Execute(object parameter)
            {
                if (AddBuyingClicked != null && parameter is Buying)
                    AddBuyingClicked(parameter as Buying);
            }
        }
    }
}
