using PruefungProj_LifeOrganaiser.Model;
using PruefungProj_LifeOrganaiser.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PruefungProj_LifeOrganaiser.Commands
{
    internal class CopyTripCommand : ICommand
    {
        private readonly TripViewModel _viewModel;

        public CopyTripCommand(TripViewModel vm)
        {
            _viewModel = vm;
        }

        public bool CanExecute(object parameter) => parameter is Trip;

        public void Execute(object parameter)
        {
            _viewModel.CopyTrip(parameter as Trip);
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
