using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PruefungProj_LifeOrganaiser.Model
{
    internal class Trip : INotifyPropertyChanged
    {

        public int Id { get; set; }
        private string _city;
        public string City
        {
            get => _city;
            set { _city = value; OnPropertyChanged(); }
        }

        private string _description;
        public string Description
        {
            get => _description;
            set { _description = value; OnPropertyChanged(); }
        }

        private string _imagePath;
        public string ImagePath
        {
            get => _imagePath;
            set { _imagePath = value; OnPropertyChanged(); }
        }

        private bool _isVisited;
        public bool IsVisited
        {
            get => _isVisited;
            set
            {
                if (_isVisited == value) return;
                
                    _isVisited = value;
                    OnPropertyChanged();
                   
                }
        }

        private DateTime _startDate;
        public DateTime StartDate
        {
            get => _startDate;
            set { _startDate = value; OnPropertyChanged(); }
        }

        private double _budget;
        public double Budget
        {
            get => _budget;
            set { _budget = value; OnPropertyChanged(); }
        }

        private int _rating;
        public int Rating
        {
            get => _rating;
            set { _rating = value; OnPropertyChanged(); }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

}
