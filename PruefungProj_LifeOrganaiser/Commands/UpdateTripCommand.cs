//using PruefungProj_LifeOrganaiser.Model;
//using PruefungProj_LifeOrganaiser.ViewModel;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Input;

//namespace PruefungProj_LifeOrganaiser.Commands
//{
//    internal class UpdateTripCommand : ICommand
//    {
//        private readonly TripViewModel _viewModel;

//        public UpdateTripCommand(TripViewModel vm) => _viewModel = vm;

//        public bool CanExecute(object parameter) => parameter is Trip;

//        public void Execute(object parameter)
//        {
//            if (parameter is Trip trip)
//            {
//                _viewModel.UpdateTripStatus(trip);
//            }
//        }

//        public event EventHandler CanExecuteChanged;
//    }
//}
