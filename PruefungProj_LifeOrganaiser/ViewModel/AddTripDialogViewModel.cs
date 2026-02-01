using PruefungProj_LifeOrganaiser.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PruefungProj_LifeOrganaiser.ViewModel
{
    internal class AddTripDialogViewModel : INotifyPropertyChanged
    {
        private string _city;
        private string _description;
        private bool _isVisited;
        private DateTime _startDate = DateTime.Today;
        private double _budget;
        private int _rating;

        public string City { get => _city; set { _city = value; OnPropertyChanged(); } }
        public string Description { get => _description; set { _description = value; OnPropertyChanged(); } }
        public bool IsVisited { get => _isVisited; set { _isVisited = value; OnPropertyChanged(); } }
        public DateTime StartDate { get => _startDate; set { _startDate = value; OnPropertyChanged(); } }
        public double Budget { get => _budget; set { _budget = value; OnPropertyChanged(); } }
        public int Rating { get => _rating; set { _rating = value; OnPropertyChanged(); } }

        public ICommand SaveCommand { get; private set; }

        private readonly System.Windows.Window _window;

      
        public Trip GetTrip()
        {
            return new Trip
            {
                City = this.City,
                Description = this.Description,
                IsVisited = this.IsVisited,
                StartDate = this.StartDate,
                Budget = this.Budget,
                Rating = this.Rating,
                ImagePath = "images/bg2.jpg" 
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

}
