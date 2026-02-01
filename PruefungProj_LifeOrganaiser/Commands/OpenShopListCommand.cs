using PruefungProj_LifeOrganaiser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PruefungProj_LifeOrganaiser.Commands
{
    internal class OpenShopListCommand : ICommand
    {
        private readonly MainViewModel _viewModel;

        public OpenShopListCommand(MainViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewModel.OpenShopList();
        }

        public event EventHandler CanExecuteChanged;
    }
}
