using PruefungProj_LifeOrganaiser.Model;
using PruefungProj_LifeOrganaiser.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PruefungProj_LifeOrganaiser.Commands
{
    internal class OpenTripsCommand : ICommand
    {
        private readonly MainViewModel _viewModel;

        public OpenTripsCommand(MainViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
          
            var tripWindow = new TripWindow();
            tripWindow.Show(); 
        }
        public event EventHandler CanExecuteChanged;
    
}
}
