using PruefungProj_LifeOrganaiser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PruefungProj_LifeOrganaiser.Commands
{
    internal class OpenToDoCommand : ICommand
    {
        private readonly MainViewModel _viewModel;

        public OpenToDoCommand(MainViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewModel.OpenToDo();
        }

        public event EventHandler CanExecuteChanged;
    }
}
