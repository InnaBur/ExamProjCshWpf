using PruefungProj_LifeOrganaiser.View;
using PruefungProj_LifeOrganaiser.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PruefungProj_LifeOrganaiser.Commands
{
    internal class AddTripCommand : ICommand
    {
        private readonly TripViewModel _viewModel;

        public AddTripCommand(TripViewModel vm) => _viewModel = vm;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            var dialog = new AddTripDialog();
            var dialogVm = new AddTripDialogViewModel(); 
            dialog.DataContext = dialogVm;

            if (dialog.ShowDialog() == true)
            {
                var trip = dialogVm.GetTrip();
                _viewModel.AddTrip(trip); 
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
