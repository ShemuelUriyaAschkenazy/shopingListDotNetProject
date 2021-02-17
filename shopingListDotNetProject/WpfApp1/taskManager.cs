using PL.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class taskManager
    {
        public taskManager(MainWindow main)
        {
            main.VM = new generalVM(main);
        }


    }
}
