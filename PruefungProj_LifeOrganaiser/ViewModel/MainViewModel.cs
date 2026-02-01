using PruefungProj_LifeOrganaiser.Commands;
using PruefungProj_LifeOrganaiser.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PruefungProj_LifeOrganaiser.Model
{
    internal class MainViewModel
    {
        public ICommand OpenTripsCommand { get; }
        public ICommand OpenToDoCommand { get; }
        public ICommand OpenShopListCommand { get; }

        public MainViewModel()
        {
            OpenTripsCommand = new OpenTripsCommand(this);
            OpenToDoCommand = new OpenToDoCommand(this);
            OpenShopListCommand = new OpenShopListCommand(this);
        }

        public void OpenTrips()
        {
            var window = new View.TripWindow();
            window.DataContext = new TripViewModel();
            window.Show();
        }

        public void OpenToDo()
        {
            MessageBox.Show("ToDo List öffnen");
        }

        public void OpenShopList()
        {
            MessageBox.Show("Shopping List öffnen");
        }
    
}
}
