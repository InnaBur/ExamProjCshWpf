using PruefungProj_LifeOrganaiser.Commands;
using PruefungProj_LifeOrganaiser.Model;
using PruefungProj_LifeOrganaiser.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PruefungProj_LifeOrganaiser.ViewModel
{
    internal class TripViewModel : INotifyPropertyChanged
    {
        private readonly TripRepository _repo;

        public ObservableCollection<Trip> ToVisitTrips { get; set; }
        public ObservableCollection<Trip> VisitedTrips { get; set; }

        private Trip _selectedTrip;
        public Trip SelectedTrip
        {
            get => _selectedTrip;
            set
            {
                _selectedTrip = value;
                OnPropertyChanged();
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public ICommand AddTripCommand { get; private set; }
        public ICommand DeleteTripCommand { get; private set; }
        public ICommand UpdateTripCommand { get; private set; }

        public ICommand CopyTripCommand { get; private set; }

        public TripViewModel()
        {
            _repo = new TripRepository();
            _repo.AddDefaultTrips();

            var allTrips = _repo.GetAllTrips();

            ToVisitTrips = new ObservableCollection<Trip>(allTrips.Where(t => !t.IsVisited));
            VisitedTrips = new ObservableCollection<Trip>(allTrips.Where(t => t.IsVisited));
            foreach (var trip in ToVisitTrips.Concat(VisitedTrips))
            {
                trip.PropertyChanged += Trip_PropertyChanged;
            }

            AddTripCommand = new Commands.AddTripCommand(this);
            DeleteTripCommand = new Commands.DeleteTripCommand(this);
            CopyTripCommand = new Commands.CopyTripCommand(this);
        }

        private void Trip_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(Trip.IsVisited))
                return;

            var trip = sender as Trip;
            if (trip == null) return;

            if (trip.IsVisited)
            {
                ToVisitTrips.Remove(trip);
                if (!VisitedTrips.Contains(trip))
                    VisitedTrips.Add(trip);
            }
            else
            {
                VisitedTrips.Remove(trip);
                if (!ToVisitTrips.Contains(trip))
                    ToVisitTrips.Add(trip);
            }

            _repo.UpdateTrip(trip);
        }

        public void AddTrip(Trip trip)
        {
            _repo.AddTrip(trip);
            trip.PropertyChanged += Trip_PropertyChanged;

            if (trip.IsVisited)
                VisitedTrips.Add(trip);
            else
                ToVisitTrips.Add(trip);
        }

        public void DeleteTrip(Trip trip)
        {
            if (trip == null) return;

            _repo.DeleteTrip(trip.Id);

            ToVisitTrips.Remove(trip);
            VisitedTrips.Remove(trip);
        }


        public void CopyTrip(Trip trip)
        {
            if (trip == null) return;

            var newTrip = new Trip
            {
                City = trip.City + " (copy)",
                Description = trip.Description,
                ImagePath = trip.ImagePath,
                IsVisited = trip.IsVisited,
                StartDate = trip.StartDate,
                Budget = trip.Budget,
                Rating = trip.Rating
            };

            _repo.AddTrip(newTrip);

            if (newTrip.IsVisited)
                VisitedTrips.Add(newTrip);
            else
                ToVisitTrips.Add(newTrip);

            newTrip.PropertyChanged += Trip_PropertyChanged;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
 

    private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
                FilterTrips();
            }
        }

        private void FilterTrips()
        {
            var allTrips = _repo.GetAllTrips();

            var filtered = allTrips
                .Where(t => string.IsNullOrWhiteSpace(SearchText) ||
                            (t.City != null && t.City.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0))
                .ToList();

            ToVisitTrips.Clear();
            VisitedTrips.Clear();

            foreach (var trip in filtered)
            {
                if (trip.IsVisited)
                    VisitedTrips.Add(trip);
                else
                    ToVisitTrips.Add(trip);
            }
        }
    }
}